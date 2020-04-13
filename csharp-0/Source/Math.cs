using System;
using System.Collections.Generic;

namespace Codenation.Challenge
{
    public class Math
    {
        public List<int> Fibonacci()
        {
            
            List<int> list = new List<int>();
            int variavelUm = 0;
            int variavelDois = 1;
            int resultadoLista = 10;
            list.Add(0);

            while (resultadoLista <= 232)
            { 
                resultadoLista = variavelUm + variavelDois;
                variavelDois = variavelUm;
                variavelUm = resultadoLista;
                list.Add(resultadoLista);
            }
            return list;
        }

        public bool IsFibonacci(int numberToTest)
        {
            double primeiroTeste = System.Math.Sqrt((5 * System.Math.Pow(numberToTest, 2)) + 4);
            double segundoTeste = System.Math.Sqrt((5 * System.Math.Pow(numberToTest, 2)) - 4);

            if ((primeiroTeste % 1) == 0 || (segundoTeste % 1) == 0)
                return true;
            return false;
            

        }

    }
}
