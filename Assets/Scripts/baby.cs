using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class baby : MonoBehaviour
{

    //public GameObject test;

    //public Text MyScore;
    //private int Scorenum;


    public GameObject keyOB;
    public GameObject destroyText;
    public AudioSource Sound;

    public Animator burn;

    public float coolDown = 3;
    public float nextFire = 0;

    public bool inReach;
    

    public GameObject textt;
    public bool textActive;
    

    void Start()
    {
        //Scorenum = 0;
        //MyScore.text = "Find babies: " + Scorenum;


        inReach = false;
        destroyText.SetActive(false);
        textt.SetActive(false);
        textActive = false;
    }

    IEnumerator Die()
    {
        //play your sound
        yield return new WaitForSeconds(2); //waits 3 seconds
        Destroy(gameObject); //this will work after 3 seconds.
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inReach = true;
            destroyText.SetActive(true);
            textActive = true;

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inReach = false;
            destroyText.SetActive(false);
            textActive = false;
        }
    }


    void Update()
    {

        
        if(Time.time > nextFire) 
        {
        if (inReach && Input.GetKeyDown(KeyCode.E))
          {
            FindObjectOfType<Score>().IncreaseScore();

                nextFire = Time.time + coolDown;


            //Scorenum += 1;
            //MyScore.text = "Find babies: " + Scorenum;

            
            Sound.Play();
            destroyText.SetActive(false);
            burn.SetBool("press" ,true);
            StartCoroutine(Die());

          }
        }

        if (textActive && Input.GetKeyDown(KeyCode.E))
        {
            textt.SetActive(true);


        }

        if (!textActive)
        {
            textt.SetActive(false);
            
        }

    }
}