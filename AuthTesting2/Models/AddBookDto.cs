namespace AuthTesting2.Models
{
    public class AddBookDto
    {
            
        public required string Title { get; set; }
        public required string Author { get; set; }
        public string? Description { get; set; }
    
    }
}
