﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Xsolla.Payments.Api.Playfab.Catalog
{
	[Serializable]
	public class CatalogItemEntity
	{
		public const string REAL_MONEY_CURRENCY = "RM";

		[Serializable]
		public class ConsumableOptions
		{
			public uint? UsageCount;
			public uint? UsagePeriod;
		}

		[Serializable]
		public class BundleSettings
		{
			public Dictionary<string, uint> BundledVirtualCurrencies;
		}

		[Flags]
		public enum ItemGroups
		{
			None = 0,
			All = 1,
			Premium = 2,
			PowerUps = 4,
			Currency = 8
		}

		public string ItemId;
		public string DisplayName;
		public string Description;
		public string ItemImageUrl;
		public bool IsStackable;

		public Dictionary<string, uint> VirtualCurrencyPrices;
		public ConsumableOptions Consumable;
		public BundleSettings Bundle;

		public bool IsVirtualCurrency() => Bundle?.BundledVirtualCurrencies != null;
		public bool IsConsumable() => Consumable?.UsageCount != null;

		public KeyValuePair<string, uint>? GetVirtualPrice()
		{
			var prices = VirtualCurrencyPrices.Where(pair => !pair.Key.Equals(REAL_MONEY_CURRENCY)).ToList();
			if (!prices.Any()) return null;
			return prices.Any() ? prices.First() : (KeyValuePair<string, uint>?) null;
		}

		public KeyValuePair<string, float>? GetRealPrice()
		{
			if (!VirtualCurrencyPrices.ContainsKey(REAL_MONEY_CURRENCY)) return null;
			float amount = VirtualCurrencyPrices[REAL_MONEY_CURRENCY] / 100.0F;
			return new KeyValuePair<string, float>("USD", amount);
		}

		public string GetVirtualCurrencySku() => IsVirtualCurrency()
			? Bundle.BundledVirtualCurrencies.First().Key
			: string.Empty;

		public uint GetVirtualCurrencyAmount() => IsVirtualCurrency()
			? Bundle.BundledVirtualCurrencies.First().Value
			: 0;
	}
}