using MediatR;

namespace Application.Book.Delete
{
    public class DeleteBookQuery : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}