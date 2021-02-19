using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaseballWpfApp
{
    public class Players
    {
        [Key]
        public int PlayerID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal BattingAverage { get; set; }
    }
}
