using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using WebApi.Models;

namespace Locadora.Controllers
{
    [Route("api/[controller]")]
    public class FilmeController : Controller
    {

        private DataContext api;

        public FilmeController(DataContext dataContext)
        {
            this.api = dataContext;
        }
        
        // GET api/values
        [HttpGet]
        public IEnumerable<Filme> Get()
        {
            return this.api.Set<Filme>();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Filme body)
        {
            if(body != null)
            {
                this.api.Set<Filme>().Add(body);
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
