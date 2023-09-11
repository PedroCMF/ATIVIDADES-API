namespace Chapter.Models
{
    public class Usuario //Por ultimo a _context comunica com o BD
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Tipo { get; set; }
    }
}
