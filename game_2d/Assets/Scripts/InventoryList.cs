using Items;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryList : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _listOfItems;
    [SerializeField]
    private bool _addCounts;

    private void Start()
    {
        UpdateListOfItems(GameManager.Self.Player.Inventory.GetAllItems());
    }

    public void UpdateListOfItems(Item[] items)
    {
        _listOfItems.text = "";
        List<ItemArguments> _checkedItems = new List<ItemArguments>();
        for (int ind = 0; ind < items.Length; ind++)
        {
            ItemArguments checkingItem = items[ind].ItemCharacteristics;
            if (!_checkedItems.Exists(x => x._id == checkingItem._id))
            {
                int count = 1;
                for (int checkInd = ind + 1; checkInd < items.Length; checkInd++)
                {
                    ItemArguments pairItem = items[checkInd].ItemCharacteristics;
                    if (pairItem._id == checkingItem._id) count += 1;
                }
                _checkedItems.Add(checkingItem);
                _listOfItems.text += "- " + (_addCounts? count.ToString() + " " : "") + checkingItem._itemName + "\n";
            }
        }
    }
}
