using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TestManyToMany.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<Book> Books { get; set; }
    }
}
