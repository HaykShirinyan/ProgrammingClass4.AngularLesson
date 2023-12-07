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

        public async Task <List<UnitOfMeasureDto>> GetAllAsync()
        {
            var unitOfMeasureModelList = await _unitOfMeasureRepository.GetAllAsync();
            var unitOfMeasureDtoList = _mapper.Map<List<UnitOfMeasure>, List<UnitOfMeasureDto>>(unitOfMeasureModelList);

            return unitOfMeasureDtoList;
        }

        public async Task< UnitOfMeasureDto?> GetAsync(int id)
        {
            var unitOfMeasureModel = await _unitOfMeasureRepository.GetAsync(id);

            if (unitOfMeasureModel != null)
            {
                var unitOfMeasureDto = _mapper.Map<UnitOfMeasure, UnitOfMeasureDto>(unitOfMeasureModel);
                return unitOfMeasureDto;
            }

            return null;
        }

        public async Task<UnitOfMeasureDto> AddAsync(UnitOfMeasureDto unitOfMeasure)
        {
            var unitOfMeasureModel = _mapper.Map<UnitOfMeasureDto, UnitOfMeasure>(unitOfMeasure);

            var addedUnitOfMeassure = await _unitOfMeasureRepository.AddAsync(unitOfMeasureModel);
            var addedUnitOfMeasureDto = _mapper.Map<UnitOfMeasure, UnitOfMeasureDto>(addedUnitOfMeassure);

            return addedUnitOfMeasureDto;
        }

        public async Task<UnitOfMeasureDto> UpdateAsync(UnitOfMeasureDto unitOfMeasure)
        {
            var unitOfMeasureModel = _mapper.Map<UnitOfMeasureDto, UnitOfMeasure>(unitOfMeasure);

            var updatedUnitOfMeasure = await _unitOfMeasureRepository.UpdateAsync(unitOfMeasureModel);
            var updatedUnitOfMeasureDto = _mapper.Map<UnitOfMeasure, UnitOfMeasureDto>(updatedUnitOfMeasure);

            return updatedUnitOfMeasureDto;
        }

        public async Task<UnitOfMeasureDto>? DeleteAsync(int id)
        {
            var deletedUnitOfMeasure = await _unitOfMeasureRepository.DeleteAsync(id);

            if (deletedUnitOfMeasure != null)
            {
                var deletedUnitOfMeasureDto = _mapper.Map<UnitOfMeasure, UnitOfMeasureDto>(deletedUnitOfMeasure);
                return deletedUnitOfMeasureDto;
            }

            return null;
        }


    }
}
