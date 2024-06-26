﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Zone.Data;
using Zone.Data.DTOs;
using Zone.Data.DTOs.Responses;
using Zone.Data.Models;
using Zone.Services.Services.Authentication.DTO;

namespace Zone.Services.Services.Repositories.UserRepo;

sealed class UserRepo : IUserRepo
{
    private readonly DataContext _db;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _webenv;

    public UserRepo(DataContext db, IMapper mapper, IWebHostEnvironment webenv)
    {
        _db = db;
        _mapper = mapper;
        _webenv = webenv;
    }
    
    public async Task<List<UserResponseDTO>> GetUsers()
    {
        return await _db.Users.Include(user => user.JoinedZones).ProjectTo<UserResponseDTO>(_mapper.ConfigurationProvider).ToListAsync();
    }

    public async Task<UserResponseDTO> GetUser(Guid userId)
    {
        return await _db.Users.ProjectTo<UserResponseDTO>(_mapper.ConfigurationProvider).FirstAsync(user => user.Id == userId);
    }

    public async Task<User> GetUserDirectly(Guid userId)
    {
        return await _db.Users.FirstAsync(user => user.Id == userId);
    }

    public async Task<bool> CheckUserExists(string userName)
    {
        return await _db.Users.AnyAsync(user => user.UserName == userName);
    }

    public async Task<UserToLoginDataDTO> GetHashedpassword(string userName)
    {
        var data =  await _db.Users.Where(user => user.UserName == userName).Select(user => new {user.Id , user.HashedPassword}).FirstAsync();
        UserToLoginDataDTO newUserToLoginData = new UserToLoginDataDTO() { Id = data.Id, HashedPassword = data.HashedPassword };
        return newUserToLoginData;
    }

    public async Task<bool> AddUser(UserDTO newUserDTO, string hashedPassword)
    {
        User newUser = _mapper.Map<User>(newUserDTO);
        newUser.HashedPassword = hashedPassword;
        await _db.Users.AddAsync(newUser);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task RemoveUser(string userId)
    {
        throw new NotImplementedException();
    }

    public async Task CreateUsersFolders()
    {
        string storageUsersDirectory = Path.Combine(_webenv.ContentRootPath,"Storage","Users");
        List<User> users = await _db.Users.ToListAsync();
        foreach (var user in users)
        {
            string userFolder = Path.Combine(_webenv.ContentRootPath,"Storage","Users",$"{user.Id}");
            Directory.CreateDirectory(userFolder);
        }
    }
    
    
    
    
}