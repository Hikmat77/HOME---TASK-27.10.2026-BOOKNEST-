using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class BookRepository : IBookRepositories
{
    public void AddBook(Book book)
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = "INSERT INTO books (title, publishedyear, totalcopies) VALUES (@title, @publishedyear, @totalcopies)";
        connection.Execute(query, book);
    }

    public void DeleteBook(int id)
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = "delete from books where id=@id";
        connection.Execute(query, new{id});
    }

    public Book GetBook(int id)
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = "select * from books where id=@id";
        var book = connection.QuerySingle<Book>(query, new{id});
        return book;
    }

    public List<Book> GetBooks()
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = "select * from books";
        return connection.Query<Book>(query).ToList();
    }

    public void UpdateBook(Book book)
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = "update books set publishedyear=@publishedyear, totalcopies=@totalcopies where id=@id";
        connection.Execute(query, book);
    }
}