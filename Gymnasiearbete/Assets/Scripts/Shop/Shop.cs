using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public KeyCode interactKey;
    public GameObject player;
    private bool isInRange;
    private bool buttonisclicked;

    void Start()
    {
        buttonisclicked = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(interactKey) && isInRange)
        {
            TaskOnClick();
        }
    }

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
        buttonisclicked = true;
    }

    private void OnGUI()
    {
        if (buttonisclicked)
        {
            
        }
    }
    //kollar om spelar är nära nog
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject == player)
        {
            isInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)  
    {
        if (collision.gameObject == player)
        {
            isInRange = false;
        }
    }
}
