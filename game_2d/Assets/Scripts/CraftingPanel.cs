using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Interaction_objects;
using Player;

public class CraftingPanel : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _itemNameLabel;
    [SerializeField]
    private Image _itemIcon;
    [SerializeField]
    private TextMeshProUGUI _itemIngredientsListLabel;
    [SerializeField, Space]
    private Image _craftButton;
    [SerializeField]
    private Color _successToCraftColor;
    [SerializeField]
    private Color _notEnoughToCraftColor;

    private bool _successToCraft = false;
    private PotionCraft[] _availableCraftingObjects;
    private int _currentCraftingObjectIndex = 0;

    private void Start()
    {
        _availableCraftingObjects = GameManager.Self.ActualPotions;
        DisplayCraft(_currentCraftingObjectIndex);
    }

    private void OnEnable()
    {
        CheckSuccessToCraft();
    }

    private void DisplayCraft(int index)
    {
        PotionCraft craftingObject = _availableCraftingObjects[index];
        if (craftingObject == null) return;
        Item objectPrefab = craftingObject.PotionPrefab;
        _itemNameLabel.text = objectPrefab.ItemCharacteristics._itemName;
        SpriteRenderer objectSpriteRenderer = objectPrefab.gameObject.GetComponent<SpriteRenderer>();
        _itemIcon.sprite = objectSpriteRenderer?.sprite;
        _itemIcon.color = objectSpriteRenderer.color;

        string ingredientsText = "";
        foreach (KeyValuePair<GameObject, int> dictionary in craftingObject.Ingredients)
        {
            Item item = dictionary.Key.GetComponent<Item>();
            ingredientsText += dictionary.Value.ToString() + " " + item.ItemCharacteristics._itemName + "\n"; 
        }
        _itemIngredientsListLabel.text = ingredientsText;
        CheckSuccessToCraft();
    }

    private void CheckSuccessToCraft()
    {
        List<Item> playersInventory = GameManager.Self.Player.Inventory.GetAllItemsList();
        if (playersInventory == null || _availableCraftingObjects == null) return;
        _successToCraft = true;
        foreach (KeyValuePair<GameObject, int> dictionary in _availableCraftingObjects[_currentCraftingObjectIndex].Ingredients)
        {
            if (playersInventory.FindAll(x => x.ItemCharacteristics._id == dictionary.Key.GetComponent<Item>().ItemCharacteristics._id).Count < dictionary.Value)
            {
                _successToCraft = false;
                break;
            }
        }
        if (_successToCraft) _craftButton.color = _successToCraftColor;
        else _craftButton.color = _notEnoughToCraftColor;
    }

    public void Craft()
    {
        CheckSuccessToCraft();
        if (_successToCraft)
            gameObject.SetActive(false);
    }
}
