﻿using System;

namespace Xsolla.PayStation.Api.Playfab.Auth
{
	[Serializable]
	public class
		PlayfabUserRegistrationResponseEntity : PlayfabResponseEntity<PlayfabUserRegistrationResponseEntity.Payload>
	{
		[Serializable]
		public class Payload
		{
			[Serializable]
			public class EntityTokenField
			{
				public string TokenExpiration;
			}

			public string SessionTicket;
			public EntityTokenField EntityToken;
		}

		public string SessionTicket => data.SessionTicket;
		public string TokenExpiration => data.EntityToken.TokenExpiration;
	}
}