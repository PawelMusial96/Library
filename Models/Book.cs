using System.ComponentModel.DataAnnotations;

namespace ProjectLibrary.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Tytul { get; set; }
        public string Autor { get; set; }
        public string Opis { get; set; }
    }

}
