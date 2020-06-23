﻿using System;

namespace Xsolla.PayStation.Api.Playfab.Auth
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