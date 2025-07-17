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

            CreateMap<Feature, ResultMessageDto>().ReverseMap();
            CreateMap<Feature, GetByIdMessageDto>().ReverseMap();
            CreateMap<Feature, UpdateMessageDto>().ReverseMap();
            CreateMap<Feature, CreateMessageDto>().ReverseMap();
        }
    }
}
