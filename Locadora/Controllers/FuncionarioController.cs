using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using WebApi.Models;

namespace Locadora.Controllers
{
    [Route("api/[controller]")]
    public class FuncionarioController : Controller
    {

        private DataContext api;

        public FuncionarioController(DataContext dataContext)
        {
            this.api = dataContext;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Funcionario> Get()
        {
            return this.api.Set<Funcionario>();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Funcionario body)
        {
            if(body != null)
            {
                this.api.Set<Funcionario>().Add(body);
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
