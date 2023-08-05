using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopPanel;
    private int _selectedItem = 1;
    private int _itemCost = 200;
    private Player _player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        { 
            _player = other.GetComponent<Player>();
            if (_player != null)
            {
                UIManager.Instance.OpenShop(_player.diamonds);
            }
            shopPanel.SetActive(true);
        }   
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shopPanel.SetActive(false);
        }
    }

    public void SelectItem(int item)
    {
        _selectedItem = item;
        switch (item)
        {
            case 0:
                UIManager.Instance.UpdateShopSelection(100);
                _itemCost = 200;
                break;
            case 1:
                UIManager.Instance.UpdateShopSelection(-6);
                _itemCost = 400;
                break;
            case 2:
                UIManager.Instance.UpdateShopSelection(-107);
                _itemCost = 1000;
                break;
        }
    }

    public void BuyItem()
    {
        if (_player.diamonds >= _itemCost)
        {
            switch (_selectedItem)
            {
                case 0:
                    Debug.Log("Item not implemented yet");
                    break;
                case 1:
                    Debug.Log("Item not implemented yet");
                    break;
                case 2:
                    GameManager.Instance.HasKeyToCastle = true;
                    break;
            }

            _player.diamonds -= _itemCost;
            shopPanel.SetActive(false);
        }
        else 
        {
            shopPanel.SetActive(false);
        }
    }
}
