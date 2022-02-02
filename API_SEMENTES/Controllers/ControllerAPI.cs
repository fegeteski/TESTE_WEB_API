using Microsoft.AspNetCore.Mvc;
using API_SEMENTES.Models;


namespace API_SEMENTES.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class sementesController : ControllerBase
    {

        [HttpPost("Processamento_de_dados")]
        public IActionResult Processamento_de_dados(List<sementes> lista_de_sementes)
        {
            
           var num_good =
           from s in lista_de_sementes
           where ((s.seedLevel) < 1 && (s.seedStatus) == "Good")
           select s;

            int num_vezes_good = num_good.Count();

            var num_ready =
            from s in lista_de_sementes
            where ((s.seedLevel) == 1)
            select s;

            int num_vezes_ready = num_ready.Count();

           var num_bad =
           from s in lista_de_sementes
           where ((s.seedStatus) == "Bad")
           select s;

            int num_vezes_bad = num_bad.Count();

            string resultados = ($"Dados Enviados com sucesso \n Sementes Boas: {num_vezes_good}. " +
                                 $"\n Sementes Ruins: {num_vezes_bad}. \n Sementes Prontas: {num_vezes_ready}.");

            return Ok(resultados);
        }

    }


}

