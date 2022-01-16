using System;
using EconimicGame.Building;
using EconimicGame.Resources;
using TMPro;
using UnityEngine;
using EconimicGame.Building;

namespace EconimicGame.BuildingSystem
{
    public class BuildingsGrid : MonoBehaviour
    {
        public delegate void PlaceBuilding();

        public delegate void ChangeResource(ResourceType resourceType , int value);
        
        public static event PlaceBuilding OnSuccessfulPlaceBuilding;
        public static event ChangeResource OnChangeResource;
        public static event PlaceBuilding OnUnsuccessfulPlaceBuilding;

        [SerializeField] private Vector2Int _gridSize = new Vector2Int(10, 10);

        private Building[,] _grid;
        private Building _flyingBuilding;
        private BuildingBase _flyingBuildingBase;
        private Camera _mainCamera;

        private void Awake()
        {
            _grid = new Building[_gridSize.x, _gridSize.y];

            _mainCamera = Camera.main;
        }

        public void StartPlacingBuilding(BuildingController buildingPrefab)
        {
            if (buildingPrefab.BuildingBaseInfo.TryToBuildABuilding() == true)
            {
                if (_flyingBuilding != null)
                {
                    Destroy(_flyingBuilding.gameObject);
                }

                _flyingBuildingBase = buildingPrefab.BuildingBaseInfo;
                _flyingBuilding = Instantiate(buildingPrefab.BuildingInfo, transform);
            }
            else
            {
                OnUnsuccessfulPlaceBuilding?.Invoke();
                Debug.Log("Have no Gold for Build");
            }
        }

        private void Update()
        {
            if (_flyingBuilding != null)
            {
                var groundPlane = new Plane(Vector3.up, Vector3.zero);
                Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

                if (groundPlane.Raycast(ray, out float position))
                {
                    Vector3 worldPosition = ray.GetPoint(position);

                    int x = Mathf.RoundToInt(worldPosition.x);
                    int y = Mathf.RoundToInt(worldPosition.z);

                    bool available = true;

                    if (x < 0 || x > _gridSize.x - _flyingBuilding.Size.x) available = false;
                    if (y < 0 || y > _gridSize.y - _flyingBuilding.Size.y) available = false;

                    if (available && IsPlaceTaken(x, y)) available = false;

                    _flyingBuilding.transform.position = new Vector3(x, 0, y);
                    _flyingBuilding.SetTransparent(available);

                    if (available && Input.GetMouseButtonDown(0))
                    {
                        PlaceFlyingBuilding(x, y);
                    }
                }
            }
        }

        private bool IsPlaceTaken(int placeX, int placeY)
        {
            for (int x = 0; x < _flyingBuilding.Size.x; x++)
            {
                for (int y = 0; y < _flyingBuilding.Size.y; y++)
                {
                    if (_grid[placeX + x, placeY + y] != null) return true;
                }
            }

            return false;
        }

        private void PlaceFlyingBuilding(int placeX, int placeY)
        {
            for (int x = 0; x < _flyingBuilding.Size.x; x++)
            {
                for (int y = 0; y < _flyingBuilding.Size.y; y++)
                {
                    _grid[placeX + x, placeY + y] = _flyingBuilding;
                }
            }
            
            OnChangeResource?.Invoke(ResourceType.Gold, _flyingBuildingBase.BuildingInfo.CostBuilding);
            OnSuccessfulPlaceBuilding?.Invoke();

            _flyingBuilding.SetNormal();
            _flyingBuilding = null;
        }

        private void OnDrawGizmos()
        {
            for (int x = 0; x < _gridSize.x; x++)
            {
                for (int y = 0; y < _gridSize.y; y++)
                {
                    if ((x + y) % 2 == 0) Gizmos.color = new Color(0.88f, 0f, 1f, 0.1f);
                    else Gizmos.color = new Color(1f, 0.68f, 0f, 0.1f);

                    Gizmos.DrawCube(new Vector3(x, 0, y), new Vector3(1, .1f, 1));
                }
            }
        }
    }
}