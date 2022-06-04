using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{

    public List<ItemStack> inventory = new List<ItemStack>();

    public int indexOfSlectedItem = 0;

    public GameObject itemSlot;
    private GameObject hotbar;

    void Awake()
    {
        hotbar = GameObject.Find("Inventory Hotbar");
        UpdateHotbar();
    }

    void AddItemToInventory(Item item)
    {
        bool isAlreadyInInventory = inventory.Exists(stack => stack.GetItem().GetId().Equals(item.GetId()));
        if (isAlreadyInInventory) {
            inventory.ForEach((ItemStack stack) =>
            {
                if (stack.GetItem().GetId().Equals(item.GetId()))
                {
                    stack.IncreaseNumberOfItems();
                }
            });
        } else {
            inventory.Add(new ItemStack(item));
        }
        UpdateHotbar();
    }

    void OnFire()
    {
        UseItemFromInventory(indexOfSlectedItem);
    }

    void UseItemFromInventory(int index) {
        if (index < inventory.Count) {
            Item item = inventory[index].GetItem();
            Debug.Log("Using item: " + item.name);
        } else {
            Debug.Log("Using no item");
        }
    }

    void UpdateHotbar()
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            Image itemImage = hotbar.transform
                .GetChild(i)
                .Find("Icon")
                .GetComponent<Image>();

            itemImage.color = new Color(1, 1, 1, 1);
            itemImage.sprite = inventory[i].GetItem().sprite;

            int numberOfItems = inventory[i].GetNumberOfItems();
            if (numberOfItems > 1) {
                hotbar.transform
                    .GetChild(i)
                    .Find("Stack size")
                    .GetComponent<TextMeshProUGUI>()
                    .text = inventory[i].GetNumberOfItems().ToString();
            }
        }

        for (int i = 0; i < 3; i++) {
            Image background = hotbar.transform
                .GetChild(i)
                .Find("Background")
                .GetComponent<Image>();

            if (indexOfSlectedItem == i) {
                background.color = new Color(256, 256, 256, 0.25f);
            } else {
                background.color = new Color(0, 0, 0, 0.25f);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        bool isItem = collision.gameObject.CompareTag("Item");
        if (isItem)
        {
            Item item = (collision.gameObject.GetComponent<ItemBase>()).item;
            AddItemToInventory(item);
            Destroy(collision.gameObject);
        }
    }

    void OnInventorySlot1() {
        indexOfSlectedItem = 0;
        UpdateHotbar();
    }

    void OnInventorySlot2() {
        indexOfSlectedItem = 1;
        UpdateHotbar();
    }

    void OnInventorySlot3() {
        indexOfSlectedItem = 2;
        UpdateHotbar();
    }

    void OnInventory(int e) {
        Debug.Log("entered / " + e);
    }
}
