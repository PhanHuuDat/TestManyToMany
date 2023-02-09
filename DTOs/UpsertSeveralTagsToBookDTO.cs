namespace TestManyToMany.DTOs
{
    public class UpsertSeveralTagsToBookDTO
    {
        public int BookId { get; set; }
        public List<int> TagsId { get; set; } = new List<int>();
    }
}
