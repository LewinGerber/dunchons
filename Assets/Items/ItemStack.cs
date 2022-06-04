using UnityEngine;

public class ItemStack
{
    [SerializeField][Min(1)]
    private int numberOfItems = 1;
    [SerializeField]
    private Item item;

    public ItemStack(Item item)
    {
        this.item = item;
    }

    public void IncreaseNumberOfItems()
    {
        numberOfItems++;
    }

    public Item GetItem()
    {
        return item;
    }

    public int GetNumberOfItems()
    {
        return numberOfItems;
    }

    public void SetNumberOfItems(int numberOfItems) {
        this.numberOfItems = numberOfItems;
    }
}
