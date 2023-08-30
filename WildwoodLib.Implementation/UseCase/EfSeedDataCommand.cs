using WildwoddLib.DataAccess;
using WildwoodLib.Application.UseCase;

namespace WildwoodLib.Implementation.UseCase
{
    public class EfSeedDataCommand : UseCaseContext, ISeedDataCommand
    {
        public EfSeedDataCommand(WildwoodLibContext context) : base(context)
        {
        }

        public int Id => 50;

        public void Execute(int request)
        {
            if (Context.Users.Any() || Context.Books.Any()) throw new Exception();

            var categories = new List<Domain.Entites.Category>
            {
                new Domain.Entites.Category { Name = "Classic" },
                new Domain.Entites.Category { Name = "Romance" },
                new Domain.Entites.Category { Name = "Sci-Fi" },
                new Domain.Entites.Category { Name = "Fantasy" },
            };

            var writers = new List<Domain.Entites.Writer>
            {
                new Domain.Entites.Writer { FirstName = "Ivo", LastName = "Andric", CountryOfBirth = "Serbia"},
                new Domain.Entites.Writer { FirstName = "Fyodor", LastName = "Dostoevsky", CountryOfBirth = "Russia"},
                new Domain.Entites.Writer { FirstName = "Frank", LastName = "Herbert", CountryOfBirth = "USA"},
                new Domain.Entites.Writer { FirstName = "Dan", LastName = "Simmons", CountryOfBirth = "USA"},
                new Domain.Entites.Writer { FirstName = "J.R.R", LastName = "Tolkien", CountryOfBirth = "UK"},
                new Domain.Entites.Writer { FirstName = "Jane", LastName = "Austin", CountryOfBirth = "UK"},
            };

            var books = new List<Domain.Entites.Book>
            {
                new Domain.Entites.Book { Title = "Na Drini ćuprija", Quantity = 2, Writer = writers.ElementAt(0), Category = categories.ElementAt(0)},
                new Domain.Entites.Book { Title = "Crime and Punishment", Quantity = 3, Writer = writers.ElementAt(1), Category = categories.ElementAt(0)},
                new Domain.Entites.Book { Title = "Dune", Quantity = 4, Writer = writers.ElementAt(2), Category = categories.ElementAt(2)},
                new Domain.Entites.Book { Title = "Dune: Messiah", Quantity = 1, Writer = writers.ElementAt(2), Category = categories.ElementAt(2)},
                new Domain.Entites.Book { Title = "The Terror", Quantity = 3, Writer = writers.ElementAt(3), Category = categories.ElementAt(3)},
                new Domain.Entites.Book { Title = "The Fellowship of the Ring", Quantity = 4, Writer = writers.ElementAt(4), Category = categories.ElementAt(3)},
                new Domain.Entites.Book { Title = "Pride and Prejudice", Quantity = 2, Writer = writers.ElementAt(5), Category = categories.ElementAt(1)},
            };

            var users = new List<Domain.Entites.User>
            {
                new Domain.Entites.User { FirstName = "Pera", LastName = "Peric", Username = "realPera", Email = "pera32@gmail.com", Password = BCrypt.Net.BCrypt.HashPassword("password")},
                new Domain.Entites.User { FirstName = "Zika", LastName = "Zikic", Username = "ZikaPazar", Email = "zikaPoljana@gmail.com", Password = BCrypt.Net.BCrypt.HashPassword("password")},
                new Domain.Entites.User { FirstName = "Admin", LastName = "Adminovic", Username = "Admin", Email = "admin@gmail.com", Password = BCrypt.Net.BCrypt.HashPassword("password")},
                new Domain.Entites.User { FirstName = "Librarian", LastName = "Book", Username = "Librarian", Email = "lib1@gmail.com", Password = BCrypt.Net.BCrypt.HashPassword("password")},
            };

            var checkouts = new List<Domain.Entites.Checkout>
            {
                new Domain.Entites.Checkout { User = users.ElementAt(0), Book = books.ElementAt(0), DateStart = DateTime.UtcNow, DateEnd = DateTime.UtcNow.AddDays(14), WasReturned = false},
                new Domain.Entites.Checkout { User = users.ElementAt(0), Book = books.ElementAt(1), DateStart = DateTime.UtcNow, DateEnd = DateTime.UtcNow.AddDays(21), WasReturned = true},
                new Domain.Entites.Checkout { User = users.ElementAt(1), Book = books.ElementAt(2), DateStart = DateTime.UtcNow, DateEnd = DateTime.UtcNow.AddDays(14), WasReturned = false},
                new Domain.Entites.Checkout { User = users.ElementAt(3), Book = books.ElementAt(4), DateStart = DateTime.UtcNow, DateEnd = DateTime.UtcNow.AddDays(28), WasReturned = false},
            };


            var usecases = new List<Domain.Entites.UserUseCase> 
            {

            };
            // anon users can search books and register: 13, 2
            // registered can look at their checkouted books: 13, 2, 25, 17, 5
            foreach (var i in new int[] { 13, 2, 25, 17, 5 })
            {
                usecases.Add(new Domain.Entites.UserUseCase { User = users.ElementAt(0), UseCaseId = i });
                usecases.Add(new Domain.Entites.UserUseCase { User = users.ElementAt(1), UseCaseId = i });
            }
            // librarians can CRUD books, CRUD checkouts: 13, 2, 25, 14, 15, 16, 21, 22, 23, 24, 17, 5
            foreach (var i in new int[] { 13, 2, 25, 14, 15, 16, 21, 22, 23, 24, 17, 5 })
            {
                usecases.Add(new Domain.Entites.UserUseCase { User = users.ElementAt(3), UseCaseId = i });
            }
            // admins can CRUD all tables and access logs: 1-25
            for (int i = 1; i < 25; i++)
            {
                usecases.Add(new Domain.Entites.UserUseCase { User = users.ElementAt(2), UseCaseId = i });
            }

            Context.Categories.AddRange(categories);
            Context.Writers.AddRange(writers);
            Context.Books.AddRange(books);
            Context.Users.AddRange(users);
            Context.Checkouts.AddRange(checkouts);
            Context.UserUseCases.AddRange(usecases);

            Context.SaveChanges();
        }
    }
}
