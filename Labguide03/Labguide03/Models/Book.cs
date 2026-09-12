using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
namespace Labguide03.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public string Image { get; set; }

        public float Price { get; set; }
        public int TotalPage { get; set; }
        public string Sumary { get; set; }

        public List<Book> GetBookList()
        {
            List<Book> books = new List<Book>
            {
                new Book()
                {
                    Id = 1,
                    Title = "Chi Pheo",
                    AuthorId = 1,
                    GenreId = 1,
                    Image = "/images/products/b1.jpg",
                    Price = 500000,
                    TotalPage = 180,
                    Sumary = ""
                },
                new Book()
                {
                    Id = 2,
                    Title = "Bi Vo",
                    AuthorId = 2,
                    GenreId = 2,
                    Image = "/images/products/b2.jpg",
                    Price = 600000,
                    TotalPage = 200,
                    Sumary = ""
                },
                new Book()
                {
                    Id = 3,
                    Title = "Tat den",
                    AuthorId = 3,
                    GenreId = 3,
                    Image = "/images/products/b3.jpg",
                    Price = 700000,
                    TotalPage = 150,
                    Sumary = ""
                },
                new     Book()
                {
                    Id = 4,
                    Title = "Thuoc bao duong",
                    AuthorId = 4,
                    GenreId = 4,
                    Image = "/images/products/b4.jpg",
                    Price = 800000,
                    TotalPage = 250,
                    Sumary = ""
                }
            };
            return books;
        }

        public Book GetBookById(int id)
            {
                Book book = this.GetBookList().FirstOrDefault(b => b.Id == id);
                return book;
        }

        public List<SelectListItem> Authors { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Nam Cao" },
            new SelectListItem { Value = "2", Text = "Nguyen Hong" },
            new SelectListItem { Value = "3", Text = "Ngo Tat To" },
            new SelectListItem { Value = "4", Text = "Minh Minh" }
        };

        public List<SelectListItem> Genres { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Van hoc duong dai" },
            new SelectListItem { Value = "2", Text = "Van hoc duong dai" },
            new SelectListItem { Value = "3", Text = "Van hoc duong dai" },
            new SelectListItem { Value = "4", Text = "Tieu thuyet" }
        };


    }
}
