using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Drake : MonoBehaviour
{
    [SerializeField] GameObject fireBall;
    ButtonManagement buttonMangement;
    Data data;
    // Start is called before the first frame update
    void Start()
    {
        buttonMangement = GameObject.Find("ChefDeProjet").GetComponent<ButtonManagement>();
        data = GameObject.Find("ChefDeProjet").GetComponent<Data>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position,getPos(Input.GetTouch(0)),data.camSpeed*15);
        }
    }
    Vector3 getPos(Touch myTouch)
    {
        Ray mousePos = Camera.main.ScreenPointToRay(myTouch.position);
        Plane ground = new Plane(Vector3.forward, new Vector3(0, 0, 0));
        float distance;
        ground.Raycast(mousePos, out distance);
        Vector3 t = mousePos.GetPoint(distance);
        if (t.y < -4) t.y=-4;
        return t;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag != "Ennemy" || collision.collider.tag=="invisibleWall") return;
        loose();
    }
    public void loose()
    {
        int sc = GameObject.Find("ChefDeProjet").GetComponent<Generator>().nbSpawn;
        if (sc > PlayerPrefs.GetInt("dd_bs")) PlayerPrefs.SetInt("dd_bs", sc);
        if(Advertisement.IsReady() && Random.Range(0,2)==0)
            Advertisement.Show("video");
        buttonMangement.looseGame();
    }
    public void reStart()
    {
        transform.position = Camera.main.transform.Find("spawnPoint").position;
    }
}
