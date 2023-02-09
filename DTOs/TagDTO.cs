using System.Text.Json.Serialization;
using TestManyToMany.Models;

namespace TestManyToMany.DTOs
{
    public class TagDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<BookDTO> Books { get; set; }
    }
}
