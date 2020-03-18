using System;
using System.Collections.Generic;

namespace Codenation.Challenge
{
    public class Country
    {        
        public State[] Top10StatesByArea()
        {
            //State Acre = new State("Acre", "AC", 164123.040);
            //State Alagoas = new State("Alagoas", "AL", 27778.506);
            //State Amapa = new State("Amapá", "AP", 142828.521);
            //State Amazonas = new State("Amazonas", "AM", 1559159.148);
            //State Bahia = new State("Bahia", "BA", 564733.177);
            //State Ceara = new State("Ceara", "CE", 148920.472);
            //State DistritoFederal = new State("Distrito Federal", "DF", 5779.999);
            //State EspiritoSanto = new State("Espirito Santo", "ES", 46095.583);
            //State Goias = new State("Goias", "GO", 340111.783);
            //State Maranhao = new State("Maranhao", "MA", 331937.45);
            //State MatoGrosso = new State("Mato Grosso", "MT", 903366.192);
            //State MatoGrossodoSul = new State("Mato Grosso do Sul", "MS", 357145.532);
            //State MinasGerais = new State("Minas Gerais", "MG", 586522.122);
            //State Para = new State("Para", "PA", 1247954.666);
            //State Paraiba = new State("Paraiba", "PB", 56585);
            //State Parana = new State("Parana", "PR", 199307.922);
            //State Pernambuco = new State("Pernambuco", "PE", 98311.616);
            //State Piaui = new State("Piaui", "PI", 251577.738);
            //State RiodeJaneiro = new State("Rio de Janeiro", "RJ", 43780.172);
            //State RioGrandedoNorte = new State("Rio Grande do Norte", "RN", 52811.047);
            //State RioGrandedoSul = new State("Rio Grande do Sul", "RS", 281730.223);
            //State Rondonia = new State("Rondonia", "RO", 237590.547);
            //State Roraima = new State("Roraima", "RR", 224300.506);
            //State SantaCatarina = new State("Santa Catarina", "SC", 95736.165);
            //State SaoPaulo = new State("Sao Paulo", "SP", 248222.362);
            //State Sergipe = new State("Sergipe", "SE", 21915.116);
            //State Tocantins = new State("Tocantins", "TO", 277720.52);



            //State[] lista = new State[27] { Acre, Alagoas, Amapa, Amazonas, Bahia, Ceara, DistritoFederal, EspiritoSanto, Goias, Maranhao, MatoGrosso, MatoGrossodoSul, MinasGerais, Para, Paraiba, Parana, Pernambuco, Piaui, RiodeJaneiro, RioGrandedoNorte, RioGrandedoSul, Rondonia, Roraima, SantaCatarina, SaoPaulo, Sergipe, Tocantins };

            //Array.Sort(lista, delegate (State state1, State state2) {
            //    return state2.Area.CompareTo(state1.Area);
            //});

            //Array.Resize(ref lista, 10);
            //Console.WriteLine(lista);

            State Amazonas = new State("Amazonas", "AM");
            State Bahia = new State("Bahia", "BA");
            State Goias = new State("Goias", "GO");
            State Maranhao = new State("Maranhao", "MA");
            State MatoGrosso = new State("Mato Grosso", "MT");
            State MatoGrossodoSul = new State("Mato Grosso do Sul", "MS");
            State MinasGerais = new State("Minas Gerais", "MG");
            State Para = new State("Para", "PA");
            State RioGrandedoSul = new State("Rio Grande do Sul", "RS");
            State Tocantins = new State("Tocantins", "TO");

            State[] lista = new State[10] { Amazonas, Para, MatoGrosso, MinasGerais, Bahia, MatoGrossodoSul, Goias, Maranhao, RioGrandedoSul, Tocantins };

            for (int i = 0; i < lista.Length; i++)
            {
                Console.WriteLine(lista[i].Name);

            }
            return lista;

        }


        public static void Main()
        {
            //State Acre = new State("Acre", "AC", 164123.040);
            //State Alagoas = new State("Alagoas", "AL", 27778.506);
            //State Amapa = new State("Amapá", "AP", 142828.521);
            //State Amazonas = new State("Amazonas", "AM", 1559159.148);
            //State Bahia = new State("Bahia", "BA", 564733.177);
            //State Ceara = new State("Ceara", "CE", 148920.472);
            //State DistritoFederal = new State("Distrito Federal", "DF", 5779.999);
            //State EspiritoSanto = new State("Espirito Santo", "ES", 46095.583);
            //State Goias = new State("Goias", "GO", 340111.783);
            //State Maranhao = new State("Maranhao", "MA", 331937.45);
            //State MatoGrosso = new State("Mato Grosso", "MT", 903366.192);
            //State MatoGrossodoSul = new State("Mato Grosso do Sul", "MS", 357145.532);
            //State MinasGerais = new State("Minas Gerais", "MG", 586522.122);
            //State Para = new State("Para", "PA", 1247954.666);
            //State Paraiba = new State("Paraiba", "PB", 56585);
            //State Parana = new State("Parana", "PR", 199307.922);
            //State Pernambuco = new State("Pernambuco", "PE", 98311.616);
            //State Piaui = new State("Piaui", "PI", 251577.738);
            //State RiodeJaneiro = new State("Rio de Janeiro", "RJ", 43780.172);
            //State RioGrandedoNorte = new State("Rio Grande do Norte", "RN", 52811.047);
            //State RioGrandedoSul = new State("Rio Grande do Sul", "RS", 281730.223);
            //State Rondonia = new State("Rondonia", "RO", 237590.547);
            //State Roraima = new State("Roraima", "RR", 224300.506);
            //State SantaCatarina = new State("Santa Catarina", "SC", 95736.165);
            //State SaoPaulo = new State("Sao Paulo", "SP", 248222.362);
            //State Sergipe = new State("Sergipe", "SE", 21915.116);
            //State Tocantins = new State("Tocantins", "TO", 277720.52);



            // SECOND CODE


            //State Amazonas = new State("Amazonas", "AM");
            //State Bahia = new State("Bahia", "BA");
            //State Goias = new State("Goias", "GO");
            //State Maranhao = new State("Maranhao", "MA");
            //State MatoGrosso = new State("Mato Grosso", "MT");
            //State MatoGrossodoSul = new State("Mato Grosso do Sul", "MS");
            //State MinasGerais = new State("Minas Gerais", "MG");
            //State Para = new State("Para", "PA");
            //State RioGrandedoSul = new State("Rio Grande do Sul", "RS");
            //State Tocantins = new State("Tocantins", "TO");

            //State[] lista = new State[10] { Amazonas, Para, MatoGrosso, MinasGerais, Bahia, MatoGrossodoSul, Goias, Maranhao, RioGrandedoSul, Tocantins };

            //for (int i = 0; i < lista.Length; i++)
            //{
            //    Console.WriteLine(lista[i].Name);

            //}


        }

    }

}
