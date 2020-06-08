using ApiSalaPrueba.Web.Data;
using ApiSalaPrueba.Web.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSalaPrueba.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalasController : ControllerBase
    {
        private readonly ApiContext context;

        public SalasController(ApiContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Sala>> Get()
        {
            return context.Salas.ToList();
        }

        [HttpGet("{Id}", Name = "ObtenerSalaPorId")]
        public ActionResult<Sala> Get(int id)
        {
            var sala = context.Salas.FirstOrDefault(p => p.Id == id);
            if (sala == null)
            {
                return NotFound();
            }
            return sala;
        }

        [HttpPost]
        public ActionResult<Sala> Post([FromBody] Sala sala)
        {
            context.Salas.Add(sala);
            context.SaveChanges();

            //return sala;

            return new CreatedAtRouteResult("ObtenerSalaPorId", new { id = sala.Id }, sala);
        }

        [HttpPut("{Id}")]
        public ActionResult<Sala> Put(int id, [FromBody] Sala sala)
        {
            if (id != sala.Id)
            {
                return BadRequest();
            }

            context.Entry(sala).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{Id}")]
        public ActionResult<Sala> Delete(int id)
        {
            var sala = context.Salas.FirstOrDefault(p => p.Id == id);
            if (sala == null)
            {
                return NotFound();
            }
            context.Salas.Remove(sala);
            context.SaveChanges();
            return Ok();
        }




    }
}
