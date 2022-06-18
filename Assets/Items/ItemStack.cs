using UnityEngine;

public class ItemStack
{
    [SerializeField][Min(1)]
    private int numberOfItems = 1;
    [SerializeField]
    private IInteractable interactable;

    public ItemStack(IInteractable interactable)
    {
        this.interactable = interactable;
    }

    public void IncreaseNumberOfItems()
    {
        numberOfItems++;
    }

    public IInteractable GetInteractable()
    {
        return interactable;
    }

    public int GetNumberOfItems()
    {
        return numberOfItems;
    }

    public void SetNumberOfItems(int numberOfItems) {
        this.numberOfItems = numberOfItems;
    }
}
