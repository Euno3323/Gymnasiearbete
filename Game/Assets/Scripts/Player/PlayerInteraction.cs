using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [Header("References")]
    public GameObject interactIcon;
    private Vector2 interactionArea = new Vector2(1f, 1f);
    public void openInteractableIcon() 
    {
        interactIcon.SetActive(true);
    }

    public void closeInteractableIcon()
    {
		interactIcon.SetActive(false);
	}

    void Start()
    {
        closeInteractableIcon();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        { 
            CheckInteraction();
        }
        
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, 1f, Vector2.zero, 3f);
        foreach (RaycastHit2D hit in hits){
            if (hit.transform.GetComponent<Interactable>())
            {
                openInteractableIcon();
            } else
            {
                closeInteractableIcon();
            }
        }
    }


    private void CheckInteraction()
    {
        // RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, interactionArea, 0, Vector2.zero);
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, 1f, Vector2.zero, 3f);
        Debug.DrawRay(transform.position, Vector2.right, Color.red, 1f);

        if (hits.Length > 0) 
        {
            foreach (RaycastHit2D raycast in hits) 
            {
                if (raycast.transform.GetComponent<Interactable>())
                {
                    raycast.transform.GetComponent<Interactable>().Interact();
                }
            }
        }
    }
}
