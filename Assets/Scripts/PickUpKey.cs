using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : MonoBehaviour
{
    public GameObject keyOB;
    public GameObject invOB;
    public GameObject pickUpText;
    public AudioSource keySound;

    public bool inReach;

    public GameObject textt;
    public bool textActive;
    
    void Start()
    {
        inReach = false;
        pickUpText.SetActive(false);
        invOB.SetActive(false);
        textt.SetActive(false);
        textActive = false;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inReach = true;
            pickUpText.SetActive(true);
            textActive = true;

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inReach = false;
            pickUpText.SetActive(false);
            textActive = false;
        }
    }


    void Update()
    {
        if (inReach && Input.GetKeyDown(KeyCode.E))
        {
            keyOB.SetActive(false);
            keySound.Play();
            invOB.SetActive(true);
            pickUpText.SetActive(false);
          
            
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
