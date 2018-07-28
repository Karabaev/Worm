using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
namespace Game
{
    public class EnvironmentController : MonoBehaviour
    {
        [SerializeField] private GameObject backgroundPrefab;
        [SerializeField] private Transform spawnPoint;
        private GameObject bgInstance;
        private PlayerController player;

        private void Awake()
        {
            Debug.Logger.CheckReference(this.gameObject, this.backgroundPrefab);
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            Debug.Logger.CheckReference(this.gameObject, this.player);
            player.OnBackgroundReplace.AddListener(ReplaceBg);
        }


        public void ReplaceBg()
        {
            try
            {
                Debug.Logger.LogInfo(gameObject, "Replace");
                bgInstance = Instantiate(this.backgroundPrefab, this.spawnPoint.position, Quaternion.identity);
                spawnPoint = bgInstance.GetComponentInChildren<BGSpawnBorder>().spawnPoint;
            }
            catch (Exception ex)
            {
                Debug.Logger.LogError(this.gameObject, ex.Message);
            }
        }

        

    }
}

