using System.Collections;
using UnityEngine;
using Assets.Types;
using Assets.Managers;

namespace Assets.Scripts
{
    public class InventorySlot : MonoBehaviour
    {
        public InventoryItem item = new InventoryItem();
        public GameObject slotItem;

        public void Start()
        {
            var data = ItemManager.GetItemData(item.id);
            if (data != null && data.sprite != null)
            {
                var inst = Instantiate(slotItem, transform);
                inst.GetComponent<SpriteRenderer>().sprite = data.sprite;
            }
        }
    }
}