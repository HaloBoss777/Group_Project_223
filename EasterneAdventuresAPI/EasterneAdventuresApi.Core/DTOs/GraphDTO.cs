using System;
using System.Collections.Generic;
using System.Text;

namespace EasterneAdventuresApi.Core.DTOs
{
    public class GraphDTO
    {
        public List<string> Labels { get; set; }
        public List<decimal> Values { get; set; }
        public List<string> BackgroundColor { get; set; }
    }

    public class PopularActivitiesDTO
    {
        public string Name { get; set; }
        public int Attending { get; set; }
    }
}
