﻿using FRED.Api.Series.Arguments;
using FRED.Api.Core.ApiFacades;
using FRED.Api.Tags.Data;
using FRED.Api.Core.Requests;
using Newtonsoft.Json;
using FRED.Api.Core.Arguments;
using System.Threading.Tasks;

namespace FRED.Api.Series.ApiFacades
{
	/// <summary>
	/// Provides a facade for consuming the fred/series/search/tags API endpoint. Results are returned in a TagContainer instance.
	/// </summary>
	public class SeriesSearchTags : ApiBase, ISeriesSearchTags
	{
		#region properties

		/// <summary>
		/// Argument values used in a fetch. Argument names match those in the FRED API.
		/// </summary>
		public SeriesSearchTagsArguments Arguments { get; set; } = new SeriesSearchTagsArguments();

		#endregion

		#region constructors

		public SeriesSearchTags(IRequest request = null) : base(request)
		{
		}

		#endregion

		#region public methods

		/// <summary>
		/// Fetches data from a FRED service endpoint.
		/// </summary>
		/// <returns>
		/// A <see cref="TagContainer"/> containing FRED data. 
		/// An abnormal fetch returns null and a message is available in the <see cref="FetchMessage"/> property.
		/// </returns>
		public TagContainer Fetch()
		{
			TagContainer result = base.Fetch<TagContainer>();

			return result;
		}

		/// <summary>
		/// Fetches data from a FRED service endpoint asynchronously.
		/// </summary>
		/// <returns>
		/// A <see cref="TagContainer"/> containing FRED data.
		/// An abnormal fetch returns null and a message is available in the <see cref="FetchMessage"/> property.
		/// </returns>
		public async Task<TagContainer> FetchAsync()
		{
			TagContainer result = await base.FetchAsync<TagContainer>();

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
	/// Defines the interface for SeriesSearchTags types.
	/// </summary>
	public interface ISeriesSearchTags : IApiBase
	{
		#region properties

		SeriesSearchTagsArguments Arguments { get; set; }

		#endregion

		#region public methods

		TagContainer Fetch();

		Task<TagContainer> FetchAsync();

		#endregion

	}

}
