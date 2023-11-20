using Microsoft.AspNetCore.Mvc;
using trabalho_rodeio.Models;

namespace trabalho_rodeio.Controllers
{
    public class GerarDadosController : Controller
    {
        private readonly Contexto _context;
        
        public GerarDadosController(Contexto context)
        {
            _context = context;
        }

        public IActionResult GerarPeoes()
        {

            var todosPeoes = _context.Peoes.ToList();
            _context.Peoes.RemoveRange(todosPeoes);
            _context.SaveChanges();

            Random random = new Random();
            string[] vnome = { "João", "Maria", "Pedro", "Ana", "Carlos", "Laura", "Fernando", "Leticia", "Gabriel", "Isabel" };
            string[] vsobrenome = { "Silva", "Oliveira", "Pereira", "Santos", "Costa", "Lima", "Martins", "Cruz", "Melo", "Almeida" };

            for (int i = 0; i < 20; i++)
            {
                Peao peao = new Peao();

                string nomeCompleto = vnome[random.Next(vnome.Length)] + " " + vsobrenome[random.Next(vsobrenome.Length)];
                peao.Nome = nomeCompleto;

                DateTime dataNascimento = new DateTime(1950, 1, 1);
                int diasAleatorios = random.Next(0, 13000);
                dataNascimento = dataNascimento.AddDays(diasAleatorios);

                peao.DataNascimento = dataNascimento;

                peao.QuantidadeMontarias = 0;

                _context.Peoes.Add(peao);
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Peoes");
        }
    }
}
