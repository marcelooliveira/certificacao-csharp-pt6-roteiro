using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace _01._05
{
    class Program
    {
        static void Main(string[] args)
        {
            LojaDeFilmes loja = ObterDados();

            DataContractSerializer formatter = new DataContractSerializer(typeof(LojaDeFilmes));
            using (FileStream outputStream =
                new FileStream("Filmes.xml", FileMode.OpenOrCreate, FileAccess.Write))
            {
                formatter.WriteObject(outputStream, loja);
            }

            LojaDeFilmes inputData;
            using (FileStream inputStream =
            new FileStream("Filmes.xml", FileMode.Open, FileAccess.Read))
            {
                inputData = (LojaDeFilmes)formatter.ReadObject(inputStream);
            }

            foreach (var diretor in inputData.Diretores)
            {
                Console.WriteLine(diretor.Nome);
            }

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

    [Serializable]
    public class Diretor : ISerializable
    {
        public string Nome { get; set; }
        public int NumeroFilmes;
        public string Resumo { get; set; }

        public Diretor(SerializationInfo info, StreamingContext context)
        {
            Resumo = info.GetString("Resumo");
        }

        public Diretor()
        {
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Resumo", $"O diretor {0} tem {1} filmes disponíveis.");
        }

        [OnSerializing()]
        internal void OnSerializingMethod(StreamingContext context)
        {
            Console.WriteLine($"Antes da serialização do diretor: {this.Nome}");
        }

        [OnSerialized()]
        internal void OnSerializedMethod(StreamingContext context)
        {
            Console.WriteLine($"Depois da serialização do diretor: {this.Nome}");
        }

        [OnDeserializing()]
        internal void OnDeserializingMethod(StreamingContext context)
        {
            Console.WriteLine($"Antes da serialização do diretor: {this.Nome}");
        }

        [OnDeserialized()]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            Console.WriteLine($"Depois da serialização do diretor: {this.Nome}");
        }
    }

    [Serializable]
    public class Filme
    {
        public Diretor Diretor { get; set; }
        public string Titulo { get; set; }
        public string Ano { get; set; }
    }

    [Serializable]
    public class LojaDeFilmes
    {
        public List<Diretor> Diretores = new List<Diretor>();
        public List<Filme> Filmes = new List<Filme>();
        public static LojaDeFilmes TestData()
        {
            LojaDeFilmes result = new LojaDeFilmes();
            // ...
            return result;
        }
    }
}
