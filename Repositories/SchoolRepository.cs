using School.Models;

namespace School.Repositories
{
    public class SchoolRepository
    {
        readonly EntityContext context;
        public SchoolRepository(EntityContext context)
        {
            this.context = context;
        }
        public  List<School.Models.School> GetAll()
        {
            return context.schools.ToList();
        }
    }
}
