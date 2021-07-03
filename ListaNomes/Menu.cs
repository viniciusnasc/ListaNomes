using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ListaNomes
{
    class Menu
    {
        public static string MenuPrincipal()
        {
            Console.WriteLine("Seja bem vindo ao banco de nomes." +
                              "\nDigite 'incluir' para criar um novo nome;" +
                              "\nDigite 'alterar' para atualizar algum nome;" +
                              "\nDigite 'deletar' para excluir algum nome;" +
                              "\nDigite 'listar' para mostrar todos nomes cadastrados;" +
                              "\nOu digite 'sair' para Sair da aplicação.");

            return Console.ReadLine().ToUpper();
        }

        public static void Incluir(List<string> lista)
        {
            Console.Clear();

            Console.WriteLine("INCLUSÃO DE NOMES: ");
            Console.Write("Digite o nome que deseja incluir(não é valido nomes repetidos): ");
            string nome = Console.ReadLine().Trim();// Trim = retira espaços antes e depois do texto

            // Utilizei regex para retirar espaços extras em nome compostos
            Regex regex = new("[ ]{2,}"); // Encontra na string dois ou mais espaços
            nome = regex.Replace(nome, " "); // Altera os espaços encontrados por apenas um

            // Variaveis para impedir nomes duplicados com caixa alta, caixa baixa, ou primeira letra maiuscula, resto minuscula
            string nomeAlt, nomeLow, nomeFL;
            nomeAlt = nome.ToUpper();
            nomeLow = nome.ToLower();
            nomeFL = "";
            if(nome.Length != 0)
                nomeFL = char.ToUpper(nome[0]) + nome.Substring(1);

            while (string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine("Não é permitido valor nulo!");
                Console.Write("Digite um nome valido: ");
                nome = Console.ReadLine();
            }

            if (lista.Find(x => x == nome) == null && lista.Find(x => x.ToUpper() == nomeAlt) == null && lista.Find(x => x.ToLower() == nomeLow) == null && lista.Find(x => x == nomeFL) == null)
            {
                lista.Add(nome);
                Console.WriteLine("Nome cadastrado com sucesso!\n");
            }
            else
                Console.WriteLine("Este nome já está incluso na lista. Nome não cadastrado.\n");
        }

        public static void Alterar(List<string> lista)
        {
            Console.Clear();
            Console.WriteLine("ALTERAR NOME CADASTRADO: ");
            Console.Write("Digite o nome que deseja alterar: ");
            string nome = Console.ReadLine();

            if (lista.Find(x => x == nome) == null)
                Console.WriteLine("Nome não encontrado!\n");
            else
            {
                Console.Write("Digite a alteração que deseja fazer: ");
                int indice = lista.FindIndex(x => x == nome);
                lista[indice] = Console.ReadLine();
                Console.WriteLine("Nome alterado com sucesso!\n");
            }
        }

        public static void Deletar(List<string> lista)
        {
            Console.Clear();
            Console.Write("Digite o nome que deseja excluir da lista: ");
            string nome = Console.ReadLine();

            if (lista.Find(x => x == nome) == null)
                Console.WriteLine("Nome não cadastrado!\n");
            else
            {
                lista.Remove(nome);
                Console.WriteLine("Nome removido com sucesso!\n");
            }
        }

        public static void Listar(List<string> lista)
        {
            Console.Clear();
            Console.WriteLine("Nomes cadastrados no sistema:");

            if (lista.Count == 0)
                Console.WriteLine("Nenhum nome cadastrado!");

            foreach (string obj in lista)
                Console.WriteLine(obj);

            Console.WriteLine();
        }
    }
}
