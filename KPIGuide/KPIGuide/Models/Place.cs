using System;
using System.Collections.Generic;
using System.Text;

namespace KPIGuide.Models
{
    public class Place
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> ImagePath { get; set; }
        public List<string> Addresses { get; set; }
    }
}
