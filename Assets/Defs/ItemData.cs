using System.Collections;
using UnityEngine;

namespace Assets.Defs
{
    public enum ItemEnum
    {
        Default
    }

    public class ItemData
    {
        public string name = "";
        public int stack = 0;

       public ItemData() { }
       public ItemData(string name, int stack) 
       {
            this.name = name;
            this.stack = stack;
       }
    }
}