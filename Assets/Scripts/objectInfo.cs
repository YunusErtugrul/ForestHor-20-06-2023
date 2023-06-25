using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectInfo : MonoBehaviour
{
    public GameObject player;
    public GameObject noteUI;
    //public GameObject hud;
    public GameObject inv;

    public GameObject pickUpText;
    public GameObject exitText;

    public AudioSource pickUpSound;

    public bool inReach;

    public bool alReady;
    public AudioSource takeSound;
    public Animator takeAI;

    void Start()
    {
        noteUI.SetActive(false);
        //hud.SetActive(true);
        inv.SetActive(true);
        pickUpText.SetActive(false);
        exitText.SetActive(false);
        inReach = false;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inReach = true;
            pickUpText.SetActive(true);

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inReach = false;
            pickUpText.SetActive(false);
        }
    }




    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inReach && alReady == false)
        {
            takeSound.Play();
            StartCoroutine(pressE());
            takeAI.SetTrigger("take");
            takeAI.ResetTrigger("exit");
        }
        if (Input.GetKeyDown(KeyCode.Q) && alReady)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            noteUI.SetActive(false);
            //hud.SetActive(true);
            inv.SetActive(true);
            //player.GetComponent<FirstPersonController>().enabled = true;
            alReady = false;
            pickUpText.SetActive(true);
            exitText.SetActive(false);
            Time.timeScale = 1;
            takeAI.SetTrigger("exit");
            takeAI.ResetTrigger("take");
        }
    }

    IEnumerator pressE()
    {
        yield return new WaitForSeconds(0.5f);
        noteUI.SetActive(true);
        pickUpSound.Play();
        pickUpText.SetActive(false);
        inv.SetActive(false);
        //player.GetComponent<FirstPersonController>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        alReady = true;
        exitText.SetActive(true);
        //Time.timeScale = 0;
    }


    public void ExitButton()
    {


    }
}