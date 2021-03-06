﻿using FRED.API.Base;
using FRED.API.Base.Data;
using System;
using System.Collections.Generic;

namespace FRED.API.Series.Data
{
	/// <summary>
	/// Provides data properties for a vintage date container, including a collection of vintage dates. 
	/// </summary>
	public class VintageDateContainer : ExtendedContainer<FREDData.vintage_date_order_by_values>
	{
		#region properties

		public List<DateTime> vintage_dates { get; set; }

		#endregion

	}
}
