using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }

        [StringLength(128)]
        public string Name { get; set; }
        public short SignUpFree { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
    }
}
