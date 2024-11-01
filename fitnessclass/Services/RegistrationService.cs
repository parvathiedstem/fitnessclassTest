
using fitnessclass.Models;
using fitnessclass.Repositories;

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
            var fitnessClass = await _classRepository.GetClassByIdAsync( classId);
            Console.WriteLine(fitnessClass);
            if (fitnessClass == null) throw new Exception("Class not found");

            if (!await _repository.HasCapacity(classId)) throw new Exception("Class is full");

            if (await _repository.MemberHasOverlappingClass(memberName, fitnessClass.DateTime)) throw new Exception("Member has overlapping class");

            if ((fitnessClass.DateTime - DateTime.Now).TotalHours < 1) throw new Exception("Registration must be 1 hour before class");



            var registration = new Registration
            {
                ClassId = classId,
                MemberName = memberName,
                MemberEmail = memberEmail,
                RegistrationTime = DateTime.Now.ToUniversalTime(),
                IsCanceled = false,
                CancellationReason = ""
            };

            await _repository.AddRegistration(registration);
            await _repository.SaveChangesAsync();
        }

        public async Task CancelRegistration(int registrationId, string cancellationReason)
        {
            var registration = await _repository.GetRegistrationById(registrationId);
            if (registration == null) throw new Exception("Registration not found");

            var fitnessClass = await _classRepository.GetClassByIdAsync(registration.ClassId);
            if ((fitnessClass.DateTime - DateTime.Now).TotalHours < 2) throw new Exception("Cannot cancel within 2 hours of class");

            await _repository.CancelRegistration(registration, cancellationReason);
            await _repository.SaveChangesAsync();
        }

    }
}
