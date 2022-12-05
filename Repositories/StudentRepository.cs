using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Models;

namespace School.Repositories
{
    public class StudentRepository
    {
         readonly EntityContext context;
        public StudentRepository(EntityContext _context)
        {
            context = _context;
        }
        public async Task<int> Create( Student student)
        {
            context.students.Add(student);
            int EffectedRaws = await  context.SaveChangesAsync();
            return EffectedRaws;
        }
         public  Task< Student> GetById(int id)
        {
            return context.students.Where(student => student.Id == id).FirstOrDefaultAsync();
             
        }
        public async Task<int> update(Student newstudent, int id)
        {
            var oldstudentobiect= await GetById(id);
            oldstudentobiect.Name = newstudent.Name;
            oldstudentobiect.Birthdate = newstudent.Birthdate;
            oldstudentobiect.age= newstudent.age;
            context.students.Update(oldstudentobiect);
            int EffectedRaws = await context.SaveChangesAsync();
            return EffectedRaws;
        }
        public async Task<int> Delete(int id)
        {
            var oldstudentobiect = await GetById(id);
            context.students.Remove(oldstudentobiect);
            int EffectedRaws = await context.SaveChangesAsync();
            return EffectedRaws;

        }

    }
}
