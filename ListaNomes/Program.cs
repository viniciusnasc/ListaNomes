using System;
using System.Collections.Generic;

namespace ListaNomes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> nomes = new();

            string menu = Menu.MenuPrincipal();

            while (menu != "SAIR")
            {
                switch(menu)
                {
                    case "INCLUIR":
                        Menu.Incluir(nomes);
                        break;

                    case "ALTERAR":
                        Menu.Alterar(nomes);
                        break;

                    case "DELETAR":
                        Menu.Deletar(nomes);
                        break;

                    case "LISTAR":
                        Menu.Listar(nomes);
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida!\n");
                        break;
                }

                menu = Menu.MenuPrincipal();
            }

            Console.WriteLine("\nObrigado por utilizar nosso sistema! :)");
        }
    }
}
