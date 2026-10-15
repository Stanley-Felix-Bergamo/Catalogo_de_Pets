using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Catalogo_de_cadastro_de_Pets.Propriedades;
using static System.Net.Mime.MediaTypeNames;

namespace Catalogo_de_cadastro_de_Pets
{
    internal class Program
    {
        static string s_Path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ListaPets.txt");
        static List<Pet> Lista_Pets = new List<Pet>();
        static Pet obj_Pet = new Pet();
        static FuncaoGeral obj_FuncaoGeral = new FuncaoGeral();
        static int i_Opcao = 0;
        static string s_Nome = string.Empty;
        static bool b_Encontrou = false;


        static string[] s_ItensMenu =
      {
           "╔════════════════════════════════════╗",
           "║0 - Sair                            ║",
           "║1 - Cadastrar                       ║",
           "║2 - Editar                          ║",
           "║3 - Apagar                          ║",
           "║4 - Buscar                          ║",
           "║5 - Listar todos                    ║",
           "╚════════════════════════════════════╝",
        };

        static void PopulandoMenu(string[] ps_Itens)
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════╗");
            Console.WriteLine("║                                    ║");
            Console.WriteLine("║         Catálogo de Pets           ║");
            Console.WriteLine("║                                    ║");
            Console.WriteLine("╚════════════════════════════════════╝");
            Console.WriteLine();

            for (int i = 0; i < ps_Itens.Length; i++)
            {
                Console.WriteLine(ps_Itens[i]);
            }
            Console.WriteLine();
            Console.Write("");
        }

        static void TelaInicial()
        {
            Console.WriteLine();
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                            P E T S                                    ║");
            Console.WriteLine("╠═════════════════════════╦═════════════════════════════════════════════╣");
            Console.WriteLine("║ Qual é o tipo do Animal ║                                             ║");
            Console.WriteLine("╠═════════════════════════╬═════════════════════════════════════════════╣");
            Console.WriteLine("║                    Raça ║                                             ║");
            Console.WriteLine("╠═════════════════════════╬═════════════════════════════════════════════╣");
            Console.WriteLine("║                    Nome ║                                             ║");
            Console.WriteLine("╠═════════════════════════╬═════════════════════════════════════════════╣");
            Console.WriteLine("║                   Idade ║                                             ║");
            Console.WriteLine("╠═════════════════════════╬═════════════════════════════════════════════╣");
            Console.WriteLine("║        Vacinação em dia ║                                             ║");
            Console.WriteLine("╚═════════════════════════╩═════════════════════════════════════════════╝");
            Console.WriteLine("\n\n");
        }


        static void ImportaDados(string ps_Path)
        {
            if (File.Exists(ps_Path))
            {
                string s_Line = string.Empty;
                int i_Cont = 0;

                StreamReader obj_SR = new StreamReader(ps_Path);

                while (!(obj_SR.EndOfStream))
                {
                    Pet obj_Pet = new Pet();

                    s_Line = obj_SR.ReadLine();
                    string[] s_Dados = s_Line.Split(',');

                    obj_Pet.s_TipoAnimal = s_Dados[0];
                    obj_Pet.s_Raca = s_Dados[1];
                    obj_Pet.s_Nome = s_Dados[2];
                    obj_Pet.i_Idade = Convert.ToInt32(s_Dados[3]);
                    obj_Pet.s_Vacina = s_Dados[4];

                    Lista_Pets.Add(obj_Pet);
                }
                obj_SR.Close();
                Console.WriteLine("Importação dos dados realizado com sucesso !");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("O arquivo de importação não existe,verifique o caminho do arquivo.");
                Console.ReadLine();
            }
        }

