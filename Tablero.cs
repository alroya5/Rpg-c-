using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;


namespace Rpg_proyecto_final_
{
    class Tablero
    {
        //Esta clase controla el tablero, los turnos y todo lo relacionado con estos, por ejemplo los enemigos, la representación del tablero
        //o los combates
        string[,] tableroTiposCasillas = new string[5, 5];
        string[,] tableroTiposDeUnidades = new string[4, 4];
        string[,] indicadorPersonaje = new string[5, 5];
        int?[,] tableroObjetos = new int?[4, 4];
        Enemigo[,] conjuntoEnemigos = new Enemigo[4, 4];
        bool seguirCombate = true;
        Dragon d1=new Dragon(60,25,50,80,"Dragón");
        Esqueleto e1=new Esqueleto(35,5,4,25,"Esqueleto"), e2=new Esqueleto(35, 5, 4, 25,"Esqueleto"), e3 = new Esqueleto(35, 5, 4, 25,"Esqueleto");
        Fantasma f1=new Fantasma(35,15,15,50,"Fantasma"), f2 = new Fantasma(35, 15, 15, 50, "Fantasma"), f3 = new Fantasma(35, 15, 15, 50, "Fantasma");
        int posx = 0;int posy=0;
        int d = 1, e = 3, f = 2;

        string[] tiposCasillas = new string[6] {"[posada]","[desierto]","[tundra]","[cementerio]","[pradera]","[pantano]"};
        string[] tiposUnidades = new string[4] { "[personaje]", "[dragón]", "[fantasma]", "[esqueleto]" };
        
