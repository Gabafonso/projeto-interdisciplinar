using System.ComponentModel.DataAnnotations.Schema;

namespace FisioBackend.Models;

[Table("Funcionarios")]
public class Funcionario : Pessoa
{
    public string Especialidade { get; set; }
}