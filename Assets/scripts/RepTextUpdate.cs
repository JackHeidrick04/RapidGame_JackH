using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RepTextUpdate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("Reputation").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
