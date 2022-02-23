using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PJYAAC_SG1_21_22_2.Logic.Interfaces;
using PJYAAC_SG1_21_22_2.Models.Entities;

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

        // GET: api/Car/GetAll
        [HttpGet]
        [ActionName("GetAll")]
        public IEnumerable<Bicycle> Get()
        {
            return bicycleLogic.ReadAll();
        }

        // GET api/Car/Get/5
        [HttpGet("{id}")]
        public Bicycle Get(int id)
        {
            return bicycleLogic.Read(id);
        }

        // POST api/Car/Create
        [HttpPost]
        [ActionName("Create")]
        public IActionResult Post(Bicycle bicycle)
        {
            //var result = new ActionResult(true);

            try
            {
                bicycleLogic.Create(bicycle);
            }
            catch (Exception)
            {
                // result.IsSuccess = false;
            }

            return Ok();
        }

        // PUT api/Car/Update
        [HttpPut]
        [ActionName("Update")]
        public IActionResult Put(Bicycle bicycle)
        {
            //var result = new ApiResult(true);

            try
            {
                bicycleLogic.Update(bicycle);
            }
            catch (Exception)
            {
                //result.IsSuccess = false;
            }

            return Ok();
        }

        // DELETE api/Car/Delete/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //var result = new ApiResult(true);

            try
            {
                bicycleLogic.Delete(id);
            }
            catch (Exception)
            {
                //result.IsSuccess = false;
            }

            return Ok();
        }
    }
}