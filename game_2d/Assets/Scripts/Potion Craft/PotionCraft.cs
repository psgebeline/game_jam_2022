using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interaction_objects;
using RotaryHeart.Lib.SerializableDictionary;

[CreateAssetMenu(fileName = "PotionCraft", menuName = "Potions/CraftList")]
public class PotionCraft : ScriptableObject
{
    [SerializeField]
    private Item _potionPrefab;
    [SerializeField]
    private PotionIngredients _ingredients;

    public Item PotionPrefab => _potionPrefab;
    public PotionIngredients Ingredients => _ingredients;
}

[System.Serializable]
//                                                          item        count
public class PotionIngredients : SerializableDictionaryBase<GameObject, int> { }
