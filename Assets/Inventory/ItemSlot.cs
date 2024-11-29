using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Inventory inventory;
    public Item itemInSlot = null;
    public Image buttonImage;
    public TextMeshProUGUI itemText;

    private void OnValidate()
    {
        Refresh();
    }

    /// <summary>
    /// Updates image displayed, and if you can click the button
    /// </summary>
    public void Refresh()
    {
        if(itemInSlot != null)
        {
            buttonImage.sprite = itemInSlot.sprite;
            itemText.text = itemInSlot.name;
            buttonImage.gameObject.SetActive(true);
        } else
        {
            buttonImage.sprite = null;
            itemText.text = "";
            buttonImage.gameObject.SetActive(false);
        }
    }

    public void Update()
    {
        Refresh();
    }

    public void UseItemInSlot()
    {
        if (itemInSlot != null)
        {
            itemInSlot.Use(inventory.owner, inventory.owner);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (itemInSlot != null)
        {
           inventory.itemDescription.text = itemInSlot.name + "\n" + itemInSlot.description;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (itemInSlot != null)
        {
            inventory.itemDescription.text = "";
        }
    }
}
