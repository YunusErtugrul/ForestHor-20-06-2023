using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hidingPlace : MonoBehaviour
{
    public GameObject hideText, stopHideText;
    public GameObject normalPlayer, hidingPlayer;
    public enemyAI monsterScript;
    public Transform monsterTransform;
    bool interactable, hiding;
    public float loseDistance;
    public Camera cam;
    public GameObject mouse, tus, tus2;
    public AudioSource hSound, stophSound;
    public Detector dec;
    
    
    
    void Start()
    {
        mouse.SetActive(false);
        tus.SetActive(false);
        tus2.SetActive(false);
        interactable = false;
        hiding = false;
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if(dec.inTrigger == true)
            {
                hideText.SetActive(true);
                interactable = true;
            }
            else if(dec.inTrigger == false)
            {
                hideText.SetActive(false);
                interactable = false;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            hideText.SetActive(false);
            interactable = false;
        }
    }
    void Update()
    {
        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                hideText.SetActive(false);
                hSound.Play();
                hidingPlayer.SetActive(true);
                float distance = Vector3.Distance(monsterTransform.position, normalPlayer.transform.position);
                if (distance > loseDistance)
                {
                    if (monsterScript.chasing == true)
                    {
                        monsterScript.stopChase();
                    }
                }
                mouse.SetActive(true);
                tus.SetActive(true);
                tus2.SetActive(true);
                hiding = true;
                normalPlayer.SetActive(false);
                interactable = false;
            }
        }
        if (hiding == true)
        {
            if (Input.GetMouseButtonDown(1))
            {
                cam.fieldOfView = 30;
                
            }
            if(Input.GetKeyDown(KeyCode.R))
            {
                cam.fieldOfView = 60;
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                stophSound.Play();
                mouse.SetActive(false);
                tus.SetActive(false);
                tus2.SetActive(false);
                normalPlayer.SetActive(true);
                hidingPlayer.SetActive(false);
                hiding = false;
            }
        }
    }
}