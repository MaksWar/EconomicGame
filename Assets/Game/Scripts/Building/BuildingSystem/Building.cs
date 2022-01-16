using UnityEngine;

namespace EconimicGame.BuildingSystem
{
    public class Building : MonoBehaviour
    {
        public Vector2Int Size => _size;
        
        [SerializeField] private Renderer _mainRenderer;
        [SerializeField] private Vector2Int _size = Vector2Int.one;

        public void SetTransparent(bool available)
        {
            if (available)
            {
                _mainRenderer.material.color = Color.green;
            }
            else
            {
                _mainRenderer.material.color = Color.red;
            }
        }

        public void SetNormal()
        {
            _mainRenderer.material.color = Color.white;
        }

        private void OnDrawGizmos()
        {
            for (int x = 0; x < _size.x; x++)
            {
                for (int y = 0; y < _size.y; y++)
                {
                    if ((x + y) % 2 == 0) Gizmos.color = new Color(0.88f, 0f, 1f, 0.5f);
                    else Gizmos.color = new Color(1f, 0.68f, 0f, 0.5f);

                    Gizmos.DrawCube(transform.position + new Vector3(x, 0, y), new Vector3(1, .1f, 1));
                }
            }
        }
    }
}