﻿using GameHall.Model;
using GameHall.Service;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;


namespace GameHall.Controller
{
    [Route("~/produtos")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        private readonly IValidator<Produto> _produtoValidator;
        public ProdutoController(
            IProdutoService produtoService,
            IValidator<Produto> produtoValidator 
            )
        {
            _produtoService = produtoService;
            _produtoValidator = produtoValidator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _produtoService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(long id)
        {
            var Resposta = await _produtoService.GetById(id);

            if(Resposta is null)
            {
                return NotFound();
            }

            return Ok(Resposta);
        }

        [HttpGet("nome/{nome}")]
        public async Task<ActionResult> GetByNome(string nome)
        {
            return Ok(await _produtoService.GetByNome(nome));
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Produto produto)
        {
            var validarProduto = await _produtoValidator.ValidateAsync(produto);

            if (!validarProduto.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, validarProduto);

            var Resposta = await _produtoService.Create(produto);

            if (Resposta is null)
                return BadRequest("Categoria não encontrada!");

            return CreatedAtAction(nameof(GetById), new {id = produto.Id}, produto);
        }
        //
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Produto produto)
        {
            if(produto.Id == 0)
                return BadRequest("Id do game inválido!");

            var validarProduto = await _produtoValidator.ValidateAsync(produto);

            if (!validarProduto.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, validarProduto);

            var Resposta = _produtoService.Update(produto);

            if (Resposta is null)
                return NotFound("Game e/ou Categoria não encontrados!");

            return Ok(Resposta);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var BuscaProduto = await _produtoService.GetById(id);

            if (BuscaProduto is null)
                return NotFound("Produto não encontrado!");

            await _produtoService.Delete(BuscaProduto);

            return NoContent();
        }

    }
}
