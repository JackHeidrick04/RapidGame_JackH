using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldTextUpdate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("Gold").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
