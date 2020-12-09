using MediatR;

namespace Application.Book.Add
{
    public class AddBookQuery : IRequest<Unit>
    {
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int Genre { get; set; }
    }
}