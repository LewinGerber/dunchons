using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Coin : MonoBehaviour, IInteractable
{
    [SerializeField]
    private Item item;

    [SerializeField]
    private GameObject owner;

    [SerializeField]
    private AudioClip coinSound;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PrimaryUse()
    {
        audioSource.clip = coinSound;
        audioSource.Play();
    }

    public void SecondaryUse() { }

    public Item GetItem()
    {
        return item;
    }

    public GameObject GetOwner()
    {
        return owner;
    }
}
