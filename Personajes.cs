using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Rpg_proyecto_final_
{
    class Personajes
    {
        //clase que define al jugador
        public int vida,vidamax, cordura, temperatura, ingenio, fuerza, magia, defensa, nivel,xp;
       
        ArrayList mochila = new ArrayList();
        private string name { get; set; }
        private string[] razaLista = new string[4] { "mago", "guerrero", "sanador", "asesino" };
        private string[] ListaObjetos = new string[4] { "bomba", "poción", "enciclopedia", "armadura" };
        public string raza;

        //costructor por defecto
        public Personajes(string name)
        {
            this.name = name;
             vida=50;
             vidamax = 50;
             cordura=5;
             temperatura=36;
             ingenio=10;
             fuerza=10;
             magia=0;
             defensa=10;
             nivel=1;
              xp = 0;
             

        }
        //Función que permite subir de nivel dependiendo de la raza
        public void SubirNivel(Personajes p1)
        {
            if (xp >= 80)
            {
                if (p1.raza == "mago")
                {
                    //mago
                    Console.WriteLine("¡Subiste de nivel!");
                    p1.ingenio++;
                    p1.magia++;
                    p1.nivel++;
                    if (nivel % 2 != 0)
                    {
                        p1.fuerza++;
                        p1.defensa++;
                    }
                    p1.xp = 0;


                }
                else if (p1.raza == "guerrero")
                {
                    //guerrero
                    Console.WriteLine("¡Subiste de nivel!");
                    p1.fuerza += 2;
                    p1.defensa += 2;
                    p1.nivel++;
                    if (nivel % 2 != 0)
                    {
                        p1.ingenio++;

                    }
                    p1.xp = 0;

                }
                else if (p1.raza == "sanador")
                {
                    //sanador
                    Console.WriteLine("¡Subiste de nivel!");
                    p1.magia++;
                    p1.defensa++;
                    p1.nivel++;
                    if (nivel % 2 != 0)
                    {
                        p1.fuerza++;
                        p1.ingenio++;
                    }
                    p1.xp = 0;
                }
                else if (p1.raza == "asesino")
                {
                    //sanador
                    Console.WriteLine("¡Subiste de nivel!");
                    p1.fuerza += 2;
                    p1.nivel++;
                    if (nivel % 2 != 0)
                    {
                        p1.ingenio++;
                        p1.defensa++;
                    }
                    p1.xp = 0;
                }
            }
            
        }
        //Función que permite al jugador atacar según su raza
        public void atacar(Personajes p1,Enemigo c)
        {
            int dañoJugador= p1.fuerza - c.defensa/10;
            int opc=0;
            if (p1.raza == "mago")
            {
                //mago
                Console.WriteLine("Elige una acción: ");
                Console.WriteLine("1-Magia ofensiva: "+p1.magia * p1.ingenio/10 + " de daño\n2-Magia Sanadora: "+p1.magia*p1.ingenio/10+" de vida curada\n3-Usar objeto");

                try
                {
                    opc = Convert.ToInt32(Console.ReadLine());
                    


                }
                catch (System.FormatException)
                {

                    Console.Clear();
                    Console.WriteLine("Carácter inválido ");
                    atacar(p1, c);
                }
                switch (opc)
                {
                    case 1:
                        c.vida -= p1.magia*p1.ingenio/10;
                        Console.WriteLine("Has inflingido {0} daño al objetivo. Le quedan {1} puntos de vida",p1.magia * p1.ingenio/10, c.vida);
                       
                        break;
                    case 2:
                        
                        if (p1.vida >= vidamax)
                        {
                            Console.WriteLine("Ya tienes la vida al completo");
                        }
                        else
                        {

                            p1.vida += p1.magia * ingenio / 10;
                            Console.WriteLine("Te has curado {0} de vida", p1.magia * p1.ingenio / 10);

                        }
                        
                        
                        break;
                    case 3:
                        UsarObjeto(p1, c);

                        break;

                }


            }
            else if (p1.raza == "guerrero")
            {
                //guerrero
                Console.WriteLine("Elige una acción: ");
                Console.WriteLine("1-Cuerpo a cuerpo: " + dañoJugador + " de daño\n2-Ataque a distancia: " + dañoJugador + " de daño\n3-Usar objeto");

                try
                {
                    opc = Convert.ToInt32(Console.ReadLine());



                }
                catch (System.FormatException)
                {

                    Console.Clear();
                    Console.WriteLine("Carácter inválido ");
                    atacar(p1, c);
                }
                switch (opc)
                {
                    case 1:
                        c.vida -= dañoJugador;
                        Console.WriteLine("Has inflingido {0} daño al objetivo. Le quedan {1} puntos de vida", dañoJugador, c.vida);
                        
                        break;
                    case 2:
                        c.vida -= dañoJugador;
                        Console.WriteLine("Has inflingido {0} daño al objetivo. Le quedan {1} puntos de vida", dañoJugador, c.vida);
                        
                        break;
                    case 3:
                        UsarObjeto(p1, c);

                        break;
                }

            }
            else if (p1.raza == "sanador")
            {
                //sanador
                Console.WriteLine("Elige una acción: ");
                Console.WriteLine("1-Magia Sanadora: " + p1.ingenio + " de vida curada\n2-Sanación vampírica: "+p1.magia+"\n3-Ataque básico "+10+"\n4-Usar objeto");

                try
                {
                    opc = Convert.ToInt32(Console.ReadLine());



                }
                catch (System.FormatException)
                {

                    Console.Clear();
                    Console.WriteLine("Carácter inválido ");
                    atacar(p1, c);
                }
                switch (opc)
                {
                    
                    case 1:
                        if (p1.vida >= vidamax)
                        {
                            Console.WriteLine("Ya tienes la vida al completo");
                        }
                        else
                        {

                            p1.vida += p1.ingenio;
                            Console.WriteLine("Te has curado {0} de vida", p1.ingenio);

                        }
                        
                        
                       
                        break;
                  
                    case 2:
                        c.vida -= p1.magia ;
                        if (p1.vida >= vidamax)
                        {
                            Console.WriteLine("Ya tienes la vida al completo");
                        }
                        else
                        {
                           
                            p1.vida += p1.magia;
                           
                        }
                        
                        Console.WriteLine("Has inflingido {0} daño al objetivo y te curas {1} de vida. Le quedan {2} puntos de vida", p1.magia,p1.magia, c.vida);

                        break;
                    case 3:
                        c.vida -= 10;
                        Console.WriteLine("Has inflingido 10 daño al objetivo. Le quedan {0} puntos de vida", c.vida);

                        break;
                    case 4:
                        UsarObjeto(p1, c);

                        break;
                }

            }
            else if (p1.raza == "asesino")
            {
                //sanador
                Console.WriteLine("Elige una acción: ");
                Console.WriteLine("1-Cuerpo a cuerpo: " + dañoJugador*(3/2) + " de daño\n2-Usar objeto");

                try
                {
                    opc = Convert.ToInt32(Console.ReadLine());



                }
                catch (System.FormatException)
                {

                    Console.Clear();
                    Console.WriteLine("Carácter inválido ");
                    atacar(p1, c);
                }
                switch (opc)
                {
                    case 1:
                        c.vida -= dañoJugador * (3 / 2);
                        Console.WriteLine("Has inflingido {0} daño al objetivo. Le quedan {1} puntos de vida", dañoJugador * (3 / 2), c.vida);

                        break;
                    case 2:
                        UsarObjeto(p1, c);

                        break;

                }

            }

        }
        //Función que te permite usar objetos en combate según lo halla en su mochila
        public void UsarObjeto(Personajes p1,Enemigo c)
        {
            int opc=0;
            if (p1.mochila.Count < 1)
            {
                Console.WriteLine("No tienes objetos, vuelve a elegir otra opción");
                atacar(p1, c);
            }
            else
            {
                Console.WriteLine("Elige un objeto: ");
                MostrarMochila();
                try
                {
                    opc = Convert.ToInt32(Console.ReadLine());



                }
                catch (System.FormatException)
                {

                    Console.Clear();
                    Console.WriteLine("Carácter inválido ");
                    UsarObjeto(p1, c);
                }
                switch (opc)
                {
                    case 1:
                        UsarObjetos(opc, c, p1);

                        break;
                    case 2:
                        if (p1.mochila.Count < opc)
                        {
                            Console.WriteLine("No tienes objetos en esta posición, vuelve a elegir otro objeto");
                            atacar(p1, c);
                        }
                        else
                        {
                            UsarObjetos(opc, c, p1);
                        }
                        

                        break;
                    case 3:
                        if (p1.mochila.Count < opc)
                        {
                            Console.WriteLine("No tienes objetos en esta posición, vuelve a elegir otro objeto");
                            atacar(p1, c);
                        }
                        else
                        {
                            UsarObjetos(opc, c, p1);
                        }
                        break;
                    case 4:
                        if (p1.mochila.Count < opc)
                        {
                            Console.WriteLine("No tienes objetos en esta posición, vuelve a elegir otro objeto");
                            atacar(p1, c);
                        }
                        else
                        {
                            UsarObjetos(opc, c, p1);
                        }
                        break;
                    case 5:
                        if (p1.mochila.Count < opc)
                        {
                            Console.WriteLine("No tienes objetos en esta posición, vuelve a elegir otro objeto");
                            atacar(p1, c);
                        }
                        else
                        {
                            UsarObjetos(opc, c, p1);
                        }
                        break;
                }

            }
            



        }
        //Función para mostrar las estadísticas del jugador
        public void MostrarEstadísticas(Personajes a)
        {
            Console.WriteLine("Estadísticas de " + a.name+ ", nivel "+a.nivel+":");
            Console.WriteLine("Raza: " + a.raza);
            Console.WriteLine("Vida: " + a.vida+"/"+a.vidamax);
            Console.WriteLine("Cordura: " + a.cordura);
            Console.WriteLine("Temperatura: " + a.temperatura);
            Console.WriteLine("Ingenio: " + a.ingenio);
            Console.WriteLine("Fuerza: " + a.fuerza);
            Console.WriteLine("Magia: " + a.magia);
            Console.WriteLine("Defensa: " + a.defensa);
            Console.WriteLine("Experiencia: " + a.xp);
           

        }
        //Modifica las estadísticas del personaje en función de la raza elegida
        public void CambiarEstadísticas(Personajes a,int raza)
        {
            if (raza==1)
            {
                //mago
                a.raza = razaLista[0];
                a.ingenio +=10;
                a.magia += 10;

            }
            else if (raza==2)
            {
                //guerrero
                a.raza = razaLista[1];
                a.fuerza += 10;
                a.defensa += 10;
            }
            else if (raza==3)
            {
                //sanador
                a.raza = razaLista[2];
                a.ingenio += 10;
                a.magia += 5;
            }
            else if (raza==4)
            {
                //asesino
                a.raza = razaLista[3];
                a.fuerza += 15;
                a.defensa += 5;
            }
           

        }
        //Muestra el contenido de la mochila del jugador
        public void MostrarMochila()
        {
            for(int i = 0; i < mochila.Count; ++i)
            {
                Console.WriteLine((i+1)+" tienes: "+mochila[i]);
                
            }
        }
        //Comprueba que tipo de objeto se está escogiendo para usarlo
        public void UsarObjetos(int n,Enemigo c,Personajes p1)
        {
            if (mochila[n-1] == "bomba")
            {
                Console.WriteLine("Has inflingido 15 daño al objetivo. Le quedan {0} puntos de vida", c.vida);
                c.vida -= 15;
                mochila.Remove("bomba");
            }
            else if (mochila[n-1] == "pocion")
            {
                if (p1.vida >= vidamax)
                {
                    Console.WriteLine("Ya tienes la vida al completo");
                }
                else
                {
                    Console.WriteLine("Te has curado 15 puntos de vida, tienes {0} puntos de vida",  p1.vida);
                    p1.vida += 15;
                    mochila.Remove("pocion");
                }
               
            }
            else if (mochila[n-1] == "enciclopedia")
            {
                Console.WriteLine("Aumentas tu ingenio en 2 puntos, tienes {0} puntos de ingenio", p1.ingenio);
                p1.ingenio += 3;
                mochila.Remove("enciclopedia");

            }
            else if (mochila[n-1] == "armadura")
            {
                Console.WriteLine("Aumentas tu ingenio en 6 defensa, tienes {0} puntos de defensa", p1.defensa);
                p1.defensa += 6;
                mochila.Remove("armadura");
            }

        }
        //Permite añadir objetos seleccionados del tablero a la mochila
        public void AñadirAMochila(int? n,Personajes p1)
        {
            switch (n)
            {
                case 0:
                    int n2 = 0;
                    ComprobarCapMochila(n2);
                   
                    return;            
                case 1:
                    int n3 = 1;
                    ComprobarCapMochila(n3);
                    
                    return;
                case 2:
                    int n4 = 2;
                    ComprobarCapMochila(n4);                  
                    return;
                case 3:
                    int n5 = 3;
                    ComprobarCapMochila(n5);             
                    return;
            }
                
        }
        //Esta función comprueba la capacidad de la mochila y permite cambiar un nuevo objeto por uno ya obtenido
        public void ComprobarCapMochila(int n)
        {
            string sel="";
            if (mochila.Count >= 5)
            {
                Console.WriteLine("Tu mochila está llena, sustituyelo por otro objeto: ");
                MostrarMochila();
                sel = Console.ReadLine();
                
                switch (sel)
                {
                    case "1":
                        mochila.Insert(1, ListaObjetos[n]);
                        return;
                    case "2":
                        mochila.Insert(2, ListaObjetos[n]);
                        return;
                    case "3":
                        mochila.Insert(3, ListaObjetos[n]);
                        return;
                    case "4":
                        mochila.Insert(4, ListaObjetos[n]);
                        return;
                }
            }
            else
            {
                mochila.Add(ListaObjetos[n]);
            }
        }
       

    }
}
