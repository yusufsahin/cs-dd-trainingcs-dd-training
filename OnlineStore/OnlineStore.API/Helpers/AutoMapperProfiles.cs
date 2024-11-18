using AutoMapper;
using OnlineStore.API.Dtos;
using OnlineStore.Entity.Concrete;

namespace OnlineStore.API.Helpers
{
    public class AutoMapperProfiles:Profile
    {

        public AutoMapperProfiles()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            ///CreateMap<CategoryDto, Category>();
        }
    }
}
