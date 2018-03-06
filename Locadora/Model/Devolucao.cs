namespace WebApi.Models
{
  public class Devolucao
  {
    public long Id { get; set; }

    public string DataEntrega { get; set; }

    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; }

    public int FilmeId { get; set; }
    public Filme Filme { get; set; }

    public int FuncionarioId { get; set; }
    public Funcionario Funcionario { get; set; }
  }
}