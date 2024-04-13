using AutoMapper;
using Zone.Data.Data.DTOs;
using Zone.Data.Data.DTOs.Requests;
using Zone.Data.Data.Models;

namespace Zone.Services.Services.AutoMapping;

public class AutoMappingProfile : Profile
{
    public AutoMappingProfile()
    {
        //MODEL TO DTO
        CreateMap<User, UserDTO>();

        //DTO TO MODEL
        CreateMap<NewZoneRequestDTO, Data.Data.Models.Zone>();
        CreateMap<UserDTO, User>();
    }
}
    
