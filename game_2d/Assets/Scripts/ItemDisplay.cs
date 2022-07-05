using Items;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
    [SerializeField]
    private Image _itemIcon;
    [SerializeField]
    private TextMeshProUGUI _itemName;

    private Sprite _defaultIconSprite;
    private Color _defaultIconColor;

    private void Awake()
    {
        _defaultIconSprite = _itemIcon.sprite;
        _defaultIconColor = _itemIcon.color;
    }

    public void UpdateItemInfo(Item item)
    {
        if (item == null)
        {
            _itemIcon.sprite = _defaultIconSprite;
            _itemIcon.color = _defaultIconColor;
            _itemName.text = "";
            return;
        }
        SpriteRenderer sprite = item.gameObject.GetComponent<SpriteRenderer>();
        _itemIcon.sprite = sprite?.sprite;
        _itemIcon.color = sprite? sprite.color : Color.white;
        _itemName.text = item.ItemCharacteristics._itemName;
    }
}
