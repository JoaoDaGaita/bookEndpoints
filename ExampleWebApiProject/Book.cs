

using System.Text.Json.Serialization;

public class Book
    {
        [JsonIgnore]
        public Guid Id { get; set; } = new Guid("2033fee4-4784-4fb4-a857-74c245f6c35a");
        public string Title { get; set; } = "";

        public Genre StatusGenre {get; set;}
        public string Author { get; set; } = "";

        public double Price { get; set; }

        public int Quantity { get; set; }

        // Construtor padrão (necessário para desserialização)
        public Book()
        {
            
        }

        // Construtor parametrizado
        public Book(int id, string title, Genre genre, string author, double price, int quantity)
        {            
            Title = title;
            StatusGenre = genre;
            Author = author;
            Price = price;
            Quantity = quantity;
        }
    }