        //Esta función muestra por pantalla el tablero que incluye la posición del jugador, tipos de casilla y enemigos
        public void SacarTablero()
        {    
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    
                    Console.Write("                         "+tableroTiposCasillas[i, j] + tableroTiposDeUnidades[i,j]+indicadorPersonaje[i,j]);

                }
                Console.WriteLine("");
            }

        }
        //Esta función rellena todos los arrays que componen el tablero
        public void RellenarTablero()
        {
            Random dado = new Random();
            sacarEnemigos(tableroTiposDeUnidades, tiposUnidades);
            RellenarObjetos();
            int fila, columna,casilla,unit;
           
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    
                    fila=dado.Next(0, 4);
                    columna=dado.Next(0, 4);
                    casilla = dado.Next(0, 6);
                    unit = dado.Next(0, 4);

                    tableroTiposCasillas[i, j] = tiposCasillas[casilla];
                    indicadorPersonaje[posx, posy] = "*";






                }
               
            }
            
            




        }
        //Rellena el array de enemigos evitando que se superpongan
        void sacarEnemigos(string[,] ttdu, string[] unidades)
        {
            Random dado = new Random();
            var dragy = dado.Next(0, 4);
            var dragx = dado.Next(0, 4);
            while (dragy == 0 && dragx == 0)
            {
                dragy = dado.Next(0, 4);
                dragx = dado.Next(0, 4);
                
            }
            conjuntoEnemigos[dragx, dragy] = d1;
            ttdu[dragx, dragy] = unidades[1];

            int fantasma1x = dado.Next(0, 4);
            int fantasma1y = dado.Next(0, 4);
            int fantasma2x = dado.Next(0, 4);
            int fantasma2y = dado.Next(0, 4);
            while (fantasma1x==0&&fantasma1y==0||fantasma2x==0&&fantasma2y==0||fantasma1x==dragx&&fantasma1y==dragy||fantasma2x==dragx&&fantasma2y==dragy)
            {
                fantasma1x = dado.Next(0, 4);
                fantasma1y = dado.Next(0, 4);
                fantasma2x = dado.Next(0, 4);
                fantasma2y = dado.Next(0, 4);
            }
            ttdu[fantasma1x, fantasma1y] = unidades[2];
            conjuntoEnemigos[fantasma1x, fantasma1y] = f1;
            ttdu[fantasma2x, fantasma2y] = unidades[2];
            conjuntoEnemigos[fantasma2x, fantasma2y] = f2;

            int esqueleto1x = dado.Next(0, 4);
            int esqueleto1y = dado.Next(0, 4);
            int esqueleto2x = dado.Next(0, 4);
            int esqueleto2y = dado.Next(0, 4);
            int esqueleto3x = dado.Next(0, 4);
            int esqueleto3y = dado.Next(0, 4);
            while (esqueleto1x == 0 && esqueleto1y == 0 || esqueleto2x == 0 && esqueleto2y == 0 || esqueleto3x == 0 && esqueleto3y == 0 || esqueleto1x == dragx && esqueleto1y == dragy || esqueleto2x == dragx && esqueleto2y == dragy || esqueleto3x == dragx && esqueleto3y == dragy || esqueleto1x == fantasma1x && esqueleto1y == fantasma1y || esqueleto2x == fantasma1x && esqueleto2y == fantasma1y || esqueleto3x == fantasma1x && esqueleto3y == fantasma1y || esqueleto1x == fantasma2x && esqueleto1y == fantasma2y || esqueleto2x == fantasma2x && esqueleto2y == fantasma2y || esqueleto3x == fantasma2x && esqueleto3y == fantasma2y)
            {
                 esqueleto1x = dado.Next(0, 4);
                 esqueleto1y = dado.Next(0, 4);
                 esqueleto2x = dado.Next(0, 4);
                 esqueleto2y = dado.Next(0, 4);
                 esqueleto3x = dado.Next(0, 4);
                 esqueleto3y = dado.Next(0, 4);

            }
            ttdu[esqueleto1x,esqueleto1y] = unidades[3];
            conjuntoEnemigos[esqueleto1x, esqueleto1y] = e1;
            ttdu[esqueleto2x, esqueleto2y] = unidades[3];
            conjuntoEnemigos[esqueleto2x, esqueleto2y] = e2;
            ttdu[esqueleto3x, esqueleto3y] = unidades[3];
            conjuntoEnemigos[esqueleto3x, esqueleto3y] = e3;

            for (int i = 0; i < 4; ++i)
            {

                for (int j = 0; j < 4; ++j)
                {
                    if(ttdu[i, j] == null)
                    {
                        ttdu[i,j] = "Casilla vacía";
                    }
                }

            }










                }
        //Muestra las posibilidades de movimiento del jugador y permite al jugador escojer entre estas
        public void ElegirMovimiento(Personajes personaje)
        {
            int mov = 0;
            bool correcto = true;
            
           
            Random dado = new Random();
            while (seguirCombate)
            {
                ComprobarObjeto(personaje);
                Console.WriteLine("Pulsa cualquier tecla para tirar el dado de 4 caras");
                Console.ReadKey();
                mov = dado.Next(1, 4);
                int except1 = posx + mov;
                int except2 = posy + mov;
                int except3 = posx - mov;
                int except4 = posy - mov;
                Console.WriteLine("Te puedes mover {0} casillas", mov);
                Console.WriteLine("Elige una dirección para moverte: ");
                while (correcto)
                {
                    if (except1 > 4 )
                    {
                        except1 = 4;
                        
                    }
                    else if (except2>4)
                    {
                        except2 = 4;
                    }
                    else if (except3<0)
                    {
                        except3 = 4;
                    }
                    else if (except4<0)
                    {
                        except4 = 4;
                    }
                    else
                    {
                        correcto = false;
                    }

                }
               
                
                Console.WriteLine("1.Abajo {0} 2.Derecha {1} 3.Arriba {2} 4.Izquierda {3} ", tableroTiposCasillas[except1,posy], tableroTiposCasillas[posx, except2], tableroTiposCasillas[except3, posy], tableroTiposCasillas[posx, except4]);
              
                
                
                    string opc = Console.ReadLine();
                    if (opc == "1"||  opc == "2" || opc == "3" || opc == "4")
                    {
                    switch (opc)
                    {
                        case "1":
                            {
                                if (except1 == 4)
                                {
                                    ResetExcept(except1, except2, except3, except4, personaje);
                                }
                                else
                                {
                                    Console.WriteLine("Has avanzado hacia el {0}", tableroTiposCasillas[except1, posy]);
                                    for (int i = 0; i < 6; ++i)
                                    {
                                        if (tableroTiposCasillas[except1, posy] == tiposCasillas[i])
                                        {
                                            ElegirZona(tiposCasillas, personaje, i);

                                            MoverDerecha(indicadorPersonaje, tableroTiposCasillas, tableroTiposDeUnidades, except1,personaje);
                                            Console.WriteLine("pulsa para continuar");
                                            Console.ReadKey();
                                            Console.Clear();
                                            personaje.MostrarEstadísticas(personaje);
                                            SacarTablero();
                                            ElegirMovimiento(personaje);

                                        }
                                    }
                                }
                               


                                break;
                            }
                        case "2":
                            {
                                if (except2 == 4)
                                {
                                    ResetExcept(except1, except2, except3, except4, personaje);
                                }
                                else
                                {
                                    Console.WriteLine("Has avanzado hacia el {0}", tableroTiposCasillas[posx, except2]);
                                    for (int i = 0; i < 6; ++i)
                                    {
                                        if (tableroTiposCasillas[posx, except2] == tiposCasillas[i])
                                        {
                                            ElegirZona(tiposCasillas, personaje, i);
                                            MoverArriba(indicadorPersonaje, tableroTiposCasillas, tableroTiposDeUnidades, except2,personaje);

                                            Console.WriteLine("pulsa para continuar");
                                            Console.ReadKey();
                                            Console.Clear();
                                            personaje.MostrarEstadísticas(personaje);
                                            SacarTablero();
                                            ElegirMovimiento(personaje);

                                        }
                                    }
                                }
                               
                                break;
                            }
                        case "3":
                            {
                                if (except3 ==4)
                                {
                                    ResetExcept(except1, except2, except3, except4, personaje);
                                }
                                else
                                {
                                    Console.WriteLine("Has avanzado hacia el {0}", tableroTiposCasillas[except3, posy]);
                                    for (int i = 0; i < 6; ++i)
                                    {
                                        if (tableroTiposCasillas[except3, posy] == tiposCasillas[i])
                                        {
                                            ElegirZona(tiposCasillas, personaje, i);
                                            MoverIzquierda(indicadorPersonaje, tableroTiposCasillas, tableroTiposDeUnidades, except3,personaje);
                                            Console.WriteLine("pulsa para continuar");
                                            Console.ReadKey();
                                            Console.Clear();
                                            personaje.MostrarEstadísticas(personaje);
                                            SacarTablero();
                                            ElegirMovimiento(personaje);

                                        }
                                    }
                                }
                               
                                break;
                            }
                        case "4":
                            {
                                if (except4 ==4 )
                                {
                                    ResetExcept(except1, except2, except3, except4, personaje);
                                }
                                else
                                {
                                    Console.WriteLine("Has avanzado hacia el {0}", tableroTiposCasillas[posx, except4]);
                                    for (int i = 0; i < 6; ++i)
                                    {
                                        if (tableroTiposCasillas[posx, except4] == tiposCasillas[i])
                                        {
                                            ElegirZona(tiposCasillas, personaje, i);
                                            MoverAbajo(indicadorPersonaje, tableroTiposCasillas, tableroTiposDeUnidades, except4,personaje);
                                            Console.WriteLine("pulsa para continuar");
                                            Console.ReadKey();
                                            Console.Clear();
                                            personaje.MostrarEstadísticas(personaje);
                                            SacarTablero();
                                            ElegirMovimiento(personaje);
                                        }
                                    }
                                }

                               
                                break;
                            }

                    }
                   
                        
                    }

               
                
                else
                {
                    Console.WriteLine("Error,vuelve a tirar el dado");
                    Console.ReadKey();
                    Console.Clear();
                    personaje.MostrarEstadísticas(personaje);
                    SacarTablero();
                    ElegirMovimiento(personaje);

                }
                

            }
            
            


        }
        //Controla los cambios de estado que sufres al caer en un desierto
        void Desierto(Personajes p1)
        {
            Console.WriteLine("El calor del desierto es insufrible, tu temperatura aumenta 3 puntos");
            p1.temperatura += 3;
            if (p1.temperatura > 42)
            {
                seguirCombate = false;
            }
        }
        //Controla los cambios de estado que sufres al caer en un pantano
        void Pantano(Personajes p1)
        {
            Console.WriteLine("Tu viaje por el pantano resulta más peligroso de lo que pensabas, tu temperatura y vida se reducen en un punto");
            p1.temperatura -= 1;
            p1.vida -= 1;
            if (p1.vida <= 0||p1.temperatura<30)
            {
                PerderJuego(p1);
            }
        }
        //Controla los cambios de estado que sufres al caer en una posada
        void PosadaChunga(Personajes p1)
        {
            Console.WriteLine("Descansas en la posada pero desearías irte lo antes posible, tu vida aumenta 1 punto y tu cordura disminuye 1 punto");
            if (p1.vida >= 50)
            {

            }
            else
            {
                p1.vida += 1;
            }
            
            p1.cordura -= 1;
            if (p1.cordura <= 0)
            {
                PerderJuego(p1);
            }
        }
        //Controla los cambios de estado que sufres al caer en un cementerio
        void Cementerio(Personajes p1)
        {
            Console.WriteLine("Estás casi seguro de que algo te está observando en el cementerio, tu cordura se reduce en 3 puntos");
            p1.cordura -= 3;
            if (p1.cordura <= 0)
            {
                PerderJuego(p1);
            }
        }
        //Controla los cambios de estado que sufres al caer en una tundra
        void Tundra(Personajes p1)
        {
            Console.WriteLine("El frío de la tundra te congela hasta los huesos, tu temperatura se reduce en 3 puntos");
            p1.temperatura -= 3;
            if (p1.temperatura <30)
            {
                PerderJuego(p1);
            }
        }
        //Controla los cambios de estado que sufres al caer en una pradera
        void Pradera(Personajes p1)
        {
            Console.WriteLine("La refrescante brisa de la pradera te llena de satisfacción, te das un merecido descanso en la pradera, tu vida y cordura aumentan un punto y tu temperatura se restablece");
            if (p1.vida == 50)
            {

            }
            else
            {
                p1.vida += 1;
            }
            
            p1.cordura += 1;
            p1.temperatura = 36;
        }
        //Esta función controla en que tipo de casilla se encuentra el jugador
        void ElegirZona(string[] tipo,Personajes p1,int a)
        {
            if (tipo[a] == tiposCasillas[0])
            {
                PosadaChunga(p1);
            }
            else if (tipo[a] == tiposCasillas[1])
            {
                Desierto(p1);
            }
            else if (tipo[a] == tiposCasillas[2])
            {
                Tundra(p1);
            }
            else if (tipo[a] == tiposCasillas[3])
            {
                Cementerio(p1);
            }
            else if (tipo[a] == tiposCasillas[4])
            {
                Pradera(p1);
            }
            else if (tipo[a] == tiposCasillas[5])
            {
                Pantano(p1);
            }

        }
        //Esta función vuelve a tirar el dado si se elige una opción de movimiento inválida
        void ResetExcept(int a,int b,int c,int d,Personajes p1)
        {
            Console.WriteLine("Esta opción es inválida, vuelve a tirar los dados");
            Console.ReadKey();
            Console.Clear();
            a = 0;
            b = 0;
            c = 0;
            d = 0;

            p1.MostrarEstadísticas(p1);
            SacarTablero();
            ElegirMovimiento(p1);
           
        }
        //Moviento hacia la derecha según el lanzamiento del dado
        void MoverDerecha(string[,] tabPers,string[,]tabTipos,string[,]tabUnit,int m1,Personajes p1)
        {
            for(int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    if (tabPers[i, j]=="*")
                    {
                        tabPers[i, j] = "";

                        tabPers[m1, j] = "*";

                        if ( tabUnit[m1, j] !=null)
                        {
                            
                            ComprobarEnemigo(i, j, p1,m1);  
                        }
                    }
                    
                }


            }
            posx = m1;

        }
        //Moviento hacia arriba según el lanzamiento del dado
        void MoverArriba(string[,] tabPers, string[,] tabTipos, string[,] tabUnit, int m1,Personajes p1)
        {
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    if (tabPers[i, j] == "*")
                    {
                        tabPers[i, j] = "";

                        tabPers[i, m1] = "*";
                        if ( tabUnit[i, m1] != null)
                        {
                           
                            ComprobarEnemigo(i, j, p1,m1);
                        }
                        

                    }
                    
                }


            }
            posy = m1;
        }
        //Moviento hacia la izquierda según el lanzamiento del dado
        void MoverIzquierda(string[,] tabPers, string[,] tabTipos, string[,] tabUnit, int m1, Personajes p1)
        {
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    if (tabPers[i, j] == "*")
                    {
                        tabPers[i, j] = "";
                        tabPers[m1, j] = "*";

                        if ( tabUnit[m1, j] != null)
                        {
                           
                            ComprobarEnemigo(i, j, p1,m1);
                        }

                    }
                   
                }


            }
            posx = m1;

        }
        //Moviento hacia abajo según el lanzamiento del dado
        void MoverAbajo(string[,] tabPers, string[,] tabTipos, string[,] tabUnit, int m1, Personajes p1)
        {
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    if (tabPers[i, j] == "*")
                    {
                        tabPers[i, j] = "";

                        tabPers[i, m1] = "*";
                        if ( tabUnit[i, m1] != null)
                        {
                            
                            ComprobarEnemigo(i, j, p1,m1);
                        }

                    }
                    
                }


            }

            posy = m1;
        }
        //Comprueba si hay un enemigo en la casilla en la que te encuentras y de que tipo es
        void ComprobarEnemigo(int i,int j,Personajes p1,int m1)
        {
            if (conjuntoEnemigos[i,j]==e1)
            {

                Console.WriteLine("Te encuentras con un esqueleto,");
                Combate(p1, e1, i, j);
                
                
               
            }
            else if (conjuntoEnemigos[i, j] == e2)
            {
                Console.WriteLine("Te encuentras con un esqueleto,");
                Combate(p1, e2, i, j);



            }
            else if (conjuntoEnemigos[i, j] == e3)
            {
                Console.WriteLine("Te encuentras con un esqueleto,");
                Combate(p1, e3,i,j);



            }
            else if (conjuntoEnemigos[i, j] == f1)
            {
                Console.WriteLine("Te encuentras con un fantasma,");
                Combate(p1, f1,i,j);



            }
            else if (conjuntoEnemigos[i, j] == f2)
            {
                Console.WriteLine("Te encuentras con un fantasma,");
                Combate(p1, f2, i, j);



            }
            else if (conjuntoEnemigos[i, j] == d1)
            {
                Console.WriteLine("Te encuentras con un dragón,");
                Combate(p1, d1, i, j);



            }


        }
        //Turnos de combate al caer en la misma casilla que un enemigo
        void Combate(Personajes p1,Enemigo e,int m1,int m2)
        {

            while (e.vida>0)
            {
                p1.atacar(p1, e);
                e.atacar(p1, e);
            }
            if (e.vida <= 0)
            {
                
                Console.WriteLine("Has derrotado al monstruo, ganas {0} puntos de xp, tu aventura continúa",e.exp);
                p1.xp += e.exp;
                ComprobarVictoria(m1, m2);
                tableroTiposDeUnidades[m1, m2] = "";
                conjuntoEnemigos[m1, m2] = null;
                p1.SubirNivel(p1);
            }
           
           
        }
        //Maneras de perder el juego
        void PerderJuego(Personajes p1)
        {
            seguirCombate = false;
            if (p1.vida <= 0)
            {
                Console.Clear();
                p1.MostrarEstadísticas(p1);
                Console.WriteLine("El entorno es demasiado hostil para ti, has muerto, suerte a la próxima...");
                Console.WriteLine("Pulsa cualquier tecla para salir");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else if (p1.cordura <= 0)
            {
                Console.Clear();
                p1.MostrarEstadísticas(p1);
                Console.WriteLine("Tu estado mental está tan deteriorado que no puedes continuar, suerte a la próxima...");
                Console.WriteLine("Pulsa cualquier tecla para salir");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else if (p1.temperatura < 30)
            {
                Console.Clear();
                p1.MostrarEstadísticas(p1);
                Console.WriteLine("El frío extremo te desorienta hasta que pierdes la consciencia, suerte a la próxima...");
                Console.WriteLine("Pulsa cualquier tecla para salir");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else if (p1.temperatura > 42)
            {
                Console.Clear();
                p1.MostrarEstadísticas(p1);
                Console.WriteLine("Eres incapaz de aguantar el calor extremo y desfalleces en el acto, suerte a la próxima...");
                Console.WriteLine("Pulsa cualquier tecla para salir");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
        //Coloca los objetos aleatoriamente en el tablero
        void RellenarObjetos()
        {
            int b=0, p=0, e=0, a=0;
            bool seguir ;
            Random dado = new Random();
            for (int i = 0; i < 4; ++i)
            {
                seguir = true;
                for (int j = 0; j < 4; ++j)
                {
                    
                    if (tableroObjetos[i, j] ==null)
                    {
                       
                        do
                        {

                            int d = dado.Next(0, 4);
                            if (d == 0 && b <6)
                            {
                                tableroObjetos[i, j] = d;
                                b += 1;
                                seguir = false;
                            }
                            else if (d == 1 && p < 3)
                            {
                                tableroObjetos[i, j] = d;
                                p += 1;
                                seguir = false;
                            }
                            else if (d == 2 && e < 2)
                            {
                                tableroObjetos[i, j] = d;
                                e += 1;
                                seguir = false;
                            }
                            else if (d == 3 && a < 2)
                            {
                                tableroObjetos[i, j] = d;
                                a += 1;
                                seguir = false;
                            }




                        } while (seguir == true);
                        
                    }

               }

            }
        }
        //Comprueba si en la casilla del jugador hay un objeto y le pregunta si lo quiere añadir a su inventario
        void ComprobarObjeto(Personajes p1)
        {
            if (tableroObjetos[posx, posy] == null)
            {

            }
            else
            {
                string opc = null;
                if (tableroObjetos[posx, posy] == 0)
                {
                    Console.WriteLine("Te has encontrado con una bomba, ¿deseas cogerla?");
                }
                else if (tableroObjetos[posx, posy] == 1)
                {
                    Console.WriteLine("Te has encontrado con una poción, ¿deseas cogerla?");
                }
                else if (tableroObjetos[posx, posy] == 2)
                {
                    Console.WriteLine("Te has encontrado con una enciclopedia, ¿deseas cogerla?");
                }
                else if (tableroObjetos[posx, posy] == 3)
                {
                    Console.WriteLine("Te has encontrado con una armadura, ¿deseas cogerla?");
                }
                Console.WriteLine("1.OK    |||    2.NO");
                opc = Console.ReadLine();
                if (opc == "1" || opc == "2")
                {
                    switch (opc)
                    {
                        case "1":
                            p1.AñadirAMochila(tableroObjetos[posx, posy], p1);
                            tableroObjetos[posx, posy] = null;
                            p1.MostrarMochila();
                            return;

                        case "2":
                            return;

                    }


                }
                else
                {
                    Console.Clear();
                    p1.MostrarEstadísticas(p1);
                    SacarTablero();
                    ComprobarObjeto(p1);
                }
            }
            
            
        }
        //Esta función se llama cada vez que matas a un enemigo y comprueba si están todos los enemigos muertos y así ganar
        void ComprobarVictoria(int a,int b)
        {
            

            if (tableroTiposDeUnidades[a, b] == tiposUnidades[1])
            {
                d--;
            }
            else if (tableroTiposDeUnidades[a, b] == tiposUnidades[2])
            {
                f--;
            }
            else if (tableroTiposDeUnidades[a, b] == tiposUnidades[3])
            {
                e--;
            }
            if (d <= 0 && f <= 0 && e <= 0)
            {
                Console.WriteLine("El reinado del terror del dragón ha llegado a su fin, felicidades aventurero, has ganado");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

    }
}
