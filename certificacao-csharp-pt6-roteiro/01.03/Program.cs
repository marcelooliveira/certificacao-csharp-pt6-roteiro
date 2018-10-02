using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace _01._03
{
    class Program
    {
        static void Main(string[] args)
        {
            LojaDeFilmes loja = LojaDeFilmes.TestData();
            XmlSerializer formatter = new XmlSerializer(typeof(LojaDeFilmes));
            using (FileStream outputStream = new FileStream("Filmes.xml", FileMode.OpenOrCreate, FileAccess.Write))
            {
                formatter.Serialize(outputStream, loja);
            }
            LojaDeFilmes inputData;
            using (FileStream inputStream =
            new FileStream("Filmes.xml", FileMode.Open, FileAccess.Read))
            {
            }
        }
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
        public int Ano { get; set; }
    }

    [Serializable]
    class LojaDeFilmes
    {
        List<Diretor> Diretor = new List<Diretor>();
        List<Filme> Filmes = new List<Filme>();
        public static LojaDeFilmes TestData()
        {
            LojaDeFilmes result = new LojaDeFilmes();
            // ...
            return result;
        }
    }
}
