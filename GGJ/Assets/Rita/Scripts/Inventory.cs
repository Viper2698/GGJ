using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{
    public int piecesofWood = 0;
    public int ropeAmount = 0;
    public int SpaceShipPieces = 0;
    public Text woodAmountText, ropeAmountText, spaceShipAmountText;
    

    // Update is called once per frame
    void Update()
    {   
        woodAmountText.text = piecesofWood.ToString();
        ropeAmountText.text = ropeAmount.ToString();
        spaceShipAmountText.text = SpaceShipPieces.ToString();
        Debug.Log("Inside Inventory" + piecesofWood);
    }
}
