using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text palyerGemsText;
    public Image selectionImage;
    public Text gemCountText;
    public Image[] healthImages;

    private static UIManager _instance;
    public static UIManager Instance 
    {
        get 
        {
            if (_instance == null)
            {
                Debug.Log("UIManager is null");
            }

            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }

    public void OpenShop(int gemCount) 
    {
        palyerGemsText.text = gemCount + "G";
    }

    public void UpdateShopSelection(int yPos)
    { 
        selectionImage.rectTransform.anchoredPosition = new Vector2(selectionImage.rectTransform.anchoredPosition.x, yPos);
    }

    public void UpdateGemCount(int gems)
    {
        gemCountText.text = gems.ToString();
    }

    public void UpdateHealth(int currentHealth)
    {
        for(int health = 0; health <= currentHealth; health++) 
        {
            if (health == currentHealth) 
            {
                healthImages[health].enabled = false;
            }
        }

    }
}
