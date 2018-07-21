using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
	
	private void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	private void Update ()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, transform.position.y, transform.position.z), Time.deltaTime * 10f);
    }
}
