using System.Collections;
using UnityEngine;
using EconimicGame.Resources;

namespace EconimicGame.Building
{
    public class BuildingGold : BuildingBase
    {
        public int CountOfProduceGold => _countOfProduceGold;
        public int CountOfConsumeEnergy => _countOfConsumeEnergy;
        public float TimeForProduceGold => _timeForProduceGold;

        [SerializeField] private int _countOfProduceGold;
        [SerializeField] private int _countOfConsumeEnergy;
        [SerializeField] private float _timeForProduceGold;

        public override void StartProduce()
        {
            ResourceController.Instance.AddConsumedResource(ResourceType.Energy, _countOfConsumeEnergy);
            
            StartCoroutine(Produce());
        }

        public override void StopProduce()
        {
            StopCoroutine(Produce());
        }

        public override void DestroyBuilding()
        {
            
        }

        private IEnumerator Produce()
        {
            while (true)
            {
                yield return new WaitForSeconds(_timeForProduceGold);

                if (ResourceController.Instance.CheckEnergyForProduce() == true || _countOfConsumeEnergy == 0)
                {
                    ResourceController.Instance.AddResource(ResourceType.Gold, _countOfProduceGold);
                }
                else
                {
                    Debug.Log("Have no enough energy");
                }
            }
        }
    }
}