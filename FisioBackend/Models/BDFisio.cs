using Microsoft.EntityFrameworkCore;

namespace FisioBackend.Models;

public class BDFisio : DbContext{

public BDFisio(DbContextOptions<BDFisio> options): base(options){}
    public DbSet<Pessoa> Pessoas { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Agenda> Agendas { get; set; }
    public DbSet<Servico> Servicos { get; set; }
    public DbSet<TipoServico> TiposServico { get; set; }
    public DbSet<Pagamento> Pagamentos { get; set; }
}