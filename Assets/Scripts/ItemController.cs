using System.Collections;
using UnityEngine;
using Assets.Defs;

namespace Assets.Scripts
{
    public class ItemController : MonoBehaviour
    {
        public ItemEnum item = ItemEnum.Default;
        public LayerMask colMask;

        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (colMask != (colMask | (1<<collision.gameObject.layer)))
            {
                Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
            }
        }
    }
}