namespace src.Models;

public class Contract {
    public Contract(){
        this.DataCriacao = DateTime.Now;
        this.Valor = 0;
        this.TokenId = "000000";
        this.Pago = false;
    }
    public Contract(string TokenId, int Valor){
        this.DataCriacao = DateTime.Now;
        this.TokenId = TokenId;
        this.Valor = Valor;
        this.Pago = false;
    }
    public int Id { get; set; }
    public DateTime DataCriacao { get; set; }
    public string TokenId { get; set; }
    public int Valor { get; set; }
    public bool Pago { get; set; }
    public int PersonId { get; set; }

}