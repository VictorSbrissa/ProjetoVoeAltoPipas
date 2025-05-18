using Microsoft.AspNetCore.Mvc;
using VoeAltoPipas.Application.DTO;
using VoeAltoPipas.Application.Interfaces;
using VoeAltoPipas.Domain.Entities;

namespace APIvoeAltoPipas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _produtoService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _produtoService.GetByIdAsync(id));
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] ProdutoDTO produtoDto)
        {
            if (produtoDto.Nome == null || produtoDto.Preco <= 0 || produtoDto.Descricao == null || produtoDto.Imagem == null)
            {
                return BadRequest("Dados inválidos.");
            }

            // Caminho para salvar a imagem
            var caminhoImagem = Path.Combine(Directory.GetCurrentDirectory(), "root", "imagens", produtoDto.Imagem.FileName);

            // Verifica se a pasta 'imagens' existe, se não, cria a pasta
            var diretorioImagens = Path.GetDirectoryName(caminhoImagem);
            if (!Directory.Exists(diretorioImagens))
            {
                Directory.CreateDirectory(diretorioImagens);
            }

            // Salvando a imagem na pasta desejada
            using (var stream = new FileStream(caminhoImagem, FileMode.Create))
            {
                await produtoDto.Imagem.CopyToAsync(stream);
            }

            produtoDto.ImagemUrl = "/imagens/" + produtoDto.Imagem.FileName;

            //return Ok(new { mensagem = "Produto cadastrado com sucesso!" });
            await _produtoService.AddAsync(produtoDto);
            return CreatedAtAction(nameof(GetById), new { id = produtoDto.Nome }, produtoDto);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProdutoDTO produtoDto)
        {
            await _produtoService.UpdateAsync(id, produtoDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _produtoService.DeleteAsync(id);
            return NoContent();
        }
    }
}
