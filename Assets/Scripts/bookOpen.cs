using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bookOpen : MonoBehaviour
{
    public GameObject noteUI;
    public AudioSource pickUpSound;
    public GameObject inv;
    public bool alReaady;
    public GameObject exitImage;

    void Start()
    {
        noteUI.SetActive(false);
        //hud.SetActive(true);
        inv.SetActive(true);
        alReaady = false;
        exitImage.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && alReaady == false)
        {
            noteUI.SetActive(true);
            pickUpSound.Play();
            //player.GetComponent<FirstPersonController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            inv.SetActive(false);
            exitImage.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            noteUI.SetActive(false);
            inv.SetActive(true);
            alReaady = false;
            //hud.SetActive(true);
            //player.GetComponent<FirstPersonController>().enabled = true;
        }
    }

    public void ExitButton()
    {

    }
}