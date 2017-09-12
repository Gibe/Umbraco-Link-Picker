using System;
using Umbraco.Core.PropertyEditors;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Newtonsoft.Json;
using Umbraco.Core.Logging;

namespace LinkPicker.Umbraco.PropertyConverters
{
    [PropertyValueType(typeof(Models.LinkPicker))]
    [PropertyValueCache(PropertyCacheValue.All, PropertyCacheLevel.Content)]
    public class LinkPickerValueConverter : PropertyValueConverterBase
    {
        /// <summary>
        /// Method to see if the current property type is of type
        /// LinkPicker editor.
        /// </summary>
        /// <param name="propertyType">The current property type.</param>
        /// <returns>True if the current property type of type LinkPicker editor.</returns>
        public override bool IsConverter(PublishedPropertyType propertyType)
        {
            return propertyType.PropertyEditorAlias.Equals("Gibe.LinkPicker");
        }

        /// <summary>
        /// Method to convert a property value to an instance of the LinkPicker class.
        /// </summary>
        /// <param name="propertyType">The current published property
        /// type to convert.</param>
        /// <param name="source">The original property data.</param>
        /// <param name="preview">True if in preview mode.</param>
        /// <returns>An instance of the LinkPicker class.</returns>
        public override object ConvertSourceToObject(PublishedPropertyType propertyType, object source, bool preview)
        {
            if (source == null)
                return null;

            if (UmbracoContext.Current == null)
                return null;

            var sourceString = source.ToString();

            try
            {
                var linkPicker = JsonConvert.DeserializeObject<Models.LinkPicker>(sourceString);

                return linkPicker;
            }
            catch (Exception ex)
            {
                LogHelper.Error<LinkPickerValueConverter>(ex.Message, ex);

                return null;
            }
        }
    }
}
