using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BooksWpfApp
{
    public class Titles
    {
        [Key]
        public string ISBN { get; set; }

        public string Title { get; set; }
        
        public int EditionNumber { get; set; }
        
        public string Copyright { get; set; }
    }
}
