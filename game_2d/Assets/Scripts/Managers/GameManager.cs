using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using Interaction_objects;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private PlayerComponent _player;
    [SerializeField, Tooltip("Potions which will be included in this scene")]
    private PotionCraft[] _actualPotions;
    private List<Item> _actualIngredients = new List<Item>();
    private InteractionObject _selectedObject;

    public static GameManager Self;
    public PlayerComponent Player => _player;
    public PotionCraft[] ActualPotions => _actualPotions;
    public List<Item> ActualIngredients => _actualIngredients;
    public InteractionObject SelectedObject => _selectedObject;

    private void Awake()
    {
        Self = this;
        CheckPotionsId();
        AddActualIngredients();
        CheckActualIngredients();
    }

    private void AddActualIngredients()
    {
        for (int potionIndex = 0; potionIndex < _actualPotions.Length; potionIndex++)
        {
            var potion = _actualPotions[potionIndex];
            foreach (GameObject key in potion.Ingredients.Keys)
            {
                Item item = key.GetComponent<Item>();
                if (item != null && !_actualIngredients.Exists(x => x == item))
                {
                    _actualIngredients.Add(item);
                }
            }
        }
    }

    private void CheckPotionsId()
    {
        List<Item> potions = new List<Item>();
        foreach (PotionCraft potion in _actualPotions)
        {
            potions.Add(potion.PotionPrefab);
        }
        foreach (Item potion in potions)
        {
            if (potions.FindAll(x => x.ItemCharacteristics._id == potion.ItemCharacteristics._id).Count > 1)
            {
#if UNITY_EDITOR
                Item samePotion = potions.Find(x => x != potion && x.ItemCharacteristics._id == potion.ItemCharacteristics._id);
                Debug.LogError($"Potion <b>{potion.gameObject}</b> with <b>{potion.ItemCharacteristics._id}</b> id has the same id with <b>{samePotion.gameObject}</b>");
                UnityEditor.EditorApplication.isPlaying = false;
                return;
#endif
            }
        }
    }

    private void CheckActualIngredients()
    {
        List<Item> checkedItems = new List<Item>();
        foreach (Item item in _actualIngredients)
        {
            if (checkedItems.Exists(x => x.ItemCharacteristics._id == item.ItemCharacteristics._id))
            {
#if UNITY_EDITOR
                Item sameItem = checkedItems.Find(x => x != item && x.ItemCharacteristics._id == item.ItemCharacteristics._id);
                Debug.LogError($"Item <b>{item.gameObject}</b> with <b>{item.ItemCharacteristics._id}</b> id has the same id with <b>{sameItem.gameObject}</b>");
                UnityEditor.EditorApplication.isPlaying = false;
#endif
            }
            else
            {
                checkedItems.Add(item);
            }
        }
        _actualIngredients = checkedItems;
    }

    public void ItemHasBeedSelected(InteractionObject interactionObject)
    {
        _selectedObject = interactionObject;
    }

    public void ItemHasBeedUnselected(InteractionObject interactionObject)
    {
        if (_selectedObject == interactionObject) _selectedObject = null;
    }
}
