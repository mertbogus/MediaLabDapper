﻿using MediLabDapper.Dtos.DoctorDtos;
using MediLabDapper.Repositories.DepartmentRepositories;
using MediLabDapper.Repositories.DoctorRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace MediLabDapper.Controllers
{
    public class DoctorController(IDoctorRepository _doctorRepository, IDepartmentRepository _departmentRepository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var doctors = await _doctorRepository.GetDoctorsWithDepartmentAsync();
            return View(doctors);
        }

        public async Task<IActionResult> DeleteDoctor(int id)
        {
            await _doctorRepository.DeleteDoctorAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CreateDoctor()
        {
            var departments = await _departmentRepository.GetAllDepartmentAsync();
            ViewBag.Departments = (from x in departments
                                   select new SelectListItem
                                   {
                                       Text = x.DepartmentName,
                                       Value = x.DepartmentId.ToString()
                                   }).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctor( CreateDoctorDto createDoctorDto)
        {
            await _doctorRepository.CreateDoctorAsync(createDoctorDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateDoctor(int id)
        {
            var departments = await _departmentRepository.GetAllDepartmentAsync();
            ViewBag.Departments = (from x in departments
                                   select new SelectListItem
                                   {
                                       Text = x.DepartmentName,
                                       Value = x.DepartmentId.ToString()
                                   }).ToList();
            var doctor= await _doctorRepository.GetByIdDoctorAsync(id);
            return View (doctor);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDoctor(UpdateDoctorDto updateDoctorDto)
        {
            await _doctorRepository.UpdateDoctorAsync(updateDoctorDto);
            return RedirectToAction(nameof(Index));
        }

    }
}
