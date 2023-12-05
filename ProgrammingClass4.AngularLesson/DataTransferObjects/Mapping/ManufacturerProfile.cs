using AutoMapper;
using ProgrammingClass4.AngularLesson.Models;

namespace ProgrammingClass4.AngularLesson.DataTransferObjects.Mapping
{
    public class ManufacturerProfile : Profile
    {
        public ManufacturerProfile() 
        {
            CreateMap<Manufacturer, ManufacturerDto>()
                .ReverseMap();

            CreateMap<Manufacturer, ReferencedManufacturerDto>()
                .ReverseMap();
        }
    }
}
