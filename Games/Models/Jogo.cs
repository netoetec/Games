namespace Games.Models;

public class Jogo
{
    public int Numero { get; set; } 
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public List<string> Plataforma { get; set; }
    public string Imagem { get; set; }

    // Metedo Construtor
    public Jogo()
    {
        Plataforma = new List<string>();
    }
}
