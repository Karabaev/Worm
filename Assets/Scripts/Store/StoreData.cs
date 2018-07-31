using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Game.Store
{
    [Serializable]
    [CreateAssetMenu(fileName = "StoreData", menuName = "Scriptable Object/Store data")]
    public class StoreData : ScriptableObject
    {
        public List<StoreItem> Items { get; set; }
    }
}
