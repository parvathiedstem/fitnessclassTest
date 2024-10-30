using fitnessclass.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using fitnessclass.Repositories;

namespace fitnessclass.Services
{
    public class FitnessClassService : IFitnessClassService
    {
        private readonly IFitnessClassRepository _repository;

        public FitnessClassService(IFitnessClassRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<FitnessClass>> GetAvailableClasses(DateTime? startDate, DateTime? endDate, string instructor, string className)
        {
            return await _repository.GetAvailableClasses(startDate, endDate, instructor, className);
        }
    }
}
