using System.ComponentModel.DataAnnotations;

namespace XBoxRentals.Models
{
    public class MembershipType
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public short SignUpFee { get; set; }

        public byte DurationInMonths { get; set; }

        public byte DiscountRate { get; set; }

        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;
        public static readonly byte Monthly = 2;
        public static readonly byte Quarterly = 3;
        public static readonly byte Annually = 4;
    }
}