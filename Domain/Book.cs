using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lenkie_Assessment.Domain
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsReserved { get; set; }
        public DateTime? ReservedUntil { get; set; }
        public Guid? BorrowedByCustomerId { get; set; }
        public Guid? ReservedByCustomerId { get; set; }
        public DateTime? BorrowedUntil { get; set; }
    }
}
