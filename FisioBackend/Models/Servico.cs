namespace FisioBackend.Models;
public class Servico 
{
    public int Id { get; set; }
    public string FormaPag { get; set; }
    public float ValorServ { get; set; }
    public int Cronograma { get; set; }
    public int FuncionarioId { get; set; }
    public int TipoServicoId { get; set; }
}