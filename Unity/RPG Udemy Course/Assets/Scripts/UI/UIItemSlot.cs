using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class UIItemSlot : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI itemText;

    public InventoryItem item;

    public void UpdateSlot(InventoryItem item)
    {
        this.item = item;

        itemImage.color = Color.white;

        if (this.item != null)
        {
            itemImage.sprite = item.data.icon;

            if (this.item.stackSize > 1)
            {
                itemText.text = this.item.stackSize.ToString();
            }
            else
            {
                itemText.text = "";
            }
        }
    }
}
