
namespace Game
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.SceneManagement;
    /// <summary>
    /// Направления перемещения персонажа
    /// </summary>
    public enum PlayerTurn
    {
        Forward,
        Top,
        Down
    }
    /// <summary>
    /// Класс управления персонажом
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private GameData gameData;
        [SerializeField] private List<Vector3> turnRotations;
        [SerializeField] private PlayerTurn currentTurn;
        [SerializeField] private bool IsDead = false;
        [SerializeField] private string cameraBordersTag = string.Empty, obstaclesTag = string.Empty, backgroundBorderTag = string.Empty;
        public UnityEvent OnDead;
        public UnityEvent OnBackgroundReplace;
        private void Start()
        {
            this.currentTurn = PlayerTurn.Forward;
            this.TurnPlayer();
        }

        private void Update()
        {
            if (!IsDead)
            {
                this.ChangeTurn();
                this.Move();
            }
        }

        /// <summary>
        /// Перемещение персонажа.
        /// </summary>
        private void Move()
        {
            this.transform.localPosition += this.transform.right * gameData.GameSpeed * Time.deltaTime;
        }

        /// <summary>
        /// Изменить угол поворота персонажа
        /// </summary>
        private void ChangeTurn()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (this.CurrentTurn == PlayerTurn.Forward) this.CurrentTurn = PlayerTurn.Down;
                this.CurrentTurn = this.CurrentTurn == PlayerTurn.Down ? PlayerTurn.Top : PlayerTurn.Down;
            }
        }

        /// <summary>
        /// Непосредственно повернуть объект игрока
        /// </summary>
        private void TurnPlayer()
        {
            switch (this.currentTurn)
            {
                case PlayerTurn.Forward:
                    this.transform.rotation = Quaternion.Euler(turnRotations[0]);
                    break;
                case PlayerTurn.Top:
                    this.transform.rotation = Quaternion.Euler(turnRotations[1]);
                    break;
                case PlayerTurn.Down:
                    this.transform.rotation = Quaternion.Euler(turnRotations[2]);
                    break;
                default:
                    break;
            }
        }

        private PlayerTurn CurrentTurn
        {
            get
            {
                return this.currentTurn;
            }
            set
            {
                this.currentTurn = value;
                this.TurnPlayer();
            }
        }

        /// <summary>
        /// Умереть
        /// </summary>
        private void Dead()
        {
            IsDead = true;
            OnDead.Invoke();
            SceneManager.LoadScene(0);
        }

        /// <summary>
        /// Столкновение (обычно смерть)
        /// </summary>
        /// <param name="other"></param>
        private void OnCollisionEnter2D(Collision2D other)
        {
            if(other.collider.tag == this.cameraBordersTag || other.collider.tag == this.obstaclesTag)
            {
                this.Dead();
                return;
            }
        }

        /// <summary>
        /// Вхождение в триггер
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == backgroundBorderTag)
            {
                this.OnBackgroundReplace.Invoke();
            }
        }
    }
}



