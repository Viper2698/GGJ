using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public GameObject item;
    public bool empty;
    public Sprite icon;
    public void UpdateSlot()
    {
        this.GetComponent<Image>().sprite = icon;
    }
}
    public class Item
{
    public string name;
    public Sprite spriteItem = null;
    public bool pickedUp;

    public Item(string name, Image image)
    {
        this.name = name;
    }
   
}