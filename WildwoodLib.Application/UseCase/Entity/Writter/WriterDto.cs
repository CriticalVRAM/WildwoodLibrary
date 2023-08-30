namespace WildwoodLib.Application.UseCase.Entity.Writter
{
    public class WriterDto
    {
        public required int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? CountryOfBirth { get; set; }
    }
    public class CreateWriterDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? CountryOfBirth { get; set; }
    }
}
