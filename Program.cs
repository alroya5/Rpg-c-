using System;

namespace Rpg_proyecto_final_
{
    class Program
    {
        //Codigo hecho por Alvaro Rodrigez Yagüe y Pablo Castellot Barajas.
        //inicio del juego y llama a funciones dentro de otras clases
        static void Main(string[] args)
        {
            Intro();
            Tablero tablero = new Tablero();
            Personajes p1 = new Personajes(CreaciónDePersonaje());
            p1.CambiarEstadísticas(p1, ElegirRaza());
            p1.MostrarEstadísticas(p1);
            tablero.RellenarTablero();
            Console.WriteLine("Pulsa cualquier tecla para continuar");
            Console.ReadKey();
            tablero.SacarTablero();
            tablero.ElegirMovimiento(p1);
            
            

            
        }
        //Estas dos funciones permiten seleccionar tanto el nombre como la raza del jugador
        static string CreaciónDePersonaje()
        {

            var name = "";
            
            Console.WriteLine("Escribe un nombre para el personaje: ");
            name = Console.ReadLine();
            Console.WriteLine(name + " creado");
            Console.ReadKey();
            Console.Clear();
            
            return name;

        }
        static int ElegirRaza()
        {
            int raza = 2;
           
            
            do
            {
                Console.Clear();
                Console.WriteLine("Elige una raza para tu personaje: ");
                Console.WriteLine(" 1-Mago\n 2-Guerrero\n 3-Sanador\n 4-Asesino");

            } while (!Int32.TryParse(Console.ReadLine(),out raza)||raza>4||raza<1);
              
           

            Console.Clear();
            return raza;
        }
        static void Intro()
        {
            Console.WriteLine("Érase una vez, en el plácido reino de Elaria...");
            Console.ReadKey();
            Console.WriteLine("Los ciudadanos de este reino vivían tranquilamente, pero un fatídico día el dragón rojo Ankalagon se estableció dentro del reino, destruyendo a todos los que se interpusieron en su camino.");
            Console.ReadKey();
            Console.WriteLine("La mayoría de supervivientes huyeron, pero unos pocos decidieron quedarse en esta tierra maldita, siendo corrompidos o resucitados como no muertos por la magia negra del dragón.");
            Console.ReadKey();
            Console.WriteLine("Tú, aventurero, has sido contratado por el legítimo señor de estas tierras por tu buena reputación, y se te ha encargado acabar con esta amenaza.");
            Console.ReadKey();
            Console.WriteLine("Suerte, aventurero.");
            Console.ReadKey();
           

        }

    }
}
