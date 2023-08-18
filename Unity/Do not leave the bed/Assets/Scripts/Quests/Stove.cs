using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : Quest
{
    bool hasLoot = true;

    override public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose && hasLoot)
        {
            if (player != null)
            {
                if (player.TurnedGasOff)
                {
                    AudioManager.Instance.PlayInteractionAudioClip();
                    hasLoot = false;
                    Item item = new Item(givenItemType);
                    player.CollectItem(item);
                }
                else
                {
                    dialog.ShowDialogText("This can kill me, I need to find a way to turn off the gas");
                }
            }
        }
    }
}
