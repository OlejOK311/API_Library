using EFData;
using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Book.Add
{
    public class AddBookHandler : IRequestHandler<AddBookQuery>
    {
        private readonly DataContext _context;

        public AddBookHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(AddBookQuery request, CancellationToken cancellationToken)
        {
            var book = new Domain.Book
            {
                Title = request.Title,
                AuthorId = request.AuthorId,
                Genre = (Domain.Enums.Genres)request.Genre
            };

            _context.Books.Add(book);
            _context.SaveChanges();

            return await Unit.Task;
        }
    }
}
