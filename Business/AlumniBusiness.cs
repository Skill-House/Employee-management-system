using DataAccess;
using DataAccess.Entities;

namespace Business
{
    public class AlumniBusiness
    {
        private readonly AlumniRepository alumniRepository;
        public AlumniBusiness()
        {
            this.alumniRepository = new AlumniRepository();
        }

        public async Task<Alumnus> GetAlumnusAsync(int Id)
        {
            var alumnus = await alumniRepository.GetById(Id);
            return alumnus;
        }
    }
}