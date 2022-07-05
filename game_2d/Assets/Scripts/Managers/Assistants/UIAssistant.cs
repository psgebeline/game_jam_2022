using Items;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAssistant : MonoBehaviour
{
    private GameManager _gameManager;

    [SerializeField]
    private InventoryList _playersInventoryList;
    [SerializeField]
    private ItemDisplay _itemDisplay;

    private void Start()
    {
        _gameManager = GameManager.Self;
        _gameManager.Player.Inventory.OnInventoryChanged += UpdateListOfItems;
        _gameManager.Player.OnPlayerChangedItem += UpdateItemDisplay;
    }

    private void UpdateListOfItems(Item[] items)
    {
        _playersInventoryList.UpdateListOfItems(items);
    }

    private void UpdateItemDisplay(Item item)
    {
        _itemDisplay.UpdateItemInfo(item);
    }
}
