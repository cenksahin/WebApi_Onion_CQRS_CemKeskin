namespace YoutubeApi.Domain.Common
{
    public class EntityBase : IEntityBase
    {
        public int Id { get; set; }

        public DateTime? CreateDate { get; set; } = DateTime.Now;

        public bool? IsDeleted { get; set; } = false;
    }
}