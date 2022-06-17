using AutoMapper;
using SocialMedia.Core.Entities;
using SocialMedia.Rest.Models;

namespace SocialMedia.Rest
{
    /// <summary>
    /// Used for mapping entities to DTO's.
    /// </summary>
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<Follower, FollowerItem>();
        }
    }
}
