using AutoMapper;
using Reactivities.Domain.Entities;

namespace Reactivities.Application.Mappings;

public class GeneralProfile : Profile
{
    public GeneralProfile()
    {
        CreateMap<Activity, Activity>();
    }
}
