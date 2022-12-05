using System.ComponentModel.DataAnnotations.Schema;

namespace FisioBackend.Models;

[Table("Clientes")]
public class Cliente : Pessoa
{
    public float Renda { get; set; }
}