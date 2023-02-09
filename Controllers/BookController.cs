using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using TestManyToMany.DataAccess;
using TestManyToMany.DTOs;
using TestManyToMany.Models;

namespace TestManyToMany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost("add-tag")]
        public async Task<ActionResult<Book>> AddTagToBook(AddTagToBookDTO dto)
        {
            var book = await _context.Book.Where(b => b.Id == dto.BookId).Include(b => b.Tags).FirstOrDefaultAsync();

            if (book == null)
            {
                return NotFound();
            }

            var tag = await _context.Tag.FindAsync(dto.TagId);

            if (tag == null)
            {
                return NotFound();
            }

            book.Tags.Add(tag);
            await _context.SaveChangesAsync();
            return Ok(book);
        }

        [HttpGet]
        public async Task<ActionResult<Book>> GetBook(int bookId)
        {
            var book = await _context.Book.Where(b => b.Id == bookId).Include(b=>b.Tags).FirstOrDefaultAsync();


            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost("upsert")]
       
        public async Task<ActionResult<Book>> UpsertTagsToBook(UpsertSeveralTagsToBookDTO dto)
        {
            var book = await _context.Book.Where(b => b.Id == dto.BookId).Include(b => b.Tags).FirstOrDefaultAsync();

            if (book == null)
            {
                return NotFound();
            }

            var tags =  _context.Tag.Where(t => dto.TagsId.Any()).ToList();

            

            book.Tags = tags;
            await _context.SaveChangesAsync();
            return Ok(book);
        }
    }
}
