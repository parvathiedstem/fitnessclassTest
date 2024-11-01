using fitnessclass.Models;
using fitnessclass.Data;
using Microsoft.EntityFrameworkCore;
using fitnessclass.Repositories;

namespace fitnessclass.Repositories
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly FitnessDbContext _context;

        public RegistrationRepository(FitnessDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ClassExists(int classId) => 
            await _context.FitnessClasses.AnyAsync(c => c.Id == classId);

        public async Task<bool> HasCapacity(int classId) 
        {
            var fitnessClass = await _context.FitnessClasses.FindAsync(classId);
            return fitnessClass != null && fitnessClass.AvailableSpots > 0;
        }
        public async Task<bool> MemberHasOverlappingClass(string memberName, DateTime classDateTime) 
        
        {
            var classtime = DateTime.SpecifyKind(classDateTime, DateTimeKind.Utc);
            return await _context.Registrations.AnyAsync(r => r.MemberName == memberName && 
                r.RegistrationTime <= classtime && 
                classtime < r.RegistrationTime.AddHours(1));
        }


        public async Task AddRegistration(Registration registration) 
        {
            _context.Registrations.Add(registration);
            var fitnessClass = await _context.FitnessClasses.FindAsync(registration.ClassId);
            if (fitnessClass != null) fitnessClass.AvailableSpots--;
        }
        public async Task<Registration> GetRegistrationById(int registrationId) => 
            await _context.Registrations.FindAsync(registrationId);


        public async Task CancelRegistration(Registration registration, string reason) 
        {
            registration.IsCanceled = true;
            registration.CancellationReason = reason;

            var fitnessClass = await _context.FitnessClasses.FindAsync(registration.ClassId);
            if (fitnessClass != null) fitnessClass.AvailableSpots++;
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
