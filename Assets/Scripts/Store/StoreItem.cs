namespace Game.Store
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using System;

    [Serializable]
    public abstract class StoreItem
    {
        public string name;


        public string Name
        {
            get
            {
                return name;
            }
        }
        string Description { get; set; }
        Sprite Icon { get; set; }
        int Price { get; set; }

        public abstract void Enable();
        public abstract void Disable();
    }
}

