using System.Text;
using System.Globalization;
using Newtonsoft.Json;

namespace DESAFIO_DAS_SEMENTES
{
    class Program
    {
        static async Task Main(string[] args)
        {
            List<sementes> lista_de_sementes = new List<sementes>();

            string[] array = File.ReadAllLines(@"C:\TEXTOS\sementes.txt");

            for (int k = 0; k < array.Length; k++)
            {
                sementes a = new sementes();

                string[] auxiliar = array[k].Split(',');

                a.seedType = auxiliar[0];
                a.seedLevel = Convert.ToDouble(auxiliar[1],CultureInfo.InvariantCulture);
                a.seedStatus = auxiliar[2];
                a.plantingDate = Convert.ToDateTime(auxiliar[3]);

                lista_de_sementes.Add(a);

            }

            //Envia valores p/ API
            var json = JsonConvert.SerializeObject(lista_de_sementes);
            StringContent? httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PostAsync("https://localhost:7014/api/sementes/Processamento_de_dados", httpContent);

            //Retona valores
            var responseString = await response.Content.ReadAsStringAsync();
           
            Console.WriteLine(responseString);
            Console.ReadKey();

        }  
    }
}
