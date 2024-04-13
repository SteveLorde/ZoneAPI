using AutoMapper;
using Zone.Data.Data.DTOs;
using Zone.Data.Data.DTOs.Requests;
using Zone.Services.Services.Authentication.DTO;
using Zone.Services.Services.JWT;
using Zone.Services.Services.JWT.DTO;
using Zone.Services.Services.PasswordHash;
using Zone.Services.Services.Repositories.UserRepo;

namespace Zone.Services.Services.Authentication;

public class Authentication : IAuthentication
{
    private readonly IPasswordHash _passwordHash;
    private readonly IMapper _mapper;
    private readonly IUserRepo _userRepo;
    private readonly IJWT _jwtService;

    public Authentication(IPasswordHash passwordHash, IMapper mapper, IUserRepo userRepo, IJWT jwtService)
    {
        _passwordHash = passwordHash;
        _mapper = mapper;
        _userRepo = userRepo;
        _jwtService = jwtService;
    }
    
    public async Task<string> Login(AuthRequestDTO loginReq)
    {
        string token = "";
        //1st, check username in database
        bool checkuser = await CheckIfUserExists(loginReq.UserName);
        if (!checkuser)
        {
            return "username / password are wrong";
        }
        else
        {
            //2- Get User Password
            UserToLoginDataDTO userToLoginData = await _userRepo.GetHashedpassword(loginReq.UserName);
            JWTRequestDTO userjwtreq = _mapper.Map<JWTRequestDTO>(userToLoginData);
            //3- verify password
            bool checkpassword = await VerifyPassword(loginReq.Password, userToLoginData.HashedPassword) ;
            if (checkpassword)
            {
                token  = _jwtService.CreateToken(userjwtreq);
                return token;
            }
            else
            {
                return "username / password are wrong";
            }
        }
    }

    public async Task<bool> Register(AuthRequestDTO registerReq)
    {
        //check is userexists
        bool checkUserExists = await CheckIfUserExists(registerReq.UserName);
        if (checkUserExists)
        {
            return false;
        }
        else
        {
            //map new user data from registerreq
            UserDTO  newUserDto = _mapper.Map<UserDTO>(registerReq);
            //1-hash password
            string hashedpassword =  _passwordHash.CreateHashedPassword(newUserDto.Password);
            //2-add to database
            return await _userRepo.AddUser(newUserDto, hashedpassword);
        }
    }

    private async Task<bool> CheckIfUserExists(string userName)
    {
        return await _userRepo.CheckUserExists(userName);
    }
    
    private async Task<bool> VerifyPassword(string passwordtoverify, string hashedpassword)
    {
        //1-extract salt from database user hashedpassword, pass string pattern SALT.HASHEDPASSWORD
        var extractedsavedpassword = hashedpassword.Split(".");
        var extractedsalt = extractedsavedpassword[0];
        var extractedhashedpass = extractedsavedpassword[1];
        //2-generate hashed password with given salt
        var passwordtotest = _passwordHash.HashPasswordWithGivenSalt( extractedsalt, passwordtoverify);
        //3-compare
        if (passwordtotest == extractedhashedpass)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    
    
    
}