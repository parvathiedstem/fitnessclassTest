using fitnessclass.Models;
using fitnessclass.Repositories;
using fitnessclass.Models.Dto;

namespace fitnessclass.Services
{
    public class FitnessClassService : IFitnessClassService
    {
        private readonly IFitnessClassRepository _repository;

        public FitnessClassService(IFitnessClassRepository repository)
        {
            _repository = repository;
        }

        public async Task<FitnessClass> AddClassAsync(FitnessClassRequest request)
        {
            var fitnessClass = new FitnessClass
            {
                ClassName = request.ClassName,
                Instructor = request.Instructor,
                DateTime = request.DateTime,
                Capacity = request.Capacity,
                RoomNumber = request.RoomNumber,
                AvailableSpots = request.Capacity
            };

            return await _repository.AddClassAsync(fitnessClass);
        }

        public async Task<FitnessClass> GetClassByIdAsync(int id)
        {
            return await _repository.GetClassByIdAsync(id);
        }


        public async Task<IEnumerable<FitnessClass>> GetAvailableClasses(DateTime startDate, DateTime endDate, string instructor, string className)
        {
            return await _repository.GetAvailableClasses(startDate, endDate, instructor, className);
        }
    }
}
