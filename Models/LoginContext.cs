using Microsoft.EntityFrameworkCore;
using teste.Models;

public class LoginContext : DbContext
{
    public DbSet<Pessoa> Pessoas {get;set;} = null!;
    
    public LoginContext()
    {}
    public LoginContext(DbContextOptions<LoginContext> opcoesDeConfiguracao)
    :base(opcoesDeConfiguracao){}
}