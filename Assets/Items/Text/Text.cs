using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class Text : MonoBehaviour, IInteractable
{
    [SerializeField]
    private Item item;

    [SerializeField]
    private GameObject owner;

    [SerializeField]
    private TextMeshProUGUI textMesh;

    [SerializeField]
    private Image backdrop;

    private bool isTextShowing = false;
    private AudioSource audioSource;

    void Start() {
        this.audioSource = GetComponent<AudioSource>();
        backdrop.color = new Color(1, 1, 1, 1);
        backdrop.enabled = false;
    }

    public void PrimaryUse() {
        isTextShowing = !isTextShowing;
        if (isTextShowing) {
            backdrop.enabled = true;
            textMesh.text = "YOU JUST GOT COCONUTMALLED";
            audioSource.Play();
        } else {
            backdrop.enabled = false;
            textMesh.text = "";
            audioSource.Stop();
        }
    }

    public void SecondaryUse() { }

    public Item GetItem() {
        return item;
    }

    public GameObject GetOwner() {
        return owner;
    }
}
