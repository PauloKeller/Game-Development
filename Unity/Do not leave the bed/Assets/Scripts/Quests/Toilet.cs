using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toilet : Quest
{
    bool hasLoot = true;

    override public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose && hasLoot)
        {
            var itemNeeded = player.Items.Find(item => item.Type == requiredItemType);
            if (itemNeeded != null)
            {
                AudioManager.Instance.PlayInteractionAudioClip();
                player.UseItem(requiredItemType);
                Item item = new Item(givenItemType);
                player.CollectItem(item);
                hasLoot = false;
            }
            else
            {
                ShowRequiredItemMessage();
            }
        }
    }
}
