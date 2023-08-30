namespace WildwoodLib.Application.UseCase.Entity.Book
{
    public class BookDto
    {
        public required int BookId { get; set; }
        public required string Title { get; set; }
        public required int Quantity { get; set; }
        public required string Writer { get; set; }
        public required string Category { get; set; }
    }
    public class BookSearchDto : PagedSearch
    {
        public string? TitleKeyword { get; set; }
        public string? WriterKeyword { get; set; }
        public string? CategoryKeyword { get; set; }
    }
    public class CreateBookDto
    {
        public required string Title { get; set; }
        public required int Quantity { get; set; }
        public required int WriterId { get; set; }
        public required int CategoryId { get; set; }
    }
    public class UpdateBookDto : CreateBookDto
    {
        public required int Id { get; set; }
    }
}
