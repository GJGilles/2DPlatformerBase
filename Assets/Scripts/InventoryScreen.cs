using System.Collections.Generic;
using UnityEngine;
using Assets.Managers;
using Assets.Types;

namespace Assets.Scripts
{
    public class InventoryScreen : MonoBehaviour
    {
        public GameObject slot;
        public int width = 1;

        void Start()
        {
            InputManager.BlockKeys(1);

            float x_min = GetComponent<RectTransform>().rect.xMin + (GetComponent<RectTransform>().rect.width - width * slot.GetComponent<SpriteRenderer>().sprite.bounds.size.x) / 2;
            float x_unit = slot.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
            float y_min = GetComponent<RectTransform>().rect.yMin + slot.GetComponent<SpriteRenderer>().sprite.bounds.size.y;
            float y_unit = slot.GetComponent<SpriteRenderer>().sprite.bounds.size.y;

            int size = InventoryManager.GetSize();
            List<GameObject> slots = new List<GameObject>();
            for (int i = 0; i < size; i++)
            {
                var inst = Instantiate(slot, transform);
                inst.transform.position = new Vector2(x_min + (i % width) * x_unit, y_min + (i / width) * y_unit);
                slots.Add(inst);
            }

            var items = InventoryManager.GetItems();
            for (int i = 0; i < items.Count; i++)
            {
                slots[items[i].position].GetComponent<InventorySlot>().item = items[i];
            }

            for (int i = 0; i < slots.Count; i++)
            {
                if (slots[i].GetComponent<InventorySlot>().item.id == ItemEnum.None)
                {
                    slots[i].GetComponent<InventorySlot>().item = new InventoryItem() { position = i };
                }
            }
        }
    }
}