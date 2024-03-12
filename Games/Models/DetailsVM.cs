namespace Games.Models;

public class DetailsVM
{
    public Jogo Anterior { get; set; }
    public Jogo Atual { get; set; }
    public Jogo Proximo { get; set; }
    public List<Plataforma> Plataformas { get; set; }
}