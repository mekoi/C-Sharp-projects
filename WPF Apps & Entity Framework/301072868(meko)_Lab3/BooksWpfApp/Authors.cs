using System.ComponentModel.DataAnnotations;

namespace BooksWpfApp
{
    public class Authors
    {
        [Key]
        public int AuthorID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
