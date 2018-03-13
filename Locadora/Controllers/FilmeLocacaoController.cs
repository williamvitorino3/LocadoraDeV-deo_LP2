using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using WebApi.Models;

namespace Locadora.Controllers
{
    [Route("api/[controller]")]
    public class FilmeLocacaoController : Controller
    {
        private DataContext api;

        public FilmeLocacaoController(DataContext dataContext)
        {
            this.api = dataContext;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<FilmeLocacao> Get()
        {
            return this.api.Set<FilmeLocacao>();
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]FilmeLocacao body)
        {
            if(body != null)
            {
                this.api.Set<FilmeLocacao>().Add(body);
                this.api.SaveChanges();
                return new ObjectResult(body);
            }
            return NotFound();
        }

        [HttpGet("{id}", Name = "GetFilmeLocacao")]
        public IActionResult GetById(long id)
        {
            var item = this.api.FilmeLocacoes.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] FilmeLocacao item)
        {
            if (item == null || item.Id != id)
                return BadRequest();

            var filmeLocacao = this.api.FilmeLocacoes.FirstOrDefault(t => t.Id == id);
            if (filmeLocacao == null)
                return NotFound();

            filmeLocacao = item;

            this.api.FilmeLocacoes.Update(filmeLocacao);
            this.api.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = this.api.FilmeLocacoes.FirstOrDefault(t => t.Id == id);
            if(todo == null)
                return NotFound();
            
            this.api.FilmeLocacoes.Remove(todo);
            this.api.SaveChanges();
            return new NoContentResult();
        }
    }
}
