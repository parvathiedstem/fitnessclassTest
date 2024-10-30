using fitnessclass.Data;
using fitnessclass.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fitnessclass.Repositories
{
    public class FitnessClassRepository : IFitnessClassRepository
    {
        private readonly FitnessDbContext _context;

        public FitnessClassRepository(FitnessDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FitnessClass>> GetAvailableClasses(DateTime? startDate, DateTime? endDate, string instructor, string className)
        {
            var query = _context.FitnessClasses.AsQueryable();

            if (startDate.HasValue)
                query = query.Where(c => c.DateTime >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(c => c.DateTime <= endDate.Value);

            if (!string.IsNullOrEmpty(instructor))
                query = query.Where(c => c.Instructor == instructor);

            if (!string.IsNullOrEmpty(className))
                query = query.Where(c => c.ClassName == className);

            return await query.ToListAsync();
        }
    }
}
