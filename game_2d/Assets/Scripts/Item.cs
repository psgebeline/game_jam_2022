using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Items
{
    public class Item : MonoBehaviour
    {
        [SerializeField]
        private ItemArguments _itemCharacteristics;
        [SerializeField]
        private Color _selectedColor = Color.green;

        private bool _canBePickedUp;
        private SpriteRenderer _spriteRenderer;
        private Color _defaultColor;
        private Transform _player;
        private float _playerDistanceToSelection;

        public bool CanBePickedUp => _canBePickedUp;
        public ItemArguments ItemCharacteristics => _itemCharacteristics;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _defaultColor = _spriteRenderer.color;
        }

        private void OnEnable()
        {
            UnselectItem();
        }

        private void Start()
        {
            var player = GameManager.Self.Player;
            _player = player.transform;
            _playerDistanceToSelection = player.DistanceToSelection;
        }

        private void Update()
        {
            _canBePickedUp = (Vector2.Distance(_player.transform.position, transform.position) <= _playerDistanceToSelection) ? true : false;
            if (_canBePickedUp) return;
            UnselectItem();
        }

        private void OnMouseOver()
        {
            if (!_canBePickedUp) return;
            SelectItem();
        }

        private void OnMouseExit()
        {
            if (!_canBePickedUp) return;
            UnselectItem();
        }

        public void SelectItem()
        {
            _spriteRenderer.color = _selectedColor;
            GameManager.Self.ItemHasBeedSelected(this);
        }

        public void UnselectItem()
        {
            _spriteRenderer.color = _defaultColor;
            GameManager.Self.ItemHasBeedUnselected(this);
        }
    }

    //todo check if it needs another file for this structure
    [System.Serializable]
    public struct ItemArguments
    {
        public string _itemName;
        public int _id;
    }
}
