﻿using FRED.Api.Releases.Arguments;
using FRED.Api.Core.ApiFacades;
using FRED.Api.Tags.Data;
using FRED.Api.Core.Requests;
using Newtonsoft.Json;
using System.Threading.Tasks;
using FRED.Api.Core.Arguments;

namespace FRED.Api.Releases.ApiFacades
{
	/// <summary>
	/// Provides a facade for consuming the fred/release/related_tags API endpoint. Results are returned in a TagContainer instance.
	/// </summary>
	public class ReleaseRelatedTags : ApiBase, IReleaseRelatedTags
	{
		#region properties

		/// <summary>
		/// Argument values used in a fetch. Argument names match those in the FRED API.
		/// </summary>
		public ReleaseRelatedTagsArguments Arguments { get; set; } = new ReleaseRelatedTagsArguments();

		#endregion

		#region constructors

		public ReleaseRelatedTags(IRequest request = null) : base(request)
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
	/// Defines the interface for ReleaseRelatedTags types.
	/// </summary>
	public interface IReleaseRelatedTags : IApiBase
	{
		#region properties

		ReleaseRelatedTagsArguments Arguments { get; set; }

		#endregion

		#region public methods

		TagContainer Fetch();

		Task<TagContainer> FetchAsync();

		#endregion

	}

}
