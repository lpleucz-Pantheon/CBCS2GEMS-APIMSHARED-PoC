using APIMShared.Models;
using AutoMapper;
using RestSharp;

namespace APIMShared.Mappers
{
    public class ExternalRequestToModelsMappingProfile: Profile
    {
        public ExternalRequestToModelsMappingProfile()
        {
            //To Test
            CreateMap<RestResponse, JWTTokenModel>()
                .ForMember(x => x.access_token, m => m.MapFrom(d => d.Content));            
        }
    }
}