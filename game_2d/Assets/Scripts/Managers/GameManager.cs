using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using Interaction_object;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private PlayerComponent _player;
    private InteractionObject _selectedObject;

    public static GameManager Self;
    public PlayerComponent Player => _player;
    public InteractionObject SelectedObject => _selectedObject;

    private void Awake()
    {
        Self = this;
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
