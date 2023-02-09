using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        private readonly IMapper _mapper;
        public BookController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;  
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
            _context.Book.Update(book);

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

            var tags = _context.Tag.AsNoTracking().Where(t => dto.TagsId.Contains(t.Id)).ToList();
            
            var book = await _context.Book.AsNoTracking().Where(b => b.Id == dto.BookId).Include(b => b.Tags).FirstOrDefaultAsync();
            
            if (book == null)
            {
                return NotFound();
            }





            book.Tags = tags;
            _context.Book.Update(book);
            await _context.SaveChangesAsync();
            return Ok(book);
        }
    }
}
