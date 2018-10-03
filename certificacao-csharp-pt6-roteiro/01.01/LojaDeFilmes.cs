﻿using System.Collections.Generic;
using System.Xml.Serialization;

namespace _01._03
{
    [XmlRoot("MovieStore")]
    public class LojaDeFilmes
    {
        [XmlArray("Directors")]
        public List<Diretor> Diretores = new List<Diretor>();
        [XmlArray("Movies")]
        public List<Filme> Filmes = new List<Filme>();
        public static LojaDeFilmes AdicionarFilme(Filme filme)
        {
            LojaDeFilmes loja = new LojaDeFilmes();
            // ...
            return loja;
        }
    }

    [XmlType("Director")]
    public class Diretor
    {
        [XmlElement("Name")]
        public string Nome { get; set; }
        [XmlIgnore]
        public int NumeroFilmes;
    }

    [XmlType("Movie")]
    public class Filme
    {
        [XmlElement("Director")]
        public Diretor Diretor { get; set; }
        [XmlElement("Title")]
        public string Titulo { get; set; }
        [XmlElement("Year")]
        public string Ano { get; set; }
    }
}