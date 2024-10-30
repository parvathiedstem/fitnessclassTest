using fitnessclass.Models;
using fitnessclass.Models;
using System.Threading.Tasks;

namespace FitnessClassScheduling.Repositories
{
    public interface IRegistrationRepository
    {
        Task<bool> ClassExists(int classId);
        Task<bool> HasCapacity(int classId);
        Task AddRegistration(Registration registration);
        Task SaveChangesAsync();
    }
}
