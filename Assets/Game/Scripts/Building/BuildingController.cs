using EconimicGame.BuildingSystem;
using UnityEngine;

namespace EconimicGame.Building
{
    public class BuildingController : MonoBehaviour
    {
        public BuildingSystem.Building BuildingInfo => _buildingInfo;
        public BuildingBase BuildingBaseInfo => _buildingBase;
        
        [SerializeField] private BuildingBase _buildingBase;
        [SerializeField] private BuildingSystem.Building _buildingInfo;
        
        private bool _isActive = false;

        private void OnEnable()
        {
            BuildingsGrid.OnSuccessfulPlaceBuilding += Init;
        }

        private void OnDisable()
        {
            BuildingsGrid.OnSuccessfulPlaceBuilding -= Init;
        }

        private void Init()
        {
            if (_isActive == false)
            {
                _buildingBase.StartProduce();
                _isActive = true;
            }
        }
    }
}