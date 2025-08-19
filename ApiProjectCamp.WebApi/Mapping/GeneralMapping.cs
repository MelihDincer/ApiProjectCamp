using ApiProjectCamp.WebApi.Dtos.AboutDtos;
using ApiProjectCamp.WebApi.Dtos.CategoryDtos;
using ApiProjectCamp.WebApi.Dtos.FeatureDtos;
using ApiProjectCamp.WebApi.Dtos.MessageDtos;
using ApiProjectCamp.WebApi.Dtos.NotificationDtos;
using ApiProjectCamp.WebApi.Dtos.ProductDtos;
using ApiProjectCamp.WebApi.Dtos.ServiceDtos;
using ApiProjectCamp.WebApi.Dtos.TestimonialDtos;
using ApiProjectCamp.WebApi.Entities;
using AutoMapper;

namespace ApiProjectCamp.WebApi.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, GetByIdFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();

            CreateMap<Message, ResultMessageDto>().ReverseMap();
            CreateMap<Message, GetByIdMessageDto>().ReverseMap();
            CreateMap<Message, UpdateMessageDto>().ReverseMap();
            CreateMap<Message, CreateMessageDto>().ReverseMap();

            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, GetByIdProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, ResultProductWithCategoryDto>().ForMember(x => x.CategoryName, y => y.MapFrom(z => z.Category.CategoryName)).ReverseMap();
            CreateMap<Product, GetByIdProductWithCategoryDto>().ForMember(x => x.CategoryName, y => y.MapFrom(z => z.Category.CategoryName)).ReverseMap();

            CreateMap<Service, ResultServiceDto>().ReverseMap();
            CreateMap<Service, GetByIdServiceDto>().ReverseMap();
            CreateMap<Service, UpdateServiceDto>().ReverseMap();
            CreateMap<Service, CreateServiceDto>().ReverseMap();

            CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, GetByIdTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();

            CreateMap<Notification, ResultNotificationDto>().ReverseMap();
            CreateMap<Notification, GetByIdNotificationDto>().ReverseMap();
            CreateMap<Notification, UpdateNotificationDto>().ReverseMap();
            CreateMap<Notification, CreateNotificationDto>().ReverseMap();

            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, GetByIdCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();

            CreateMap<About, ResultAboutDto>().ReverseMap();
            CreateMap<About, GetByIdAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();
            CreateMap<About, CreateAboutDto>().ReverseMap();
        }
    }
}
