using System.ComponentModel.DataAnnotations;

namespace Invento.Model
{
    public  class Category
    {
        public Category()
        {
            Items = new HashSet<Item>();
        }
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(50)]
        public required string CategoryName { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
