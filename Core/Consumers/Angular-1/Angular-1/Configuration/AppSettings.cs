﻿using FRED.Api.Configuration.Interfaces;
using Microsoft.Extensions.Configuration;

namespace FRED.Api.Configuration
{
	public class AppSettings : IAppSettings
	{
		#region fields

		private static string sectionNameLiteral = "Credentials";
		private static string apiKey = "ApiKey";

		#endregion

		#region properties 

		public string ApiKey { get; private set; }

		#endregion

		#region constructors

		public AppSettings(IConfiguration configuration)
		{
			ApiKey = configuration[$"{sectionNameLiteral}:{apiKey}"];
		}

		#endregion

	}
}
