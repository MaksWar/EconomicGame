using EconimicGame.Building;
using UnityEngine;

namespace EconimicGame.UI
{
    public class SpawnButtonUI : MonoBehaviour
    {
        public void SpawnBuilding(GameObject house)
        {
            Instantiate(house, parent:null);
        }
    }
}