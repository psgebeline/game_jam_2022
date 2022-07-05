using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Interaction_object
{
    public class Item : InteractionObject
    {
        [SerializeField]
        private ItemArguments _itemCharacteristics;

        public ItemArguments ItemCharacteristics => _itemCharacteristics;
    }

    //todo check if it needs another file for this structure
    [System.Serializable]
    public struct ItemArguments
    {
        public string _itemName;
        public int _id;
    }
}
