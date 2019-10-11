﻿using Exercises.Models.Data;
using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercises.Controllers
{
    public class AdminController : Controller
    {

        [HttpGet]
        public ActionResult Majors()
        {
            var model = MajorRepository.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddMajor()
        {

            return View(new Major());
        }

        [HttpPost]
        public ActionResult AddMajor(Major major)
        {
            if (string.IsNullOrEmpty(major.MajorName))
            {
                ModelState.AddModelError("", "Major name is a required field.");
                return View("AddMajor", major);
            }
            else
            {
                MajorRepository.Add(major.MajorName);
                return RedirectToAction("Majors");
            }
        }

        [HttpGet]
        public ActionResult EditMajor(int id)
        {
            var major = MajorRepository.Get(id);
            return View(major);
        }

        [HttpPost]
        public ActionResult EditMajor(Major major)
        {

            if (string.IsNullOrEmpty(major.MajorName))
            {
                ModelState.AddModelError("", "Major name is a required field.");
                return View("EditMajor", major);
            }
            else
            {

                MajorRepository.Edit(major);
                return RedirectToAction("Majors");
            }
        }

        [HttpGet]
        public ActionResult DeleteMajor(int id)
        {
            var major = MajorRepository.Get(id);
            return View(major);
        }

        [HttpPost]
        public ActionResult DeleteMajor(Major major)
        {
            MajorRepository.Delete(major.MajorId);
            return RedirectToAction("Majors");
        }

        [HttpGet]
        public ActionResult States()
        {
            var model = StateRepository.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddState()
        {
            return View(new State());
        }

        [HttpPost]
        public ActionResult AddState(State state)
        {
            if (string.IsNullOrEmpty(state.StateAbbreviation))
            {
                ModelState.AddModelError("", "You must enter state abbreviation.");

                if (string.IsNullOrEmpty(state.StateName))
                {
                    ModelState.AddModelError("", "You must enter state name.");
                }

                return View("AddState", state);
            }

            else
            {
                StateRepository.Add(state);
                return RedirectToAction("States");
            }

        }


        [HttpGet]
        public ActionResult EditState(string id)
        {
            var state = StateRepository.Get(id);
            return View(state);
        }

        [HttpPost]
        public ActionResult EditState(State state)
        {
            if (string.IsNullOrEmpty(state.StateName))
            {
                ModelState.AddModelError("", "Must enter state name.");
                return View("EditState", state);
            }

            else
            {
                StateRepository.Edit(state);
                return RedirectToAction("States");
            }

        }

        [HttpGet]
        public ActionResult DeleteState(string id)
        {
            var state = StateRepository.Get(id);

            return View(state);
        }

        [HttpPost]
        public ActionResult DeleteState(State state)
        {
            StateRepository.Delete(state.StateAbbreviation);

            return RedirectToAction("States");
        }


        [HttpGet]
        public ActionResult Courses()
        {
            var model = CourseRepository.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddCourse()
        {
            return View(new Course());
        }

        [HttpPost]
        public ActionResult AddCourse(Course course)
        {
            if (string.IsNullOrEmpty(course.CourseName))
            {
                ModelState.AddModelError("", "You must enter course name.");
                return View("AddCourse", course);
            }
            else
            {
                CourseRepository.Add(course.CourseName);
                return RedirectToAction("Courses");
            }

        }

        [HttpGet]
        public ActionResult EditCourse(int id)
        {
            var course = CourseRepository.Get(id);
            return View(course);
        }

        [HttpPost]
        public ActionResult EditCourse(Course course)
        {
            if (string.IsNullOrEmpty(course.CourseName))
            {
                ModelState.AddModelError("", "You must enter course name");
                return View("EditCourse", course);

            }
            else
            {
                CourseRepository.Edit(course);
                return RedirectToAction("Courses");
            }

        }

        [HttpGet]
        public ActionResult DeleteCourse(int id)
        {
            var course = CourseRepository.Get(id);
            return View(course);
        }

        [HttpPost]
        public ActionResult DeleteCourse(Course course)
        {
            CourseRepository.Delete(course.CourseId);
            return RedirectToAction("Courses");
        }

    }
}