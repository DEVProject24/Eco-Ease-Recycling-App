using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco_Ease_Recycling.Models
{
    public class RecyclingActivityModel
    {
        public string Date {  get; set; }
        public string Materials { get; set; }

        public double MoneyEarned { get; set; }
        public string UserId { get; set; }
        public double Weight { get; set; }

        
    }
}
