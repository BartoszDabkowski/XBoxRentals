using System;

namespace XBoxRentals.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsSubscribedToEmail { get; set; }
        public MembershipTypeDto MembershipType { get; set; }
        public int MembershipTypeId { get; set; }
    }
}