using MediatR;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace Application.Book.GetBookByAuthorId
{
    public class GetBookByAuthorIdResponse
    {
        
        public List<Domain.Book> Books { get; set; }
    }
}