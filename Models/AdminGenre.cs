namespace ProjectLibrary.Models
{
    public class AdminGenre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int AdminBookId { get; set; }

        public virtual AdminBook AdminBook { get; set; }
    }
}
