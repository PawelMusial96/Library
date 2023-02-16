namespace ProjectLibrary.Models
{
    public class AdminAuthor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual AdminBook AdminBook { get; set; }
    }
}
