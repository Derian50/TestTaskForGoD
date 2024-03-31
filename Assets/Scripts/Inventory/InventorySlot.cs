using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class InventorySlot : MonoBehaviour
{

    Item item;

    public Image itemImage;
    public Text quantity;

    public Button removeButton;
    private bool isClicked = false;

    public void UpdateSlot(Item itemInSlot, int quantityInSlot)
    {
        item = itemInSlot;


        if (itemInSlot != null && quantityInSlot !=0)
        {

            removeButton.enabled = true;
            itemImage.enabled = true; 
            
            itemImage.sprite = itemInSlot.itemIcon;

            if (quantityInSlot > 1)
            {
               
                quantity.enabled = true;
                quantity.text = quantityInSlot.ToString();
            }
            else
            {
                quantity.enabled = false;
                
            }

        }
        else
        {
            removeButton.enabled = false;
            itemImage.enabled = false;
            quantity.enabled = false;
        }
    }

    public void UseItem()
    {
        isClicked = !isClicked;
        if(isClicked)
        {
            removeButton.gameObject.SetActive(true);

        }
        else
        {
            removeButton.gameObject.SetActive(false);
        }
    }

    public void RemoveItem()
    {
        if (Inventory.instance.quantityList[Inventory.instance.itemList.IndexOf(item)] <= 1)
        {
            removeButton.gameObject.SetActive(false);
            isClicked = false;
        }
        Inventory.instance.RemoveItem(Inventory.instance.itemList[Inventory.instance.itemList.IndexOf(item)], 1);
       
    }
}
