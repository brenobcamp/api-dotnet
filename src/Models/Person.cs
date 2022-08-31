namespace src.Models;
using System.Collections.Generic;

public class Person
{
    public Person(){
        this.Nome = "template";
        this.Idade = 0;
        this.Contratos = new List<Contract>();
        this.Ativado = true;
    }
    public Person(string Nome, int Idade, string? cpf){
        this.Nome = Nome;
        this.Idade = Idade;
        this.Cpf= cpf;
        this.Contratos = new List<Contract>();
        this.Ativado = true;
    } 
    public int Id { get; set; }
    public string Nome { get; set;}
    public int Idade { get; set; }
    public string? Cpf { get; set; }
    public bool Ativado { get; set; }
    public List<Contract> Contratos { get; set; }
}