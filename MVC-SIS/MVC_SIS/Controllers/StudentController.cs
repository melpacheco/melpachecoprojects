using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercises.Models.Data;
using Exercises.Models.ViewModels;

namespace Exercises.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = StudentRepository.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new StudentVM();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentVM studentVM)
        {

            if (ModelState.IsValid)
            {
                studentVM.Student.Courses = new List<Course>();

                foreach (var id in studentVM.SelectedCourseIds)
                    studentVM.Student.Courses.Add(CourseRepository.Get(id));

                studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

                StudentRepository.Add(studentVM.Student);

                return RedirectToAction("List");
            }

            else
            {
                return View("Add", studentVM);
            }

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            StudentVM model = new StudentVM();

            var studentVM = StudentRepository.Get(id);

            model.Student.Major = new Major();

            model.Student.FirstName = studentVM.FirstName;
            model.Student.LastName = studentVM.LastName;
            model.Student.Major.MajorId = studentVM.Major.MajorId;
            model.Student.StudentId = studentVM.StudentId;
            model.Student.Courses = studentVM.Courses;
            model.Student.GPA = studentVM.GPA;
            model.SetCourseItems(CourseRepository.GetAll());
            model.SetMajorItems(MajorRepository.GetAll());

            model.Student.Address = new Address();
            model.Student.Address.AddressId = studentVM.Address.AddressId;
            model.Student.Address.Street1 = studentVM.Address.Street1;
            model.Student.Address.Street2 = studentVM.Address.Street2;
            model.Student.Address.City = studentVM.Address.City;
            model.Student.Address.State = studentVM.Address.State;
            model.Student.Address.PostalCode = studentVM.Address.PostalCode;


            return View(model);
        }




        [HttpPost]
        public ActionResult Edit(StudentVM model)
        {
            StudentVM student = new StudentVM();
            student.Student.FirstName = model.Student.FirstName;
            student.Student.LastName = model.Student.LastName;
            student.Student.StudentId = model.Student.StudentId;
            student.Student.Courses = model.Student.Courses;
            student.Student.GPA = model.Student.GPA;

            student.Student.Major = MajorRepository.Get(model.Student.Major.MajorId);
            

            student.Student.Address = new Address();
            student.Student.Address.AddressId = model.Student.Address.AddressId;
            student.Student.Address.Street1 = model.Student.Address.Street1;
            student.Student.Address.Street2 = model.Student.Address.Street2;
            student.Student.Address.City = model.Student.Address.City;
            student.Student.Address.State = model.Student.Address.State;
            student.Student.Address.PostalCode = model.Student.Address.PostalCode;

            

            if (ModelState.IsValid)
            {
                StudentRepository.SaveAddress(student.Student.Address.AddressId, student.Student.Address);
                StudentRepository.Edit(student.Student);
                return RedirectToAction("List");
            }

            else
            {

                model.SetCourseItems(CourseRepository.GetAll());
                model.SetMajorItems(MajorRepository.GetAll());

                return View("Edit", model);
            }


        }

        [HttpGet]
        public ActionResult Delete(int id)
        {

            var student = StudentRepository.Get(id);

            return View(student);
        }

        [HttpPost]
        public ActionResult Delete(Student student)
        {
            StudentRepository.Delete(student.StudentId);

            return RedirectToAction("List");
        }

    }



}
