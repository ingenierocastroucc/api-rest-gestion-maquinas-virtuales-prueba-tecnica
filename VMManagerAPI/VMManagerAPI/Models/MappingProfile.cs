using VMManagerAPI.DTOs;
using VMManagerAPI.Models;
using AutoMapper;
using VMManagerAPI.Models.Dto;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateVirtualMachineDto, VirtualMachine>();
        CreateMap<UpdateVirtualMachineDto, VirtualMachine>();
        CreateMap<VirtualMachine, VirtualMachineDto>();
        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>();
    }
}