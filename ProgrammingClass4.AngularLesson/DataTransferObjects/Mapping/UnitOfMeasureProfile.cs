using AutoMapper;
using ProgrammingClass4.AngularLesson.Models;

namespace ProgrammingClass4.AngularLesson.DataTransferObjects.Mapping
{
    public class UnitOfMeasureProfile : Profile
    {
            CreateMap<UnitOfMeasure, UnitOfMeasureDto>();
            CreateMap<UnitOfMeasureDto, UnitOfMeasure>();
    }
}
