using System.Threading.Tasks;
using CadastroUsuarios.Dominio;
using CadastroUsuarios.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;

namespace CadastroUsuarios.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {

        private readonly ICadastroUsuarioRepositorio _repo;

        public UsuarioController(ICadastroUsuarioRepositorio repo)
        {
            _repo = repo;
        }
        // GET api/usuario
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var resultado = await _repo.GetTodosUsuarios();
                return Ok(resultado);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET api/usuario/5
        [HttpGet("{id}")]
        public  IActionResult Get(int id)
        {
            try
            {
                var resultado =  _repo.GetUsuario(id);
                return Ok(resultado);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST api/usuario
        [HttpPost]        
        public async Task<IActionResult> Post([FromBody]Usuario model)
        {

            try
            {

                model.ValidarDataNascimento();

                _repo.Add(model);

                if (await _repo.SaveChangesAsync())
                    return Ok(model);
                else
                    return BadRequest();

            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }            

        }

        // PUT api/usuario/5
        [HttpPut("{UsuarioId}")]
       public async Task<IActionResult> Put([FromBody]Usuario model,int Id)
        {

            try
            {
                _repo.Update(model);

                if (await _repo.SaveChangesAsync())
                    return Ok();
                else
                    return BadRequest();

            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }            

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var usuario = _repo.GetUsuario(id);
                
                _repo.Delete(usuario);

                 if (await _repo.SaveChangesAsync())
                    return Ok();
                else
                    return BadRequest();
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


    }
}