using Locadora.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Locadora.Service
{
    public class FipeApiService
    {

        public static List<Carro> BuscarMarcas()
        {
            string url = "http://fipeapi.appspot.com/api/1/carros/marcas.json";
            WebClient client = new WebClient();
            return JsonConvert.DeserializeObject<List<Carro>>(client.DownloadString(url));
        }

        public static List<Carro> BuscarCarros(Carro carro)
        {
            string url = "http://fipeapi.appspot.com/api/1/carros/veiculos/" + carro.IdMarca + ".json";
            WebClient client = new WebClient();
            return JsonConvert.DeserializeObject<List<Carro>>(client.DownloadString(url));
        }

        public static List<Carro> BuscarModelos(Carro carro)
        {
            string url = "http://fipeapi.appspot.com/api/1/carros/veiculo/" + carro.IdMarca + "/" + carro.IdentVeiculo + ".json";
            WebClient client = new WebClient();
            return JsonConvert.DeserializeObject<List<Carro>>(client.DownloadString(url));
        }

        public static Carro BuscarDadosVeiculo(Carro carro)
        {
            string url = "http://fipeapi.appspot.com/api/1/carros/veiculo/" + carro.IdMarca + "/" + carro.IdentVeiculo + "/" + carro.Fipe_codigo + ".json";
            WebClient client = new WebClient();
            return JsonConvert.DeserializeObject<Carro>(client.DownloadString(url));
        }

    }
}
