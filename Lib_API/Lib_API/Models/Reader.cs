namespace Lib_API.Models
{
    public class Reader
    {
        public int ReaderId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public ICollection<Loan> Loans { get; set; }
    }
}
