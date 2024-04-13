using AutoMapper;
using Zone.Data.Data.DTOs;
using Zone.Data.Data.DTOs.Requests;
using Zone.Data.Data.DTOs.Responses;
using Zone.Data.Data.Models;

namespace Zone.Services.Services.AutoMapping;

public class AutoMappingProfile : Profile
{
    public AutoMappingProfile()
    {
        //MODEL TO DTO
        CreateMap<User, UserDTO>();
        CreateMap<User, UserResponseDTO>();
        CreateMap<Data.Data.Models.ZoneLobby, ZoneResponseDTO>();

        //DTO TO MODEL
        CreateMap<NewZoneRequestDTO, Data.Data.Models.ZoneLobby>();
        CreateMap<UserDTO, User>();
    }
}
    
