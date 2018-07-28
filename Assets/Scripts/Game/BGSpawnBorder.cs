namespace Game
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using System.Linq;
    using Debug;
    using System;
    public class BGSpawnBorder : MonoBehaviour
    {
        [SerializeField] private GameObject backgroundPrefab;
        [SerializeField] private Transform spawnPoint;
        private GameObject[] topObstaclePoints;
        private GameObject[] bottomObstaclePoints;
        [SerializeField] private string topObstaclePointsTag;
        [SerializeField] private string bottomObstaclePointsTag;
        [SerializeField] private GameObject[] obstaclePrefabs;
        [SerializeField] private int topObstaclesCount;
        [SerializeField] private int bottomObstaclesCount;
        [SerializeField] private Vector3 obstacleScale = new Vector3(.1f, .1f, .1f);
        private GameObject prev;

        private void Awake()
        {
            topObstaclePoints = GameObject.FindGameObjectsWithTag(topObstaclePointsTag);
            bottomObstaclePoints =  GameObject.FindGameObjectsWithTag(bottomObstaclePointsTag);
            if (topObstaclePoints == null || bottomObstaclePoints == null || !topObstaclePoints.Any() || !bottomObstaclePoints.Any())
            {
                Debug.Logger.LogError(this.gameObject, "Точки появления препятсткий не инициализированы.");
            }

            SpawnObstacles(topObstaclePoints, obstaclePrefabs, topObstaclesCount);
            SpawnObstacles(bottomObstaclePoints, obstaclePrefabs, bottomObstaclesCount);

            if (backgroundPrefab == null)
            {
                Debug.Logger.LogError(this.gameObject, "BackgroundPrefab не инициализирован.");
            }
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
                        GameObject obs = Instantiate(prefabs[val], points[i].transform.position, Quaternion.identity, this.transform.parent);
                        obs.transform.localScale = this.obstacleScale;
                        obsCont++;
                    }
                    catch (Exception ex)
                    {
                        Debug.Logger.LogError(this.gameObject, ex.Message);
                        break;
                    }

                }
            }
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                if (this.Prev != null)
                {
                    Destroy(this.prev);
                }

                GameObject bg = Instantiate(this.backgroundPrefab, this.spawnPoint.position, Quaternion.identity);
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
}
