using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lenkie_Assessment.Domain
{
    public class Notification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public Guid CustomerId { get; set; }
        public bool IsAvailable { get; set; }
    }
}
