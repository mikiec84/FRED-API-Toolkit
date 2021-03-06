﻿using FRED.Api.Series.Arguments;
using FRED.Api.Series.Data;
using FRED.Api.Core.ApiFacades;
using FRED.Api.Core.Requests;
using System.Threading.Tasks;
using FRED.Api.Core.Arguments;
using Newtonsoft.Json;

namespace FRED.Api.Series.ApiFacades
{
	/// <summary>
	/// Provides a facade for consuming the fred/series/search API endpoint. Results are returned in a SeriesSearchContainer instance.
	/// </summary>
	public class SeriesSearch : ApiBase, ISeriesSearch
	{
		#region properties

		/// <summary>
		/// Argument values used in a fetch. Argument names match those in the FRED API.
		/// </summary>
		public SeriesSearchArguments Arguments { get; set; } = new SeriesSearchArguments();

		#endregion

		#region constructors

		public SeriesSearch(IRequest request = null) : base(request)
		{
		}

		#endregion

		#region public methods

		/// <summary>
		/// Fetches data from a FRED service endpoint.
		/// </summary>
		/// <returns>
		/// A <see cref="SeriesSearchContainer"/> containing FRED data. 
		/// An abnormal fetch returns null and a message is available in the <see cref="FetchMessage"/> property.
		/// </returns>
		public SeriesSearchContainer Fetch()
		{
			SeriesSearchContainer result = base.Fetch<SeriesSearchContainer>();

			return result;
		}

		/// <summary>
		/// Fetches data from a FRED service endpoint asynchronously.
		/// </summary>
		/// <returns>
		/// A <see cref="SeriesSearchContainer"/> containing FRED data.
		/// An abnormal fetch returns null and a message is available in the <see cref="FetchMessage"/> property.
		/// </returns>
		public async Task<SeriesSearchContainer> FetchAsync()
		{
			SeriesSearchContainer result = await base.FetchAsync<SeriesSearchContainer>();

			return result;
		}

		/// <summary>
		/// Returns the arguments for the instance.
		/// </summary>
		/// <returns>The arguments for the instance.</returns>
		public override ArgumentsBase GetArguments()
		{
			return Arguments;
		}

		#endregion

	}

	/// <summary>
	/// Defines the interface for SeriesSearch types.
	/// </summary>
	public interface ISeriesSearch : IApiBase
	{
		#region properties

		SeriesSearchArguments Arguments { get; set; }

		#endregion

		#region public methods

		SeriesSearchContainer Fetch();

		Task<SeriesSearchContainer> FetchAsync();

		#endregion

	}

}