namespace FisioBackend.Models;


public class Agenda
{

    public int Id { get; set; }

    public int DiaDaSemana { get; set; }

    public string HoraInic { get; set; }
    public string HoraFim { get; set; }

    public int FuncionarioId { get; set; }
}