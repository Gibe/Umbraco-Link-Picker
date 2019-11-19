using Umbraco.Core;

namespace Gibe.LinkPicker.Models
{
	public class LinkPicker
	{
		public int Id { get; set; }
		public string Udi { get; set; }
		public string Name { get; set; }
		public string Url { get; set; }
		public string Target { get; set; }
		public string Hashtarget { get; set; }
	}
}
