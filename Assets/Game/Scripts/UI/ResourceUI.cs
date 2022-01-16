using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using EconimicGame.Resources;
using UnityEngine;
using UnityEngine.UI;

namespace EconimicGame.UI
{
    public class ResourceUI : MonoBehaviour
    {
        [SerializeField] private Text _gold;
        [SerializeField] private Text _energy;

        private void OnEnable()
        {
            ResourceEnergy.OnChangeEnergy += SetEnergy;
            ResourceGold.OnChangeGold += SetGold;
        }

        private void OnDisable()
        {
            ResourceEnergy.OnChangeEnergy -= SetEnergy;
            ResourceGold.OnChangeGold -= SetGold;
        }

        private void SetEnergy(int consumedEnergy, int producedEnergy)
        {
            _energy.text = "Energy : " + Mathf.Clamp(consumedEnergy, 0, Int32.MaxValue).ToString() + " / " +
                           Mathf.Clamp(producedEnergy, 0, Int32.MaxValue).ToString();
        }

        private void SetGold(int currentGold)
        {
            _gold.text = "Gold : " + Mathf.Clamp(currentGold, 0, Int32.MaxValue).ToString();
        }
    }
}