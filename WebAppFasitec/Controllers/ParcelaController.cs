using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAppFasitec.Entities;
using WebAppFasitec.Repository;

namespace WebAppFasitec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParcelaController : ControllerBase
    {
        private readonly IUnitOfWork _context;

        public ParcelaController(IUnitOfWork context)
        {
            _context = context;
        }

        // GET: api/Parcela
        [HttpGet]
        public  ActionResult<IEnumerable<Parcela>> Get()
        {
            try
            {
                return _context.ParcelaRepository.Get().ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar obter as parcelas no sistema!!!");
            }
        }

        // GET: api/Parcela/5
        [HttpGet("{id}", Name = "ObterParcela")]
        public ActionResult<Parcela> Get(int id)
        {
            try
            {
                var parcela = _context.ParcelaRepository.GetById(p => p.IdParcela == id);

                if (parcela == null)
                    return NotFound($"A parcela com o id = {id} não foi encontrada no sistema!!!");
                return parcela;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar obter a parcela no sistema!!!");
            }  
        }

        // POST: api/Parcela
        [HttpPost]
        public ActionResult Post([FromBody] Parcela parcela)
        {
            try
            {
                _context.ParcelaRepository.Add(parcela);
                _context.Commit();

                int cod = parcela.IdParcela;

                return new CreatedAtRouteResult("ObterParcela", new { id = cod }, parcela);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar criar a parcela no sistema!!!");
            }
          
            
        }

        // PUT: api/Parcela/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Parcela parcela)
        {
            try
            {
                if (id != parcela.IdParcela)
                    return BadRequest($"Não é possível atualizar a parcela com id = {id}!!!");

                _context.ParcelaRepository.Update(parcela);
                _context.Commit();
                return Ok($"Parcela com id = {id} foi atualizada com sucesso!!!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar a parcela com o id = {id} no sistema!!!");
            }
            
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Parcela> Delete(int id)
        {
            var parcela = _context.ParcelaRepository.GetById(p => p.IdParcela == id);

            if (parcela == null)
                return NotFound();

            _context.ParcelaRepository.Delete(parcela);
            _context.Commit();
            return parcela;
        }
    }
}
