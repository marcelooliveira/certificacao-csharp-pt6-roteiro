using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace _01._04
{
    class Program
    {
        static void Main(string[] args)
        {
            LojaDeFilmes loja = new LojaDeFilmes
            {
                Diretores = new List<Diretor>
                {
                    new Diretor { Nome = "James Cameron" },
                    new Diretor { Nome = "Francis Lawrence" },
                    new Diretor { Nome = "Zack Snyder" },
                    new Diretor { Nome = "Joss Whedon" },
                    new Diretor { Nome = "Martin Scorsese" },
                    new Diretor { Nome = "Christopher Nolan" },
                    new Diretor { Nome = "Scott Derrickson" },
                    new Diretor { Nome = "Gareth Edwards" },
                    new Diretor { Nome = "Justin Kurzel" }
                },
                Filmes = new List<Filme> {
                    new Filme {
                        Diretor = new Diretor { Nome = "James Cameron" },
                        Titulo = "Avatar",
                        Ano = "2009"
                    },
                    new Filme {
                        Diretor = new Diretor { Nome = "Francis Lawrence" },
                        Titulo = "I Am Legend",
                        Ano = "2007"
                    },
                    new Filme {
                        Diretor = new Diretor { Nome = "Zack Snyder" },
                        Titulo = "300",
                        Ano = "2006"
                    },
                    new Filme {
                        Diretor = new Diretor { Nome = "Joss Whedon" },
                        Titulo = "The Avengers",
                        Ano = "2012"
                    },
                    new Filme {
                        Diretor = new Diretor { Nome = "Martin Scorsese" },
                        Titulo = "The Wolf of Wall Street",
                        Ano = "2013"
                    },
                    new Filme {
                        Diretor = new Diretor { Nome = "Christopher Nolan" },
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
                        Diretor = new Diretor { Nome = "Scott Derrickson" },
                        Titulo = "Doctor Strange",
                        Ano = "2016"
                    },
                    new Filme {
                        Diretor = new Diretor { Nome = "Gareth Edwards" },
                        Titulo = "Rogue One: A Star Wars Story",
                        Ano = "2016"
                    },
                    new Filme {
                        Diretor = new Diretor { Nome = "Justin Kurzel" },
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

            var json = JsonConvert.SerializeObject(loja);
            using (var writer = new StreamWriter("loja.json"))
            {
                writer.Write(json);
            }
        }
    }

    class Diretor
    {
        public string Nome { get; set; }

        [NonSerialized]
        public int tempData;
    }

    class Filme
    {
        public Diretor Diretor { get; set; }
        public string Titulo { get; set; }
        public string Ano { get; set; }
    }

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
