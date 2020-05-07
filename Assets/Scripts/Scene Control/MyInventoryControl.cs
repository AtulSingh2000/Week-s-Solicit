using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;

public class MyInventoryControl : MonoBehaviour
{
    public int slotA_index, slotB_index, slotC_index;
    public RectTransform[] activePanel;
    public bool bool1, bool2, bool3, bool4, bool5;

    [Header("Reset")]
    public bool resetData;

    private void Start()
    {
        FirstInventoryVisit();
        LoadState();
        ActiveEquipped();
    }
    private void Update()
    {

        if (resetData)
            ResetInventory();
    }

    public void SwitchWeaponA(int weaponIndex)
    {
        slotA_index = weaponIndex;
        SaveState();
    }
    public void SwitchWeaponB(int weaponIndex)
    {
        slotB_index = weaponIndex;
        SaveState();
    }
    public void SwitchWeaponC(int weaponIndex)
    {
        slotC_index = weaponIndex;
        SaveState();
    }
    public void PurchaseBool1(bool myVal)
    {
        bool1 = myVal;
        SaveState();
    }
    public void PurchaseBool2(bool myVal)
    {
        bool2 = myVal;
        SaveState();
    }
    public void PurchaseBool3(bool myVal)
    {
        bool3 = myVal;
        SaveState();
    }
    public void PurchaseBool4(bool myVal)
    {
        bool4 = myVal;
        SaveState();
    }
    public void PurchaseBool5(bool myVal)
    {
        bool5 = myVal;
        SaveState();
    }
    public void SaveState()
    {
        SaveSystem.SaveInventory(this);
    }
    public void LoadState()
    {
        StateData data = SaveSystem.LoadInventory();

        slotA_index = data.slotA_val;
        slotB_index = data.slotB_val;
        slotC_index = data.slotC_val;

        bool1 = data.pb1;
        bool2 = data.pb2;
        bool3 = data.pb3;
        bool4 = data.pb4;
        bool5 = data.pb5;
    }
    private void FirstInventoryVisit()
    {
        string path2 = Application.persistentDataPath + "/this.Inv";

        if (!File.Exists(path2))
        {
            Debug.Log("First Inventory Visit");
            SaveState();
        }
        else
            Debug.Log("Not First Inventory Visit");
    }
    public void ResetInventory()
    {
        bool1 = false;
        bool2 = false;
        bool3 = false;
        bool4 = false;
        bool5 = false;
        SaveState();
    }
    private void ActiveEquipped()
    {
        switch (slotA_index)
        {
            case 0:
                activePanel[0].GetComponent<Image>().enabled = false;  //SetActive(false);
                break;                     
            case 1:                        
                activePanel[1].GetComponent<Image>().enabled = false;  //SetActive(false);
                break;           
            default:             
                activePanel[0].GetComponent<Image>().enabled = true;  //SetActive(true);
                activePanel[1].GetComponent<Image>().enabled = true;  //SetActive(true);
                break;           
        }                        
        switch (slotA_index)     
        {                        
            case 0:              
                activePanel[2].GetComponent<Image>().enabled = false;  //SetActive(false);
                break;                     
            case 1:                        
                activePanel[3].GetComponent<Image>().enabled = false;  //SetActive(false);
                break;           
            default:             
                activePanel[2].GetComponent<Image>().enabled = true;  //SetActive(true);
                activePanel[3].GetComponent<Image>().enabled = true;  //SetActive(true);
                break;           
        }                        
        switch (slotA_index)     
        {                        
            case 0:              
                activePanel[4].GetComponent<Image>().enabled = false;  //SetActive(false);
                break;           
            case 1:              
                activePanel[5].GetComponent<Image>().enabled = false;  //SetActive(false);
                break;           
            default:             
                activePanel[4].GetComponent<Image>().enabled = true;  //SetActive(true);
                activePanel[5].GetComponent<Image>().enabled = true;  //SetActive(true);
                break;
        }
    }
}
