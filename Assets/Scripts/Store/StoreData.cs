using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Store
{
    [CreateAssetMenu(fileName = "StoreData", menuName = "Scriptable Object/Store data")]
    public class StoreData : ScriptableObject
    {
        public List<StoreItem> Items = new List<StoreItem>();
    }
}
