using MediatR;

namespace Application.Book.GetBookByAuthorId
{
    public class GetBookByAuthorIdQuery : IRequest<GetBookByAuthorIdResponse>
    {
        public int AuthorId { get; set; }
    }
}