using AutoMapper;
using ProgrammingClass4.AngularLesson.DataTransferObjects;
using ProgrammingClass4.AngularLesson.Models;
using ProgrammingClass4.AngularLesson.Repositories.Definitions;
using ProgrammingClass4.AngularLesson.Services.Definitions;

namespace ProgrammingClass4.AngularLesson.Services.Implementations
{
    public class UnitOfMeasureService : IUnitOfMeasureService
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
            var unitOfMeasureModelList = _unitOfMeasureRepository.GetAllUnits();
            var unitOfMeasureDtoList = _mapper.Map<List<UnitOfMeasure>, List<UnitOfMeasureDto>>(unitOfMeasureModelList);

            return unitOfMeasureDtoList;
        }

        public UnitOfMeasureDto? GetUnit(int id)
        {
            var unitOfMeasureModel = _unitOfMeasureRepository.GetUnit(id);

            if (unitOfMeasureModel != null)
            {
                var unitOfMeasureDto = _mapper.Map<UnitOfMeasure, UnitOfMeasureDto>(unitOfMeasureModel);
                return unitOfMeasureDto;
            }

            return null;
        }

        public UnitOfMeasureDto AddUnitOfMeasure(UnitOfMeasureDto unitOfMeasure)
        {
            var unitOfMeasureModel = _mapper.Map<UnitOfMeasureDto, UnitOfMeasure>(unitOfMeasure);

            var addedUnitOfMeassure = _unitOfMeasureRepository.AddUnit(unitOfMeasureModel);
            var addedUnitOfMeasureDto = _mapper.Map<UnitOfMeasure, UnitOfMeasureDto>(addedUnitOfMeassure);

            return addedUnitOfMeasureDto;
        }

        public UnitOfMeasureDto UpdateUnitOfMeasure(UnitOfMeasureDto unitOfMeasure)
        {
            var unitOfMeasureModel = _mapper.Map<UnitOfMeasureDto, UnitOfMeasure>(unitOfMeasure);

            var updatedUnitOfMeasure = _unitOfMeasureRepository.UpdateUnit(unitOfMeasureModel);
            var updatedUnitOfMeasureDto = _mapper.Map<UnitOfMeasure, UnitOfMeasureDto>(updatedUnitOfMeasure);

            return updatedUnitOfMeasureDto;
        }

        public UnitOfMeasureDto? DeleteUnitOfMeasure(int id)
        {
            var deletedUnitOfMeasure = _unitOfMeasureRepository.DeleteUnit(id);

            if (deletedUnitOfMeasure != null)
            {
                var deletedUnitOfMeasureDto = _mapper.Map<UnitOfMeasure, UnitOfMeasureDto>(deletedUnitOfMeasure);
                return deletedUnitOfMeasureDto;
            }

            return null;
        }

        public UnitOfMeasureDto? GetUnitOfMeasure(int id)
        {
            throw new NotImplementedException();
        }
    }
}
