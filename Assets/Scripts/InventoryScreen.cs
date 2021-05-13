using UnityEngine;
using Assets.Managers;
using Assets.Types;

namespace Assets.Scripts
{
    public class InventoryScreen : MonoBehaviour
    {
        private int inputLevel = 1;

        public void Start()
        {
            InputManager.BlockKeys(inputLevel);

            var items = InventoryManager.GetItems();
            for (int i = 0; i < items.Count; i++)
            {
                GameObject child = transform.GetChild(items[i].position).gameObject;
                if (child != null)
                    child.GetComponent<InventorySlot>().item = items[i];
            }

            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).GetComponent<InventorySlot>().item.id == ItemEnum.None)
                {
                    transform.GetChild(i).GetComponent<InventorySlot>().item = new InventoryItem() { position = i };
                }
            }
        }

        public void Update()
        {
            if (InputManager.GetKeyDown(KeyCode.I, inputLevel))
            {
                InputManager.UnblockKeys(inputLevel);
                Destroy(transform.parent.gameObject);
            }
        }
    }
}