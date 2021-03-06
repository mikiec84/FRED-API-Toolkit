﻿using FRED.Api.Core.Arguments;
using System;

namespace FRED.Api.Sources.Arguments
{
	/// <summary>
	/// Provides argument properties for the Source API facade.
	/// </summary>
	public class SourceArguments : ArgumentsBase
	{
		#region properties

		public int source_id { get; set; }
		public DateTime? realtime_start { get; set; }
		public DateTime? realtime_end { get; set; }

		internal override string UrlExtension
		{
			get { return "source"; }
		}

		#endregion

	}
}
