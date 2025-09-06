using AutoMapper;
using Reactivities.Application.Features.Activities.DTOs;
using Reactivities.Domain.Entities;

namespace Reactivities.Application.Mappings;

public class GeneralProfile : Profile
{
    public GeneralProfile()
    {
        CreateMap<Activity, Activity>();
        CreateMap<CreateActivityDto, Activity>();
        CreateMap<UpdateActivityDto, Activity>();
    }
}
