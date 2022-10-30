using System;
using System.Collections.Generic;
using System.Text;

namespace Rpg_proyecto_final_
{
    class Enemigo
    {
        //clase de la que heredan los tres tipos de enemigos
        public int vida,vidamax, daño, defensa, exp;
         public string nombre;
        public Enemigo(int i,int d,int de,int xp,string n)
        {
            vida = i;
            vidamax = i;
            daño = d;
            defensa = de;
            exp = xp;

        }
        //Función que permite a los enemigos atacar
        public void atacar(Personajes p1,Enemigo c)
        {
            p1.vida -= c.daño*p1.defensa/25;
            Console.WriteLine("El {0} te hace {1} de daño, te quedan {2} puntos de vida",c,c.daño * p1.defensa / 25, p1.vida);
              if (p1.vida <= 0)
            {
                Console.WriteLine("Te ha matado un {0}, suerte a la próxima");
                Console.WriteLine("Gracias por jugar");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
        
    }
}
