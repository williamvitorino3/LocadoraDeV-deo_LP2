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
