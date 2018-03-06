using System;

namespace WebApi.Models
{
  public class FilmeLocacao
  {
    public long Id { get; set; }

    public string Data { get; set; }

    public Double Valor { get; set; }

    public int FilmeId { get; set; }
    public Filme Filme { get; set; }
    
    public int LocacaoId { get; set; }
    public Locacao Locacao { get; set; }
  }
}