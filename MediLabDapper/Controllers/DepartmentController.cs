﻿using MediLabDapper.Dtos.DepartmentDtos;
using MediLabDapper.Repositories.DepartmentRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MediLabDapper.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<IActionResult> Index()
        {
            var departments = await _departmentRepository.GetAllDepartmentAsync();
            return View(departments);
        }

        public async Task<IActionResult> DeleteDepartment(int id)
        {
            await _departmentRepository.DeleteDepartmentAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CreateDepartment()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateDepartment(CreateDepartmentDto createDepartmentDto)
        {
            await _departmentRepository.CreateDepartmentAsync(createDepartmentDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateDepartment(int id)
        {
            var department= await _departmentRepository.GetDepartmenByIdAsync(id);
            return View(department);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDepartment(UpdateDepartmentDto updateDepartmentDto)
        {
            await _departmentRepository.UpdateDepartmentAsync(updateDepartmentDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
