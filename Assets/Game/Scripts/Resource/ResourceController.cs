using System;
using UnityEngine;

namespace EconimicGame.Resources
{
    public class ResourceController : MonoBehaviour
    {
        public static ResourceController Instance;
        
        [SerializeField] private int _startGold;
        [SerializeField] private int _startEnergy;
        
        private ResourceEnergy _resourceEnergy = new ResourceEnergy();
        private ResourceGold _resourceGold = new ResourceGold();

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            _resourceEnergy.SetStartValue(_startEnergy);
            _resourceGold.SetStartValue(_startGold);
        }

        public void AddResource(ResourceType resourceType, int value)
        {
            switch (resourceType)
            {
                case ResourceType.Energy:
                    _resourceEnergy.AddResource(value);
                    break;
                case ResourceType.Gold:
                    _resourceGold.AddResource(value);
                    break;
            }
        }        
        
        public void AddConsumedResource(ResourceType resourceType, int value)
        {
            switch (resourceType)
            {
                case ResourceType.Energy:
                    _resourceEnergy.AddConsumedResource(value);
                    break;
                case ResourceType.Gold:
                    _resourceGold.AddConsumedResource(value);
                    break;
            }
        }      
        
        public void DelResource(ResourceType resourceType, int value)
        {
            switch (resourceType)
            {
                case ResourceType.Energy:
                    _resourceEnergy.DelResource(value);
                    break;
                case ResourceType.Gold:
                    _resourceGold.DelResource(value);
                    break;
            }
        }        
        
        public void DelConsumedResource(ResourceType resourceType, int value)
        {
            switch (resourceType)
            {
                case ResourceType.Energy:
                    _resourceEnergy.DelConsumedResource(value);
                    break;
                case ResourceType.Gold:
                    _resourceGold.DelConsumedResource(value);
                    break;
            }
        }

        public bool CheckEnergyForProduce(int consumeEnergy)
        {
            return true;
        }
    }
}