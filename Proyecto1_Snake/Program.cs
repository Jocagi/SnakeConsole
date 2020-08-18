using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_Snake
{

    public static class Plano_Cartesiano 
    {
        //Límites de la pantalla

        public static int x;
        public static int y;
        
    }

    public class Serpiente 
    {
       
        //Puntos iniciales de la serpiente

        int cabezax = 0;
        int cabezay = 0;

        int P2x = -1;
        int P2y = 0;

        int P3x = -2;
        int P3y = 0;

        int P4x = -3;
        int P4y = 0;

        int colax = -4;
        int colay = 0;
        

        //Instrucciones para el movimiento

        internal String Movimiento(String tecla)
        {
            //variables que definen el movimiento

            string Nuevo_Movimiento;
            bool GAME_OVER_Pared = false;
            bool GAME_OVER_Cola = false;
            bool INVALIDO = false;

            switch (tecla)
            {
                case "UpArrow":

                    if (Math.Abs(cabezay + 1) != Math.Abs(Plano_Cartesiano.y))
                    {
                        if (cabezay + 1 != colay)
                        {
                            if (cabezay + 1 != P2y)
                            {
                                //Instrucciones serpiente arriba
                                colax = P4x;
                                colay = P4y;

                                P4x = P3x;
                                P4y = P3y;

                                P3x = P2x;
                                P3y = P2y;

                                P2x = cabezax;
                                P2y = cabezay;

                                //cabezax = cabezax;
                                cabezay = cabezay + 1;
                            }
                            else
                            { 
                                INVALIDO = true;
                            }
                        }
                        else
                        {
                            GAME_OVER_Cola = true;
                        }
                    }
                    else
                    {
                        GAME_OVER_Pared = true;
                    }

                    break;

                
            case "DownArrow":
                if (cabezay - 1 != Math.Abs(Plano_Cartesiano.y))
                {
                    if (cabezay - 1 != colay)
                    {
                        if (cabezay - 1 != P2y)
                        {
                            //Instrucciones serpiente abajo
                            colax = P4x;
                            colay = P4y;

                            P4x = P3x;
                            P4y = P3y;

                            P3x = P2x;
                            P3y = P2y;

                            P2x = cabezax;
                            P2y = cabezay;

                            //cabezax = cabezax;
                            cabezay = cabezay - 1;
                        }
                        else
                        {
                            INVALIDO = true;
                        }
                    }
                    else
                    {
                        GAME_OVER_Cola = true;
                    }
                }
                else
                {
                    GAME_OVER_Pared = true;
                }
                break;

            case "LeftArrow":

                if (cabezax - 1 != Math.Abs(Plano_Cartesiano.x))
                {
                    if (cabezax - 1 != colax)
                    {
                        if (cabezax - 1 != P2x)
                        {
                            //Instrucciones serpiente izquierda
                            colax = P4x;
                            colay = P4y;

                            P4x = P3x;
                            P4y = P3y;

                            P3x = P2x;
                            P3y = P2y;

                            P2x = cabezax;
                            P2y = cabezay;

                            cabezax = cabezax - 1;
                            //cabezay = cabezay;
                        }
                        else
                        {
                            INVALIDO = true;
                        }
                    }
                    else
                    {
                        GAME_OVER_Cola = true;
                    }
                }
                else
                {
                    GAME_OVER_Pared = true;
                }

                break;

            case "RightArrow":

                if (cabezax + 1 != Math.Abs(Plano_Cartesiano.x)) {
                    if (cabezax + 1 != colax)
                    {
                        if (cabezax + 1 != P2x)
                        {
                            //Instrucciones serpiente derecha
                            colax = P4x;
                            colay = P4y;

                            P4x = P3x;
                            P4y = P3y;

                            P3x = P2x;
                            P3y = P2y;

                            P2x = cabezax;
                            P2y = cabezay;

                            cabezax = cabezax + 1;
                            //cabezay = cabezay;
                        }
                        else
                        {
                            INVALIDO = true;
                        }
                    }
                    else
                    {
                        GAME_OVER_Cola = true;
                    }
                }
                else
                {
                    GAME_OVER_Pared = true;
                }
                break;



                default:
                    break;
            }
            

            //Mensajes

            if ((GAME_OVER_Pared == false) && (GAME_OVER_Cola == false))
            {
                if (INVALIDO == true)
                {
                    //Mensaje devuelto (Invalido)
                    Nuevo_Movimiento = $"MOVIMIENTO INVALIDO\nNUEVO MOVIEMIENTO Cabeza:({cabezax}, {cabezay}), Cola:({colax}, {colay}) ; Ingrese nuevo movimiento:";
                }
                else
                {
                    //Mensaje devuelto (Normal)
                    Nuevo_Movimiento = $"NUEVO MOVIEMIENTO Cabeza:({cabezax}, {cabezay}), Cola:({colax}, {colay}) ; Ingrese nuevo movimiento:";
                }
            }
            else
            {
                if (GAME_OVER_Pared == true)
                {
                    //Mensaje devuelto (Fin del juego)
                    Nuevo_Movimiento = "GAME OVER: TE ESTRELLASTE CONTRA LA PARED";
                }
                else
                { 
                    //Mensaje devuelto (Fin del juego)
                    Nuevo_Movimiento = "GAME OVER: CHOCASTE CON TU COLA";
                }
            }

            return Nuevo_Movimiento;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Tamaño de la ventana
            Console.SetWindowSize(95, 30);

            //variables

            bool Salir = false;
            bool Over = false;
            String Si_No;
            String Mensaje;
            String tecla;

            //Mensaje inicial
            Console.WriteLine("Inicio");

            //Determinar limites del plano cartesiano

            //

            //Limite en x
            Console.Write("Ingrese limite en x: ");
            Plano_Cartesiano.x = Convert.ToInt32(Console.ReadLine());

            //Verifica si x es de un tamano mayor a la serpiente
            while(Plano_Cartesiano.x <= 4)
            {
                Console.Write("Ingrese limite en x mas grande: ");
                Plano_Cartesiano.x = Convert.ToInt32(Console.ReadLine());
            }

            //Limite en y
            Console.Write("Ingrese limite en y: ");
            Plano_Cartesiano.y = Convert.ToInt32(Console.ReadLine());

            //Verifica si x es de un tamano mayor a la serpiente
            while (Plano_Cartesiano.x <= 0)
            {
                Console.Write("Ingrese limite en y mas grande: ");
                Plano_Cartesiano.y = Convert.ToInt32(Console.ReadLine());
            }

            //

            //Inicia el Juego

            while (Over == false)
            {
                Salir = false;
                Serpiente s = new Serpiente();

                Console.Write("NUEVO MOVIEMIENTO Cabeza:(0, 0), Cola:(-4, 0) ; Ingrese nuevo movimiento:");

                // Teclas para los movimientos de la serpiente

                while (Salir == false)
                {

                    //Leer tecla

                    var key = Console.ReadKey().Key;

                    // verificar si no se ha presionado la tecla x

                    if (key != ConsoleKey.X)
                    {

                        tecla = Convert.ToString(key); //Convertir tecla presionada a texto para ejecutarlo en el método "Movimiento"

                        //Mostrar Mensaje

                        Mensaje = s.Movimiento(tecla);

                        Console.Write(tecla);
                        Console.Write("\n" + Mensaje);


                        //  Volver a jugar?
                        if((Mensaje == "GAME OVER: TE ESTRELLASTE CONTRA LA PARED")||(Mensaje == "GAME OVER: CHOCASTE CON TU COLA"))
                        {
                            Console.ReadKey();
                            Console.Write("\nDeseas volver a jugar? (Esciba si o no): ");
                            Si_No = Console.ReadLine();

                            if((Si_No == "s") || (Si_No == "sí") || (Si_No == "si") || (Si_No == "Si") || (Si_No == "S") || (Si_No == "Sí"))
                            {
                                Salir = true;
                            }
                            else
                            {
                                Over = true;
                                Salir = true;
                            }

                        }
                    }
                    else
                    {
                        Salir = true;
                    }
                }

            }
        }
    }
}
