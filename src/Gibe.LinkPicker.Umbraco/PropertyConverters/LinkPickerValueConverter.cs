using System;
using Newtonsoft.Json;
using Umbraco.Core;
using Umbraco.Core.Logging;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.PropertyEditors;
using Umbraco.Web;

namespace Gibe.LinkPicker.PropertyConverters
{
	public class LinkPickerValueConverter : PropertyValueConverterBase
	{
		/// <summary>
		/// Method to see if the current property type is of type
		/// LinkPicker editor.
		/// </summary>
		/// <param name="propertyType">The current property type.</param>
		/// <returns>True if the current property type of type LinkPicker editor.</returns>
		public override bool IsConverter(IPublishedPropertyType propertyType)
				=> propertyType.EditorAlias.InvariantEquals("Gibe.LinkPicker");

		/// <inheritdoc />
		public override Type GetPropertyValueType(IPublishedPropertyType propertyType)
				=> typeof(Models.LinkPicker);

		/// <inheritdoc />
		public override PropertyCacheLevel GetPropertyCacheLevel(IPublishedPropertyType propertyType)
				=> PropertyCacheLevel.Element;

		/// <summary>
		/// Method to convert a property value to an instance of the LinkPicker class.
		/// </summary>
		/// <param name="owner"></param>
		/// <param name="propertyType">The current published property
		/// type to convert.</param>
		/// <param name="source">The original property data.</param>
		/// <param name="preview">True if in preview mode.</param>
		/// <returns>An instance of the LinkPicker class.</returns>
		public override object ConvertSourceToIntermediate(IPublishedElement owner, IPublishedPropertyType propertyType, object source, bool preview)
		{
			if (source == null)
				return null;
			
			var sourceString = Convert.ToString(source);

			var umbracoHelper = Umbraco.Web.Composing.Current.UmbracoHelper;

			try
			{
				var linkPicker = JsonConvert.DeserializeObject<Models.LinkPicker>(sourceString);
				if (linkPicker.Id > 0 || !string.IsNullOrWhiteSpace(linkPicker.Udi))
				{
					var content =
							linkPicker.Udi != null
									? umbracoHelper.Content(Udi.Parse(linkPicker.Udi))
									: umbracoHelper.Content(linkPicker.Id);

					linkPicker.Url = content?.Url ?? linkPicker.Url;
				}

				return linkPicker;
			}
			catch (Exception ex)
			{
				Umbraco.Core.Composing.Current.Logger.Error<LinkPickerValueConverter>(ex.Message, ex);
				return null;
			}
		}
	}
}
