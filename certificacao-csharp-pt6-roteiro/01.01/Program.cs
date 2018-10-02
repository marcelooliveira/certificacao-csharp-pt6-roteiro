using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace _01._01
{
    class Program
    {
        static void Main(string[] args)
        {
            LojaDeFilmes loja = LojaDeFilmes.TestData();
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream outputStream =
            new FileStream("Filmes.bin", FileMode.OpenOrCreate, FileAccess.Write))
            {
                formatter.Serialize(outputStream, loja);
            }

            LojaDeFilmes inputData;
            using (FileStream inputStream = new FileStream("Filmes.bin", FileMode.Open, FileAccess.Read))
            {
                inputData = (LojaDeFilmes)formatter.Deserialize(inputStream);
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
        public int DuracaoMinutos { get; set; }
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
