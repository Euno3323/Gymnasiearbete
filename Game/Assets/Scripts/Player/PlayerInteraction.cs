using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [Header("References")]
    public GameObject interactIcon;

    void Start()
    {
        closeInteractableIcon();
    }
    void Update()
    {
        checkInteraction();
    }
	private void openInteractableIcon()
	{
		interactIcon.SetActive(true);
	}

	private void closeInteractableIcon()
	{
		interactIcon.SetActive(false);
	}

    private void checkInteraction()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, 2f, Vector2.zero, 4f);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.transform.GetComponent<Interactable>())
            {
                openInteractableIcon();
            }
            else
            {
                closeInteractableIcon();
            }
        }
        if (hits.Length > 0 && Input.GetKeyDown(KeyCode.E))
        {
            foreach (RaycastHit2D hit in hits) 
            {
                if (hit.transform.GetComponent<Interactable>()) 
                {
                    hit.transform.GetComponent<Interactable>().Interact();
                    return;
                }
            }
        }
	}
}
