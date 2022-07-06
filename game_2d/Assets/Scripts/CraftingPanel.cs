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
    [SerializeField]
    private GameObject _nextButton;
    [SerializeField]
    private GameObject _prevButton;

    private bool _successToCraft = false;
    private PotionCraft[] _availableCraftingObjects;
    private int _currentCraftingObjectIndex = 0;
    private PlayerComponent _player;

    private void Start()
    {
        _availableCraftingObjects = GameManager.Self.ActualPotions;
        _player = GameManager.Self.Player;
        DisplayCraft(_currentCraftingObjectIndex);
    }

    private void OnEnable()
    {
        CheckSuccessToCurrentCraft();
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
        CheckSuccessToCurrentCraft();
    }

    private void CheckSuccessToCurrentCraft()
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
        foreach (KeyValuePair<GameObject, int> dictionary in _availableCraftingObjects[_currentCraftingObjectIndex].Ingredients)
        {
            for (int count = 0; count < dictionary.Value; count++)
            {
                Item item = _player.Inventory.RemoveItemWithId(dictionary.Key.GetComponent<Item>().ItemCharacteristics._id);
                Destroy(item.gameObject);
            }
        }
        Item craftedObjectPrefab = _availableCraftingObjects[_currentCraftingObjectIndex].PotionPrefab;
        _player.PickUpAnItem(Instantiate(craftedObjectPrefab));
        if (_successToCraft)
            gameObject.SetActive(false);
        CheckSuccessToCurrentCraft();
    }

    public void NextCraft()
    {
        _currentCraftingObjectIndex += 1;
        if (_currentCraftingObjectIndex + 1 > _availableCraftingObjects.Length - 1)
            _nextButton.SetActive(false);
        if (_currentCraftingObjectIndex > 0)
            _prevButton.SetActive(true);
        DisplayCraft(_currentCraftingObjectIndex);
        CheckSuccessToCurrentCraft();
    }

    public void PrevCraft()
    {
        _currentCraftingObjectIndex -= 1;
        if (_currentCraftingObjectIndex - 1 < 0)
            _prevButton.SetActive(false);
        if (_currentCraftingObjectIndex < _availableCraftingObjects.Length - 1)
            _nextButton.SetActive(true);
        DisplayCraft(_currentCraftingObjectIndex);
        CheckSuccessToCurrentCraft();
    }
}
