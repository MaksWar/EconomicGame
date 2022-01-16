using System.Collections;
using UnityEngine;

namespace EconimicGame.Resources
{
    public class ResourceGold : ResourceBase
    {
        public delegate void ChangeGold(int currentGold);

        public static event ChangeGold OnChangeGold;

        public override void AddResource(int countOfResource)
        {
            base.AddResource(countOfResource);
            
            OnChangeGold?.Invoke(currentCount);
        }

        public override void SetStartValue(int value)
        {
            base.SetStartValue(value);

            OnChangeGold?.Invoke(currentCount);
        }

        public override void DelResource(int countOfResource)
        {
            base.DelResource(countOfResource);
            
            OnChangeGold?.Invoke(currentCount);
        }
    }
}