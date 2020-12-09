using MediatR;

namespace Application.Book.Update
{
    public class UpdateBookQuery : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int Genre { get; set; }
    }
}