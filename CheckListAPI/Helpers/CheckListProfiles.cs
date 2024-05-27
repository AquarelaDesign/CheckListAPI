using AutoMapper;
using CheckListAPI.Models.Dtos;
using CheckListAPI.Models;

namespace CheckListAPI.Helpers
{
    public class CheckListProfiles : Profile
    {
        public CheckListProfiles()
        {
            CreateMap<CheckListItens, CheckListItensDto>();
            CreateMap<CheckListItens, CheckListItensAddDto>().ReverseMap();
            CreateMap<CheckListItens, CheckListItensAddDto>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CheckListItemGroup, CheckListItensGroupDto>();
            CreateMap<CheckListItemGroup, CheckListItensGroupAddDto>().ReverseMap();
            CreateMap<CheckListItemGroup, CheckListItensGroupAddDto>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CheckListItensVehicle, CheckListItensVehicleDto>();
            CreateMap<CheckListItensVehicle, CheckListItensVehicleAddDto>().ReverseMap();
            CreateMap<CheckListItensVehicle, CheckListItensVehicleAddDto>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CheckListOwner, CheckListOwnerDto>();
            CreateMap<CheckListOwner, CheckListOwnerAddDto>().ReverseMap();
            CreateMap<CheckListOwner, CheckListOwnerAddDto>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CheckListHeader, CheckListHeaderDto>();
            CreateMap<CheckListHeader, CheckListHeaderAddDto>().ReverseMap();
            CreateMap<CheckListHeader, CheckListHeaderAddDto>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CheckListSupervisor, CheckListSupervisorDto>();
            CreateMap<CheckListSupervisor, CheckListSupervisorAddDto>().ReverseMap();
            CreateMap<CheckListSupervisor, CheckListSupervisorAddDto>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CheckListVehicles, CheckListVehicleDto>();
            CreateMap<CheckListVehicles, CheckListVehicleAddDto>().ReverseMap();
            CreateMap<CheckListVehicles, CheckListVehicleAddDto>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Users, UsersDto>();
            CreateMap<Users, UsersAddDto>().ReverseMap();
            CreateMap<Users, UsersAddDto>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
