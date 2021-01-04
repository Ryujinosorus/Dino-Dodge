using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setSCORE : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = PlayerPrefs.GetInt("dd_bs", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
