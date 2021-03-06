﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ODASApp.Manager;
using ODASApp.Models;

namespace ODASApp.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        private DrRegistrationManager aManager=new DrRegistrationManager();
        public ActionResult Index()
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("Home", "Home");
                ;
            }
            return View();
        }
        public ActionResult DoctorIndex()
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("Home", "Home");
                ;
            }
            List<DrRegistration> aList = aManager.GetAll();
            return View(aList);
        }
        public ActionResult PatientIndex()
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("Home", "Home");
                ;
            }
            List<PtRegistration> aRegistrations = aManager.GetAllPatient();
            return View(aRegistrations);
        }
        public ActionResult Details(int? id)
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("Home", "Home");
                ;
            }
            DrRegistration aRegistration = aManager.Get(id);
            return View(aRegistration);
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("Home", "Home");
                ;
            }
            DrRegistration aRegistration = aManager.Get(id);
            return View(aRegistration);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int? id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int message = aManager.Delete(id);
                    if (message > 0)
                    {
                        ViewBag.showMsg = "Deleted Successfully";
                    }
                    else
                    {
                        ViewBag.showMsg = "failed to Delete! please try again";
                    }
                }
            }
            catch (Exception exception)
            {
                ViewBag.showMsg = exception.Message;

            }
            return View();
        }
        public ActionResult PatientDetails(int? id)
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("Home", "Home");
                ;
            }
            PtRegistration aRegistration = aManager.GetPatient(id);
            return View(aRegistration);
        }
        [HttpGet]
        public ActionResult PatientDelete(int? id)
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("Home", "Home");
                ;
            }
            PtRegistration aRegistration = aManager.GetPatient(id);
            return View(aRegistration);
        }
        [HttpPost]
        [ActionName("PatientDelete")]
        public ActionResult ConfirmPatientDelete(int? id)
        {
            try
            {
                int message = aManager.PtDelete(id);

                if (message > 0)
                {
                    ViewBag.showMsg = "Deleted Successfully";
                }
                else
                {
                    ViewBag.showMsg = "failed to Delete! please try again";
                }
            }
            catch (Exception exception)
            {
                ViewBag.showMsg = exception.Message;

            }

            return View();
        }
	}
}