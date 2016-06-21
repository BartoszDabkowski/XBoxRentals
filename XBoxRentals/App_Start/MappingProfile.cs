using AutoMapper;
using XBoxRentals.Dtos;
using XBoxRentals.Models;

namespace XBoxRentals.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Game, GameDto>();
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Genre, GenreDto>();
            Mapper.CreateMap<Rating, RatingDto>();
            Mapper.CreateMap<File, FileDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Rental, NewRentalDto>();
            Mapper.CreateMap<Rental, RentalDto>();

            Mapper.CreateMap<GameDto, Game>()
                .ForMember(g => g.Id, opt => opt.Ignore());

            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(g => g.Id, opt => opt.Ignore());
        }
    }
}