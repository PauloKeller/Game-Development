using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasementDoor : MonoBehaviour
{
    [SerializeField]
    Vector3 positionToGo;
    [SerializeField]
    ItemType requiredItemType;
    Player player;
    bool playerIsClose = false;
    bool isOpen = false;
    Dialog dialog;

    void Start()
    {
        dialog = FindObjectOfType<Dialog>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerIsClose = true;
            player = other.GetComponent<Player>();
            
            if (!isOpen)
            {
                if (playerIsClose && player.HasNecessaryItem(requiredItemType))
                {
                    UnlockDoor();
                }
                else 
                {
                    dialog.ShowDialogText("I need the Basement Key to open, I let the key on my safe place!");
                }
            }
            else
            {
                EnterDoor();
            }  
        }
    }

    void UnlockDoor() 
    {
        isOpen = true;
        EnterDoor();
    }

    void EnterDoor()
    {
        player.transform.position = positionToGo;
    }
}
