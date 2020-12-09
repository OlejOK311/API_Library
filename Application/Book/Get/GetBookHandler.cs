using EFData;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Application.Book.Get
{
    public class GetBookHandler : IRequestHandler<GetBookQuery, GetBookResponse>
    {
        private readonly DataContext _context;

        public GetBookHandler(DataContext context)
        {
            _context = context;
        }
        
        public async Task<GetBookResponse> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            var getBookResponse = await _context.Books.FirstOrDefaultAsync(p => p.Id == request.Id);

            return new GetBookResponse()
            {
                Title = getBookResponse.Title,
                AuthorId = getBookResponse.Author.Id,
                Genre = (int)getBookResponse.Genre
            };
        }
    }
}
