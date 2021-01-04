using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repeatBG : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag != "Player") return;
        Transform parent = transform.parent;
        Debug.Log(parent.name);
        Instantiate(parent.gameObject, new Vector3(parent.position.x+117, parent.position.y, parent.position.z), Quaternion.identity);
    }
}
