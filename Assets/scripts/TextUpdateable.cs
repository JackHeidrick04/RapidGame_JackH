using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextUpdateable : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string Prefix = string.Empty;
    void Start()
    {
        // Optional: Find the TextMeshProUGUI component if not assigned
        if (textComponent == null)
        {
            textComponent = FindObjectOfType<TextMeshProUGUI>();
        }
    }

    // Method to update text based on an integer input
    public void UpdateText(int number)
    {
        if (textComponent != null)
        {
            // Update the textComponent's text property
            textComponent.text =  Prefix + number.ToString();
        }
    }
}
