using UnityEngine;

namespace EconimicGame.Building
{
    [RequireComponent(typeof(BuildingController))]
    public abstract class BuildingBase : MonoBehaviour
    {
        [SerializeField] private BuildingParam _buildingParam;
        
        /// <summary>
        /// Начало производства ресурса
        /// </summary>
        public abstract void StartProduce();

        /// <summary>
        /// Остановка производства ресурса
        /// </summary>
        public abstract void StopProduce();

        /// <summary>
        /// Логика при удаление здания
        /// </summary>
        public abstract void DestroyBuilding();
    }
}