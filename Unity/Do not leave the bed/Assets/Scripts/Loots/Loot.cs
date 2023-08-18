using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Loot : MonoBehaviour
{
    [SerializeField]
    protected ItemType itemType;
    [SerializeField]
    protected string warningMessage;
    [SerializeField]
    protected bool hasItem = true;
    protected bool playerIsClose = false;
    protected Player player;
    protected Dialog dialog;

    void Start()
    {
        dialog = FindObjectOfType<Dialog>();
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if (hasItem)
            {
                hasItem = false;
                var item = new Item(itemType);

                if (player != null)
                {
                    AudioManager.Instance.PlayInteractionAudioClip();
                    player.CollectItem(item);
                }
            }
            else
            {
                dialog.ShowDialogText(warningMessage);   
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerIsClose = true;
            player = other.GetComponent<Player>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerIsClose = false;
    }
}
