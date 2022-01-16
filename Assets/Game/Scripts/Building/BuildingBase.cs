using EconimicGame.Resources;
using UnityEngine;

namespace EconimicGame.Building
{
    [RequireComponent(typeof(BuildingController), typeof(BuildingSystem.Building))]
    public abstract class BuildingBase : MonoBehaviour
    {
        public BuildingParam BuildingInfo => _buildingParam;
        
        [SerializeField] private BuildingParam _buildingParam;

        public virtual bool TryToBuildABuilding()
        {
            return ResourceController.Instance.CheckGoldToBuildABuilding(_buildingParam.CostBuilding);
        }

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