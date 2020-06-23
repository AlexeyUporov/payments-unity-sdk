﻿using System.Text;
using JetBrains.Annotations;
using Xsolla.Core;
using Xsolla.PayStation.Api.Playfab.Auth;
using Xsolla.PayStation.Api.Playfab.Catalog;
using Xsolla.PayStation.Api.Playfab.Inventory;
using Xsolla.PayStation.Api.Playfab.Purchases;

namespace Xsolla.PayStation.Api.Playfab
{
	[PublicAPI]
	public class PlayfabApi : MonoSingleton<PlayfabApi>
	{
		public AuthToken Token { get; set; }

		public static PlayfabAuth Auth = new PlayfabAuth();
		public static PlayfabCatalog Catalog = new PlayfabCatalog();
		public static PlayfabInventory Inventory = new PlayfabInventory();
		public static PlayfabPurchases Purchases = new PlayfabPurchases();

		public override void Init()
		{
			base.Init();
			Token = null;
		}

		public WebRequestHeader GetAuthHeader()
		{
			return !(Token is AuthToken.Playfab token)
				? null
				: new WebRequestHeader {Name = "X-Authentication", Value = token.SessionTicket};
		}

		public static string GetFormattedUrl(string urlTemplate)
		{
			var urlBuilder = new StringBuilder(string.Format(urlTemplate, XsollaSettings.PlayfabTitleId));
			return urlBuilder.ToString();
		}
	}
}