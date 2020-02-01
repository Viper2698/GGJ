using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{   
    public GameObject inventory;
    public GameObject[] slots;
    public int allSlots;
    public int enabledSlots;
    public GameObject slotHolder;
    // Start is called before the first frame update
    void Start()
    {
        allSlots = 6;
        slots = new GameObject[allSlots];
        for(int i = 0; i<allSlots;i++)
        {
            slots[i] = slotHolder.transform.GetChild(i).gameObject;
            if (slots[i].GetComponent<InventorySlot>().item == null)
                slots[i].GetComponent<InventorySlot>().empty = true;
        }
    }

    public void AddItem(GameObject item,Sprite sprite)
    {
        for(int i =0; i<allSlots;i++)
        {
            if(slots[i].GetComponent<InventorySlot>().empty)
            {
                item.GetComponent<InventorySlot>().item = item;
                item.GetComponent<Item>().pickedUp = true;
                slots[i].GetComponent<InventorySlot>().icon = sprite;
                item.transform.parent = slots[i].transform;
                item.SetActive(false);
                slots[i].GetComponent<InventorySlot>().UpdateSlot();
                slots[i].GetComponent<InventorySlot>().empty = false;
            }
            return;
        }
    }
}
