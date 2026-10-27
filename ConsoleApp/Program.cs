using Domain.Models;
using Infrastructure.Repositories;

var bookRepo = new BookRepository();
var authorRepo = new AuthorRepository();
var genreRepo = new GenreRepository();

while (true)
{
    System.Console.WriteLine("======================================");
    System.Console.WriteLine(@"--- MAIN MENU ---
--- BOOKS ---
1) Show All Books.
2) Show Book by id.
3) Add new Book.
4) Update Book.
5) Delete Book.
--- AUTHORS ---
6) Show All Authors.
7) Show Author by id.
8) Add new Author.
9) Update Author.
10) Delete Author.
--- GENRES ---
11) Show All Genres.
12) Show Genre by id.
13) Add new Genre.
14) Update Genre.
15) Delete Genre.
0) Exit.");
    System.Console.Write("Choose --> ");
    var a = Console.ReadLine();
    System.Console.WriteLine("======================================");
    switch (a)
    {
        // ===================== BOOKS =====================
        case "1":
        {
            var books = bookRepo.GetBooks();
            foreach (var b in books)
            {
                System.Console.WriteLine($"{b.Id} | {b.Title} | {b.PublishedYear} | {b.TotalCopies}");
            }
            break;
        }
        case "2":
        {
            System.Console.Write("Enter book id --> ");
            var id = Convert.ToInt32(Console.ReadLine());
            var b = bookRepo.GetBook(id);
            System.Console.WriteLine($"{b.Id} | {b.Title} | {b.PublishedYear} | {b.TotalCopies}");
            break;
        }
        case "3":
        {
            System.Console.Write("Enter Title --> ");
            var title = Console.ReadLine()!;
            System.Console.Write("Enter Published Year --> ");
            var year = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter Total Copies --> ");
            var copies = Convert.ToInt32(Console.ReadLine());
            var newBook = new Book()
            {
                Title = title,
                PublishedYear = year,
                TotalCopies = copies
            };
            bookRepo.AddBook(newBook);
            break;
        }
        case "4":
        {
            System.Console.Write("Enter Id to update --> ");
            var uid = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter Title --> ");
            var utitle = Console.ReadLine()!;
            System.Console.Write("Enter Published Year --> ");
            var uyear = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter Total Copies --> ");
            var ucopies = Convert.ToInt32(Console.ReadLine());
            var updateBook = new Book()
            {
                Id = uid,
                Title = utitle,
                PublishedYear = uyear,
                TotalCopies = ucopies
            };
            bookRepo.UpdateBook(updateBook);
            break;
        }
        case "5":
        {
            System.Console.Write("Enter id to delete --> ");
            var did = Convert.ToInt32(Console.ReadLine());
            bookRepo.DeleteBook(did);
            break;
        }

        // ===================== AUTHORS =====================
        case "6":
        {
            var authors = authorRepo.GetAuthors();
            foreach (var author in authors)
            {
                System.Console.WriteLine($"{author.Id} | {author.Fullname} | {author.Country} | {author.BirthYear}");
            }
            break;
        }
        case "7":
        {
            System.Console.Write("Enter author id --> ");
            var id = Convert.ToInt32(Console.ReadLine());
            var ath = authorRepo.GetAuthor(id);
            System.Console.WriteLine($"{ath.Id} | {ath.Fullname} | {ath.Country} | {ath.BirthYear}");
            break;
        }
        case "8":
        {
            System.Console.Write("Enter Fullname --> ");
            var name = Console.ReadLine()!;
            System.Console.Write("Enter Country --> ");
            var country = Console.ReadLine()!;
            System.Console.Write("Enter Birth Year --> ");
            var birthYear = Convert.ToInt32(Console.ReadLine());
            var newAuthor = new Author()
            {
                Fullname = name,
                Country = country,
                BirthYear = birthYear
            };
            authorRepo.AddAuthor(newAuthor);
            break;
        }
        case "9":
        {
            System.Console.Write("Enter Id to update --> ");
            var uid = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter Fullname --> ");
            var uname = Console.ReadLine()!;
            System.Console.Write("Enter Country --> ");
            var ucountry = Console.ReadLine()!;
            System.Console.Write("Enter Birth Year --> ");
            var ubirthYear = Convert.ToInt32(Console.ReadLine());
            var updateAuthor = new Author()
            {
                Id = uid,
                Fullname = uname,
                Country = ucountry,
                BirthYear = ubirthYear
            };
            authorRepo.UpdateAuthor(updateAuthor);
            break;
        }
        case "10":
        {
            System.Console.Write("Enter id to delete --> ");
            var did = Convert.ToInt32(Console.ReadLine());
            authorRepo.DeleteAuthor(did);
            break;
        }

        // ===================== GENRES =====================
        case "11":
        {
            var genres = genreRepo.GetGenres();
            foreach (var genre in genres)
            {
                System.Console.WriteLine($"{genre.Id} | {genre.Name}");
            }
            break;
        }
        case "12":
        {
            System.Console.Write("Enter genre id --> ");
            var id = Convert.ToInt32(Console.ReadLine());
            var g = genreRepo.GetGenre(id);
            System.Console.WriteLine($"{g.Id} | {g.Name}");
            break;
        }
        case "13":
        {
            System.Console.Write("Enter Name --> ");
            var name = Console.ReadLine()!;
            var newGenre = new Genre()
            {
                Name = name
            };
            genreRepo.AddGenre(newGenre);
            break;
        }
        case "14":
        {
            System.Console.Write("Enter Id to update --> ");
            var uid = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter Name --> ");
            var uname = Console.ReadLine()!;
            var updateGenre = new Genre()
            {
                Id = uid,
                Name = uname
            };
            genreRepo.UpdateGenre(updateGenre);
            break;
        }
        case "15":
        {
            System.Console.Write("Enter id to delete --> ");
            var did = Convert.ToInt32(Console.ReadLine());
            genreRepo.DeleteGenre(did);
            break;
        }

        // ===================== EXIT =====================
        case "0":
            System.Console.WriteLine("Exiting....");
            return;
    }
}