using MarvelPaschoalotto.Models;
using MarvelPaschoalotto.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvelPaschoalotto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarvelController : ControllerBase
    {
        private readonly IMarvel _marvelRepository;
        public MarvelController(IMarvel repository) 
        {
            _marvelRepository = repository;
        }


        /// <summary>
        /// Retorna uma lista com as informações dos personagens Marvel.
        /// </summary>
        /// <response code="200">A requisição foi concluída! Verifique o arquivo "personagensmarvel.txt"</response>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Marvel> retorno;
            try
            {
                retorno = await _marvelRepository.GetList();
                return Ok("Ok!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// Retorna os dados individuais de um personagem Marvel.
        /// </summary>
        /// <param name="id">ID do personagem Marvel</param>
        /// <response code="400">A requisição não foi concluída, verifique o parâmetro informado</response>
        /// <response code="200">A requisição foi concluída! Verifique o arquivo "personagensmarvel.txt"</response>
        /// <returns>Uma personagem Marvel, e suas informações</returns>
        [HttpGet,Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Marvel retorno;
            try
            {
                retorno = await _marvelRepository.Get(id);
                return Ok("Ok!");
            }
            catch (Exception e)
            {
                return BadRequest("Verifique o parâmetro inserido!");
            }
        }


    }
}
