using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Stairs : Quest
{
    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose) 
        {
            var hammer = player.Items.Find(item => item.Type == ItemType.Hammer);
            var screwdriver = player.Items.Find(item => item.Type == ItemType.Screwdriver);
            if (hammer == null)
            {
                dialog.ShowDialogText("I need to find the hammer");
                return;
            }

            if (screwdriver == null)
            {
                dialog.ShowDialogText("I need to find the screwdriver");
                return;
            }

            player.UseItem(ItemType.Hammer);
            player.UseItem(ItemType.Screwdriver);

            AudioManager.Instance.PlayWinGameAudioClip();
            dialog.ShowWinGame();
        }
    }
}
