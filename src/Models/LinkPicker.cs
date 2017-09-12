using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkPicker.Umbraco.Models
{
    public class LinkPicker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Target { get; set; }
        public string Hashtarget { get; set; }
    }
}
