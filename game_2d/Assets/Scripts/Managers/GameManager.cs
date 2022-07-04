using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using Items;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private PlayerComponent _player;
    private Item _selectedItem;

    public static GameManager Self;
    public PlayerComponent Player => _player;
    public Item SelectedItem => _selectedItem;

    private void Awake()
    {
        Self = this;
    }

    public void ItemHasBeedSelected(Item item)
    {
        _selectedItem = item;
    }

    public void ItemHasBeedUnselected(Item item)
    {
        if (_selectedItem == item) _selectedItem = null;
    }
}
