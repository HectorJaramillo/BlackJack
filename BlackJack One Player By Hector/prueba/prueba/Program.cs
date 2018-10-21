using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Proyecto_unidad_3
{
    public class Carta//Clase pubblica Carta
    {
        //Se pues decir que GET recibe una captura de datos(Los lee) y set Muestra la captura hecha dentro de el(Los imprime)
        public string Id { get; set; }//variable de tipo string Id 
        public string Symbolo { get; set; }//variable de tipo string
        public string Nombre { get; set; }//variable de tipo string
        private int valor;//variable de tipo int
        public int Valor { get {return valor;} set { valor = value; } }//variable de tipo int
        public Carta(string identity, string symbol, string name, int value)//Constructor Carta que recibe los datos a las
        {   //variables antes capturadas
            Id = identity;//Igualacion de la variable privada a una local/publica
            Valor = value;//Igualacion de la variable privada a una local/publica
            Symbolo = symbol;//Igualacion de la variable privada a una local/publica
            Nombre = name;//Igualacion de la variable privada a una local/publica
        }
    }
    public class BlackJack//Creacion de Clase BlackJack
    {
        private List<Carta> CrearCartas()//Creo Lista privada la cual contiene la Clase Carta(Ahi almacenara los datos)
        {
            List<Carta> cartas = new List<Carta>();//Creo una segunda lista  contiene la Clase Carta
            string symbol = "♥";//declaracion de variable simbolo(igualada a simbolo corazon pero puede cambiar)
            for (int Indice = 0; Indice < 4; Indice++)//Ciclo For con 4 indices diferentes debido a las 4 simbolos en las cartas
            {
                switch (Indice)//Estructura selectiva switch
                {
                    case 0:
                        symbol = "♥";//Con el Indice 0 usara el simbolo Corazon
                        break;
                    case 1:
                        symbol = "♦";//Con el Indice 1 usara el simbolo Diamantes
                        break;
                    case 2:
                        symbol = "♣";//Con el Indice 2 usara el simbolo Trebol
                        break;
                    case 3:
                        symbol = "♠";//Con el Indice 3 usara el simbolo Picas
                        break;
                }
                for (int Indice2 = 1; Indice2 < 14; Indice2++)//Ciclo For el cual cuenta que las cartas sean 13 de cada simbolo
                {
                    if (Indice2 < 11 && Indice2 != 1)//Si las Cartas estan en el rango 2-9 su numero de carta y valor numerico seran iguales
                        cartas.Add(new Carta(Indice2.ToString(), symbol, Indice2 + " " + symbol, Indice2));//Envio de parametros al constructor de la clase carta
                    else
                    {
                        switch (Indice2)
                        {//Las cartas J,Q,K tienen un valor numerico=10
                            case 1:
                                cartas.Add(new Carta("A", symbol, "A " + symbol, 11));//Envio de parametros al constructor de la clase carta
                                break;
                            case 11:
                                cartas.Add(new Carta("J", symbol, "J " + symbol, 10));//Envio de parametros al constructor de la clase carta
                                break;
                            case 12:
                                cartas.Add(new Carta("Q", symbol, "Q " + symbol, 10));//Envio de parametros al constructor de la clase carta
                                break;
                            case 13:
                                cartas.Add(new Carta("K", symbol, "K " + symbol, 10));//Envio de parametros al constructor de la clase carta
                                break;
                        }
                    }
                }
            }
            return cartas;//Devuelve la Lista con la baraja completa
        }
        private Stack<Carta> Revolver()//Pila en la cual se almacenara la baraja revuelta
        {
            List<Carta> MazoNuevo = CrearCartas();//Lista que se iguala a la lista crear cartas de la clase BlacJack
            Stack<Carta> CartasRandom = new Stack<Carta>();//Lista donde se almacenaran las cartas revueltas de maneraa temporal
            Random rnd = new Random();//Creacion de objeto de la clase random
            int Random;//Variable de tipo int
            for (int Indice = 0; Indice < 52; Indice++)//desde Indice 1 al 52 por la cantidad de cartas de la baraja
            {
                Random = rnd.Next(MazoNuevo.Count);//Variable random igualada a el tamaño de la lista
                CartasRandom.Push(MazoNuevo[Random]);//Ingresa la posicion del elemento antes seleccionado y lo agrega a la Pila
                MazoNuevo.RemoveAt(Random);//Se elimina esa posicion de la lista MazoNuevo
            }
            return CartasRandom;//Se retorna la Pila
        }
        public void Jugar()//Metodo void Jugar
        {
            int Ganados = 0, Perdidos = 0;//Inicializacion de variables de tipo int a 0       
            Marca2://Etiqueta Marca2
            Stack<Carta> Cartas = Revolver();//Se iguala una nueva lista a el metodo revolver
            int Puntos = 0;//Variable de tipo int igualada a 0
            int CartasSacadas = 1;//Variable de tipo int igualada a 1
            Console.WriteLine("Bienvenido a BlackJack Remaster 2.0 100% real no fake 60 fps 4K full HD");
            Console.WriteLine("Juegos Ganados: {0} , Juegos Perdidos: {1}", Ganados, Perdidos);
            Carta Carta = Cartas.Pop();//Se quita la carta seleccionada de la Pila
            Puntos = Carta.Valor + Puntos;//a la variable puntos se le suma el valor de la carta
            Console.WriteLine("\nCarta No.{0} es: {1}\t\tPuntos={2}", CartasSacadas, Carta.Nombre, Puntos);
            ++CartasSacadas;//Contador cartas Sacadas +1
            Carta Carta2 = Cartas.Pop();//Se quita la carta seleccionada de la Pila
            Puntos = Carta2.Valor+Puntos;//a la variable puntos se le suma el valor de la carta
            int Contador = 0;//variable de tipo int
                Console.WriteLine("\nCarta No.{0} es: {1}\t\tPuntos={2}", CartasSacadas, Carta2.Nombre, Puntos);
            Marca://Etiqueta Marca
            if (CartasSacadas == 5)//Si el usuario saco 5 cartas
            {
                if (Puntos == 21)//Si los puntos son igual a 21 Gana
                {
                    Console.WriteLine("\nFelicidades has ganado!!!");
                    Console.ReadKey(true);
                    Perdidos++;// Contador +1
                    goto Fin;
                }
                if (Puntos != 21)//Si son diferente a 21 pierde
                {
                    Console.WriteLine("Has Perdido");
                    Console.ReadKey(true);
                    Perdidos++;// Contador +1
                    goto Fin; //Instruccion ir a Etiqueta
                }
            }
            if(Puntos>21)//Si los puntos son mayores a 21
            {
                Console.WriteLine("Has Perdido");
                Console.ReadKey(true);
                Perdidos++;// Contador +1
                goto Fin;//Instruccion ir Etiqueta
            }
            if (Puntos == 21)//Si los puntos son igual a 21 Gana
            {
                Console.WriteLine("\nFelicidades has ganado!!!");
                Console.ReadKey(true);
                Ganados++;// Contador +1
                goto Fin;//Instruccion ir a Etiqueta
            }
            Console.WriteLine("Desea tomar otra carta? \n1.-Si \n2.-No");
            int Opcion = 0;// variable int
            try {//Exepcion de formato
                Opcion = int.Parse(Console.ReadLine());
            } catch (Exception Error) { Console.WriteLine("Ingrese una opcion valida en el menu"); goto Marca; }
            if (Opcion == 1)//Si opcion =1
            {
                ++CartasSacadas;//Contador +1
                Carta CartaExtra = Cartas.Pop();//cartaExtra
                Puntos = CartaExtra.Valor + Puntos;
                if (Puntos > 21 && Contador == 0)
                {
                    if (CartaExtra.Valor == 11 || Carta.Valor == 11 || Carta2.Valor == 11)//Si cartaextra, carta o carta2=11 y contador=0
                    {
                        Puntos -= 10;//Puntos -10
                        Contador++;//Contador +1
                    }
                }
                if (Puntos > 21 && Contador == 1)//Si puntos mayor que 21 y contador=1
                {
                    if (CartaExtra.Valor == 11)//Si carta extra es igual a 11
                    {
                        Puntos -= 10;//Puntos -10
                        Contador++;//Contador +1
                    }
                }
                if (Puntos > 21 && Contador == 2)//Si puntos mayor que 21 y contador=2
                {
                    if (CartaExtra.Valor == 11)//Si carta extra es igual a 11
                    {
                        Puntos -= 10;//Puntos -10
                        Contador++;//Contador +1
                    }
                }
                Console.WriteLine("\nCarta No.{0} es: {1}\t\tPuntos={2}", CartasSacadas, CartaExtra.Nombre, Puntos);
                if (CartasSacadas <6)//Si cartas sacadas menor que 6
                {
                    if (Puntos == 21)//Si los puntos son igual a 21 Gana
                    {
                        Console.WriteLine("\nFelicidades has ganado!!!");
                        Ganados++;//Contador +1
                        Console.ReadKey(true);
                        goto Fin;//Instruccion ir a Etiqueta
                    }
                    if (Puntos != 21 && CartasSacadas > 5)
                    {
                        Console.WriteLine("Has Perdido");
                        Perdidos++;// Contador +1
                        Console.ReadKey(true);
                        goto Fin; //Instruccion ir a Etiqueta
                    }
                    else if (Puntos > 21)
                    {
                        Console.WriteLine("Has perdido");
                        Perdidos++;// Contador +1
                        Console.ReadKey(true);
                        goto Fin; //Instruccion ir a Etiqueta
                    }
                    goto Marca;//Instruccion ir a Etiqueta
                }
            }
                if (CartasSacadas >= 5)//Si CartasSacadasMayor o igual a 5
                {
                    if (Puntos == 21)//Si puntos =21
                    {
                        Console.WriteLine("\nFelicidades has ganado!!!");
                        Console.ReadKey(true);
                        Perdidos++;
                        goto Fin;//Instruccion ir a Etiqueta
                }
                    if (Puntos != 21)//Si puntos diferentes de 21
                {
                        Console.WriteLine("Has Perdido");
                        Console.ReadKey(true);
                        Perdidos++;//Contador +1
                        goto Fin;//Instruccion ir a Etiqueta
                }
                }       
            else { Console.WriteLine("Ingrese una opcion valida en el menu"); goto Marca; }// Si capturan una opcion invalida se envia al usuario a volver a capturar los datos
            Fin://Etiqueta Fin
            Console.WriteLine("Desea jugar otra vez\n1.-Si \n2.-No");
            int OtraVez=0;// variable in =0
            try//Excepcion de formato de entrada
            {
                 OtraVez = int.Parse(Console.ReadLine());               
            }
            catch (Exception Error) {Console.WriteLine("Ingrese una opcion valida en el menu"); goto Fin; }
                
                if(OtraVez==1)//Si otra vez =1
                {
                    Console.Clear();//Limpiar Consola
                    goto Marca2;//Ir a etiqueta Marca2
                }
                else if(OtraVez==2)//Si otravez =2 termina el programa
                {                   
                }
                else//Si no
                {
                    Console.WriteLine("Opcion no especificada en el menu");
                    goto Fin;//Ir a etiqueta Fin
            }
                Console.ReadKey();           
        }
        class Program
        {
            static void Main(string[] args)
            {
                Console.OutputEncoding = Encoding.Unicode;//Permite que se impriman los simbolos "♥" "♦" "♣" "♠"
                BlackJack Juego = new BlackJack();// Objeto de la ClaseBlackJack
                Juego.Jugar();//Llamando el metodo Jugar con el objeto Juego
            }
        }
    }
}
