using System;
using System.Collections.Generic;
using System.Text;

namespace Rpg_proyecto_final_
{
    class Fantasma:Enemigo
    {//Clase tipo fantasma que hereda de enemigo con un constructor por defecto
        public Fantasma(int vida,int daño, int def,int xp,string n): base(vida, daño, def, xp,n)
        {

            vida = 35;
            daño = 15;
            def = 15;
            xp = 50;
            n = "Fantasma";
        }
    }
}
