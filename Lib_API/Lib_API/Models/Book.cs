namespace Lib_API.Models;

public class Book
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public int AuthorId { get; set; }
    public int GenreId { get; set; }
    public int PublishYear { get; set; }
    public bool Available { get; set; }

    public Author Author { get; set; }
    public Genre Genre { get; set; }
    public ICollection<Loan> Loans { get; set; }
}

