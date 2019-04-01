// -------------------------------------------------------------------------------------------------------------------------
// <copyright file="ValuesController.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator name="Aniket Kamble"/>
// ---------------------------------------------------------------------------------------------------------------------------
namespace EmployeeData.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        /*ublic ActionResult Index()
         {
             return View;
         }*/
        /// <summary>
        /// Get method
        /// </summary>
        /// <returns></returns>
        //// GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// Get method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //// GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// Post method
        /// </summary>
        /// <param name="value"></param>
        //// POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        /// <summary>
        /// Put method
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        //// PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        /// <summary>
        /// Delete method
        /// </summary>
        /// <param name="id"></param>
        //// DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}