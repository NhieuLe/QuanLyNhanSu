using System.ComponentModel.DataAnnotations;

namespace NhanSuAPI.Data
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid().ToString();
        }
        [Key]
        public string Id { get; set; }
        public DateTimeOffset? DeleteDate { get; set; }
    }
}
