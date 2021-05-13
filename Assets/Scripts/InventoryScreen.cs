using System.Collections;
using UnityEngine;
using Assets.Managers;

namespace Assets.Scripts
{
    public class InventoryScreen : MonoBehaviour
    {
        public GameObject slot;
        public int width = 1;

        void Start()
        {
            InputManager.BlockKeys(1);

            float x_min = transform.position.x - (width * slot.GetComponent<RectTransform>().rect.width) / 2;
            float x_width = slot.GetComponent<RectTransform>().rect.width;
            float y = transform.position.y - GetComponent<RectTransform>().rect.height + slot.GetComponent<RectTransform>().rect.height;

            int idx = 0;
            var items = InventoryManager.GetItems();
            foreach (var item in items)
            {
                var inst = Instantiate(slot, gameObject.transform);
                inst.transform.position = new Vector2(x_min + idx * x_width, y);
                inst.GetComponent<>().item = item;

                idx++;
                if (idx >= width)
                {

                }
            }
        }
    }
}