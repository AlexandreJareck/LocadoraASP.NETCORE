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

        #region WsCar

        public static List<Carro> BuscarMarcas()
        {
            
            string url = "https://parallelum.com.br/fipe/api/v1/carros/marcas";
            WebClient client = new WebClient();
            return JsonConvert.DeserializeObject<List<Carro>>(client.DownloadString(url));
        }

        public static List<Modelo> BuscarCarros(Carro carro)
        {
            string url = "https://parallelum.com.br/fipe/api/v1/carros/marcas/" + carro.IdMarca + "/modelos";
            WebClient client = new WebClient();
            var result = JsonConvert.DeserializeObject<Carro>(client.DownloadString(url));            

            return result.Modelos;
        }

        public static List<Carro> BuscarModelos(Carro carro)
        {        
            string url = "https://parallelum.com.br/fipe/api/v1/carros/marcas/" + carro.IdMarca + "/modelos/" + carro.IdentVeiculo + "/anos";            
            WebClient client = new WebClient();
            return JsonConvert.DeserializeObject<List<Carro>>(client.DownloadString(url));
        }

        public static Carro BuscarDadosVeiculo(Carro carro)
        {        
            string url = "https://parallelum.com.br/fipe/api/v1/carros/marcas/" + carro.IdMarca + "/modelos/" + carro.IdentVeiculo + "/anos/" + carro.CodigoFipe;            
            WebClient client = new WebClient();
            return JsonConvert.DeserializeObject<Carro>(client.DownloadString(url));
        }

        #endregion

        #region WsMoto

        public static List<Moto> BuscarMarcasMoto()
        {
            string url = "https://parallelum.com.br/fipe/api/v1/motos/marcas";
            WebClient client = new WebClient();
            return JsonConvert.DeserializeObject<List<Moto>>(client.DownloadString(url));
        }

        public static List<Modelo> BuscarMotos(Moto moto)
        {
            string url = "https://parallelum.com.br/fipe/api/v1/motos/marcas/" + moto.IdMarca + "/modelos";
            WebClient client = new WebClient();
            var result = JsonConvert.DeserializeObject<Moto>(client.DownloadString(url));

            return result.Modelos;
        }

        public static List<Moto> BuscarModelosMoto(Moto moto)
        {
            string url = "https://parallelum.com.br/fipe/api/v1/motos/marcas/" + moto.IdMarca + "/modelos/" + moto.IdentVeiculo + "/anos";
            WebClient client = new WebClient();
            return JsonConvert.DeserializeObject<List<Moto>>(client.DownloadString(url));
        }

        public static Moto BuscarDadosVeiculoMoto(Moto moto)
        {
            string url = "https://parallelum.com.br/fipe/api/v1/motos/marcas/" + moto.IdMarca + "/modelos/" + moto.IdentVeiculo + "/anos/" + moto.CodigoFipe;
            WebClient client = new WebClient();
            return JsonConvert.DeserializeObject<Moto>(client.DownloadString(url));
        } 

        #endregion

    }
}
