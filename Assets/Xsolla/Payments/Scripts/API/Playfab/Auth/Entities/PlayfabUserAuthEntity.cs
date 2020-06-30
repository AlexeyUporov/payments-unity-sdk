﻿using System;

namespace Xsolla.Payments.Api.Playfab.Auth
{
	[Serializable]
	public class PlayfabUserAuthEntity
	{
		public string Username;
		public string Password;
		public string TitleId;

		public PlayfabUserAuthEntity(string userName, string password, string titleId)
		{
			Username = userName;
			Password = password;
			TitleId = titleId;
		}
	}
}