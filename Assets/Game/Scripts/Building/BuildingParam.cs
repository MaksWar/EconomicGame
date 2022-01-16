using UnityEngine;

namespace EconimicGame.Building
{
    [CreateAssetMenu(fileName = "Создать строение", order = 1)]
    public class BuildingParam : ScriptableObject
    {
        public BuildingType BuildingType => _buildingType;
        public int CostBuilding => _costBuilding;

        /// <summary>
        /// Тип ресурса который здание производит либо же добавляет
        /// </summary>
        [Header("Тип ресурса здания")] [SerializeField]
        private BuildingType _buildingType;


        /// <summary>
        /// Стоимость здания
        /// </summary>
        [Header("Стоимость здания")] [SerializeField]
        private int _costBuilding;
    }
}