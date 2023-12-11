using AutoMapper;
using ProgrammingClass4.AngularLesson.Models;

namespace ProgrammingClass4.AngularLesson.DataTransferObjects.Mapping
{
    public class UnitOfMeasureProfile : Profile
    {
        public UnitOfMeasureProfile() 
        {
            CreateMap<UnitOfMeasure, UnitOfMeasureDto>();
            CreateMap<UnitOfMeasureDto, UnitOfMeasure>();

            CreateMap<UnitOfMeasure, ReferencedUnitOfMeasureDto>()
               .ReverseMap();

        }
            
    }
}
