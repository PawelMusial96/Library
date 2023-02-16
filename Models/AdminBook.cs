using System.ComponentModel.DataAnnotations;

namespace ProjectLibrary.Models
{
    public class AdminBook
    {
        
        public int Id { get; set; }
        public string Tytul { get; set; }
        public int AdminAuthorID { get; set; }

        public virtual AdminAuthor AdminAuthor { get; set; }

        public int GenreID { get; set; }

        public string Opis { get; set; }

        public DateTime Date { get; set; }
    }
}
