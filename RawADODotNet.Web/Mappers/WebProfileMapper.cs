using AutoMapper;
using Project.InfraStructure.Models.Dtos;
using RawADODotNet.Web.ViewModel;

namespace RawADODotNet.Web.Mappers
{
    public class WebProfileMapper : Profile
    {
        public static readonly Mapper Mapper;

        static WebProfileMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(config =>
            {
                MapConfig(config);
            }));
        }

        public WebProfileMapper()
        {
            MapConfig(this);
        }

        public static void MapConfig(IProfileExpression expression)
        {
            expression.CreateMap<EmployeeVM, EmployeeDto>().ReverseMap();
        }
    }
}

