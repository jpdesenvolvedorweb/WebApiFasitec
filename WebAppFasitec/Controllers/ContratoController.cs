using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAppFasitec.Entities;
using WebAppFasitec.Repository;
using WebAppFasitec.Trade;

namespace WebAppFasitec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratoController : ControllerBase
    {
        private readonly IUnitOfWork _context;

        public ContratoController(IUnitOfWork context)
        {
            _context = context;
        }

        // GET: api/Contrato
        [HttpGet]
        public ActionResult<IEnumerable<Contrato>> Get()
        {
            try
            {
                return _context.ContratoRepository.Get().ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar obter os contratos no sistema!!!");
            }
            
        }

        // GET: api/Contrato/5
        [HttpGet("{id}", Name ="ObterContrato")]
        public ActionResult<Contrato> Get(int id)
        {
            try
            {
                var contrato = _context.ContratoRepository.GetById(p => p.IdContrato == id);
                if (contrato == null)
                    return NotFound($"O contrato com o id = {id} não foi encontrado no sistema!!!");
                return contrato;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar obter o contrato no sistema!!!");
            }
           
        }

        // POST: api/Contrato
        [HttpPost]
        public ActionResult Post([FromBody] Contrato contrato)
        {
            try
            {
                _context.ContratoRepository.Add(contrato);
                _context.Commit();

                int cod = contrato.IdContrato;
                var pessoa = _context.PessoaRepository.GetById(p => p.IdPessoa == contrato.IdPessoa);
                ContratoTrade.Oper(cod, contrato, pessoa);

                _context.ParcelaRepository.AddRange(ContratoTrade.parcelas());
                _context.Commit();
                
                return new CreatedAtRouteResult("ObterContrato", new { id = cod }, contrato);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar criar o contrato no sistema!!!");
            }
        }

        // PUT: api/Contrato/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Contrato contrato)
        {
            try
            {
                if (id != contrato.IdContrato)
                    return BadRequest($"Não é possível atualizar o contrato com o id = {id}!!!");

                _context.ContratoRepository.Update(contrato);
                _context.Commit();
                return Ok($"Contrato com o id = {id} foi atualizado com sucesso!!!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar o contrato com o id = {id} no sistema!!!");
            }
           
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Contrato> Delete(int id)
        {
            try
            {
                var contrato = _context.ContratoRepository.GetById(p => p.IdContrato == id);

                if (contrato == null)
                    return NotFound($"O contrato com o id = {id} não foi encontrado!!!");

                _context.ContratoRepository.Delete(contrato);
                _context.Commit();
                return contrato;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao excluir o contrato com o id = {id}!!!");
            }
           
        }
    }
}
