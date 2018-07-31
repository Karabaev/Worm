namespace Game
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using System;
    public class NonStaticObstacle : MonoBehaviour
    {
        [SerializeField] private Transform[] endPoints;
        [SerializeField] private float moveSpeed;
        [SerializeField] private int pointIndex = 0;
        [SerializeField] private float radius;
        [SerializeField] private float minimalDistanceBetweenPoints;
        private void Update()
        {
            this.Move();
        }

        private void Move()
        {
            try
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, 
                                                                this.endPoints[this.pointIndex].position, 
                                                                Time.deltaTime * this.moveSpeed);
                if (this.transform.position == this.endPoints[this.pointIndex].position)
                {
                    this.pointIndex++;
                }
            }
            catch (IndexOutOfRangeException)
            {
                this.pointIndex = 0;
            }
        }

        private void EndPointsPlace()
        {  
            float xMax = radius, xMin = 0, yMax = radius, yMin = 0;
            Vector2 newPos = new Vector2();
            for (int i = 0; i < this.endPoints.Length; i++)
            {
                newPos.x = UnityEngine.Random.Range(xMin, xMax);
                newPos.y = UnityEngine.Random.Range(yMin, yMax);

                this.endPoints[i].transform.position = new Vector3();
            }
        }

        public float Radius
        {
            get
            {
                return radius;
            }
        }
       
    }
}
