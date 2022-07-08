using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Controls
{
    public class PlayerController : MonoBehaviour
    {
        //create variables
        [SerializeField]
        private KeyCode _pickUpKey;
        [SerializeField]
        private KeyCode _dropKey;

        private Rigidbody2D _rb;
        private PlayerComponent _player;

        // Start is called before the first frame update
        void Start()
        {
            _rb = this.GetComponent<Rigidbody2D>();
            _player = GameManager.Self.Player;
        }

        private void Update()
        {
            MouseScroll();
            ButtonsLogic();
        }

        /// <summary>
        /// FixedUpdate usually calls for working with physics 
        /// </summary>
        void FixedUpdate()
        {
            Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            PlayerMoving(movement); //move the character in direction of input by calling the function below
        }

        //create a function to transform 2d position vector; normalization to account for diagonal movement?
        void PlayerMoving(Vector2 direction)
        {
            _rb.MovePosition((Vector2)transform.position + (direction * _player.MovementSpeed * Time.fixedDeltaTime)); //if we are working on FixedUpdate we need to use Time.fixedDeltaTime
        }

        public event Action<ControllsEnum.MouseScrollType> OnMouseScrolled;

        private void MouseScroll()
        {
            float mouseScroll = Input.GetAxis("Mouse ScrollWheel");
            if (mouseScroll > 0) OnMouseScrolled.Invoke(ControllsEnum.MouseScrollType.Up);
            else if (mouseScroll < 0) OnMouseScrolled.Invoke(ControllsEnum.MouseScrollType.Down);
        }

        private void ButtonsLogic()
        {
            if (Input.GetKeyDown(_pickUpKey))
                OnPlayerPickingUp.Invoke();
            if (Input.GetKeyDown(_dropKey))
                OnPlayerDropping.Invoke();
        }

        public event Action OnPlayerPickingUp;
        public event Action OnPlayerDropping;
    }
}
//good changes