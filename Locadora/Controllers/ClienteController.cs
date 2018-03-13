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

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Cliente item)
        {
            if (item == null || item.Id != id)
                return BadRequest();

            var cliente = this.api.Clientes.FirstOrDefault(t => t.Id == id);
            if (cliente == null)
                return NotFound();

            cliente.Nome = item.Nome;
            cliente.Telefone = item.Telefone;

            this.api.Clientes.Update(cliente);
            this.api.SaveChanges();
            return new ObjectResult(cliente);
        }

        [HttpGet("{id}", Name = "GetCliente")]
        public IActionResult GetById(long id)
        {
            var item = this.api.Clientes.FirstOrDefault(t => t.Id == id);
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

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = this.api.Clientes.FirstOrDefault(t => t.Id == id);
            if(todo == null)
                return NotFound();
            
            this.api.Clientes.Remove(todo);
            this.api.SaveChanges();
            return new NoContentResult();
        }
    }
}
