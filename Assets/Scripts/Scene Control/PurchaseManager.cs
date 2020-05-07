using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseManager : MonoBehaviour
{
    public Button[] gun; //Shotgun, AKM, HK416, Minigun, M249
    public Button[] Equip;
    public Button[] Unequip;
    public Button[] purchaseButton;
    
    public GameObject ErrorText;

    public bool isItem1;
    public bool isItem2;
    public bool isItem3;
    public bool isItem4;
    public bool isItem5;

    public GameObject settings;

    public int cash;
    // Start is called before the first frame update
  
    void Start()
    {
        //settings = GameObject.Find("StartSceneControl");
        cash = settings.GetComponent<GlobalSettingsControl>().totalCoinCount;
        ActivationState();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(cash);
    }

    void LoadBoolValues()
    {
        isItem1 = settings.GetComponent<MyInventoryControl>().bool1;
        isItem2 = settings.GetComponent<MyInventoryControl>().bool2;
        isItem3 = settings.GetComponent<MyInventoryControl>().bool3;
        isItem4 = settings.GetComponent<MyInventoryControl>().bool4;
        isItem5 = settings.GetComponent<MyInventoryControl>().bool5;
    }

    /// <summary>
    /// Called at Start
    /// </summary>
    void ActivationState()
    {
        LoadBoolValues();
        if (isItem1)
        {
            gun[0].interactable = isItem1;
            Equip[0].interactable = isItem1;
            Unequip[0].interactable = isItem1;
            purchaseButton[0].gameObject.SetActive(false); 
        }
            //
        if(isItem2)
        {
            gun[1].interactable = isItem1;
            Equip[1].interactable = isItem2;
            Unequip[1].interactable = isItem2;
            purchaseButton[1].gameObject.SetActive(false);
        }
            //
        if(isItem3)
        {
            gun[2].interactable = isItem3;
            Equip[2].interactable = isItem3;
            Unequip[2].interactable = isItem3;
            purchaseButton[2].gameObject.SetActive(false);
        }
            //
        if(isItem4)
        {
            gun[3].interactable = isItem4;
            Equip[3].interactable = isItem4;
            Unequip[3].interactable = isItem4;
            purchaseButton[3].gameObject.SetActive(false);
        }
            //
        if (isItem5)
        {
            gun[4].interactable = isItem5;
            Equip[4].interactable = isItem5;
            Unequip[4].interactable = isItem5;
            purchaseButton[4].gameObject.SetActive(false);
        }
    }

    public void Purchase1()
    {
        if (cash > 50)
        {
            gun[0].interactable = true;
            Equip[0].interactable = true;
            Unequip[0].interactable = true;
            purchaseButton[0].gameObject.SetActive(false);
            cash -= 10;
            settings.GetComponent<GlobalSettingsControl>().totalCoinCount = cash;
            settings.GetComponent<GlobalSettingsControl>().cashUpdate();
            settings.GetComponent<MyInventoryControl>().PurchaseBool1(true);
        }
        else
        {
            StartCoroutine(ErrorMessage());
        }
    }

    public void Purchase2()
    {
        if (cash > 60)
        {
            gun[1].interactable = true;
            Equip[1].interactable = true;
            Unequip[1].interactable = true;
            purchaseButton[1].gameObject.SetActive(false);
            cash -= 20;
            settings.GetComponent<GlobalSettingsControl>().totalCoinCount = cash;
            settings.GetComponent<GlobalSettingsControl>().cashUpdate();
            settings.GetComponent<MyInventoryControl>().PurchaseBool2(true);
        }
        else
        {
            StartCoroutine(ErrorMessage());
        }
    }

    public void Purchase3()
    {
        if (cash > 70)
        {
            gun[2].interactable = true;
            Equip[2].interactable = true;
            Unequip[2].interactable = true;
            purchaseButton[2].gameObject.SetActive(false);
            cash -= 30;
            settings.GetComponent<GlobalSettingsControl>().totalCoinCount = cash;
            settings.GetComponent<GlobalSettingsControl>().cashUpdate();
            settings.GetComponent<MyInventoryControl>().PurchaseBool3(true);
        }
        else
        {
            StartCoroutine(ErrorMessage());
        }
    }

    public void Purchase4()
    {
        if (cash > 120)
        {
            gun[3].interactable = true;
            Equip[3].interactable = true;
            Unequip[3].interactable = true;
            purchaseButton[3].gameObject.SetActive(false);
            cash -= 40;
            settings.GetComponent<GlobalSettingsControl>().totalCoinCount = cash;
            settings.GetComponent<GlobalSettingsControl>().cashUpdate();
            settings.GetComponent<MyInventoryControl>().PurchaseBool4(true);
        }
        else
        {
            StartCoroutine(ErrorMessage());
        }
    }

    public void Purchase5()
    {
        if (cash > 100)
        {
            gun[4].interactable = true;
            Equip[4].interactable = true;
            Unequip[4].interactable = true;
            purchaseButton[4].gameObject.SetActive(false);
            cash -= 50;
            settings.GetComponent<GlobalSettingsControl>().totalCoinCount = cash;
            settings.GetComponent<GlobalSettingsControl>().cashUpdate();
            settings.GetComponent<MyInventoryControl>().PurchaseBool5(true);
        }
        else
        {
            StartCoroutine(ErrorMessage());
        }
    }

    IEnumerator ErrorMessage()
    {
        ErrorText.SetActive(true);
        yield return new WaitForSeconds(3);
        ErrorText.SetActive(false);
    }
}
