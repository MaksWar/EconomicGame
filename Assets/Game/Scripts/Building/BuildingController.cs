using System;
using UnityEngine;

namespace EconimicGame.Building
{
    public class BuildingController : MonoBehaviour
    {
        [SerializeField] private BuildingBase _building;

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            _building.StartProduce();
        }
    }
}