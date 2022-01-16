namespace EconimicGame.Resources
{
    public class ResourceEnergy : ResourceBase
    {
        public delegate void ChangeEnergy(int consumedEnergy, int producedEnergy);

        public static event ChangeEnergy OnChangeEnergy;

        public override void AddResource(int countOfResource)
        {
            base.AddResource(countOfResource);
            
            OnChangeEnergy?.Invoke(consumedCount, currentCount);
        }

        public override void AddConsumedResource(int countOfResource)
        {
            base.AddConsumedResource(countOfResource);
            
            OnChangeEnergy?.Invoke(consumedCount, currentCount);
        }

        public override void DelResource(int countOfResource)
        {
            base.DelResource(countOfResource);
            
            OnChangeEnergy?.Invoke(consumedCount, currentCount);
        }

        public override void DelConsumedResource(int countOfResource)
        {
            base.DelConsumedResource(countOfResource);
            
            OnChangeEnergy?.Invoke(consumedCount, currentCount);
        }

        public override void SetStartValue(int value)
        {
            base.SetStartValue(value);
            
            OnChangeEnergy?.Invoke(consumedCount, currentCount);
        }
    }
}