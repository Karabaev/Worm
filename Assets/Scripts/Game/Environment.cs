using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentConntroller : MonoBehaviour
{
    [Header("Настойка препятствий")]
    [SerializeField] private GameObject obstaclePrefab;
    private List<GameObject> obstacles = new List<GameObject>();
    [SerializeField] private int obstacleCount = 9;
    [SerializeField] private Vector3 startObstaclesposition;
    [SerializeField] private float maxXRange;
    [SerializeField] private float minXRange;
    [SerializeField] private float maxYRange;
    [SerializeField] private float minYRange;
    [SerializeField] private float obstaclesOffset = 3.0f;

    [Header("Настройка фона")]
    [SerializeField] private GameObject backgroundPrefab;
    private List<GameObject> backGrounds = new List<GameObject>();
    [SerializeField] private int backGroundCount = 2;
    [SerializeField] private float backgroundOffset = 10.0f;
    [SerializeField] private Vector3 startBackgroundPosition;
    [SerializeField] private Transform backGroundEndingPosition;
    private Transform player;
    private Transform leftCameraBorder;
    private Transform rightCameraBorder;

    private void Start ()
    {
        CreateBackgrounds();
        CreateObstacles();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        leftCameraBorder = GameObject.FindGameObjectWithTag("LeftCameraBorder").transform;
        rightCameraBorder = GameObject.FindGameObjectWithTag("RightCameraBorder").transform;
        if (player == null) Debug.LogError("Не найден объект с тегом Player");
        if(rightCameraBorder == null) Debug.LogError("Не найден объект с тегом RightCameraBorder");
        if(leftCameraBorder == null) Debug.LogError("Не найден объект с тегом LeftCameraBorder");
    }
	private void Update ()
    {
        BackgroundMove();
        ObstaclesMove();
    }
    private void CreateObstacles()
    {
        for (int i = 0; i < obstacleCount; i++)
        {
            Vector3 pos = new Vector3(startObstaclesposition.x + obstaclesOffset * i + Random.Range(minXRange, maxXRange), 
                                      startObstaclesposition.y + Random.Range(minYRange, maxYRange), startObstaclesposition.z);
            obstacles.Add(Instantiate(obstaclePrefab, pos, Quaternion.identity));
        }
    }
    private void CreateBackgrounds()
    {
        for (int i = 0; i < backGroundCount; i++)
        {
            Vector3 pos = new Vector3(startBackgroundPosition.x + backgroundOffset * i, startBackgroundPosition.y, startBackgroundPosition.z);
            obstacles.Add(Instantiate(backgroundPrefab, pos, Quaternion.identity));
        }
    }
    private void BackgroundMove()
    {

    }
    private void ObstaclesMove()
    {
        
    }
}
