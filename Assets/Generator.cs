using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{
    [SerializeField]GameObject wall;
    Vector2 borneY = new Vector2(-6.5f,8);
    private Data data;
    GameObject player;
    Transform garbage;
    public int nbSpawn = 0;
    Text scoreTXT;
    // Start is called before the first frame update

    IEnumerator spawn()
    {
        nbSpawn++;
        scoreTXT.text = nbSpawn.ToString();
        GameObject go = Instantiate(wall, new Vector3(player.transform.position.x + 50, 0, 0), Quaternion.identity);
        go.transform.parent = garbage;

        int nbOfBlock = getNbOfBlocks();
        int nbOfBlockDone = 0;
        while (nbOfBlockDone != nbOfBlock)
        {
            int i = Random.Range(0, 4);
            if (go.transform.GetChild(i).gameObject.activeSelf)
            {
                go.transform.GetChild(i).gameObject.SetActive(false);
                nbOfBlockDone++;
            }
        }

        yield return new WaitForSeconds(data.borneSpawn);
        StartCoroutine(spawn());
    }
    public void stop()
    {
        StopAllCoroutines();
    }
    public void reStart()
    {
        scoreTXT = GameObject.Find("scoreTXT").GetComponent<Text>();
        scoreTXT.text = "0";
        nbSpawn = 0;
        player = GameObject.Find("xSpawn").gameObject;
        garbage = GameObject.Find("garbage").transform;
        data = GameObject.Find("ChefDeProjet").GetComponent<Data>();
        StartCoroutine(spawn());
    }
    private int getNbOfBlocks()
    {
        if (nbSpawn > 22)
            return 1;
        else if (nbSpawn > 10)
            return 2;
        return 3;
    }

}
