using Domain;
using Domain.Enums;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFData
{
    public class DataSeed
    {
        public static async Task SeedDataAsync(DataContext context)
        {
            if (!EnumerableExtensions.Any(context.Authors))
            {
                var author = new List<Author>
                {
                    new Author
                    {
                        FirstName = "Александр",
                        LastName = "Сергеевич",
                        FamilyName = "Пушкин",
                        Gender = Genders.Male
                    },
                    new Author
                    {
                        FirstName = "Лев",
                        LastName = "Николаевич",
                        FamilyName = "Толстой",
                        Gender = Genders.Male
                    },
                    new Author
                    {
                        FirstName = "Николай",
                        LastName = "Васильевич",
                        FamilyName = "Гоголь",
                        Gender = Genders.Female
                    }
                };

                context.Authors.AddRange(author);
                context.SaveChanges();
            }

            var pushkin = context.Authors.FirstOrDefault(p => p.FamilyName == "Пушкин");
            var tolstoy = context.Authors.FirstOrDefault(p => p.FamilyName == "Толстой");

            if (!EnumerableExtensions.Any(context.Books))
            {
                var book = new List<Book>
                {
                    new Book
                    {
                        Title = "Капитанская дочка",
                        AuthorId = pushkin.Id,
                        Genre = Genres.Classic,
                        Author = pushkin
                    },
                    new Book
                    {
                        Title = "Война и мир",
                        AuthorId = tolstoy.Id,
                        Genre = Genres.Classic,
                        Author = tolstoy
                    },
                    new Book
                    {
                        Title = "Анна Каренина",
                        AuthorId = tolstoy.Id,
                        Genre = Genres.Classic,
                        Author = tolstoy
                    }
                };

                context.Books.AddRange(book);
                context.SaveChanges();
            }

        }
    }
}
