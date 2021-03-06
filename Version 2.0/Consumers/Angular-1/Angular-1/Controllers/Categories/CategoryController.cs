﻿using AngularConsumer1.Configuration.Interfaces;
using AngularConsumer1.Models.Categories;
using FRED.Api.Categories.ApiFacades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace AngularConsumer1.Controllers.Categories
{
	[Route("api/[controller]")]
	public class CategoryController : ControllerBase
	{
		#region fields

		private readonly ICategory api;
		private readonly IAppSettings appSettings;
		private readonly ILogger<CategoryController> logger;

		#endregion

		#region constructors

		public CategoryController(
			ICategory api,
			IAppSettings appSettings,
			ILogger<CategoryController> logger) : base()
		{
			this.api = api;
			this.appSettings = appSettings;
			this.logger = logger;
		}

		#endregion

		#region public methods

		[Produces("application/json")]
		[ProducesResponseType(200, Type = typeof(string))]
		[ProducesResponseType(500, Type = typeof(string))]
		[HttpGet("{id}")]
		public async Task<IActionResult> GetAsync(int id)
		{
			CategoryResponse result = new CategoryResponse();

			try
			{
				api.Arguments.ApiKey = appSettings.ApiKey;
				api.Arguments.category_id = id;

				result.container = await api.FetchAsync();

				SetApiValues(api, result);
			}
			catch (Exception exception)
			{
				logger.LogError(exception, "GetCategory failed");
				return StatusCode(500);
			}

			return Ok(result);
		}

		#endregion

	}

}