using Microsoft.AspNetCore.Mvc;
using School.Models;
using School.Repositories;

namespace School.Controllers
{
    public class StudentController : Controller
    {
        readonly StudentRepository _studentrepository;
        readonly SchoolRepository _schoolRepository;
        public StudentController(StudentRepository studentrepository, SchoolRepository schoolRepository)
        {
            _studentrepository = studentrepository;
            _schoolRepository = schoolRepository;
        }
        [HttpGet]
        public  async Task< IActionResult> New()
        {
            List<School.Models.School> schoollist =  _schoolRepository.GetAll();
            ViewData["schools"]=schoollist;
            return View(new Student());
        }
        [HttpPost]
        public async Task<IActionResult> SaveNew(Student newstudent)
        {
            if(ModelState.IsValid) {

                 await _studentrepository.Create(newstudent);
                return RedirectToAction("Index","Home");
            }
            
            return View("New",newstudent);
        }
        public  async Task< IActionResult> Edit(int id)
        {
            var student = await _studentrepository.GetById(id);
            List<School.Models.School> schoollist = _schoolRepository.GetAll();
            ViewData["schools"] = schoollist;
            return View("Edit", student);
        }




        public async Task <IActionResult> SaveEdit( Student NewStudent, int id)
        {
         
               await _studentrepository.update( NewStudent,id);
                return RedirectToAction("Index", "Home");
            
        }
        public async Task< IActionResult> GetDetails(int Id)
        {
            var student = await _studentrepository.GetById(Id);
            return View("GetDetails", student);
        }
        public async Task< IActionResult> Remove(int id)
        {
           await _studentrepository.Delete(id);
            return View("New");
        }

    }
}
