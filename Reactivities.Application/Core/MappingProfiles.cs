using AutoMapper;
using Reactivities.Reactivities.Domain;

namespace Reactivities.Reactivities.Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Activity, Activity>();
        }
    }
}