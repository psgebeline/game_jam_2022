using Interaction_objects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Inventory.Inventory), typeof(Controls.PlayerController))]
    public class PlayerComponent : MonoBehaviour
    {
        [SerializeField]
        private float _movementSpeed = 10f;
        [SerializeField, Min(0f)]
        private float _distanceToSelection = 3f;
        [SerializeField]
        private bool _takeLastPickedItem;
        [SerializeField]
        private bool _lookOnItems;
        [SerializeField]
        private Transform _dropPoint;
        private Inventory.Inventory _inventory;
        private Item _currentItem;
        private Controls.PlayerController _controller;

        public float DistanceToSelection => _distanceToSelection;
        public bool TakeLastPickedItem => _takeLastPickedItem;
        public float MovementSpeed => _movementSpeed;
        public ref Inventory.Inventory Inventory => ref _inventory;
        public Item CurrentItem => _currentItem;

        private void Awake()
        {
            _inventory = GetComponent<Inventory.Inventory>();
            _inventory.OnInventoryChangedNullReturn += TakeAnCurrentItem;
            _controller = GetComponent<Controls.PlayerController>();
            _controller.OnMouseScrolled += OnMouseScrolled;
            _controller.OnPlayerPickingUp += PickUpAnItem;
            _controller.OnPlayerDropping += DropItem;
        }

        private void PickUpAnItem()
        {
            var selectedItem = GameManager.Self.SelectedObject;
            if (selectedItem == null) return;
            if (selectedItem is Item)
            {
                PickUpAnItem((Item)selectedItem);
            }
            else if (selectedItem is Patient)
            {
                Debug.Log("it's patient!");
            }
        }

        public void PickUpAnItem(Item item)
        {
            if (!_inventory.AddItem(item)) return;
            item.UnselectItem();
            item.gameObject.SetActive(false);
            item.transform.parent = transform;
            item.transform.position = transform.position;
            TakeAnCurrentItem();
        }

        public event Action<Item> OnPlayerChangedItem;

        private void TakeAnCurrentItem()
        {
            if (!_lookOnItems) return;
            if (_currentItem != null) _currentItem.gameObject.SetActive(false);
            _currentItem = _inventory.GetItemByCurrentIndex();
            OnPlayerChangedItem?.Invoke(_currentItem);
            if (_currentItem == null) return;
            _currentItem.gameObject.SetActive(true);
        }

        private void OnMouseScrolled(ControllsEnum.MouseScrollType swapType)
        {
            switch (swapType)
            {
                case ControllsEnum.MouseScrollType.Up:
                    _inventory.NextItem();
                    break;
                case ControllsEnum.MouseScrollType.Down:
                    _inventory.PrevItem();
                    break;
            }
            TakeAnCurrentItem();
        }

        private void DropItem()
        {
            if (!_lookOnItems || _currentItem == null || !_inventory.RemoveItem(_currentItem)) return;
            if (_dropPoint != null)
                _currentItem.transform.position = _dropPoint.transform.position;
            _currentItem.transform.parent = null;
            _currentItem = null;
            OnPlayerChangedItem.Invoke(_currentItem);
        }
    }
}
