using Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Inventory.Inventory), typeof(Controls.PlayerController))]
    public class PlayerComponent : MonoBehaviour
    {
        [SerializeField, Min(0f)]
        private float _distanceToSelection = 3f;
        [SerializeField]
        private bool _takeLastPickedItem;
        private Inventory.Inventory _inventory;
        private Item _currentItem;
        private Controls.PlayerController _controller;

        public float DistanceToSelection => _distanceToSelection;
        public bool TakeLastPickedItem => _takeLastPickedItem;

        private void Awake()
        {
            _inventory = GetComponent<Inventory.Inventory>();
            _controller = GetComponent<Controls.PlayerController>();
            _controller.OnMouseScrolled += OnMouseScrolled;
        }

        public void PickUpAnItem(Item item)
        {
            if (!_inventory.AddItem(item)) return;
            item.gameObject.SetActive(false);
            item.transform.parent = transform;
            item.transform.position = transform.position;
            TakeAnItem();
        }

        private void TakeAnItem()
        {
            if (_currentItem != null) _currentItem.gameObject.SetActive(false);
            _currentItem = _inventory.GetItemByCurrentIndex();
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
            TakeAnItem();
        }
    }
}
