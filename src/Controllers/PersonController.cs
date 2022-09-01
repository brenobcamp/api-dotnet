using Microsoft.AspNetCore.Mvc;
using src.Models;
using src.Persistence;
using Microsoft.EntityFrameworkCore;

namespace src.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase{

    private DatabaseContext _context { get; set; }
    public PersonController(DatabaseContext context){
        this._context = context;
    }
    [HttpGet]
    public List<Person> Get(){
        //Person pessoa = new Person("breno", 24, "123456789");
        //Contract NovoContrato = new Contract("abc123", 5000);
        //essoa.Contratos.Add(NovoContrato);
        return _context.People.Include(p => p.Contratos).ToList();
    }
    [HttpPost]
    public Person Post([FromBody]Person pessoa){
        _context.People.Add(pessoa);
        _context.SaveChanges();
        return pessoa;
    }
    [HttpPut("{id}")]
    public string Update([FromRoute] int id, [FromBody] Person pessoa){
        _context.People.Update(pessoa);
        _context.SaveChanges();
        
        return "Dados do id " + id + " atualizados";
    }
    [HttpDelete]
    public string PersonDelete([FromRoute]int id){
        return "deletado pessoa de Id " + id;
    }

}