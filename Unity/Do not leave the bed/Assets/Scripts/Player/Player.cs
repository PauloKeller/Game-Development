using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Player : MonoBehaviour
{
    int health = 10;
    bool isBleeding = false;
    bool canBleed = false;
    Light2D flashlight;
    List<Item> items = new List<Item>();
    bool turnedGasOff = false;
    Dialog dialog;
    bool isAlive = true;

    [SerializeField]
    int bleedDamage = 1;

    public bool IsAlive {
        get {
            return isAlive;
        }
    }

    public bool TurnedGasOff 
    {
        get 
        {
            return turnedGasOff;
        }

        set 
        { 
            turnedGasOff = value;
        }
    }

    public int Health { 
        get {
            return health;
        } 
    }

    public List<Item> Items 
    {
        get 
        {
            return items;
        }
    }
    
    public bool IsBleeding
    {
        set {
            isBleeding = value;
            canBleed = value;
        }

        get {
            return isBleeding;
        }
    }



    void Start()
    {
        flashlight = GetComponentInChildren<Light2D>();
        ToggleFlashLight();
        dialog = FindObjectOfType<Dialog>();
    }

    void ToggleFlashLight() 
    {
        flashlight.gameObject.SetActive(!flashlight.gameObject.activeInHierarchy);
        flashlight.GetComponent<Flashlight>().IsOn = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleFlashLight();
        }

        if (IsBleeding && canBleed)
        {
            canBleed = false;
            StartCoroutine(BleedRotine());
        }

        if (Input.GetKeyDown(KeyCode.R))
        { 
            UseMedKit();
        }
    }

    public void SufferDamage(int amount) 
    {
        Debug.Log("Player health: " + health);
        health -= amount;
        if (health <= 0)
        {
            AudioManager.Instance.PlayGameOverAudioClip();
            isAlive = false;
            dialog.ShowGameOver();
        }
    }

    IEnumerator BleedRotine() {
        SufferDamage(1);
        yield return new WaitForSeconds(5f);
        canBleed = true;
    }

    public void CollectItem(Item item) 
    {

        Debug.Log(GetMessageForItem(item.Type));
        dialog.ShowDialogText(GetMessageForItem(item.Type));
        items.Add(item);
    }

    string GetMessageForItem(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.Spanner:
                return "I grab a Spanner, Daddy fixed the toilet with this sometimes";
            case ItemType.Screwdriver:
                return "I grab a Screwdriver, Mommy used this to open the basement hatch when I got stuck there";
            case ItemType.Hammer:
                return "I grab a Hammer, every week Daddy says he will fix the stairs on the basement, maybe now I can do it";
            case ItemType.BasementKey:
                return "I grab the Basement Key, It's dark there and full of trash I don't like";
            case ItemType.MedKit:
                return "I grab a Med Kit, I can use it to cover my wonds (PRESS R TO HEAL YOUR WONDS)";
            case ItemType.Valve:
                return "I grab a Valve, Mommy uses this to turn off the gas, she always complains about the shower";
            default:
                return "";
        }
    }

    public void UseItem(ItemType itemType)
    {
        var item = items.Find(item => item.Type == itemType);
        if (items.Contains(item)) 
        {
            items.Remove(item);
        }
    }

    public bool HasNecessaryItem(ItemType requiredItemType) 
    {
        Item itemNeeded = Items.Find(item => item.Type == requiredItemType);
        if (itemNeeded != null)
        {
            return true;
        }

        return false;
    }

    public void UseMedKit()
    {
        if (isBleeding)
        {
            if (HasNecessaryItem(ItemType.MedKit))
            {
                UseItem(ItemType.MedKit);
                isBleeding = false;
                dialog.ShowDialogText("You stop the bleeding");
            }
            else
            {
                dialog.ShowDialogText("I need a medkit to stop the bleeding");
            }
        }
    }
}
