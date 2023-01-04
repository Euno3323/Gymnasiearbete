using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [Header("References")]
    public GameObject interactIcon;
    private Vector2 interactionArea = new Vector2(0.1f, 1f);

    void Start()
    {
        interactIcon.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        { 
            CheckInteraction();
        }
    }

    public void openInteractableIcon() 
    {
        interactIcon.SetActive(true);
    }

    public void closeInteractableIcon()
    {
		interactIcon.SetActive(false);
	}

    private void CheckInteraction()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, interactionArea, 0, Vector2.zero);

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
