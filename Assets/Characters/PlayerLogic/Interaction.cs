using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    void OnFire()
    {
        Inventory.Instance.UseSelectedItem();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionObject = collision.gameObject;
        if (collisionObject.CompareTag("Item"))
        {
            if (Inventory.Instance.HasSpaceInInventory()) {
                Inventory.Instance.AddInteractable(collisionObject.GetComponent<IInteractable>());
                Destroy(collisionObject);
            } else {
                Debug.Log("Inventory is full");
            }
        }
    }
}