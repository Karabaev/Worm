
namespace Game.Debug
{
    using System;
    using UnityEngine;
    
    [ExecuteInEditMode]
    public class VisualizeNonStaticRadius : MonoBehaviour
    {
        private readonly float _360Degrees = Mathf.PI * 2;
        [SerializeField] int lineCount; // количество вершин
        private float lineStep; // номер вершины
        private float radius = 0; // радиус окружности
        private NonStaticObstacle obstacle; // ссылка на основной объект

        private void Start()
        {
            obstacle = gameObject.GetComponentInChildren<NonStaticObstacle>();
        }

        void Update()
        { 
            lineStep = _360Degrees / lineCount;
            try
            {
                radius = obstacle.Radius;
            }
            catch (NullReferenceException)
            {
                Logger.LogError(gameObject, "Не найден компонент NonStaticObstacle.");
            }
            for (int i = 0; i < lineCount; i++)
            {
                try
                {
                    Debug.DrawLine(this.GetPointPosition(i), this.GetPointPosition(i + 1), Color.green);
                }
                catch(ArgumentOutOfRangeException)
                {
                    Debug.DrawLine(this.GetPointPosition(i), this.GetPointPosition(0));
                }
            }
        }

        /// <summary>
        /// Получить координаты вершины на окружности.
        /// </summary>
        /// <param name="i">Номер вершины.</param>
        /// <returns></returns>
        private Vector3 GetPointPosition(int i)
        {
            Vector3 result = new Vector3();
            result.x = this.radius * Mathf.Cos(lineStep * i) + transform.position.x;
            result.y = this.radius * Mathf.Sin(lineStep * i) + transform.position.y;
            result.z = 0;
            return result;
        }
    }
}
