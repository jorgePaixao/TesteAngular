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
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var resultado = await _repo.GetUsuario(id);
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
        [HttpPut("{Id}")]
        public async Task<IActionResult> Put([FromBody]Usuario model, int Id)
        {

            try
            {
                var usuario = await _repo.GetUsuario(Id);

                if (usuario == null) return NotFound();


                usuario.DataNascimento = model.DataNascimento;
                usuario.Email = model.Email;
                usuario.Escolaridade = model.Escolaridade;
                usuario.Nome = model.Nome;
                usuario.Sobrenome = model.Sobrenome;
                
                _repo.Update(usuario);

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
        [HttpDelete("{Id}")]

        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var usuario = await _repo.GetUsuario(Id);
                if (usuario == null) return NotFound();

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