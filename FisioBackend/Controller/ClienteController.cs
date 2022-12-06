using Microsoft.AspNetCore.Mvc;
using FisioBackend.Models;

namespace FisioBackend.Controller;
[ApiController]
[Route("cliente")]

public class ClienteController : ControllerBase
{
    private BDFisio db;

    public ClienteController(BDFisio banco)
    {
        this.db = banco;
    }

    // método Get para ler um objeto
    [HttpGet]
    public ActionResult Read()
    {
        // select * from Games
        return Ok(db.Clientes.ToList());
    }
    [HttpGet]
    [Route("{id}")]
    public ActionResult PegarPessoa(int id)
    {
        var cliente = db.Clientes.Find(id);
        if (cliente == null){
            return NotFound();
        } else {
            return Ok(cliente);
        }
    }

    // método Post para criar o objeto e incluí-lo na lista
    [HttpPost]
    public ActionResult Create(Cliente cliente)
    {
        // insert into Game values (...)
        db.Clientes.Add(cliente);
        db.SaveChanges();
        return Created(cliente.Id.ToString(), cliente);
    }

    // método Delete para deletar objeto
    [HttpDelete]
    [Route("{id}")]
    public ActionResult Delete(int id)
    {
        // tento achar o cliente 
        var cliente = db.Clientes.Find(id);
        // se eu não achei o cliente, encerro o peograma, avisando que não achei o cliente
        if (cliente == null)
        {
            return NotFound("Cliente inexistente");
        }
        // achei o cliente e olha no que deu
        db.Clientes.Remove(cliente);
        db.SaveChanges();
        return Ok("Exclusão realizada com sucesso");
    }

    [HttpPut]
    [Route("{id}")]
    public ActionResult Update(int id, Cliente cliente) // O CLIENTE QUE ME PASSOU
    {
        Cliente? _cliente = db.Clientes.Find(id); // procura-se cliente desatualizado
        if (_cliente == null) // se n achei o cliente, encerra o código  e avisa que não achou nada
        {
            return NotFound("Cliente inexistente");
        }
        // achei o cliente e olha no que deu
        _cliente.Nome = cliente.Nome;
        _cliente.Renda = cliente.Renda;
        _cliente.Status = cliente.Status;
        _cliente.Telefone = cliente.Telefone;
        _cliente.Email = cliente.Email;
        db.SaveChanges();
        return Ok("Cliente atualizado");
    }

    [HttpPost]
    [Route("login")]
    public ActionResult Login(LoginDTO request)
    {
        var pessoa = db.Pessoas.Where(p => p.CPF.Equals(request.CPF) && p.Senha.Equals(request.Senha)).FirstOrDefault();
        if (pessoa == null){
            return NotFound("Não Achou");
        } else {
            return Ok(pessoa.Id);
        }
    }
}

public class LoginDTO
{
    public string CPF { get; set; }
    public string Senha { get; set; }
}