namespace Game
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Events;
    using System.Linq;
    using System;
    public class BGSpawnBorder : MonoBehaviour
    {
        [SerializeField] private GameObject[] topObstaclePoints;
        [SerializeField] private GameObject[] bottomObstaclePoints;
        [SerializeField] private string topObstaclePointsTag;
        [SerializeField] private string bottomObstaclePointsTag;
        [SerializeField] private GameObject[] obstaclePrefabs;
        [SerializeField] private int topObstaclesCount;
        [SerializeField] private int bottomObstaclesCount;
        [SerializeField] private Vector3 obstacleScale = new Vector3(.1f, .1f, .1f);

        [SerializeField] public Transform spawnPoint;
        public GameObject Prev { get; set; }

        private void Start()
        {
            topObstaclePoints = GameObject.FindGameObjectsWithTag(topObstaclePointsTag);
            bottomObstaclePoints = GameObject.FindGameObjectsWithTag(bottomObstaclePointsTag);
            if (topObstaclePoints == null || bottomObstaclePoints == null || !topObstaclePoints.Any() || !bottomObstaclePoints.Any())
            {
                Debug.Logger.LogError(this.gameObject, "Точки появления препятсткий не инициализированы.");
            }

            SpawnObstacles(topObstaclePoints, obstaclePrefabs, topObstaclesCount);
            SpawnObstacles(bottomObstaclePoints, obstaclePrefabs, bottomObstaclesCount);
        }
        
        private void SpawnObstacles(GameObject[] points, GameObject[] prefabs, int maxCount)
        {
            System.Random rand = new System.Random();
            int obsCont = 0;
            for (int i = 0; i < points.Length; i++)
            {
                int val = rand.Next(0, 100);
                if (val > 30 && obsCont < maxCount)
                {
                    try
                    {
                        val = rand.Next(0, obstaclePrefabs.Length);
                        GameObject obs = Instantiate(prefabs[val], points[i].transform.position, Quaternion.identity);
                        obs.transform.localScale = this.obstacleScale;
                        obsCont++;
                    }
                    catch (Exception ex)
                    {
                        Debug.Logger.LogError(this.gameObject, ex.Message);
                        break;
                    }
                }
                points[i].tag = "Untagged";
            }
        }
    }
}
