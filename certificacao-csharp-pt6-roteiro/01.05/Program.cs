using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace _01._05
{
    class Program
    {
        static void Main(string[] args)
        {
            LojaDeFilmes loja = LojaDeFilmes.TestData();
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
        }
    }

    [DataContract]
    class Diretor
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Nome { get; set; }
    }

    [DataContract]
    class Filme
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public Diretor Diretor { get; set; }
        [DataMember]
        public string Titulo { get; set; }
        [DataMember]
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
