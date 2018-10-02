using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace _01._01
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var json = await new HttpClient().GetStringAsync("https://gist.githubusercontent.com/saniyusuf/406b843afdfb9c6a86e25753fe2761f4/raw/523c324c7fcc36efab8224f9ebb7556c09b69a14/Film.JSON");
            RootObject[] list = JsonConvert.DeserializeObject<RootObject[]>(json);
            var filmes = list.Select(i => new Filme
            {
                Ano = i.Year,
                Diretor = new Diretor { Nome = i.Director },
                Titulo = i.Title
            }).ToList();
            var diretores = filmes.Select(i => i.Diretor).ToList();
            LojaDeFilmes loja = new LojaDeFilmes
            {
                Filmes = filmes.ToList(),
                Diretores = diretores
            };

            using (var sw = new StreamWriter("loja.json"))
            {
                sw.Write(JsonConvert.SerializeObject(loja));
            }

            //LojaDeFilmes loja = LojaDeFilmes.AdicionarFilme();
            //BinaryFormatter formatter = new BinaryFormatter();
            //using (FileStream outputStream =
            //new FileStream("Filmes.bin", FileMode.OpenOrCreate, FileAccess.Write))
            //{
            //    formatter.Serialize(outputStream, loja);
            //}

            //LojaDeFilmes inputData;
            //using (FileStream inputStream = new FileStream("Filmes.bin", FileMode.Open, FileAccess.Read))
            //{
            //    inputData = (LojaDeFilmes)formatter.Deserialize(inputStream);
            //}
        }
    }

    public class RootObject
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string Rated { get; set; }
        public string Released { get; set; }
        public string Runtime { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string Awards { get; set; }
        public string Poster { get; set; }
        public string Metascore { get; set; }
        public string imdbRating { get; set; }
        public string imdbVotes { get; set; }
        public string imdbID { get; set; }
        public string Type { get; set; }
        public string Response { get; set; }
        public List<string> Images { get; set; }
        public string totalSeasons { get; set; }
        public bool? ComingSoon { get; set; }
    }

    [Serializable]
    class Diretor
    {
        public string Nome { get; set; }

        [NonSerialized]
        public int tempData;
    }

    [Serializable]
    class Filme
    {
        public Diretor Diretor { get; set; }
        public string Titulo { get; set; }
        public string Ano { get; set; }
    }

    [Serializable]
    class LojaDeFilmes
    {
        public List<Diretor> Diretores = new List<Diretor>();
        public List<Filme> Filmes = new List<Filme>();
        public static LojaDeFilmes AdicionarFilme()
        {
            LojaDeFilmes result = new LojaDeFilmes();
            // ...
            return result;
        }
    }
}
