using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PJYAAC_SG1_21_22_2.Logic.Interfaces;
using PJYAAC_SG1_21_22_2.Models.DTOs;
using PJYAAC_SG1_21_22_2.Models.Entities;
using PJYAAC_SG1_21_22_2.Models.Models;

namespace PJYAAC_SG1_21_22_2.Endpoint.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BicycleController : ControllerBase
    {
        readonly IBicycleLogic bicycleLogic;

        public BicycleController(IBicycleLogic bicycleLogic)
        {
            this.bicycleLogic = bicycleLogic;
        }

        // GET: api/Bicycle/GetAll
        [HttpGet]
        [ActionName("GetAll")]
        public IEnumerable<Bicycle> Get()
        {
            return bicycleLogic.ReadAll();
        }

        // GET api/Bicycle/Get/5
        [HttpGet("{id}")]
        public Bicycle Get(int id)
        {
            return bicycleLogic.Read(id);
        }

        // POST api/Bicycle/Create
        [HttpPost]
        [ActionName("Create")]
        public ApiResult Post(BicycleDTO bicycle)
        {
            var result = new ApiResult(true);

            try
            {
                bicycleLogic.Create(new Bicycle()
                {
                    Id = bicycle.Id,
                    Model = bicycle.Model,
                    Type = bicycle.Type,
                    Color = bicycle.Color,
                    DateOfPurchase = bicycle.DateOfPurchase,
                    IsElectric = bicycle.IsElectric,
                    IsFullSuspension = bicycle.IsFullSuspension,
                    Price = bicycle.Price
                });
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.ExceptionMessages = new List<string>() { e.Message };
            }

            return result;
        }

        // PUT api/Bicycle/Update
        [HttpPut]
        [ActionName("Update")]
        public ApiResult Put(BicycleDTO bicycle)
        {
            var result = new ApiResult(true);

            try
            {
                bicycleLogic.Update(new Bicycle()
                {
                    Id = bicycle.Id,
                    Model = bicycle.Model,
                    Type = bicycle.Type,
                    Color = bicycle.Color,
                    DateOfPurchase = bicycle.DateOfPurchase,
                    IsElectric = bicycle.IsElectric,
                    IsFullSuspension = bicycle.IsFullSuspension,
                    Price = bicycle.Price
                });
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.ExceptionMessages = new List<string>() { e.Message };
            }

            return result;
        }

        // DELETE api/Bicycle/Delete/5
        [HttpDelete("{id}")]
        public ApiResult Delete(int id)
        {
            var result = new ApiResult(true);

            try
            {
                bicycleLogic.Delete(id);
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.ExceptionMessages = new List<string>() { e.Message };
            }

            return result;
        }
    }
}