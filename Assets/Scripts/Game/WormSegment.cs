using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormSegment : MonoBehaviour
{
    public GameObject Next = null;
    public GameObject Prev = null;

    IEnumerator Move()
    {
        while(true)
        {
            if (Next != null)
                if (transform.position != Next.transform.position)
                    transform.position = Next.transform.position;
            yield return new WaitForSeconds(0.1f);
        }
        
    }
    private void Start ()
    {
        StartCoroutine(Move());
    }
}
