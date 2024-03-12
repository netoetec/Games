using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Games.Models;

namespace Games.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    public IActionResult Index()
    {
        List<Jogo> jogos = GetJogos();
        List<Plataforma> plataformas = GetPlataformas();
        ViewData["Plataformas"] = plataformas;
        return View(jogos);
    }

    public IActionResult Details(int id)
    {
        List<Jogo> jogos = GetJogos();
        List<Plataforma> plataformas = GetPlataformas();
        DetailsVM details = new() {
            Plataformas = plataformas,
            Atual = jogos.FirstOrDefault(j => j.Numero == id),
            Anterior = jogos.OrderByDescending(j => j.Numero).FirstOrDefault(j => j.Numero < id),
            Proximo = jogos.OrderBy(j => j.Numero).FirstOrDefault(j => j.Numero > id),
        };
        return View(details);
    }

    private List<Jogo> GetJogos()
    {
        using (StreamReader leitor = new("Data\\jogos.json"))
        {
            string dados = leitor.ReadToEnd();
            return JsonSerializer.Deserialize<List<Jogo>>(dados);
        }
    }

        private List<Plataforma> GetPlataformas()
    {
        using (StreamReader leitor = new("Data\\plataformas.json"))
        {
            string dados = leitor.ReadToEnd();
            return JsonSerializer.Deserialize<List<Plataforma>>(dados);
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
