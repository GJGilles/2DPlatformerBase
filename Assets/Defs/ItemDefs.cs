using System.Collections.Generic;
using UnityEngine;

namespace Assets.Defs
{
    public static class ItemDefs
    {
        private static Dictionary<ItemEnum, ItemData> defs = new Dictionary<ItemEnum, ItemData>();

        public static void LoadDefs() 
        {
            defs.Add(ItemEnum.Default, new ItemData(ItemEnum.Default.ToString(), 32));
        }

        public static ItemData GetItemData(ItemEnum item)
        {
            if (defs.ContainsKey(item))
            {
                return defs[item];
            }
            else
            {
                return new ItemData();
            }
        }
    }
}