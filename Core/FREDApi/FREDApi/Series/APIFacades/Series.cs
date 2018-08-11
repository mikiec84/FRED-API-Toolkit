﻿using FRED.Api.Series.Arguments;
using FRED.Api.Series.Data;
using FRED.Api.Core.ApiFacades;
using FRED.Api.Core.Requests;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FRED.Api.Core.Arguments;

namespace FRED.Api.Series.ApiFacades
{
	/// <summary>
	/// Provides a facade for consuming the fred/series API endpoint. Results are returned in a SingleSeriesContainer instance.
	/// </summary>
	public class Series : ApiBase, ISeries
	{
		#region properties

		/// <summary>
		/// Argument values used in a fetch. Argument names match those in the FRED API.
		/// </summary>
		public SeriesArguments Arguments { get; set; } = new SeriesArguments();

		#endregion

		#region constructors

		public Series(IRequest request = null) : base(request)
		{
		}

		#endregion

		#region public methods

		/// <summary>
		/// Fetches data from a FRED service endpoint.
		/// </summary>
		/// <returns>
		/// A <see cref="SingleSeriesContainer"/> containing FRED data. 
		/// An abnormal fetch returns null and a message is available in the <see cref="FetchMessage"/> property.
		/// </returns>
		public new SingleSeriesContainer Fetch()
		{
			string json = base.Fetch();
			var result = JsonConvert.DeserializeObject<SingleSeriesContainer>(json);

			return result;
		}

		/// <summary>
		/// Fetches data from a FRED service endpoint asynchronously.
		/// </summary>
		/// <returns>
		/// A <see cref="SingleSeriesContainer"/> containing FRED data.
		/// An abnormal fetch returns null and a message is available in the <see cref="FetchMessage"/> property.
		/// </returns>
		public new async Task<SingleSeriesContainer> FetchAsync()
		{
			string json = await base.FetchAsync();
			var result = JsonConvert.DeserializeObject<SingleSeriesContainer>(json);

			return result;
		}

		#endregion

		#region protected methods

		protected override ArgumentsBase GetArguments()
		{
			return Arguments;
		}

		#endregion

	}

	/// <summary>
	/// Defines the interface for Series types.
	/// </summary>
	public interface ISeries : IApiBase
	{
		#region properties

		SeriesArguments Arguments { get; set; }

		#endregion

		#region public methods

		SingleSeriesContainer Fetch();

		Task<SingleSeriesContainer> FetchAsync();

		#endregion

	}

}
