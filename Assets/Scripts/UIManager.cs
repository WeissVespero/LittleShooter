using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthText;

    public void ChangeHealthText(float points)
    {
        _healthText.text = $"Health: {points}";
    }
}
