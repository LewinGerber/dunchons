using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonPotion : MonoBehaviour, IInteractable
{
    [SerializeField]
    private Item item;

    [SerializeField]
    private GameObject owner;

    public void PrimaryUse() {
        owner.transform.Rotate(0, 0, -90);
    }

    public void SecondaryUse() { }

    public Item GetItem() {
        return item;
    }

    public GameObject GetOwner() {
        return owner;
    }
}
