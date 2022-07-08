using Interaction_objects;
using Player.Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction_objects
{
    public class Patient : InteractionObject
    {
        [SerializeField, Range(1, 6)]
        private int _countOfPotions = 1;
        [SerializeField]
        private PotionIndicator[] _potionIndicators;
        [SerializeField]
        private float _timeOfStayingRequirementsMenu = 3f;
        [SerializeField]
        private GameObject _requirementsMenu;
        [SerializeField]
        private GameObject _successfulActionLabel;
        //item, item count
        private Dictionary<Item, int> _requirements = new Dictionary<Item, int>();

        public Dictionary<Item, int> Requirements => _requirements;
        public bool IsRequirementsMenuOpened => _requirementsMenu.activeSelf;

        protected override void Start()
        {
            base.Start();
            var potions = GameManager.Self.ActualPotions;
            for (int i = 0; i < _countOfPotions; i++)
            {
                Item potion = potions[Random.Range(0, potions.Length)].PotionPrefab;
                if (_requirements.ContainsKey(potion))
                    _requirements[potion] += 1;
                else _requirements.Add(potion, 1);
            }
            UpdatePotionIndicator();
        }

        private void UpdatePotionIndicator()
        {
            int indicatorIndex = 0;
            foreach (Item potion in _requirements.Keys)
            {
                _potionIndicators[indicatorIndex].SetIndicatorsData(potion.gameObject.GetComponent<SpriteRenderer>(), _requirements[potion]);
                indicatorIndex += 1;
            }
        }

        public IEnumerator OpenRequirementsMenu()
        {
            if (_requirements.Count > 0 && !IsRequirementsMenuOpened)
            {
                _requirementsMenu.SetActive(true);
                yield return new WaitForSeconds(_timeOfStayingRequirementsMenu);
                _requirementsMenu.SetActive(false);
            }
            yield return null;
        }

        public void GiveRequiredItems(Inventory playersInventory)
        {
            if (_requirements.Count == 0) return;
            bool confirmed = true;
            foreach (Item potion in _requirements.Keys)
            {
                if (playersInventory.GetAllItemsList().FindAll(x => x.ItemCharacteristics._id == potion.ItemCharacteristics._id).Count < _requirements[potion])
                {
                    confirmed = false;
                    break;
                }
            }
            if (!confirmed) return;
            foreach (Item potion in _requirements.Keys)
            {
                playersInventory.RemoveItemWithId(potion.ItemCharacteristics._id);
            }
            _requirements.Clear();
            _successfulActionLabel.SetActive(true);
            foreach (PotionIndicator indicator in _potionIndicators)
            {
                indicator.gameObject.SetActive(false);
            }
        }
    }
}
