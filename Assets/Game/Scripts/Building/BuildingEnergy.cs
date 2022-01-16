using EconimicGame.Resources;
using UnityEngine;

namespace EconimicGame.Building
{
    public class BuildingEnergy : BuildingBase
    {
        public int CountOfProduceEnergy => _countOfProduceEnergy;

        [SerializeField] private int _countOfProduceEnergy;

        public override void StartProduce()
        {
            ResourceController.Instance.AddResource(ResourceType.Energy, _countOfProduceEnergy);
        }

        public override void StopProduce()
        {
        }

        public override void DestroyBuilding()
        {
            
        }
    }
}