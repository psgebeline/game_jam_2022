using Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Inventory
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField, Min(1)]
        private int _capacity = 1;
        private List<Item> _items = new List<Item>();

        private int _currentItemIndex;
        private PlayerComponent _player;

        private void Awake()
        {
            _player = GetComponent<PlayerComponent>();
        }

        public bool AddItem(Item item)
        {
            if (_items.Count >= _capacity) return false;
            _items.Add(item);
            _currentItemIndex = _player.TakeLastPickedItem ? _items.Count - 1 : _currentItemIndex;
            return true;
        }

        public Item GetItem(int index = 0)
        {
            if (_items.Count == 0) return null;
            Item current_item = _items[index];
            return current_item;
        }

        public Item GetItemByCurrentIndex()
        {
            if (_items.Count == 0) return null;
            Item current_item = _items[_currentItemIndex];
            return current_item;
        }

        public bool RemoveItem(Item item)
        {
            return _items.Remove(item);
        }

        public void NextItem()
        {
            if (_items.Count == 0) return;
            if (_currentItemIndex + 1 > _items.Count - 1)
                _currentItemIndex = 0;
            else _currentItemIndex += 1;
        }

        public void PrevItem()
        {
            if (_items.Count == 0) return;
            if (_currentItemIndex - 1 < 0)
                _currentItemIndex = _items.Count - 1;
            else _currentItemIndex -= 1;
        }
    }
}
