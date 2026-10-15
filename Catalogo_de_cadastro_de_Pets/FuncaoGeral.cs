using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo_de_cadastro_de_Pets
{
    public class FuncaoGeral
    {

        /*********************************************************************************************************
            Nome da função: PegaRange
                 Parametro: string
                   Retorno: int
               Dt. Criação: 14/10/2026
                Observação: Está função é responsável por receber uma string e validar como um inteiro entre um Range
      *********************************************************************************************************/
        public int PegaRange(string ps_Msg, int pi_Min, int pi_Max)
        {
            int i_Result = 0;
            bool b_Valida = false;

            do
            {
                Console.Write(ps_Msg);
                b_Valida = int.TryParse(Console.ReadLine(), out i_Result) && i_Result >= pi_Min && i_Result <= pi_Max;

            } while (!b_Valida);

            return i_Result;
        }

        /*********************************************************************************************************
              Nome da função: PegaString
                   Parametro: string
                     Retorno: string
                 Dt. Criação: 14/10/2026
                  Observação: Está função é responsável por receber uma string e validar como um string
        *********************************************************************************************************/
        public string PegaString(string ps_Msg)
        {
            string s_Result = string.Empty;
            Console.Write(ps_Msg);
            s_Result = Console.ReadLine();

            return s_Result;
        }
        /******************************************************************************
              Nome da Função: PegaInt
                  Parametros: string
                     Retorno: int
                 Dt. Criação: 14/10/2026
                  Observação: Esta função é responsável por receber uma string e validar como um inteiro
     ******************************************************************************/
        public int PegaInt(string ps_Msg)
        {
            int i_Result = 0;
            bool b_Valida = false;

            do
            {
                Console.Write(ps_Msg);
                b_Valida = int.TryParse(Console.ReadLine(), out i_Result);

            } while (!b_Valida);

            return i_Result;
        }

    }
}
