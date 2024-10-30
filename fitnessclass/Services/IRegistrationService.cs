using System.Threading.Tasks;
using fitnessclass.Models;

namespace fitnessclass.Services
{
    public interface IRegistrationService
    {
        Task RegisterForClass(int classId, string memberName, string memberEmail);
    }
}
