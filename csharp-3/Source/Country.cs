using System;
using System.Collections.Generic;

namespace Codenation.Challenge
{
    public class Country
    {        
        public State[] Top10StatesByArea()
        {
            State[] estados = new State[10];

            estados[0] = new State("Amazonas", "AM");
            estados[1] = new State("Para", "PA");
            estados[2] = new State("Mato Grosso", "MT");
            estados[3] = new State("Minas Gerais", "MG");
            estados[4] = new State("Bahia", "BA");
            estados[5] = new State("Mato Grosso do Sul", "MS");
            estados[6] = new State("Goias", "GO");
            estados[7] = new State("Maranhao", "MA");
            estados[8] = new State("Rio Grande do Sul", "RS");
            estados[9] = new State("Tocantins", "TO");

            return estados;

        }

    }

}
