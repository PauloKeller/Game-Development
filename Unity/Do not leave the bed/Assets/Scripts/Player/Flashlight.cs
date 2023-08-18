using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField]
    float totalBattery = 100;
    [SerializeField]
    float batteryAmountPerSeconds = 1.5f;
    [SerializeField]
    float currentBattery = 100;

    bool isConsumingBattery = false;
    bool isOn = false;

    public bool IsOn 
    {
        get 
        {
            return isOn;
        }
        set 
        {
            currentBattery -= 1f;
            isConsumingBattery = value;
            isOn = value;
        }
    }
    float CurrentBattery 
    {
        get 
        {
            return currentBattery;
        }

        set 
        {
            currentBattery = value;
        }
    }
    
    void Update()
    {
        if (isOn && isConsumingBattery)
        {
            isConsumingBattery = false;
            StartCoroutine(BatteryRoutine());
        }
    }

    IEnumerator BatteryRoutine() 
    {
        Debug.Log("Current battery: " + currentBattery);
        yield return new WaitForSeconds(5f);
        currentBattery -= batteryAmountPerSeconds;
        isConsumingBattery = true;
    }
}
