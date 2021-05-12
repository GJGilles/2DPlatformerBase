using Assets.Types;
using Assets.Managers;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class ItemLoader : MonoBehaviour
    {
        public List<ItemData> items = new List<ItemData>();

        void Start()
        {
            ItemManager.LoadItems(items);
        }
    }
}