using fitnessclass.Models;
using System.Threading.Tasks;

namespace fitnessclass.Repositories
{
    public interface IRegistrationRepository
    {
        Task<bool> ClassExists(int classId);
        Task<bool> HasCapacity(int classId);
        Task AddRegistration(Registration registration);
        Task<bool> MemberHasOverlappingClass(string memberName, DateTime classDateTime);
        Task<Registration> GetRegistrationById(int registrationId);
        Task CancelRegistration(Registration registration, string reason);
        Task SaveChangesAsync();
    }
}
