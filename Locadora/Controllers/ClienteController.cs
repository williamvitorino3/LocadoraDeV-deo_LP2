using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using WebApi.Models;

namespace Locadora.Controllers
{
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private DataContext api;

        public ClienteController(DataContext dataContext)
        {
            this.api = dataContext;
        }

        // GET api/cliente
        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            return this.api.Set<Cliente>();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Cliente body)
        {
            if (body != null)
            {
                this.api.Set<Cliente>().Add(body);
                this.api.SaveChanges();
            }
        }

        // GET api/values/5
        // [HttpGet("{id}")]
        // public string Get(int id)
        // {
        //     return "value";
        // }

        // PUT api/values/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody]string value)
        // {
        // }

        // DELETE api/values/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}
