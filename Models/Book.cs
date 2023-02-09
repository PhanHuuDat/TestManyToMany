using System.ComponentModel.DataAnnotations;

namespace TestManyToMany.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Tag> Tags { get; set; } = new List<Tag>();
    }
}
