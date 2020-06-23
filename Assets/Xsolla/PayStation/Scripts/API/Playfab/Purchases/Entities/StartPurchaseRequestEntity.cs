﻿using System;
using System.Collections.Generic;

namespace Xsolla.PayStation.Api.Playfab.Purchases
{
	[Serializable]
	public class StartPurchaseRequestEntity
	{
		public class StartPurchaseRequestItem
		{
			public string ItemId;
			public uint Quantity;
		}

		public List<StartPurchaseRequestItem> Items;

		public StartPurchaseRequestEntity(string itemId, uint quantity)
		{
			Items = new List<StartPurchaseRequestItem>
			{
				new StartPurchaseRequestItem
				{
					ItemId = itemId,
					Quantity = quantity
				}
			};
		}
	}
}