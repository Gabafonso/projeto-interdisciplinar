using Microsoft.AspNetCore.Mvc;
using FisioBackend.Models;

namespace FisioBackend.Controller;
[ApiController]
[Route("servico")]
public class ServicoController : ControllerBase
{
    private BDFisio db;

    public ServicoController(BDFisio banco)
    {
        this.db = banco;
    }

    // método Get para ler um objeto
    [HttpGet]
    public ActionResult Read()
    {
        return Ok(db.Servicos.ToList());
    }

    // método Post para criar o objeto e incluí-lo na lista
    [HttpPost]
    public ActionResult Create(int funcionarioId, int tipoServicoId, Servico servico)
    {
        Funcionario? _funcionario = db.Funcionarios.Find(funcionarioId);
        if (_funcionario == null)
        {
            return NotFound("Funcionário inexistente"); 
        }

        TipoServico? _tipoServico = db.TiposServico.Find(tipoServicoId);
        if (_tipoServico == null)
        {
            return NotFound("Tipo de serviço inválido");
        }

        servico.FuncionarioId = funcionarioId;
        db.Servicos.Add(servico);
        db.SaveChanges();
        return Ok(servico);
    }

    //método Put para atualizar um objeto
    [HttpPut]
    public ActionResult Update(int servicoId, int funcionarioId, int tipoServicoId, Servico servico)
    {
        Servico? _servico = db.Servicos.Find(servicoId);
        if (servico == null)
        {
            return NotFound("Serviço inválido");
        }
        
        TipoServico? tipoServico = db.TiposServico.Find(tipoServicoId);
        if (tipoServico == null)
        {
            return NotFound("Tipo de serviço inválido");
        }

        Funcionario? funcionario = db.Funcionarios.Find(funcionarioId);
        if (funcionario == null)
        {
            return NotFound("Funcionário inexistente");
        }

        _servico.FormaPag = servico.FormaPag;
        _servico.ValorServ = servico.ValorServ;
        _servico.Cronograma = servico.Cronograma;
        db.SaveChanges();
        return Ok("Serviço atualizado");
    }

    // método Delete para deletar objeto
    [HttpDelete]
    [Route("{id}")]
    public ActionResult Delete(int id)
    {
        var servico = db.Servicos.Find(id);
        if (servico == null)
        {
            return NotFound("Serviço inexistente");
        }

        db.Servicos.Remove(servico);
        db.SaveChanges();
        return Ok("Exclusão realizada com sucesso");
    }
}