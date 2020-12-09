using EFData;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace Application.Book.GetBookByAuthorId
{
    public class GetBookByAuthorIdHandler : IRequestHandler<GetBookByAuthorIdQuery, GetBookByAuthorIdResponse>
    {
        private readonly DataContext _context;

        public GetBookByAuthorIdHandler(DataContext context)
        {
            _context = context;
        }
        
        public async Task<GetBookByAuthorIdResponse> Handle(GetBookByAuthorIdQuery request, CancellationToken cancellationToken)
        {
            var books = _context.Books.Where(p => p.Author.Id == request.AuthorId).ToArray();

            return new GetBookByAuthorIdResponse
            {
                Books = books.ToList()
            };
        }
    }
}
