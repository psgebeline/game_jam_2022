using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interaction_objects;

public class RandomItemSpawner : MonoBehaviour
{
    [SerializeField]
    private float _spawnDelay;
    [SerializeField, Tooltip("Spawn item when spawner is starting on")]
    private bool _spawnOnStart;

    private Transform _spawnedItem;
    private Item[] _actualItemsInScene;
    private bool _isSpawningState;

    private void Start()
    {
        _actualItemsInScene = GameManager.Self.ActualIngredients.ToArray();
        if (_spawnOnStart)
        {
            _isSpawningState = true;
            StartCoroutine(SpawnRandomItem(0f));
        }
    }

    private void Update()
    {
        if (!_isSpawningState && (_spawnedItem == null || _spawnedItem.parent != transform))
        {
            _isSpawningState = true;
            StartCoroutine(SpawnRandomItem(_spawnDelay));
        }

    }

    private IEnumerator SpawnRandomItem(float time)
    {
        yield return new WaitForSeconds(time);
        _spawnedItem = Instantiate(_actualItemsInScene[Random.Range(0, _actualItemsInScene.Length)], transform).transform;
        _isSpawningState = false;
    }
}
