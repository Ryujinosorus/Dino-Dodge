using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManagement : MonoBehaviour
{
    Generator generator;
    Data data;
    MooveCamerra mooveCamerra;
    Drake drake;
    [SerializeField]GameObject playBTN,deathMenu,settings;
    [SerializeField] AudioClip game,death;

    // Start is called before the first frame update
    void Start()
    {
        generator = GetComponent<Generator>();
        data = GetComponent<Data>();
        mooveCamerra = Camera.main.GetComponent<MooveCamerra>();
        drake = GameObject.Find("Dragon").GetComponent<Drake>();
    }

    // Update is called once per frame
    public void startGame(bool b)
    {
        generator.enabled = b;
        data.enabled = b;
        mooveCamerra.enabled = b;
        drake.enabled = b;
        if (b)
        {
            deathMenu.SetActive(false);
            playBTN.transform.parent.gameObject.SetActive(false);
            foreach (Transform go in GameObject.Find("garbage").GetComponentInChildren<Transform>())
                Destroy(go.gameObject);
            generator.reStart();
            data.reStart();
            drake.reStart();
            Camera.main.GetComponent<AudioSource>().clip = game;
            Camera.main.GetComponent<AudioSource>().Play();
        }
        else
        {
            Camera.main.GetComponent<AudioSource>().clip = death;
            Camera.main.GetComponent<AudioSource>().Play();
            deathMenu.SetActive(true);
        }
    }
    public void looseGame()
    {
        startGame(false);
        generator.stop();
    }


    public void reStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void changeVolume(Slider s)
    {
        PlayerPrefs.SetFloat("dd_vol", s.value);
        Camera.main.GetComponent<AudioSource>().volume = s.value;
        GameObject.Find("Dragon").GetComponent<AudioSource>().volume = s.value;
    }
}
