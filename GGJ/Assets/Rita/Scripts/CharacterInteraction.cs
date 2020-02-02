using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInteraction : MonoBehaviour
{
    private GameObject inventoryUI;
    private bool displayInventory = false;
    //private Inventory inventory;
    public Text woodText,ropeText,spaceShipText;

    public int woodAmount, ropeAmount, spaceShipAmount = 0;
    // Start is called before the first frame update
    void Start()
    {   

        updateInnventory(woodText, "Wood", 0);
        updateInnventory(ropeText, "Rope", 0);
        updateInnventory(spaceShipText, "SpaceShip", 0);

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
    private void OnCollisionStay(Collision collision)
    {
        GameObject go = collision.gameObject;
        if (Input.GetKeyDown(KeyCode.E))
        switch(collision.gameObject.tag)
        {
                case "Wood":
                    woodAmount++;
                    Destroy(go);
                    updateInnventory(woodText, "Wood", woodAmount);
                    Debug.Log(woodAmount);
                    break;
                case "Rope":
                    ropeAmount++;
                    Destroy(go);
                    updateInnventory(ropeText, "Rope", ropeAmount);
                    break;
                case "SpaceShipParts":
                    spaceShipAmount++;
                    Destroy(go);
                    updateInnventory(spaceShipText, "SpaceShip", spaceShipAmount);
                    break;
                default:
                    Debug.Log("Nothing Added");
                    break;
        }
    }

    public void updateInnventory(Text text, string item, int amount)
    {
        //text.text = item + ":" + " " + amount.ToString();
    }

   
    
}
