﻿using AlkemyUmsa.DTOs;
using AlkemyUmsa.Entities;
using AlkemyUmsa.Helper;
using AlkemyUmsa.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlkemyUmsa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        /// <summary>
        ///  Obtengo todos los roles
        /// </summary>
        /// <returns>devuelde todos los roles</returns>

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetAll()
        {
            var Roles = await _unitOfWork.RoleRepository.GetAll();

            return Roles;
        }



        [HttpPost]
        [Route("Role")]
        public async Task<IActionResult> Insert(RoleDto dto)
        {
           
            var Role = new Role(dto);
            await _unitOfWork.RoleRepository.Insert(Role);
            await _unitOfWork.Complete();
            return Ok(true);
        }

        [Authorize(Policy = "Admin")]
        [HttpPut("{id}")]
  
        public async Task<IActionResult> Update([FromRoute] int id, Role role)
        {
        var result = await _unitOfWork.RoleRepository.Update(role);
           
            await _unitOfWork.Complete();
            return Ok(true);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _unitOfWork.RoleRepository.Delete(id);

            await _unitOfWork.Complete();
            return Ok(true);
        }

    }
}
