
using IsPlanlamaAPI.Core.Entities;
using AutoMapper;
using IsPlanlamaAPI.Contract.Common.Request.PlanDtos;
using IsPlanlamaAPI.Contract.Common.Request.TeamDtos;
using IsPlanlamaAPI.Contract.Common.Request.UserDtos;
using IsPlanlamaAPI.Contract.Common.Request.TeamMemberDtos;



namespace IsPlanlamaAPI.Business.Mapping
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Plan, CreatePlanDtos>().ReverseMap();
            CreateMap<Plan, UpdatePlanDtos>().ReverseMap();
            CreateMap<Plan, ResultPlanDto>()
       .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.AssignedUserId))
       .ForMember(dest => dest.TeamId, opt => opt.MapFrom(src => src.TeamId))
       .ReverseMap();
            CreateMap<Plan, RemovePlanDto>().ReverseMap();
            CreateMap<Plan, GetPlanDto>().ReverseMap();

            CreateMap<Team, CreateTeamDto>().ReverseMap();
            CreateMap<Team, UpdateTeamDto>().ReverseMap();
            CreateMap<Team, ResultTeamDto>().ReverseMap();
            CreateMap<Team, DeleteTeamDto>().ReverseMap();

            CreateMap<User, DeleteUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, ResultUserDto>().ReverseMap();

            CreateMap<TeamMember, ResultTeamMemberDto>().ReverseMap();
            CreateMap<TeamMember, CreateTeamMemberDto>().ReverseMap();
            CreateMap<TeamMember, UpdateTeamMemberDto>().ReverseMap();
            CreateMap<TeamMember, DeleteTeamMemberDto>().ReverseMap();


            //      // PlanRequest -> Plan
            //      CreateMap<PlanRequestDTO, Plan>()
            //          .ForMember(dest => dest.Id, opt => opt.Condition(src => src.Id != 0));

            //      // Plan -> PlanResponse
            //      CreateMap<Plan, PlanResponseDto>()
            //.ForMember(dest => dest.TeamName, opt => opt.MapFrom(src => src.Team != null ? src.Team.TeamName : null))
            //.ForMember(dest => dest.AssignedUser, opt => opt.MapFrom(src => src.AssignedUser != null ? src.AssignedUser.UserName + " " + src.AssignedUser.Surname : null));

            //      CreateMap<TeamRequestDTO, Team>();

            //      // Team -> TeamResponseDto
            //      CreateMap<Team, TeamResponseDto>()
            //          .ForMember(dest => dest.UserNames, opt => opt.MapFrom(src => src.Users.Select(u => u.UserName).ToList()))
            //          .ForMember(dest => dest.PlanCount, opt => opt.MapFrom(src => src.Plans.Count));

            //      CreateMap<TeamMember, TeamMemberResponseDto>()
            //      .ForMember(dest => dest.TeamName, opt => opt.MapFrom(src => src.Team.TeamName))
            //      .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName));

            //      CreateMap<User, UserResponseDto>()
            //    .ForMember(dest => dest.TeamName, opt => opt.MapFrom(src => src.Team.TeamName))
            //    .ForMember(dest => dest.TeamMemberNames, opt => opt.MapFrom(src => src.Team.TeamMembers.Select(tm => tm.User.UserName).ToList()));

            //      CreateMap<UserRequestDto, User>();
        }
    }
}
    

