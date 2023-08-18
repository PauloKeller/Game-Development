using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hydraulics : Quest
{
    bool canTurnGasOff = true;
    override public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose && canTurnGasOff)
        {
            if (player != null)
            {
                var itemNeeded = player.Items.Find(item => item.Type == requiredItemType);
                if (itemNeeded != null)
                {
                    AudioManager.Instance.PlayInteractionAudioClip();
                    player.UseItem(requiredItemType);
                    player.TurnedGasOff = true;
                    canTurnGasOff = false;
                    dialog.ShowDialogText("I turned off the gas!");
                }
                else
                {
                    Debug.Log("Required item message");
                    dialog.ShowDialogText("I need to find the Valve");
                }
            }
        }
    }
}
