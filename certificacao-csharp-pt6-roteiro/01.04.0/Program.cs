using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace _01._04._0
{
    class Program
    {
        static void Main(string[] args)
        {
            LojaDeFilmes loja = ObterDados();

            //1) usando JavaScriptSerializer
            var serializer = new JavaScriptSerializer();
            var json = serializer.Serialize(loja);
            Console.WriteLine(json);
            var copiaLoja = serializer.Deserialize<LojaDeFilmes>(json);
            foreach (var filme in copiaLoja.Filmes)
            {
                Console.WriteLine(filme.Titulo);
            }

            //2) usando DataContractJsonSerializer
            //var serializer = new DataContractJsonSerializer(typeof(LojaDeFilmes));
            //var stream = new MemoryStream();
            //string json = "";
            //LojaDeFilmes copiaLoja;
            //using (var writer = new StreamWriter(stream))
            //{
            //    serializer.WriteObject(stream, loja);
            //    using (var reader = new StreamReader(stream))
            //    {
            //        stream.Position = 0;
            //        json = reader.ReadToEnd();
            //        Console.WriteLine(json);
            //        stream.Position = 0;
            //        copiaLoja = (LojaDeFilmes)serializer.ReadObject(reader.BaseStream);
            //    }
            //}
            //foreach (var filme in copiaLoja.Filmes)
            //{
            //    Console.WriteLine(filme.Titulo);
            //}

            //3) usando Json.NET (NewtonSoft)
            //var json = JsonConvert.SerializeObject(loja);
            //Console.WriteLine(json);
            //var copiaLoja = JsonConvert.DeserializeObject<LojaDeFilmes>(json);

            //foreach (var filme in copiaLoja.Filmes)
            //{
            //    Console.WriteLine(filme.Titulo);
            //}

            //https://www.newtonsoft.com/json
            ///< image url="$(ProjectDir)/img01.png"/>


            Console.ReadKey();
        }

        private static LojaDeFilmes ObterDados()
        {
            return new LojaDeFilmes
            {
                Diretores = new List<Diretor>
                {
                    new Diretor { Nome = "James Cameron", NumeroFilmes = 5 },
                    new Diretor { Nome = "Francis Lawrence", NumeroFilmes = 3 },
                    new Diretor { Nome = "Zack Snyder", NumeroFilmes = 6 },
                    new Diretor { Nome = "Joss Whedon", NumeroFilmes = 7 },
                    new Diretor { Nome = "Martin Scorsese", NumeroFilmes = 4 },
                    new Diretor { Nome = "Christopher Nolan", NumeroFilmes = 8 },
                    new Diretor { Nome = "Scott Derrickson", NumeroFilmes = 4 },
                    new Diretor { Nome = "Gareth Edwards", NumeroFilmes = 3 },
                    new Diretor { Nome = "Justin Kurzel", NumeroFilmes = 6 }
                },
                Filmes = new List<Filme> {
                    new Filme {
                        Diretor = new Diretor { Nome = "James Cameron", NumeroFilmes = 5 },
                        Titulo = "Avatar",
                        Ano = "2009"
                    },
                    new Filme {
                        Diretor = new Diretor { Nome = "Francis Lawrence", NumeroFilmes = 3 },
                        Titulo = "I Am Legend",
                        Ano = "2007"
                    },
                    new Filme {
                        Diretor = new Diretor { Nome = "Zack Snyder", NumeroFilmes = 6 },
                        Titulo = "300",
                        Ano = "2006"
                    },
                    new Filme {
                        Diretor = new Diretor { Nome = "Joss Whedon", NumeroFilmes = 7 },
                        Titulo = "The Avengers",
                        Ano = "2012"
                    },
                    new Filme {
                        Diretor = new Diretor { Nome = "Martin Scorsese", NumeroFilmes = 4 },
                        Titulo = "The Wolf of Wall Street",
                        Ano = "2013"
                    },
                    new Filme {
                        Diretor = new Diretor { Nome = "Christopher Nolan", NumeroFilmes = 8 },
                        Titulo = "Interstellar",
                        Ano = "2014"
                    },
                    new Filme {
                        Diretor = new Diretor { Nome = "N/A" },
                        Titulo = "Game of Thrones",
                        Ano = "2011–"
                    },
                    new Filme {
                        Diretor = new Diretor { Nome = "N/A" },
                        Titulo = "Vikings",
                        Ano = "2013–"
                    },
                    new Filme {
                        Diretor = new Diretor { Nome = "N/A" },
                        Titulo = "Gotham",
                        Ano = "2014–"
                    },
                    new Filme {
                        Diretor = new Diretor { Nome = "N/A" },
                        Titulo = "Power",
                        Ano = "2014–"
                    },
                    new Filme {
                        Diretor = new Diretor { Nome = "N/A" },
                        Titulo = "Narcos",
                        Ano = "2015–"
                    },
                    new Filme {
                        Diretor = new Diretor { Nome = "N/A" },
                        Titulo = "Breaking Bad",
                        Ano = "2008–2013"
                    },
                    new Filme {
                        Diretor = new Diretor { Nome = "Scott Derrickson", NumeroFilmes = 4 },
                        Titulo = "Doctor Strange",
                        Ano = "2016"
                    },
                    new Filme {
                        Diretor = new Diretor { Nome = "Gareth Edwards", NumeroFilmes = 3 },
                        Titulo = "Rogue One: A Star Wars Story",
                        Ano = "2016"
                    },
                    new Filme {
                        Diretor = new Diretor { Nome = "Justin Kurzel", NumeroFilmes = 6 },
                        Titulo = "Assassin's Creed",
                        Ano = "2016"
                    },
                    new Filme {
                        Diretor = new Diretor { Nome = "N/A" },
                        Titulo = "Luke Cage",
                        Ano = "2016–"
                    }
                }
            };
        }
    }

    [DataContract]
    class Diretor
    {
        [DataMember]
        public string Nome { get; set; }
        [IgnoreDataMember]
        public int NumeroFilmes;
    }

    [DataContract]
    class Filme
    {
        [DataMember]
        public Diretor Diretor { get; set; }
        [DataMember]
        public string Titulo { get; set; }
        [DataMember]
        public string Ano { get; set; }
    }

    [DataContract]
    class LojaDeFilmes
    {
        [DataMember]
        public List<Diretor> Diretores = new List<Diretor>();
        [DataMember]
        public List<Filme> Filmes = new List<Filme>();
        public static LojaDeFilmes AdicionarFilme()
        {
            LojaDeFilmes loja = new LojaDeFilmes();
            // ...
            return loja;
        }
    }
}
