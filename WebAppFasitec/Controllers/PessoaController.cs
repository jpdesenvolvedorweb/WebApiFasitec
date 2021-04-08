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
    public class PessoaController : ControllerBase
    {
        private readonly IUnitOfWork _context;

        public PessoaController(IUnitOfWork context)
        {
            _context = context;
        }

        // GET: api/Pessoa
        [HttpGet]
        public  ActionResult<IEnumerable<Pessoa>> Get()
        {
            try
            {
                return _context.PessoaRepository.Get().ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar obter as pessoas no sistema!!!");
            }
        }

        // GET: api/Pessoa/5
        [HttpGet("{id}", Name ="ObterPessoa")]
        public ActionResult<Pessoa> Get(int id)
        {
            try
            {
                var pessoa = _context.PessoaRepository.GetById(p => p.IdPessoa == id);
                if (pessoa == null)
                    return NotFound($"A pessoa com o id = {id} não foi encontrada no sistema!!!");
                return pessoa;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar obter a pessoa no sistema!!!");
            }
            
        }

        // POST: api/Pessoa
        [HttpPost]
        public ActionResult Post([FromBody] Pessoa pessoa)
        {
            try
            {
                _context.PessoaRepository.Add(pessoa);
                _context.Commit();

                int cod = pessoa.IdPessoa;

                return new CreatedAtRouteResult("ObterPessoa", new { id = cod }, pessoa);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar criar a pessoa no sistema!!!");
            }
        }

        // PUT: api/Pessoa/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Pessoa pessoa)
        {
            try
            {
                if (id != pessoa.IdPessoa)
                    return BadRequest($"Não foi possível atualizar a pessoa com o id = {id}!!!");

                _context.PessoaRepository.Update(pessoa);
                _context.Commit();
                return Ok($"Pessoa com o id = {id} foi atualizada com sucesso!!!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar a pessoa com id = {id} no sistema!!!");
            }
            
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Pessoa> Delete(int id)
        {
            try
            {
                var pessoa = _context.PessoaRepository.GetById(p => p.IdPessoa == id);

                if (pessoa == null)
                    return NotFound($"A pessoa com o id = {id} não foi encontrada!!!");

                _context.PessoaRepository.Delete(pessoa);
                _context.Commit();
                return pessoa;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao excluir a pessoa com id = {id}!!!");
            }
           
        }
    }
}
