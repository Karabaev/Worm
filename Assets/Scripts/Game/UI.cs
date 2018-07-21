using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    public int Score
    {
        set
        {
            if (value < 0)
                value = 0;
            scoreText.text = string.Format("Score: {0}", value);
        }
    }
}
