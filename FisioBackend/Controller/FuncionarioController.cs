using Microsoft.AspNetCore.Mvc;
using FisioBackend.Models;

namespace FisioBackend.Controller;
[ApiController]
[Route("funcionario")]

public class FuncionarioController : ControllerBase
{
    private BDFisio db;

    public FuncionarioController(BDFisio banco)
    {
        this.db = banco;
    }


    // método Get para ler um objeto
    [HttpGet]
    public ActionResult Read()
    {
        // select * from Games
        return Ok(db.Funcionarios.ToList());
    }

    // método Post para criar o objeto e incluí-lo na lista
    [HttpPost]
    public ActionResult Create(Funcionario funcionario)
    {
        db.Funcionarios.Add(funcionario);
        db.SaveChanges();
        return Created(funcionario.Id.ToString(), funcionario);
    }


    // método Delete para deletar objeto
    [HttpDelete]
    [Route("{id}")]
    public ActionResult Delete(int id)
    {
        // tento achar o Funcionario
        var Funcionario = db.Funcionarios.Find(id);
        // se eu não achei o Funcionario, encerro o programa, avisando que não achei o Funcionario
        if (Funcionario == null)
        {
            return NotFound();
        }
        // achei o Funcionario e olha no que deu
        db.Funcionarios.Remove(Funcionario);
        db.SaveChanges();
        return Ok("Exclusão realizada com sucesso");
    }


    [HttpPut]
    public ActionResult Update(int id, Funcionario funcionario) // O  Funcionario QUE ME PASSOU
    {
        Funcionario? _funcionario = db.Funcionarios.Find(id); // procura-se Funcionario desatualizado
        if (_funcionario == null) // se n achei o Funcionario, encerra o código  e avisa que não achou nada
        {
            return NotFound("Funcionário inexistente");
        }
        // achei o Funcionario e olha no que deu
        _funcionario.Nome = funcionario.Nome;
        _funcionario.Especialidade = funcionario.Especialidade;
        _funcionario.Status = funcionario.Status;
        _funcionario.Telefone = funcionario.Telefone;
        _funcionario.Email = funcionario.Email;
        _funcionario.Senha = funcionario.Senha;

        db.SaveChanges();
        return Ok("Funcionário atualizado");
    }


    // Ler agendas do funcionário
    [HttpGet]
    [Route("{funcionarioId}/agenda")]
    public ActionResult Read(int funcionarioId)
    {
        var agendas = db.Agendas.Where(a => a.FuncionarioId == funcionarioId); // Para cada agenda da minha tabela, eu pergunto se o FuncionarioId é igual ao id que eu recebi como parâmetro

        if (agendas == null)
        {
            return NotFound("Funcionário inexistente");
        }

        return Ok(agendas.ToList());
    }


    [HttpPost]
    [Route("{funcionarioId}/agenda")]
    public ActionResult Create(int funcionarioId, Agenda agenda)
    {
        Funcionario? funcionario = db.Funcionarios.Find(funcionarioId);
        if (funcionario == null)
        {
            return NotFound("Funcionário inexistente");
        }

        agenda.FuncionarioId = funcionarioId;
        db.Agendas.Add(agenda);
        db.SaveChanges();

        return Ok(agenda);
    }


    [HttpDelete]
    [Route("{funcionarioId}/agenda/{agendaId}")]
    public ActionResult Delete(int funcionarioId, int agendaId)
    {
        Funcionario? funcionario = db.Funcionarios.Find(funcionarioId);
        if (funcionario == null)
        {
            return NotFound("Funcionário inexistente");
        }

        Agenda? agenda = db.Agendas.Find(agendaId);
        if (agenda == null)
        {
            return NotFound("Não há agenda para este funcionário");
        }

        db.Agendas.Remove(agenda);
        db.SaveChanges();

        return Ok(agenda);
    }


    [HttpPut]
    [Route("{funcionarioId}/agenda/{agendaId}")]
    public ActionResult Update(int funcionarioId, int agendaId, Agenda agenda) // Id do dono da agenda, id da agenda, dados novos da agenda respectivamente
    {
        Funcionario? funcionario = db.Funcionarios.Find(funcionarioId); //procurando funcionario
        if (funcionario == null) //se funcionario não existir
        {
            return NotFound("Funcionário inexistente"); // retornar essa mensagem
        }

        Agenda? _agenda = db.Agendas.Find(agendaId); //procurando agenda
        if (_agenda == null) // se não existir agenda
        {
            return NotFound("Não há agenda para este funcionário"); // retornar essa mensagem
        }

        _agenda.DiaDaSemana = agenda.DiaDaSemana;
        _agenda.HoraInic = agenda.HoraInic;
        _agenda.HoraFim = agenda.HoraFim;
        db.SaveChanges();
        return Ok();
    }
}


