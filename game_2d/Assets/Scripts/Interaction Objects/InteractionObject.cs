using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction_objects
{
    [RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
    public abstract class InteractionObject : MonoBehaviour
    {
        [SerializeField]
        private Color _selectedColor = Color.green;

        private bool _canBeInteracted;
        private SpriteRenderer _spriteRenderer;
        private Color _defaultColor;
        private Transform _player;
        private float _playerDistanceToSelection;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _defaultColor = _spriteRenderer.color;
        }

        protected virtual void Start()
        {
            UnselectItem();
            var player = GameManager.Self.Player;
            _player = player.transform;
            _playerDistanceToSelection = player.DistanceToSelection;
        }

        private void Update()
        {
            _canBeInteracted = (Vector2.Distance(_player.transform.position, transform.position) <= _playerDistanceToSelection) ? true : false;
            if (_canBeInteracted) return;
            UnselectItem();
        }

        private void OnMouseOver()
        {
            if (!_canBeInteracted || transform.parent == _player) return;
            SelectItem();
        }

        private void OnMouseExit()
        {
            if (!_canBeInteracted) return;
            UnselectItem();
        }

        public virtual void SelectItem()
        {
            _spriteRenderer.color = _selectedColor;
            GameManager.Self.ItemHasBeedSelected(this);
        }

        public virtual void UnselectItem()
        {
            _spriteRenderer.color = _defaultColor;
            GameManager.Self.ItemHasBeedUnselected(this);
        }
    }
}
