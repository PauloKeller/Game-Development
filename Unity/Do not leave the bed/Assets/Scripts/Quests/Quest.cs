using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Quest : MonoBehaviour
{
    [SerializeField]
    protected ItemType requiredItemType;
    [SerializeField]
    protected ItemType givenItemType;
    protected bool playerIsClose = false;
    protected Player player;
    protected Dialog dialog;
    protected virtual void Start()
    {
        dialog = FindObjectOfType<Dialog>();
    }

    public virtual void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerIsClose = true;
            player = other.GetComponent<Player>();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        playerIsClose = false;
    }

    protected void ShowRequiredItemMessage()
    {
        dialog.ShowDialogText("I need the " + requiredItemType);
    }
}