        static void Main(string[] args)
        {
            ImportaDados(s_Path);
            do
            {

                PopulandoMenu(s_ItensMenu);
                i_Opcao = obj_FuncaoGeral.PegaRange("Entre com sua opção (0, 1, 2, 3, 4 ou 5):", 0, 5);

                switch (i_Opcao)
                {
                    case 0:
                        {
                            Console.Clear();
                            StreamWriter Obj_Sw = new StreamWriter(s_Path, false);

                            for (int i = 0; i < Lista_Pets.Count; i++)
                            {
                                obj_Pet.s_TipoAnimal = Lista_Pets[i].s_TipoAnimal;
                                obj_Pet.s_Raca = Lista_Pets[i].s_Raca;
                                obj_Pet.s_Nome = Lista_Pets[i].s_Nome;
                                obj_Pet.i_Idade = Lista_Pets[i].i_Idade;
                                obj_Pet.s_Vacina = Lista_Pets[i].s_Vacina;

                                Obj_Sw.WriteLine(
                                    obj_Pet.s_TipoAnimal + "," +
                                    obj_Pet.s_Raca + "," +
                                    obj_Pet.s_Nome + "," +
                                    obj_Pet.i_Idade + "," +
                                    obj_Pet.s_Vacina);
                            }

                            Obj_Sw.Close();
                            Environment.Exit(0);
                            break;
                        }
                    case 1:
                        {
                            Console.Clear();
                            TelaInicial();
                            do
                            {
                                Console.SetCursorPosition(28, 4);
                                obj_Pet.s_TipoAnimal = obj_FuncaoGeral.PegaString("");

                                Console.SetCursorPosition(28, 6);
                                obj_Pet.s_Raca = obj_FuncaoGeral.PegaString("");

                                Console.SetCursorPosition(28, 8);
                                obj_Pet.s_Nome = obj_FuncaoGeral.PegaString("");

                                Console.SetCursorPosition(28, 10);
                                obj_Pet.i_Idade = obj_FuncaoGeral.PegaInt("");

                                Console.SetCursorPosition(28, 12);
                                obj_Pet.s_Vacina = obj_FuncaoGeral.PegaString("");

                                Lista_Pets.Add(obj_Pet);

                                Console.Clear();
                            } while (obj_FuncaoGeral.PegaString("Deseja adicionar outro Pet (S/N) ?").ToUpper() == "S");
                            break;
                        }
                    case 2:
                        {
                            do
                            {
                                Console.Clear();
                                s_Nome = string.Empty;
                                b_Encontrou = false;

                                s_Nome = obj_FuncaoGeral.PegaString("Digite o nome do Pet que deseja editar: ");


                                for (int i = 0; i < Lista_Pets.Count; i++)
                                {
                                    if (Lista_Pets[i].s_Nome.ToUpper() == s_Nome.ToUpper())
                                    {
                                        b_Encontrou = true;
                                        Console.Clear();
                                        TelaInicial();

                                        Console.SetCursorPosition(28, 4);
                                        Console.WriteLine(Lista_Pets[i].s_TipoAnimal);

                                        Console.SetCursorPosition(28, 6);
                                        Console.WriteLine(Lista_Pets[i].s_Raca);

                                        Console.SetCursorPosition(28, 8);
                                        Console.WriteLine(Lista_Pets[i].s_Nome);

                                        Console.SetCursorPosition(28, 10);
                                        Console.WriteLine(Lista_Pets[i].i_Idade);

                                        Console.SetCursorPosition(28, 12);
                                        Console.WriteLine(Lista_Pets[i].s_Vacina);

                                        Console.SetCursorPosition(0, 14);

                                        obj_Pet = Lista_Pets[i];


                                        if (obj_FuncaoGeral.PegaString("Deseja editar tipo deste Pet (S/N) ?").ToUpper() == "S")
                                        {
                                            Console.SetCursorPosition(28, 4);
                                            Console.Write(new string(' ', 30));
                                            Console.SetCursorPosition(28, 4);
                                            obj_Pet.s_TipoAnimal = obj_FuncaoGeral.PegaString("");
                                        }

                                        Console.SetCursorPosition(0, 14);
                                        Console.Write(new string(' ', 30));
                                        Console.SetCursorPosition(0, 14);

                                        if (obj_FuncaoGeral.PegaString("Deseja editar a raça deste Pet (S/N) ?").ToUpper() == "S")
                                        {
                                            Console.SetCursorPosition(28, 6);
                                            Console.Write(new string(' ', 30));
                                            Console.SetCursorPosition(28, 6);
                                            obj_Pet.s_Raca = obj_FuncaoGeral.PegaString("");
                                        }

                                        Console.SetCursorPosition(0, 14);
                                        Console.Write(new string(' ', 30));
                                        Console.SetCursorPosition(0, 14);

                                        if (obj_FuncaoGeral.PegaString("Deseja editar o nome deste Pet (S/N) ?").ToUpper() == "S")
                                        {
                                            Console.SetCursorPosition(28, 8);
                                            Console.Write(new string(' ', 30));
                                            Console.SetCursorPosition(28, 8);
                                            obj_Pet.s_Nome = obj_FuncaoGeral.PegaString("");
                                        }

                                        Console.SetCursorPosition(0, 14);
                                        Console.Write(new string(' ', 30));
                                        Console.SetCursorPosition(0, 14);

                                        if (obj_FuncaoGeral.PegaString("Deseja editar a Idade deste Pet (S/N) ?").ToUpper() == "S")
                                        {
                                            Console.SetCursorPosition(28, 8);
                                            Console.Write(new string(' ', 30));
                                            Console.SetCursorPosition(28, 8);
                                            obj_Pet.i_Idade = obj_FuncaoGeral.PegaInt("");
                                        }

                                        Console.SetCursorPosition(0, 14);
                                        Console.Write(new string(' ', 30));
                                        Console.SetCursorPosition(0, 14);

                                        if (obj_FuncaoGeral.PegaString("Deseja editar a vacinação deste Pet (S/N) ?").ToUpper() == "S")
                                        {
                                            Console.SetCursorPosition(28, 8);
                                            Console.Write(new string(' ', 30));
                                            Console.SetCursorPosition(28, 8);
                                            obj_Pet.s_Vacina = obj_FuncaoGeral.PegaString("");
                                        }

                                        Console.SetCursorPosition(0, 14);
                                        Console.Write(new string(' ', 50));
                                        Console.SetCursorPosition(0, 14);

                                        Lista_Pets[i] = obj_Pet;
                                        break;
                                    }
                                }

                                if (!b_Encontrou)
                                {
                                    Console.WriteLine("Pet {0} não encontrado.", s_Nome);
                                }

                            } while (obj_FuncaoGeral.PegaString("Deseja editar outro Pet (S/N) ?").ToUpper() == "S");
                            break;
                        }
                    case 4:
                        {
                            do
                            {
                                Console.Clear();
                                s_Nome = string.Empty;
                                b_Encontrou = false;

                                s_Nome = obj_FuncaoGeral.PegaString("Digite o nome do Pet que deseja deletar: ");

                                for (int i = 0; i < Lista_Pets.Count; i++)
                                {
                                    if (Lista_Pets[i].s_Nome.ToUpper() == s_Nome.ToUpper())
                                    {
                                        b_Encontrou = true;
                                        Console.Clear();
                                        TelaInicial();

                                        Console.SetCursorPosition(28, 4);
                                        Console.WriteLine(Lista_Pets[i].s_TipoAnimal);

                                        Console.SetCursorPosition(28, 6);
                                        Console.WriteLine(Lista_Pets[i].s_Raca);

                                        Console.SetCursorPosition(28, 8);
                                        Console.WriteLine(Lista_Pets[i].s_Nome);

                                        Console.SetCursorPosition(28, 10);
                                        Console.WriteLine(Lista_Pets[i].i_Idade);

                                        Console.SetCursorPosition(28, 12);
                                        Console.WriteLine(Lista_Pets[i].s_Vacina);

                                        Console.SetCursorPosition(0, 14);
                                        break;
                                    }
                                }

                                if (!b_Encontrou)
                                {
                                    Console.WriteLine("Pet {0} não encontrado.", s_Nome);
                                }

                            } while (obj_FuncaoGeral.PegaString("Deseja deletar outro Pet (S/N) ?").ToUpper() == "S");
                            break;
                        }
                    case 3:
                        {
                            do
                            {
                                Console.Clear();
                                s_Nome = string.Empty;
                                b_Encontrou = false;

                                s_Nome = obj_FuncaoGeral.PegaString("Digite o nome do Pet que deseja buscar: ");

                                for (int i = 0; i < Lista_Pets.Count; i++)
                                {
                                    if (Lista_Pets[i].s_Nome.ToUpper() == s_Nome.ToUpper())
                                    {
                                        b_Encontrou = true;
                                        Console.Clear();
                                        TelaInicial();

                                        Console.SetCursorPosition(28, 4);
                                        Console.WriteLine(Lista_Pets[i].s_TipoAnimal);

                                        Console.SetCursorPosition(28, 6);
                                        Console.WriteLine(Lista_Pets[i].s_Raca);

                                        Console.SetCursorPosition(28, 8);
                                        Console.WriteLine(Lista_Pets[i].s_Nome);

                                        Console.SetCursorPosition(28, 10);
                                        Console.WriteLine(Lista_Pets[i].i_Idade);

                                        Console.SetCursorPosition(28, 12);
                                        Console.WriteLine(Lista_Pets[i].s_Vacina);

                                        Console.SetCursorPosition(0, 14);

                                        obj_Pet = Lista_Pets[i];

                                        if (obj_FuncaoGeral.PegaString("Deseja excluir este pet (S/N)? ").ToUpper() == "S")
                                        {
                                            Lista_Pets.Remove(obj_Pet);
                                        }
                                        break;
                                    }
                                }

                                if (!b_Encontrou)
                                {
                                    Console.WriteLine("Pet {0} não encontrado.", s_Nome);
                                }

                            } while (obj_FuncaoGeral.PegaString("Deseja Alterar outro contato (S/N)?").ToUpper() == "S");

                            break;
                        }
                    case 5:
                        {
                            Console.Clear();
                            int i_Linha = 0;

                            for (int i = 0; i < Lista_Pets.Count; i++)
                            {
                                if (i_Linha >= 12)
                                {
                                    Console.SetCursorPosition(0, i_Linha);
                                    Console.Write("Pressione qualquer tecla para ver os próximos Pets...");
                                    Console.ReadKey();

                                    Console.Clear();
                                    i_Linha = 0;
                                }
                                if (Lista_Pets[i].s_TipoAnimal != string.Empty)
                                {
                                    TelaInicial();

                                    Console.SetCursorPosition(28, 4 + i_Linha);
                                    Console.WriteLine(Lista_Pets[i].s_TipoAnimal);

                                    Console.SetCursorPosition(28, 6 + i_Linha);
                                    Console.WriteLine(Lista_Pets[i].s_Raca);

                                    Console.SetCursorPosition(28, 8 + i_Linha);
                                    Console.WriteLine(Lista_Pets[i].s_Nome);

                                    Console.SetCursorPosition(28, 10 + i_Linha);
                                    Console.WriteLine(Lista_Pets[i].i_Idade);

                                    Console.SetCursorPosition(28, 12 + i_Linha);
                                    Console.WriteLine(Lista_Pets[i].s_Vacina);

                                    i_Linha += 14;
                                }
                            }
                            Console.ReadLine();
                            break;
                        }
                }
            } while (true);

        }
    }
}
