using fitnessclass.Models;


namespace fitnessclass.Repositories
{
    public interface IFitnessClassRepository
    {
        Task<IEnumerable<FitnessClass>> GetAvailableClasses(DateTime startDate, DateTime endDate, string instructor, string className);
        Task<FitnessClass> AddClassAsync(FitnessClass fitnessClass);
        Task<FitnessClass> GetClassByIdAsync(int id);
    }
}
