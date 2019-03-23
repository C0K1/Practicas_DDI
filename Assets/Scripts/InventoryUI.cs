using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour 
{
	public GameObject inventoryPanel;
	private Inventory inventory;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		inventory = FindObjectOfType<Inventory>();
		if (inventory == null)
		{
			Debug.LogWarning("No se encontró el Inventario");
			return;
		} 
		inventoryPanel.SetActive(false);
		inventory.onItemChange += UpdateUI;
	}

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Q))
		{
			Debug.Log("UI Off");
			inventoryPanel.SetActive(!inventoryPanel.activeSelf);
		}
	}

	void UpdateUI()
	{
		Slot[] slots = GetComponentsInChildren<Slot>();
		for (int i = 0; i < slots.Length; i++)
		{
			if(i < inventory.items.Count)
			{
				slots[i].AddItem(inventory.items[i]);
			}
			else
			{
				slots[i].ClearSlot();
			}
		}
	}
}
