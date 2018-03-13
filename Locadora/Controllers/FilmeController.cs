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

        [HttpGet("{id}", Name = "GetFilme")]
        public IActionResult GetById(long id)
        {
            var item = this.api.Filmes.FirstOrDefault(t => t.Id == id);
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
            var todo = this.api.Filmes.FirstOrDefault(t => t.Id == id);
            if(todo == null)
                return NotFound();
            
            this.api.Filmes.Remove(todo);
            this.api.SaveChanges();
            return new NoContentResult();
        }
    }
}
