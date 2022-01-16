using UnityEngine;

namespace EconimicGame.Resources
{
    public abstract class ResourceBase : MonoBehaviour
    {
        public int CurrentCount => currentCount;
        public int ConsumedEnergy => consumedCount;

        /// <summary>
        /// Текущее колличество потребляемого ресурса
        /// </summary>
        protected int consumedCount = 0;

        /// <summary>
        ///  Текущее колличество ресурса
        /// </summary>
        protected int currentCount;

        /// <summary>
        /// Добавление ресурса
        /// </summary>
        /// <param name="countOfResource"></param>
        public virtual void AddResource(int countOfResource)
        {
            currentCount += countOfResource;
        }

        /// <summary>
        /// Добавление колличества потребляемых ресурсов
        /// </summary>
        /// <param name="countOfResource"></param>
        public virtual void AddConsumedResource(int countOfResource)
        {
            consumedCount += countOfResource;
        }

        /// <summary>
        /// Удаление колличества потребляемых ресурсов
        /// </summary>
        /// <param name="countOfResource"></param>
        public virtual void DelResource(int countOfResource)
        {
            consumedCount -= countOfResource;
        }

        /// <summary>
        /// Удаление колличества потребляемых ресурсов
        /// </summary>
        /// <param name="countOfResource"></param>
        public virtual void DelConsumedResource(int countOfResource)
        {
            consumedCount -= countOfResource;
        }

        public virtual void SetStartValue(int value)
        {
            currentCount = value;
        }
    }
}