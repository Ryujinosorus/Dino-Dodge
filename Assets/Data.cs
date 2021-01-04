using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public float camSpeed=0.000000000000000000001f,borneSpawn=1f;
    private float campSpeedUp = 0.015f,borneSpawnDown=0.035f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(faster());
    }

    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator faster()
    {
        yield return new WaitForSeconds(2f);
        if(camSpeed< 0.32f) camSpeed += campSpeedUp;
        if(borneSpawn>0.15f)borneSpawn -= borneSpawnDown;
        StartCoroutine(faster());
    }
    public void reStart()
    {
        camSpeed = 0.1f;
        borneSpawn = 1.2f;
    }
}
