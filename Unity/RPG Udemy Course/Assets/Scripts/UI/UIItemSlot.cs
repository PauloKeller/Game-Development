using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIItemSlot : MonoBehaviour, IPointerDownHandler
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

    public void CleanUpSlot()
    {
        item = null;

        itemImage.sprite = null;
        itemImage.color = Color.clear;

        itemText.text = "";
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (item.data.itemType == ItemType.Equipment)
            Inventory.instance.EquipItem(item.data);
    }
}
