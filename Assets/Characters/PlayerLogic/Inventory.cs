using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }
    private static int MAX_ITEMS = 3;

    public List<ItemStack> itemStacks = new List<ItemStack>();
    public int indexOfSlectedItem = 0;

    public GameObject itemSlot;
    private GameObject hotbar;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        hotbar = GameObject.Find("Inventory Hotbar");
        UpdateHotbar();
    }

    void UpdateHotbar()
    {
        for (int i = 0; i < itemStacks.Count; i++)
        {
            Image itemImage = hotbar.transform
                .GetChild(i)
                .Find("Icon")
                .GetComponent<Image>();

            itemImage.color = new Color(1, 1, 1, 1);
            itemImage.sprite = itemStacks[i].GetInteractable().GetItem().sprite;

            int numberOfItems = itemStacks[i].GetNumberOfItems();
            if (numberOfItems > 1)
            {
                hotbar.transform
                    .GetChild(i)
                    .Find("Stack size")
                    .GetComponent<TextMeshProUGUI>()
                    .text = itemStacks[i].GetNumberOfItems().ToString();
            }
        }

        for (int i = 0; i < 3; i++)
        {
            Image background = hotbar.transform
                .GetChild(i)
                .Find("Background")
                .GetComponent<Image>();

            if (indexOfSlectedItem == i)
            {
                background.color = new Color(256, 256, 256, 0.25f);
            }
            else
            {
                background.color = new Color(0, 0, 0, 0.25f);
            }
        }
    }

    public void OnPrimaryInteraction() {
        if (indexOfSlectedItem < itemStacks.Count)
        {
            IInteractable interactable = itemStacks[indexOfSlectedItem].GetInteractable();
            interactable.PrimaryUse();
        }
        else
        {
            Debug.Log("Using no item");
        }
    }

    public void OnSecondaryInteraction() {
        if (indexOfSlectedItem < itemStacks.Count)
        {
            IInteractable interactable = itemStacks[indexOfSlectedItem].GetInteractable();
            interactable.SecondaryUse();
        }
        else
        {
            Debug.Log("Using no item");
        }
    }

    public void AddInteractable(IInteractable interactable)
    {
        if (HasSpaceInInventoryForItem(interactable))
        {
            bool isAlreadyInInventory = itemStacks.Exists(stack => stack.GetInteractable().GetItem().GetId().Equals(interactable.GetItem().GetId()));
            if (isAlreadyInInventory)
            {
                itemStacks.ForEach((ItemStack stack) =>
                {
                    if (stack.GetInteractable().GetItem().GetId().Equals(interactable.GetItem().GetId()))
                    {
                        stack.IncreaseNumberOfItems();
                    }
                });
            }
            else
            {
                itemStacks.Add(new ItemStack(interactable));
            }
            UpdateHotbar();
        }
        else
        {
            Debug.Log("Inventory is full");
        }
    }

    public bool HasSpaceInInventoryForItem(IInteractable interactable)
    {
        bool hasSpaceForNewItem = new HashSet<ItemStack>(itemStacks).Count < MAX_ITEMS;
        
        List<string> itemIDs = itemStacks.Select(stack => stack.GetInteractable().GetItem().GetId()).ToList();
        bool isAlreadyIncluded = itemIDs.Contains(interactable.GetItem().GetId());

        return hasSpaceForNewItem || isAlreadyIncluded;
    }

    void OnInventorySlot1()
    {
        indexOfSlectedItem = 0;
        UpdateHotbar();
    }

    void OnInventorySlot2()
    {
        indexOfSlectedItem = 1;
        UpdateHotbar();
    }

    void OnInventorySlot3()
    {
        indexOfSlectedItem = 2;
        UpdateHotbar();
    }
}
