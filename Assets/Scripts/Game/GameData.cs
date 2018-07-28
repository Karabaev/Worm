using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game
{
    [CreateAssetMenu(fileName = "GameData", menuName = "Scriptable Object/Game data")]
    public class GameData : ScriptableObject
    {
        public float GameSpeed = 0;
        public int score = 0;
    }
}

