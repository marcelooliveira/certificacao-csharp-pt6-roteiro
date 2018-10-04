using System.Collections.Generic;
using System.Runtime.Serialization;

namespace _01._04
{
    [DataContract(Name="MovieStore")]
    public class LojaDeFilmes
    {
        [DataMember(Name="Directors")]
        public List<Diretor> Diretores = new List<Diretor>();
        [DataMember(Name = "Movies")]
        public List<Filme> Filmes = new List<Filme>();
        public static void AdicionarFilme(Filme filme)
        {
            // Aqui vai a lógica de inserção de filme...
        }
    }

    [DataContract(Name = "Director")]
    public class Diretor
    {
        [DataMember(Name = "Name")]
        public string Nome { get; set; }
        [IgnoreDataMember]
        public int NumeroFilmes;
    }

    [DataContract(Name = "Movie")]
    public class Filme
    {
        [DataMember(Name = "Director")]
        public Diretor Diretor { get; set; }
        [DataMember(Name = "Title")]
        public string Titulo { get; set; }
        [DataMember(Name = "Year")]
        public string Ano { get; set; }
    }
}
