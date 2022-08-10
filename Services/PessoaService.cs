using teste.Models;
using Microsoft.EntityFrameworkCore;

namespace teste.Services;

public class PessoaService : IPessoaService
{
    private readonly LoginContext _contexto;

    public PessoaService(LoginContext contexto)
    {
        _contexto = contexto;
    }

    public async Task<Pessoa?> ConsultaId(int id)
    {
        return await _contexto.Pessoas.FindAsync(id);
    }

    public async Task<Pessoa?> VerificaLogin(string nome, string senha)
    {
        var pessoa = await _contexto.Pessoas
                            .Where(p => (p.Nome == nome && p.Senha == senha))
                            .FirstOrDefaultAsync();
        return pessoa;
    }

    public async Task<IEnumerable<Pessoa>> Listar()
    {
        var pessoas = await _contexto.Pessoas.ToListAsync();
        return pessoas;
    }

    public async Task<Pessoa> CriarPessoa(Pessoa novaPessoa)
    {   
        
        _contexto.Pessoas.Add(novaPessoa);
        _contexto.SaveChanges();

        var pessoa = await _contexto.Pessoas
                        .Where(p => (p.Nome == novaPessoa.Nome && p.Senha == novaPessoa.Senha))
                        .FirstOrDefaultAsync();

        if (pessoa == null){
            throw new Exception("Erro ao salvar Pessoa");
        }

        return pessoa;
    }

}