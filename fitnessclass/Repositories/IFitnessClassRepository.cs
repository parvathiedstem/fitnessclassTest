using fitnessclass.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fitnessclass.Repositories
{
    public interface IFitnessClassRepository
    {
        Task<IEnumerable<FitnessClass>> GetAvailableClasses(DateTime? startDate, DateTime? endDate, string instructor, string className);
    }
}
