﻿using System;
<<<<<<< HEAD
using System.Collections.Generic;
=======
>>>>>>> 036a488381c363358bec2eea7d0ff8451f24cd58

namespace _02._04
{
    class Program
    {
        static void Main(string[] args)
        {
<<<<<<< HEAD
            //SETS = CONJUNTOS

            //Duas propriedades do Set
            //1. não permite duplicidade
            //2. os elementos não são mantidos em ordem específica

            //declarando set de alunos
            ISet<string> alunos = new HashSet<string>();
            //adicionando: vanessa, ana, rafael
            alunos.Add("Vanessa Tonini");
            alunos.Add("Ana Losnak");
            alunos.Add("Rafael Nercessian");

            //A linha abaixo não imprime os elementos!
            Console.WriteLine(alunos); //System.Collections.Generic.HashSet`1[System.String]

            //Imprime os alunos separados por vírgula
            Console.WriteLine(string.Join(",", alunos));

            //qual a diferença para uma lista?? vamos ver agora

            //adicionando: priscila, rollo, fabio
            alunos.Add("Priscila Stuani");
            alunos.Add("Rafael Rollo");
            alunos.Add("Fabio Gushiken");

            Console.WriteLine();
            Console.WriteLine(string.Join(",", alunos));
            //e a ordem???

            //removendo ana, adicionando marcelo
            alunos.Remove("Ana Losnak");
            alunos.Add("Marcelo Oliveira");
            //imprimindo de novo
            Console.WriteLine(string.Join(",", alunos));
            Console.WriteLine();

            //adicionando gushiken de novo - não gera erro de duplicidade!
            alunos.Add("Fabio Gushiken");
            Console.WriteLine(string.Join(",", alunos));

            //qual a vantagem do set sobre a lista? look-up!

            //desempenho HashSet x List: escalabilidade X memória

            //ordenando: sort
            //alunos.Sort();
            //copiando: alunosEmLista
            List<string> alunosEmLista = new List<string>(alunos);
            //ordenando copia
            alunosEmLista.Sort();
            //imprimindo copia
            Console.WriteLine(string.Join(",", alunosEmLista));
=======
            Console.WriteLine("Hello World!");
>>>>>>> 036a488381c363358bec2eea7d0ff8451f24cd58
        }
    }
}
