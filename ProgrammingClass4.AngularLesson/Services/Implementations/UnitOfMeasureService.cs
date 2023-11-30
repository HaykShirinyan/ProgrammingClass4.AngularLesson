using AutoMapper;
using ProgrammingClass4.AngularLesson.DataTransferObjects;
using ProgrammingClass4.AngularLesson.Models;
using ProgrammingClass4.AngularLesson.Repositories.Definitions;
using ProgrammingClass4.AngularLesson.Services.Definitions;

namespace ProgrammingClass4.AngularLesson.Services.Implementations
{
    public class UnitOfMeasureService: IUnitOfMeasureService
    {
        private readonly IUnitOfMeasureRepository _unitOfMeasureRepository;
        private readonly IMapper _mapper;

        public UnitOfMeasureService(IUnitOfMeasureRepository unitOfMeasureRepository, IMapper mapper)
        {
            _unitOfMeasureRepository = unitOfMeasureRepository;
            _mapper = mapper;
        }

        public List<UnitOfMeasureDto> GetAllUnitOfMeasures()
        {
            var unitOfMeasureList = _unitOfMeasureRepository.GetAllUnitOfMeasures();
            var unitOfMeasureDtoList = _mapper.Map<List<UnitOfMeasure>, List<UnitOfMeasureDto>>(unitOfMeasureList);
            
            return unitOfMeasureDtoList;
        }

        public UnitOfMeasureDto? GetUnitOfMeasure(int id)
        {
            var unitOfMeasureModel = _unitOfMeasureRepository.GetUnitOfMeasure(id);

            if (unitOfMeasureModel != null) 
            { 
                var unitOfMeasureDto = _mapper.Map<UnitOfMeasure, UnitOfMeasureDto>(unitOfMeasureModel);
                return unitOfMeasureDto;
            }

            return null;
        }

        public UnitOfMeasureDto AddUnitOfMeasure(UnitOfMeasureDto unitOfMeasur) 
        { 
            var unitOfMeasureModel = _mapper.Map<UnitOfMeasureDto,  UnitOfMeasure>(unitOfMeasur);
            
            var addedUnitOfMeasure = _unitOfMeasureRepository.AddUnitOfMeasure(unitOfMeasureModel);
            var addedunitOfMeasureDto = _mapper.Map<UnitOfMeasure, UnitOfMeasureDto>(addedUnitOfMeasure);

            return addedunitOfMeasureDto;
        }

        public UnitOfMeasureDto UpdateUnitOfMeasure(UnitOfMeasureDto unitOfMeasure)
        {
            var unitOfMeasureModel = _mapper.Map<UnitOfMeasureDto,UnitOfMeasure>(unitOfMeasure);

            var updatedUnitOfMeasure = _unitOfMeasureRepository.UpdateUnitOfMeasure(unitOfMeasureModel);
            var updartedUnitOfMeasureDto = _mapper.Map<UnitOfMeasure, UnitOfMeasureDto>(updatedUnitOfMeasure);

            return updartedUnitOfMeasureDto;
        }

        public UnitOfMeasureDto? DeleteUnitOfMeasure(int id)
        {
            var deletedUnitOfMeasure = _unitOfMeasureRepository.DeleteUnitOfMeasure(id);

            if(deletedUnitOfMeasure != null)
            {
                var deleteUnitOfMeasureDto = _mapper.Map<UnitOfMeasure, UnitOfMeasureDto>(deletedUnitOfMeasure);
                return deleteUnitOfMeasureDto;
            }

            return null;
        }
    }
}
