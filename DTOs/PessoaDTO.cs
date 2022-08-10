using teste.Models;

namespace teste.DTOs;

public class PessoaDTO
{
    public int Id {get;set;}
    public string Nome {get;set;} = null!;

    public static PessoaDTO DePessoaParaDTO(Pessoa pessoa)
    {
        return new PessoaDTO 
        {
            Id = pessoa.Id,
            Nome = pessoa.Nome
        };
    }  

    public static IEnumerable<PessoaDTO> DePessoasParaDTO (IEnumerable<Pessoa> pessoas)
    {
        List<PessoaDTO> pessoasDTOs = new List<PessoaDTO>();

        foreach (var pessoa in pessoas)
        {   
            pessoasDTOs.Add(
                new PessoaDTO 
                {
                    Id = pessoa.Id,
                    Nome = pessoa.Nome    
                }
            );
        }

        return pessoasDTOs;
    }
    
}