using TestManyToMany.Models;

namespace TestManyToMany.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TagDTO> Tags { get; set; } = new List<TagDTO>();
    }
}
