using Microsoft.AspNetCore.Mvc;

using teste.Models;
using teste.DTOs;
namespace teste.Controllers;

[ApiController]
[Route("[controller]")]

public class PessoaController : ControllerBase
{
    public readonly ILogger<PessoaController> _logger;
    public readonly IPessoaService _pessoaService;

    public PessoaController(ILogger<PessoaController> logger, IPessoaService pessoaService)
    {
        _logger = logger;
        _pessoaService = pessoaService;
    }

    [HttpGet]
    public string Home(){
        return "Você está perto das rotas de Pessoas.";
    }

    [HttpPost]
    public async Task<PessoaDTO> CriarPessoa(Pessoa pessoa)
    {
        var pessoaSalva = await _pessoaService.CriarPessoa(pessoa);
        return PessoaDTO.DePessoaParaDTO(pessoaSalva);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PessoaDTO?>> ConsultaId(int id){
        var pessoa = await _pessoaService.ConsultaId(id);
        if (pessoa == null) return NotFound();
        else return PessoaDTO.DePessoaParaDTO(pessoa);
    }

    [HttpGet("Todos")]
    public async Task<IEnumerable<PessoaDTO>> ConsultaTodos()
    {
        var pessoas = await _pessoaService.Listar();
        return PessoaDTO.DePessoasParaDTO(pessoas);

    }
    
}
