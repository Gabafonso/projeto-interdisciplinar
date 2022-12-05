namespace FisioBackend.Models;
public class Pagamento
{
    public int Id { get; set; }
    public float ValorTotal { get; set; }
    public float ValorPag { get; set; }
    public string FormaPag { get; set; }
    public int Status { get; set; }
    public string DataPag { get; set; }
    public string DataVenc { get; set; }
}