using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

using src.Models;
using src.Persistence;

namespace src.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase{

    private DatabaseContext _context { get; set; }
    public PersonController(DatabaseContext context){
        this._context = context;
    }
    [HttpGet]
    public ActionResult<List<Person>> Get(){
        var result = _context.People.Include(p => p.Contratos).ToList();
        if(!result.Any()) return NoContent();
        return Ok(result);
    }
    [HttpPost]
    public ActionResult<Person> Post([FromBody]Person pessoa){
        try
        {
        _context.People.Add(pessoa);
        _context.SaveChanges();
        }
        catch (System.Exception)
        {
            
            return BadRequest(new {
                msg = "Erro ao criar registro",
                status = HttpStatusCode.BadRequest
            });
        }
        return Created("Registro criado", pessoa);
    }
    [HttpPut("{id}")]
    public ActionResult<Object> Update([FromRoute] int id, [FromBody] Person pessoa){
        var result = _context.People.SingleOrDefault(e => e.Id == id);
        if(result is null){
            return NotFound(new {
                msg = "Registro não encontrado",
                status = HttpStatusCode.NotFound
            });
        }
        try
        {
          _context.People.Update(pessoa);
            _context.SaveChanges();  
        }
        catch (System.Exception)
        {
        return BadRequest(new {
        msg = $"Erro ao tentar atualizar dados da pessoa Id {id}",
        status = HttpStatusCode.BadRequest
        });
        }
        return new {
            msg = $"Dados do id {id} atualizados",
            status = HttpStatusCode.OK
        };
    }
    
    [HttpDelete("{id}")]
    public ActionResult<Object> Delete([FromRoute]int id){
        var result = _context.People.SingleOrDefault(e => e.Id == id);
        if(result is null){ 
            return BadRequest(new {
                msg = "Conteúdo inexistente, solicitação inválida",
                status = HttpStatusCode.BadRequest
            });
            }
        _context.People.Remove(result);
        _context.SaveChanges();
        return Ok(new {
            msg = $"Deletado pessoa de Id {id}",
            status = HttpStatusCode.OK
        });
    }

}
    // [HttpDelete("{id}")]
    // public string PersonDelete([FromRoute]int id){
    //     var result = _context.People.SingleOrDefault(e => e.Id == id);
    //     _context.People.Remove(result);
    //     _context.SaveChanges();
    //     return "Deletado pessoa de Id " + id;}
    
    // [HttpGet]
    // public ActionResult<List<Person>> Get(){
        // OK - 200, NoContent - 204
        //Person pessoa = new Person("breno", 24, "123456789");
        //Contract NovoContrato = new Contract("abc123", 5000);
        //essoa.Contratos.Add(NovoContrato);
    //       [HttpPut("{id}")]
    // public string Update([FromRoute] int id, [FromBody] Person pessoa){
    //     _context.People.Update(pessoa);
    //     _context.SaveChanges();
        
    //     return "Dados do id " + id + " atualizados";
    // }
    