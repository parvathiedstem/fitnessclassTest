using fitnessclass.Data;
using fitnessclass.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Linq;


namespace fitnessclass.Repositories
{
    public class FitnessClassRepository : IFitnessClassRepository
    {
        private readonly FitnessDbContext _context;

        public FitnessClassRepository(FitnessDbContext context)
        {
            _context = context;
        }

        public async Task<FitnessClass> AddClassAsync(FitnessClass fitnessClass)
        {
            _context.FitnessClasses.Add(fitnessClass);
            await _context.SaveChangesAsync();
            return fitnessClass;
        }

        public async Task<FitnessClass> GetClassByIdAsync(int id)
        {
            return await _context.FitnessClasses.FindAsync(id);
        }
        
        public async Task<IEnumerable<FitnessClass>> GetAvailableClasses(DateTime startDate, DateTime endDate, string instructor, string className)
        {
            var startdate = DateTime.SpecifyKind(startDate, DateTimeKind.Utc);
            var enddate = DateTime.SpecifyKind(endDate, DateTimeKind.Utc);

            return await _context.FitnessClasses
                .Where(fc => fc.DateTime >= startdate && fc.DateTime <= enddate)
                .Where(fc =>fc.Instructor == instructor)
                .Where(fc =>fc.ClassName == className)
                .ToListAsync();
        }
   
    }
}
