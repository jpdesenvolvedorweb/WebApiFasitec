using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAppFasitec.Entities;
using WebAppFasitec.Repository;

namespace WebAppFasitec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaturaController : ControllerBase
    {
        
        private readonly IUnitOfWork _context;

        public FaturaController(UnitOfWork context)
        {
            _context = context;
        }

        // GET: api/Fatura
        [HttpGet]
        public ActionResult<IEnumerable<Fatura>> Get()
        {
            try
            {
                return _context.FaturaRepository.Get().ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar obter as faturas no sistema!!!");
            }
        }

        // GET: api/Fatura/5
        [HttpGet("{id}", Name ="ObterFatura")]
        public ActionResult<Fatura> Get(int id)
        {
            try
            {
                var fatura = _context.FaturaRepository.GetById(p => p.IdFatura == id);
                if (fatura == null)
                    return NotFound($"A fatura com o id = {id} não foi encontrada no sistema!!!");
                return fatura;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar obter a fatura no sistema!!!");
            }
           
        }

        // POST: api/Fatura
        [HttpPost]
        public ActionResult Post([FromBody] Fatura fatura)
        {
            try
            {
                _context.FaturaRepository.Add(fatura);
                _context.Commit();

                int cod = fatura.IdFatura;

                return new CreatedAtRouteResult("ObterFatura", new { id = cod }, fatura);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar criar a fatura no sistema!!!");
            }
        }

        // PUT: api/Fatura/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Fatura fatura)
        {
            try
            {
                if (id != fatura.IdFatura)
                    return BadRequest($"Não é possível atualizar a fatura com o id = {id}!!!");

                _context.FaturaRepository.Update(fatura);
                _context.Commit();
                return Ok($"Fatura com o id = {id} foi atualizada com sucesso!!!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar criar a fatura com o id = {id} no sistema!!!");
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Fatura> Delete(int id)
        {
            try
            {
                var fatura = _context.FaturaRepository.GetById(p => p.IdFatura == id);

                if (fatura == null)
                    return NotFound($"A fatura com o id = {id} não foi encontrada!!!");

                _context.FaturaRepository.Delete(fatura);
                _context.Commit();
                return fatura;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao excluir a fatura com o id = {id}!!!");
            }
           
        }
    }
}
