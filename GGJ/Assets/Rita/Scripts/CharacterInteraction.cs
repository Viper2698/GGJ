using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    private GameObject inventoryUI;
    private bool displayInventory = false;
    // Start is called before the first frame update
    void Start()
    {
        inventoryUI = GameObject.FindGameObjectWithTag("Inventory");
        if(inventoryUI !=null)
        {
            Debug.Log("Inventory not null");
        }
        inventoryUI.active = displayInventory;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.SetActive(!displayInventory);
            displayInventory = !displayInventory;

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
  
        if(collision.gameObject.tag == "Wood")
        {
            Debug.Log("Detected object");
            GameObject go = collision.gameObject;
            if (Input.GetKey(KeyCode.V))
            { //add item to inventory
                Inventory inventory = GetComponent<Inventory>();
                Item item = go.GetComponent<Item>();
                //inventory.AddItem(go,)
               
            }
        }
    }
}
