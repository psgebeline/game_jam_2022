using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using Items;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private PlayerComponent _player;

    public static GameManager Self;
    public PlayerComponent Player => _player;

    private void Awake()
    {
        Self = this;
    }

    public void ItemHasBeedSelected(Item item)
    {
        _player.PickUpAnItem(item);
    }
}
