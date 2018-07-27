using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSpawnBorder : MonoBehaviour
{
    [SerializeField] private GameObject backgroundPrefab;
    [SerializeField] private Transform spawnPoint;
    private GameObject prev;

    private void Awake()
    {
        if (backgroundPrefab == null)
        {
            Debug.LogError(string.Format("Backgound prefab не инициализирован. Объект {0}", name));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if(this.Prev != null)
            {
                Destroy(this.prev);
            }
            
            GameObject bg = Instantiate(backgroundPrefab, spawnPoint.position, Quaternion.identity);
            bg.GetComponentInChildren<BGSpawnBorder>().Prev = this.gameObject;
        }
    }

    public GameObject Prev
    {
        get
        {
            return prev;
        }
        set
        {
            prev = value;
        }
    }
}
