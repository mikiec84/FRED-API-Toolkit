﻿using FRED.API.Tags.Arguments;

namespace FRED.API.Categories.Arguments
{
	/// <summary>
	/// Provides argument properties for the CategoryTags API facade.
	/// </summary>
	public class CategoryTagsArguments : TagsArguments
	{
		#region properties

		public int category_id { get; set; }

		internal override string UrlExtension
		{
			get { return "category/tags"; }
		}

		#endregion

	}
}
