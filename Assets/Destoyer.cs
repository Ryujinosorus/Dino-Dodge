using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destoyer : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "invisibleWall") collision.collider.transform.position = new Vector3(collision.collider.transform.position.x + 117.9977f, collision.collider.transform.position.y, 0);
        else if (collision.collider.tag != "Player") Destroy(collision.collider.gameObject);
        else collision.collider.GetComponent<Drake>().loose();
    }
}
