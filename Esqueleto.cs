using System;
using System.Collections.Generic;
using System.Text;

namespace Rpg_proyecto_final_
{
    class Esqueleto : Enemigo
    {//Clase tipo esqueleto que hereda de enemigo con un constructor por defecto
        public Esqueleto(int vida, int daño, int def, int xp,string n) : base(vida, daño, def, xp,n)
        {

            vida = 35;
            daño = 5;
            def = 4;
            xp = 25;
            n = "Esqueleto";

        }

    }
}
