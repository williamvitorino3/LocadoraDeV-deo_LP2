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

        [HttpGet("{id}", Name = "GetFuncionario")]
        public IActionResult GetById(long id)
        {
            var item = this.api.Funcionarios.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }


        // PUT api/values/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody]string value)
        // {
        // }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = this.api.Funcionarios.FirstOrDefault(t => t.Id == id);
            if(todo == null)
                return NotFound();
            
            this.api.Funcionarios.Remove(todo);
            this.api.SaveChanges();
            return new NoContentResult();
        }
    }
}
