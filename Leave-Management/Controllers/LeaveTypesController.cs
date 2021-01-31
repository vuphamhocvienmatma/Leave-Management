using AutoMapper;
using Leave_Management.Contracts;
using Leave_Management.Data;
using Leave_Management.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management.Controllers
{
    public class LeaveTypesController : Controller
    {
        private readonly ILeaveTypeRepository _repo;
        private readonly IMapper _mapper;

        public LeaveTypesController(ILeaveTypeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: LeaveTypesController
        public ActionResult Index()
        {
            var leaveType = _repo.FindAll();
            var model = _mapper.Map<List<LeaveType>, List<LeaveTypeVM>>((List<LeaveType>)leaveType);
            return View(model);
        }

        // GET: LeaveTypesController/Details/5
        public ActionResult Details(int id)
        {
            if (_repo.isExsits(id))
            {
                var oldmodel = _repo.FindById(id);
                var model = _mapper.Map<LeaveTypeVM>(oldmodel);
                return View(model);
            }
            else
                return NotFound();
        }

        // GET: LeaveTypesController/Create
        public ActionResult Create()
        {
            LeaveTypeVM model = new LeaveTypeVM();
            return View(model);
        }

        // POST: LeaveTypesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LeaveTypeVM model)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return View(model);
                }
                var leaveType = _mapper.Map<LeaveType>(model);
                leaveType.DateCreated = DateTime.Now;
                var isSuccess = _repo.Create(leaveType);
                if(!isSuccess)
                {
                    ModelState.AddModelError("", "Something went Wrong ...");
                }    
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Something went Wrong ...");
                return View(ex);
            }
            
        }

        // GET: LeaveTypesController/Edit/5
        public ActionResult Edit(int id)
        {
            if (_repo.isExsits(id))
            {
                var oldmodel = _repo.FindById(id);
                var model = _mapper.Map<LeaveTypeVM>(oldmodel);
                return View(model);
            }
            else
                return NotFound();          
        }

        // POST: LeaveTypesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LeaveTypeVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var leaveType = _mapper.Map<LeaveType>(model);
                leaveType.DateCreated = DateTime.Now;
                var isSuccess = _repo.Update(leaveType);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something went Wrong ...");
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went Wrong ...");
                return View(model);
            }
        }

        // GET: LeaveTypesController/Delete/5
        public ActionResult Delete(int id)
        {
            if (_repo.isExsits(id))
            {
                var oldmodel = _repo.FindById(id);
                var model = _mapper.Map<LeaveType>(oldmodel);
                _repo.Delete(model);
                return RedirectToAction(nameof(Index));
            }
            else
                return NotFound();
        }

        // POST: LeaveTypesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
