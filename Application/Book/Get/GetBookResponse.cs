using MediatR;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace Application.Book.Get
{
    public class GetBookResponse
    {
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int Genre { get; set; }
    }
}