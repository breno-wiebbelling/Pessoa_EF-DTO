using teste.Models;

public interface IPessoaService
{
    Task<Pessoa?> ConsultaId(int id);
    Task<Pessoa?> VerificaLogin(string nome, string senha);
    Task<IEnumerable<Pessoa>> Listar();

    Task<Pessoa> CriarPessoa(Pessoa pessoa);

}