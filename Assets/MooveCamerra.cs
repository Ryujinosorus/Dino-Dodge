using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MooveCamerra : MonoBehaviour
{
    Vector3 pos;
    Data data;
    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.Find("ChefDeProjet").GetComponent<Data>();
        pos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x+data.camSpeed,pos.y,pos.z);
    }
}
