﻿using AutoMapper;
using CoreApp.DataService.Abstraction.Interfaces;
using CoreApp.Models.DataTransfer;
using CoreApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreApp.Web.Controllers.Api
{
    public class EntityBaseApiController<TViewModel, TDto> : ImsBaseApiController
        where TDto : DtoBase
        where TViewModel : BaseViewModel
    {
        private readonly IEntityService<TDto> _service;

        public IEntityService<TDto> EntityService => _service;

        public EntityBaseApiController(IEntityService<TDto> entityService)
        {
            _service = entityService;
        }

        protected async Task<IActionResult> GetAll()
        {

            return await ServiceCall(async entityService => {
                var dtos = await entityService.ListOfDtoAsync();
                var viewModels = Mapper.Map<IEnumerable<TViewModel>>(dtos);
                if (viewModels != null)
                {
                    return new ObjectResult(viewModels);
                }
                return NotFound();
            });

        }

        protected async Task<IActionResult> ServiceCall(Func<IEntityService<TDto>, Task<IActionResult>> action)
        {
            try
            {
                if (CurrentUserId != null) _service.CurrentUserId = CurrentUserId.Value;
                if (CurrentEmployeeId != null) _service.CurrentEmployeeId = CurrentEmployeeId.Value;
                return await action(_service);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ValidationError", ex.Message);
                return BadRequest(ModelState);
            }

        }
    }
}
