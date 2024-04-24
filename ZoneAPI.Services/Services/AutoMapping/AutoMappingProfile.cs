using AutoMapper;
using Zone.Data.DTOs;
using Zone.Data.DTOs.Requests;
using Zone.Data.DTOs.Responses;
using Zone.Data.Models;

namespace Zone.Services.Services.AutoMapping;

public class AutoMappingProfile : Profile
{
    public AutoMappingProfile()
    {
        //MODEL TO DTO
        CreateMap<User, UserDTO>();
        CreateMap<User, UserResponseDTO>();
        CreateMap<ZoneLobby, ZoneResponseDTO>();

        //DTO TO MODEL
        CreateMap<NewZoneRequestDTO, ZoneLobby>();
        CreateMap<UserDTO, User>();
    }
}
    
