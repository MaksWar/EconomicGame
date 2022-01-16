using UnityEngine;

namespace EconimicGame.Building
{
    [CreateAssetMenu(fileName = "Создать строение", order = 1)]
    public class BuildingParam : ScriptableObject
    {
        public BuildingType BuildingType;

        /// <summary>
        /// Тип ресурса который здание производит либо же добавляет
        /// </summary>
        [Header("Тип ресурса здания")]
        private BuildingType _buildingType;
    }
}