namespace WebApi.Models
{
  public class Locacao
  {
    public long Id { get; set; }

    public string Data { get; set; }

    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; }

    public int FuncionarioId { get; set; }
    public Funcionario Funcionario { get; set; }
    
    public int FilmeLocacaoId { get; set; }
    public FilmeLocacao FilmeLocacao { get; set; }
  }
}