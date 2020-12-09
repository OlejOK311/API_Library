using EFData;
using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Application.Book.Update
{
    public class DeleteBookHandler : IRequestHandler<UpdateBookQuery>
    {
        private readonly DataContext _context;

        public DeleteBookHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateBookQuery request, CancellationToken cancellationToken)
        {
            var updateBook = await _context.Books.FirstOrDefaultAsync(p => p.Id == request.Id);

            if (updateBook != null)
            {
                updateBook.Title = request.Title;
                updateBook.Author = _context.Authors.FirstOrDefault(p => p.Id == request.Id);
                updateBook.Genre = (Domain.Enums.Genres)request.Genre;

                _context.SaveChanges();

                return await Unit.Task;
            }
            else return await Unit.Task;
        }
    }
}