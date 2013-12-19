using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal class Day
    {
        public DayOfWeek DayofWeek { get; set; }
        public Frequency DayFrequancy { get; set; }

        internal Day(DayOfWeek day, Frequency freq)
        {
            DayofWeek = day;
            DayFrequancy = freq;
        }

        public Day()
        {
            // TODO: Complete member initialization
        }
    }
}
