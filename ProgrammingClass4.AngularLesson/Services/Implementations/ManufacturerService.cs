using AutoMapper;
using ProgrammingClass4.AngularLesson.DataTransferObjects;
using ProgrammingClass4.AngularLesson.Models;
using ProgrammingClass4.AngularLesson.Repositories.Definitions;
using ProgrammingClass4.AngularLesson.Services.Definitions;

namespace ProgrammingClass4.AngularLesson.Services.Implementations
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly IMapper _mapper;
        private readonly IManufacturerRepository _manufacturerRepository;

        public ManufacturerService(IMapper mapper, IManufacturerRepository manufacturerRepository)
        {
            _mapper = mapper;
            _manufacturerRepository = manufacturerRepository;
        }

        public async Task<List<ManufacturerDto>> GetAllAsync()
        {
            var manufacturers = await _manufacturerRepository.GetAllAsync();
            return _mapper.Map<List<Manufacturer>, List<ManufacturerDto>>(manufacturers);
        }
    }
}
