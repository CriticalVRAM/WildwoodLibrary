using WildwoodLib.Domain.Entites;

namespace WildwoodLib.API.Core
{
    public class JwtUser : IAppUser
    {
        public required string Identity { get; set; }

        public required int Id { get; set; }

        public required IEnumerable<int> UseCaseIds { get; set; }
    }
    public class AnonimousUser : IAppUser
    {
        public string Identity => "Anonymous";

        public int Id => 0;

        public IEnumerable<int> UseCaseIds => new List<int> { 2, 13, 50 }; // search books, category and writer, register, seeddata
    }
}
