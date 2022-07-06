using Interaction_objects;
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
            OnInventoryChanged?.Invoke(GetAllItems());
            OnInventoryChangedNullReturn?.Invoke();
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

        public Item[] GetAllItems()
        {
            return _items.ToArray();
        }

        public List<Item> GetAllItemsList()
        {
            return _items;
        }

        public bool RemoveItem(Item item)
        {
            bool status = _items.Remove(item);
            if (status)
                OnInventoryChanged?.Invoke(GetAllItems());
            return status;
        }

        public Item RemoveItemWithId(int itemId)
        {
            int itemIndex = _items.FindIndex(x => x.ItemCharacteristics._id == itemId);
            Item item = _items[itemIndex];
            bool status = _items.Remove(item);
            if (!status) return null;
            OnInventoryChanged?.Invoke(GetAllItems());
            return item;
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

        public event System.Action<Item[]> OnInventoryChanged;
        public event System.Action OnInventoryChangedNullReturn;
    }
}
