using ApiProjectCamp.WebApi.Dtos.FeatureDtos;
using ApiProjectCamp.WebApi.Dtos.MessageDtos;
using ApiProjectCamp.WebApi.Entities;
using AutoMapper;

namespace ApiProjectCamp.WebApi.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Feature,ResultFeatureDto>().ReverseMap();
            CreateMap<Feature,GetByIdFeatureDto>().ReverseMap();
            CreateMap<Feature,UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature,CreateFeatureDto>().ReverseMap();

            CreateMap<Message, ResultMessageDto>().ReverseMap();
            CreateMap<Message, GetByIdMessageDto>().ReverseMap();
            CreateMap<Message, UpdateMessageDto>().ReverseMap();
            CreateMap<Message, CreateMessageDto>().ReverseMap();
        }
    }
}
