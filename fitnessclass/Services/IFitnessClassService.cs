using fitnessclass.Models;
using fitnessclass.Models.Dto;


namespace fitnessclass.Services
{
    public interface IFitnessClassService
    {
        Task<IEnumerable<FitnessClass>> GetAvailableClasses(DateTime startDate, DateTime endDate, string instructor, string className);
        Task<FitnessClass> AddClassAsync(FitnessClassRequest request);
        Task<FitnessClass> GetClassByIdAsync(int id);
    }
}
