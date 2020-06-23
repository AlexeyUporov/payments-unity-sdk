﻿using System;
using System.Collections.Generic;

namespace Xsolla.ThirdParty.Playfab.Api.Inventory
{
	[Serializable]
	public class UserInventoryEntity
	{
		public List<InventoryItem> Inventory;
		public Dictionary<string, uint> VirtualCurrency;
	}
}