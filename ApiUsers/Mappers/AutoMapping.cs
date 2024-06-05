using ApiUsers.Models;
using AutoMapper;

namespace ApiUsers.Mappers
{
    public class AutoMapping  : Profile
    {
        public AutoMapping() {

            CreateMap<phones, phonesDTO>().ReverseMap();

            CreateMap<UserDTO, User>();

           
        }
    }
}
