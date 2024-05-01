using AutoMapper;
using Zone.Data.DTOs;
using Zone.Data.DTOs.Requests;
using Zone.Data.DTOs.Responses;
using Zone.Data.Models;
using Zone.Services.Services.Authentication.DTO;
using Zone.Services.Services.JWT.DTO;

namespace Zone.Services.Services.AutoMapping;

public class AutoMappingProfile : Profile
{
    public AutoMappingProfile()
    {
        //MODEL TO DTO
        CreateMap<User, UserDTO>();
        CreateMap<User, UserResponseDTO>();
        CreateMap<ZoneLobby, ZoneResponseDTO>();
        CreateMap<Note, NoteResponseDTO>();

        //DTO TO MODEL

        CreateMap<NewZoneRequestDTO, ZoneLobby>();
        CreateMap<UserDTO, User>();
        
        //DTO To DTO
        CreateMap<RegisterRequestDTO, UserDTO>();
        CreateMap<UserToLoginDataDTO, JWTRequestDTO>();
    }
}
    
