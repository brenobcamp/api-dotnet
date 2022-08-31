using Microsoft.AspNetCore.Mvc;
using src.Models;

namespace src.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase{
    [HttpGet]
    public Person Get(){
        Person pessoa = new Person("breno", 24, "123456789");
        Contract NovoContrato = new Contract("abc123", 5000);
        pessoa.Contratos.Add(NovoContrato);
        return pessoa;
    }
    [HttpPost]
    public Person Post([FromBody]Person pessoa){
        return pessoa;
    }
    [HttpPut("{id}")]
    public string Update([FromRoute] int id, [FromBody] Person pessoa){
        Console.WriteLine(id);
        Console.WriteLine(pessoa);
        return "Dados do id " + id + " atualizados";
    }
    [HttpDelete]
    public string Delete([FromRoute]int id){
        return "deletado pessoa de Id " + id;
    }

}