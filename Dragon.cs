using System;
using System.Collections.Generic;
using System.Text;

namespace Rpg_proyecto_final_
{
    class Dragon:Enemigo
    {
        //Clase tipo dragón que hereda de enemigo con un constructor por defecto
        public Dragon(int vida, int daño, int def, int xp,string n) : base(vida, daño, def, xp,n)
        {

            vida = 60;
            daño = 25;
            def = 50;
            xp = 80;
            n = "Dragón";

        }
        
    }
}
