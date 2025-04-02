using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public abstract class MyFirstApiBaseController : ControllerBase
{    
    protected readonly List<Book> _books;

    protected MyFirstApiBaseController()
    {
        _books = new List<Book>
        {   
            new Book { 
                Id = Guid.NewGuid(), // Add ID!
                Author = "teste", 
                Price = 3.45, 
                Quantity = 4, 
                StatusGenre = Genre.fiction, // Capital enum
                Title = "abc" 
            }
        };
    }

    
    [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    protected IActionResult GetBookById(Guid id)
    {        
        var book = _books.Find(b => b.Id == id);
        return book != null ? Ok(book) : NotFound();
    }

    // 3. Return IEnumerable for better flexibility
    [ProducesResponseType(typeof(IEnumerable<Book>), StatusCodes.Status200OK)]
    protected IActionResult GetAllBooks() => Ok(_books);

    [ProducesResponseType(typeof(Book), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    protected IActionResult CreateBook(Book book)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        book.Id = Guid.NewGuid(); // Ensure ID is set
        _books.Add(book);
        return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
    }

    
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    protected IActionResult UpdateBook(Guid id, [FromBody] BookUpdateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var book = _books.Find(b => b.Id == id);
        if (book == null) return NotFound();

    
        book.Title = dto.Title;
        book.Price = dto.Price;
    

        return NoContent();
    }
}