﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Equipment : Item {
	private bool isEquipped;
	public int tier;
	public Equipment (int tier, GameObject inventorySlotObject) : base (inventorySlotObject)
	{
		this.tier = tier;


	}

}
