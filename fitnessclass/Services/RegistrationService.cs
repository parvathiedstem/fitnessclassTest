using System;
using System.Threading.Tasks;
using fitnessclass.Models;
using fitnessclass.Models;
using fitnessclass.Repositories;
using FitnessClassScheduling.Repositories;

namespace fitnessclass.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IRegistrationRepository _repository;
        private readonly IFitnessClassRepository _classRepository;

        public RegistrationService(IRegistrationRepository repository, IFitnessClassRepository classRepository)
        {
            _repository = repository;
            _classRepository = classRepository;
        }

        public async Task RegisterForClass(int classId, string memberName, string memberEmail)
        {
            var fitnessClass = await _classRepository.GetAvailableClasses( DateTime.Now,null, null, null);
            if (fitnessClass == null) throw new Exception("Class not found");

            if (!await _repository.HasCapacity(classId)) throw new Exception("Class is full");


            var registration = new Registration
            {
                ClassId = classId,
                MemberName = memberName,
                MemberEmail = memberEmail,
                RegistrationTime = DateTime.Now
            };

            await _repository.AddRegistration(registration);
            await _repository.SaveChangesAsync();
        }

    }
}
