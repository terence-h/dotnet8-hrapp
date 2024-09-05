using System;
using Account.Service.Dtos;
using Account.Service.Entities;
using AutoMapper;

namespace Account.Service.MappingProfiles;

public class CreateUserProfile : Profile
{
    public CreateUserProfile()
    {
        CreateMap<CreateUserRequest, User>();
    }
}
