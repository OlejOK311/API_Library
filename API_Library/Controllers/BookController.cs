using Application.Book.Add;
using Application.Book.Delete;
using Application.Book.Get;
using Application.Book.GetBookByAuthorId;
using Application.Book.Update;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace API_Library.Controllers
{
    [AllowAnonymous]
    public class BookController : BaseController
    {
        [HttpPost("addbook")]
        public Task<Unit> AddBookAsync(AddBookQuery query) => Mediator.Send(query);

        [HttpPost("deletebook")]
        public Task<Unit> DeleteBookAsync(DeleteBookQuery query) => Mediator.Send(query);

        [HttpPost("getbook")]
        public async Task<ActionResult<GetBookResponse>> GetBookAsync(GetBookQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost("getbyauthorid")]
        public async Task<ActionResult<GetBookByAuthorIdResponse>> GetBookByAuthorIdAsync(GetBookByAuthorIdQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost("updatebook")]
        public Task<Unit> UpdateBookAsync(UpdateBookQuery query) => Mediator.Send(query);
    }
}
