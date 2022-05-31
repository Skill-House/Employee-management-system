using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AlumniRepository
    {
        private readonly AlumniManagementContext dbContext;
        public AlumniRepository()
        {
            this.dbContext = new AlumniManagementContext();
        }

        public async Task Create(Alumnus alumnus)
        {
            dbContext.Alumni.Add(alumnus);
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(Alumnus alumnus)
        {
            var existingAlumnus = dbContext.Alumni.Where(h => h.Id == alumnus.Id).FirstOrDefault();
            if (existingAlumnus != null)
            {
                existingAlumnus.FirstName = alumnus.FirstName; // update only changeable properties
                await this.dbContext.SaveChangesAsync();
            }
        }

        public async Task<Alumnus> GetById(int Id)
        {
            var alumnus = dbContext.Alumni.FirstOrDefault(e => e.Id == Id);
            return alumnus;
        }

        public async Task Delete(int alumnusId)
        {
            var alumnus = await GetById(alumnusId);
            if (alumnus != null)
            {
                dbContext.Alumni.Remove(alumnus);
            }
        }
    }
}
