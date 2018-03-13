using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using WebApi.Models;

namespace Locadora.Controllers
{
    [Route("api/[controller]")]
    public class LocacaoController : Controller
    {
        private DataContext api;

        public LocacaoController(DataContext dataContext)
        {
            this.api = dataContext;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Locacao> Get()
        {
            return this.api.Set<Locacao>();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Locacao body)
        {
            if(body != null)
            {
                this.api.Set<Locacao>().Add(body);
                this.api.SaveChanges();
            }
        }

        [HttpGet("{id}", Name = "GetLocacao")]
        public IActionResult GetById(long id)
        {
            var item = this.api.Locacoes.FirstOrDefault(t => t.Id == id);
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
            var todo = this.api.Locacoes.FirstOrDefault(t => t.Id == id);
            if(todo == null)
                return NotFound();
            
            this.api.Locacoes.Remove(todo);
            this.api.SaveChanges();
            return new NoContentResult();
        }
    }
}
