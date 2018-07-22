using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSpawnBorder : MonoBehaviour
{
    [SerializeField] private GameObject backgroundPrefab;
    [SerializeField] private Transform spawnPoint;
    private void Awake()
    {
        if (backgroundPrefab == null) Debug.LogError(string.Format("Backgound prefab не инициализирован. Объект {0}", name));
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
           Instantiate(backgroundPrefab, spawnPoint.position, Quaternion.identity);
        Debug.Log("Триггер");
    }
}
