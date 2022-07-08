using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PotionIndicator : MonoBehaviour
{
    [SerializeField]
    private Image _potionIcon;
    [SerializeField]
    private TextMeshProUGUI _potionCount;

    public void SetIndicatorsData(SpriteRenderer image, int count)
    {
        _potionIcon.sprite = image.sprite;
        _potionIcon.color = image.color;
        _potionCount.text = count.ToString() + "x";
        gameObject.SetActive(true);
    }
}
