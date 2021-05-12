using Assets.Types;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Managers
{
    public static class InventoryManager
    {
        private static int size = 0;
        private static List<Tuple<ItemEnum, int>> inventory = new List<Tuple<ItemEnum, int>>();

        public static List<Tuple<ItemEnum, int>> SetSize(int s)
        {
            if (s >= size)
            {
                size = s;
                return new List<Tuple<ItemEnum, int>>();
            }
            return new List<Tuple<ItemEnum, int>>();
        }

        public static bool CanAddItem(ItemEnum item)
        {
            ItemData data = ItemManager.GetItemData(item);
            return inventory.Count < size || inventory.Where(t => (t.Item1 == item && t.Item2 < data.stack)).Count() > 0;
        }

        public static bool TryAddItem(ItemEnum item)
        {
            ItemData data = ItemManager.GetItemData(item);
            var slots = inventory.Where(t => (t.Item1 == item && t.Item2 < data.stack));
            if (slots.Count() > 0)
            {
                var idx = inventory.IndexOf(slots.First());
                inventory[idx] = new Tuple<ItemEnum, int>(inventory[idx].Item1, inventory[idx].Item2 + 1);
                return true;
            }

            if (inventory.Count < size)
            {
                inventory.Add(new Tuple<ItemEnum, int>(item, 1));
            }

            return false;
        }
    }
}