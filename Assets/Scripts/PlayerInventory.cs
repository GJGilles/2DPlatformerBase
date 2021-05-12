using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Assets.Defs;

namespace Assets.Scripts
{
    public class PlayerInventory : MonoBehaviour
    {
        public float radiusSuction = 3f;
        public float radiusPickup = 1f;
        public float forceSuction = 1f;
        public float forceDamping = 10f;
        public LayerMask itemMask;
        public int itemSlots = 8;

        private List<Tuple<ItemEnum, int>> inventory = new List<Tuple<ItemEnum, int>>();

        private Collider2D Collider() { return GetComponent<Collider2D>(); }

        private bool CanAddItem(ItemEnum item)
        {
            ItemData data = ItemDefs.GetItemData(item);
            return inventory.Count < itemSlots || inventory.Where(t => (t.Item1 == item && t.Item2 < data.stack)).Count() > 0;
        }

        private bool TryAddItem(ItemEnum item)
        {
            ItemData data = ItemDefs.GetItemData(item);
            var slots = inventory.Where(t => (t.Item1 == item && t.Item2 < data.stack));
            if (slots.Count() > 0)
            {
                var idx = inventory.IndexOf(slots.First());
                inventory[idx] = new Tuple<ItemEnum, int>(inventory[idx].Item1, inventory[idx].Item2 + 1);
                return true;
            }

            if (inventory.Count < itemSlots)
            {
                inventory.Add(new Tuple<ItemEnum, int>(item, 1));
            }

            return false;
        }

        private void Start()
        {
            ItemDefs.LoadDefs();
        }

        private void FixedUpdate()
        {
            Collider2D[] pickups = Physics2D.OverlapCircleAll(Collider().bounds.center, radiusPickup, itemMask);
            foreach (Collider2D item in pickups)
            {
                ItemController holder;
                if (item.gameObject.TryGetComponent(out holder))
                {
                    if (TryAddItem(holder.item))
                        Destroy(item.gameObject);
                }
            }

            Collider2D[] suctions = Physics2D.OverlapCircleAll(Collider().bounds.center, radiusSuction, itemMask);
            foreach (Collider2D item in suctions)
            {
                ItemController holder;
                if (item.gameObject.TryGetComponent(out holder))
                {
                    if (!CanAddItem(holder.item))
                        continue;

                    Rigidbody2D rb = item.gameObject.GetComponent<Rigidbody2D>();
                    Vector2 force = forceSuction * (transform.position - item.gameObject.transform.position).normalized;
                    rb.velocity = Vector2.Lerp(rb.velocity, force, forceDamping * Time.deltaTime);
                }
            }
        }
    }
}
