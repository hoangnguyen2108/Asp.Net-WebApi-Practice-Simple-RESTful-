using AutoMapper;
using PracticeWebApi.Dto;
using PracticeWebApi.Model;

namespace PracticeWebApi.Configuration
{
    public class MapperConfig:Profile
    {
        public MapperConfig()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
