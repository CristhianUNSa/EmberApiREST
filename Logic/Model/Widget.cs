using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Model
{
    public class Widget
    {
        public int id { get; set; }
        public int user { get; set; }
        public string target { get; set; }
        public string btnId { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string title { get; set; }
        public int height { get; set; }
        public int width { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public bool selected { get; set; }
    }
}
