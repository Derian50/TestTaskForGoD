using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{

    public List<Item> itemList = new List<Item>();

    public List<int> quantityList = new List<int>();


    public GameObject inventoryPanel;

    List<InventorySlot> slotList = new List<InventorySlot>();


    #region Singleton

    public static Inventory instance;

    void Awake()
    {
        instance = this;
    }

    #endregion


    public void Start()
    {
        foreach (InventorySlot child in inventoryPanel.GetComponentsInChildren<InventorySlot>())
        {
            
            slotList.Add(child);
        }
    }
    public Item getItemByName(string itemName)
    {
        foreach (Item item in itemList)
        {
            if(item.name == itemName)
            {
                return item;
            }
        }
        return null;
    }
    public int countOfAmmo()
    {
        foreach (Item item in itemList)
        {
            if(item.name == "Ammo")
            {
                return quantityList[itemList.IndexOf(item)];
            }
        }
        return 0;
    }
    public void AddItem(Item itemAdded, int quantityAdded)
    {
        
        if (itemAdded.Stackable)
        {
            if (itemList.Contains(itemAdded))
            {
                quantityList[itemList.IndexOf(itemAdded)] = quantityList[itemList.IndexOf(itemAdded)] + quantityAdded;
            }
            else
            {

                if (itemList.Count < slotList.Count)
                {
                    itemList.Add(itemAdded);
                    quantityList.Add(quantityAdded);
                }
                else { }
               
            }

        }
        else
        {
            for (int i = 0; i < quantityAdded; i++)
            {
                if (itemList.Count < slotList.Count)
                {
                    itemList.Add(itemAdded);
                    quantityList.Add(1);
                }
                else {  }
               
            }
            
        }
        
        UpdateInventoryUI();
        SaveLoadData.instance.SavePlayerData();
    }

    public void RemoveItem(Item itemRemoved, int quantityRemoved)
    {
        if (itemRemoved.Stackable)
        {
            if (itemList.Contains(itemRemoved))
            {
                quantityList[itemList.IndexOf(itemRemoved)] = quantityList[itemList.IndexOf(itemRemoved)] - quantityRemoved;

                if (quantityList[itemList.IndexOf(itemRemoved)]<= 0)
                {
                    quantityList.RemoveAt(itemList.IndexOf(itemRemoved));
                    itemList.RemoveAt(itemList.IndexOf(itemRemoved));
                }
            }
            
        }
        else
        {

            
            for (int i = 0; i < quantityRemoved; i++)
            {
                quantityList.RemoveAt(itemList.IndexOf(itemRemoved));
                itemList.RemoveAt(itemList.IndexOf(itemRemoved));
              
            }
        }
        UpdateInventoryUI();
        SaveLoadData.instance.SavePlayerData();
    }





    // --------------------------------------------------UI------------------------------------------------


    public void UpdateInventoryUI()
    {
        int ind = 0;

        foreach(InventorySlot slot in slotList)
        {

            if (itemList.Count != 0)
            {

                if (ind < itemList.Count)
                {
                    slot.UpdateSlot(itemList[ind], quantityList[ind]);
                    ind = ind + 1;
                }
                else
                {
                    slot.UpdateSlot(null, 0);
                }
            }
            else
            {
                slot.UpdateSlot(null, 0);
            }

        }
    }

   
}
