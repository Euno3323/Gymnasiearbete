using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public abstract void Interact();

    private void Reset()
    {
        GetComponent<BoxCollider>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            collision.GetComponent<PlayerInteraction>().openInteractableIcon();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
		if (collision.CompareTag("Player"))
		{
			collision.GetComponent<PlayerInteraction>().closeInteractableIcon();
		}
	}
}
