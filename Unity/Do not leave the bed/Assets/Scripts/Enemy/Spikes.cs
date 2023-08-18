using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    Dialog dialog;

    void Start()
    {
        dialog = FindObjectOfType<Dialog>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            dialog.ShowDialogText("I step on something sharp, I need some bandages to stop the bleeding");
            AudioManager.Instance.PlaySpikeClip();
            Player player = other.GetComponent<Player>();
            if (!player.IsBleeding)
            {
                player.IsBleeding = true;
            }
        }
    }
}
