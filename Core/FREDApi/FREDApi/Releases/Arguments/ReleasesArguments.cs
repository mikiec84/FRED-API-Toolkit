﻿using FRED.Api.Core;
using FRED.Api.Core.Arguments;
using System;

namespace FRED.Api.Releases.Arguments
{
	/// <summary>
	/// Provides argument properties for the Releases API facade.
	/// </summary>
	public class ReleasesArguments : ArgumentsBase
	{
		#region properties

		public DateTime? realtime_start { get; set; }
		public DateTime? realtime_end { get; set; }
		public int? limit { get; set; }
		public int? offset { get; set; }
		public FREDData.releases_order_by_values order_by { get; set; }
		public FREDData.sort_order_values sort_order { get; set; }

		internal override string UrlExtension
		{
			get { return "releases"; }
		}

		#endregion

	}
}
