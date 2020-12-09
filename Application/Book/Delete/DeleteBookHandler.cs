using EFData;
using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Application.Book.Delete
{
    public class DeleteBookHandler : IRequestHandler<DeleteBookQuery>
    {
        private readonly DataContext _context;

        public DeleteBookHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteBookQuery request, CancellationToken cancellationToken)
        {
            _context.Books.Remove(await _context.Books.FirstOrDefaultAsync(p => p.Id == request.Id));
            _context.SaveChanges();

            return await Unit.Task;
        }
    }
}