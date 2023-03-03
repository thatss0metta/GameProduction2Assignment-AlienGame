using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI promptText;
    [SerializeField] private TextMeshProUGUI staminaText = default;
    // Start is called before the first frame update
    void Start()
    {
        UpdateStamina(100);
    }

    public void UpdateText(string promptMessage)
    {
        promptText.text = promptMessage;
    }

    private void UpdateStamina(float currentStamina)
    {
        staminaText.text = currentStamina.ToString("00");
    }
}
