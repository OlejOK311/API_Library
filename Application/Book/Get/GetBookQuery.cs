using MediatR;

namespace Application.Book.Get
{
    public class GetBookQuery : IRequest<GetBookResponse>
    {
        public int Id { get; set; }
    }
}