using fitnessclass.Models;
using fitnessclass.Data;
using fitnessclass.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using FitnessClassScheduling.Repositories;

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


        public async Task AddRegistration(Registration registration) 
        {
            _context.Registrations.Add(registration);
            var fitnessClass = await _context.FitnessClasses.FindAsync(registration.ClassId);
            if (fitnessClass != null) fitnessClass.AvailableSpots--;
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
