using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    void OnPrimaryAction()
    {
        Inventory.Instance.OnPrimaryInteraction();
    }

    void OnSecondaryAction()
    {
        Inventory.Instance.OnSecondaryInteraction();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionObject = collision.gameObject;
        if (collisionObject.CompareTag("Item"))
        {
            IInteractable interactable = collisionObject.GetComponent<IInteractable>();
            if (Inventory.Instance.HasSpaceInInventoryForItem(interactable)) {
                Inventory.Instance.AddInteractable(interactable);
                collisionObject.transform.position = new Vector3(0, -100, 0);
                // Destroy(collisionObject);
            } else {
                Debug.Log("Inventory is full");
            }
        }
    }
}