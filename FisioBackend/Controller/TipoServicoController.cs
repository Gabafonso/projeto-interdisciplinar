using Microsoft.AspNetCore.Mvc;
using FisioBackend.Models;

namespace FisioBackend.Controller;
[ApiController]
[Route("tipoServico")]
public class TipoServicoController : ControllerBase
{
    private BDFisio db;

    public TipoServicoController(BDFisio banco)
    {
        this.db = banco;
    }

    // método Get para ler um objeto
    [HttpGet]
    public ActionResult Read()
    {
        return Ok(db.TiposServico.ToList());
    }

    // método Post para criar o objeto e incluí-lo na lista
    [HttpPost]
    public ActionResult Create(TipoServico tipoServico)
    {
        db.TiposServico.Add(tipoServico);
        db.SaveChanges();
        return Ok(tipoServico);
    }

    //método Put para atualizar um objeto
    [HttpPut]
    public ActionResult Update(int id, TipoServico tipoServico)
    {
        TipoServico? _tipoServico = db.TiposServico.Find(id);
        if (_tipoServico == null)
        {
            return NotFound("Tipo de serviço inexistente");
        }

        _tipoServico.Nome = tipoServico.Nome;
        db.SaveChanges();
        return Ok("Tipo de serviço atualizado");
    }

    // método Delete para deletar objeto
    [HttpDelete]
    [Route("{id}")]
    public ActionResult Delete(int id)
    {
        var tipoServico = db.TiposServico.Find(id);
        if (tipoServico == null)
        {
            return NotFound("Tipo de serviço inexistente");
        }
        
        db.TiposServico.Remove(tipoServico);
        db.SaveChanges();
        return Ok("Exclusão realizada com sucesso");
    }
}