﻿using FRED.Api.Sources.Arguments;
using FRED.Api.Sources.Data;
using FRED.Api.Core.ApiFacades;
using FRED.Api.Core.Requests;
using System.Threading.Tasks;
using FRED.Api.Core.Arguments;
using Newtonsoft.Json;

namespace FRED.Api.Sources.ApiFacades
{
	/// <summary>
	/// Provides a facade for consuming the fred/source API endpoint. Results are returned in a SourceContainer instance.
	/// </summary>
	public class Source : ApiBase, ISource
	{
		#region properties

		/// <summary>
		/// Argument values used in a fetch. Argument names match those in the FRED API.
		/// </summary>
		public SourceArguments Arguments { get; set; } = new SourceArguments();

		#endregion

		#region constructors

		public Source(IRequest request = null) : base(request)
		{
		}

		#endregion

		#region public methods

		/// <summary>
		/// Fetches data from a FRED service endpoint.
		/// </summary>
		/// <returns>
		/// A <see cref="SourceContainer"/> containing FRED data. 
		/// An abnormal fetch returns null and a message is available in the <see cref="FetchMessage"/> property.
		/// </returns>
		public new SourceContainer Fetch()
		{
			string json = base.Fetch();
			var result = JsonConvert.DeserializeObject<SourceContainer>(json);

			return result;
		}

		/// <summary>
		/// Fetches data from a FRED service endpoint asynchronously.
		/// </summary>
		/// <returns>
		/// A <see cref="SourceContainer"/> containing FRED data.
		/// An abnormal fetch returns null and a message is available in the <see cref="FetchMessage"/> property.
		/// </returns>
		public new async Task<SourceContainer> FetchAsync()
		{
			string json = await base.FetchAsync();
			var result = JsonConvert.DeserializeObject<SourceContainer>(json);

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
	/// Defines the interface for Source types.
	/// </summary>
	public interface ISource : IApiBase
	{
		#region properties

		SourceArguments Arguments { get; set; }

		#endregion

		#region public methods

		SourceContainer Fetch();

		Task<SourceContainer> FetchAsync();

		#endregion

	}

}
