using System.ComponentModel.DataAnnotations;

public class BookUpdateDto
{
    [Required]
    public string Title { get; set; } = "";
    
    [Range(0, 1000)]
    public double Price { get; set; }
    public Genre StatusGenre {get; set;}
    public string Author { get; set; } = "";
    public int Quantity { get; set; }

}