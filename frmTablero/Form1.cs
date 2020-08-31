using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmTablero
{
    public partial class Form1 : Form
    {
        #region variables
        private ResourceManager libreriaImagenes = frmTablero.Properties.Resources.ResourceManager;
        //Tenemos que asignarle las 52 cartas jugables
        List<Carta> todasCartas = new List<Carta>();
        List<Carta> cartasStackAbajo = new List<Carta>();        //Servira para determinar que las castas no se repitan
        List<Carta> cartasStackMano = new List<Carta>();        //Servira para que siga en orden cuando pidamos mano
        List<Stack> _Pilas = new List<Stack>();
        List<Stack> _PilasArriba = new List<Stack>();
        List<PictureBox> pictures = new List<PictureBox>();
        List<PictureBox> picturesMano = new List<PictureBox>();
        private int _DeltaX;
        private int _DeltaY;
        private bool _MouseDown;
        private bool _Movimiento;
        //Stacks de la parte superior del juego
        Stack stack1 = new Stack();
        Stack stack2 = new Stack();
        Stack stack3 = new Stack();
        Stack stack4 = new Stack();
        Stack stack5 = new Stack();
        Stack stack6 = new Stack();
        Stack stack7 = new Stack();

        Stack stack1Arriba = new Stack();
        Stack stack2Arriba = new Stack();
        Stack stack3Arriba = new Stack();
        Stack stack4Arriba = new Stack();

       
        
        Carta cartaMano;

        int contadorPedirMano = 0;                                //Servira para saber que carta se debe mostrar
        int contadorClick = 0;
        #endregion variables

        #region estadoInicial
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            inicioJuego();

        }
        private void inicioJuego()
        {
            contadorClick = 0;
            contadorPedirMano = 0;
            Controls.Clear();
            _Pilas.Clear();
            _PilasArriba.Clear();
            cartasStackAbajo.Clear();
            stack1.Cartas.Clear();
            stack2.Cartas.Clear();
            stack3.Cartas.Clear();
            stack4.Cartas.Clear();
            stack5.Cartas.Clear();
            stack6.Cartas.Clear();
            stack7.Cartas.Clear();
            stack1Arriba.Cartas.Clear();
            stack2Arriba.Cartas.Clear();
            stack3Arriba.Cartas.Clear();
            stack4Arriba.Cartas.Clear();

            stack1.TOS = 0;
            stack2.TOS = 0;
            stack3.TOS = 0;
            stack4.TOS = 0;
            stack5.TOS = 0;
            stack6.TOS = 0;
            stack7.TOS = 0;

            stack1Arriba.TOS = 0;
            stack2Arriba.TOS = 0;
            stack3Arriba.TOS = 0;
            stack4Arriba.TOS = 0;

            agregarToda();                           //Se agrega todas las cartas a una lsita
            ColocarControlesPrederteminados();
            
            int abajo = 150;
            int izquierda = 5;
           
            for(int i=1; i<=7; i++)
            {

                switch (i)
                {
                    case 1:
                        agregarEnStack(1, abajo, izquierda, stack1);
                        stack1.Left = izquierda;
                        stack1.Top = abajo;
                        break;
                    case 2:
                        izquierda = izquierda + 70;
                        agregarEnStack(1, abajo, izquierda, stack2);
                        stack2.Left = izquierda;
                        stack2.Top = abajo;
                        break;
                    case 3:
                        izquierda = izquierda + 70;
                        agregarEnStack(2, abajo, izquierda, stack3);
                        stack3.Left = izquierda;
                        stack3.Top = abajo;
                        break;
                    case 4:
                        izquierda = izquierda + 70;
                        agregarEnStack(3, abajo, izquierda, stack4);
                        stack4.Left = izquierda;
                        stack4.Top = abajo;
                        break;
                    case 5:
                        izquierda = izquierda + 70;
                        agregarEnStack(4, abajo, izquierda, stack5);
                        stack5.Left = izquierda;
                        stack5.Top = abajo;
                        break;
                    case 6:
                        izquierda = izquierda + 70;
                        agregarEnStack(5, abajo, izquierda, stack6);
                        stack6.Left = izquierda;
                        stack6.Top = abajo;
                        break;
                    case 7:
                        izquierda = izquierda + 70;
                        agregarEnStack(6, abajo, izquierda, stack7);
                        stack7.Left = izquierda;
                        stack7.Top = abajo;
                        break;
                }
            }
            barajarToda();

            _Pilas.Add(stack1);
            _Pilas.Add(stack2);
            _Pilas.Add(stack3);
            _Pilas.Add(stack4);
            _Pilas.Add(stack5);
            _Pilas.Add(stack6);
            _Pilas.Add(stack7);
            //Setear los stacks de arriba
            stack1Arriba.Left = 215;
            stack1Arriba.Top = 35;
            stack2Arriba.Left = 285;
            stack2Arriba.Top = 35;
            stack3Arriba.Left = 355;
            stack3Arriba.Top = 35;
            stack4Arriba.Left = 425;
            stack4Arriba.Top = 35;

            _PilasArriba.Add(stack1Arriba);
            _PilasArriba.Add(stack2Arriba);
            _PilasArriba.Add(stack3Arriba);
            _PilasArriba.Add(stack4Arriba);

        }

        //Falta Este metodo arreglarle, nos basaremos en la guia de agregarStack()
        private void agregarToda()
        {
            todasCartas.Clear();
            Carta auxToda;
            for (int i=1; i <= 13; i++)
            {
                for(int j=1; j <= 4; j++)
                {
                    switch (j)
                    {
                        case 1:
                            
                            auxToda = new Carta("c", (short)i);
                            
                            todasCartas.Add(auxToda);
                            break;
                        case 2:
                            auxToda = new Carta("d", (short)i);
                            
                            todasCartas.Add(auxToda);
                            break;
                        case 3:
                            auxToda = new Carta("h", (short)i);
                            
                            todasCartas.Add(auxToda);
                            break;
                        case 4:
                            auxToda = new Carta("s", (short)i);
                            todasCartas.Add(auxToda);
                            break;
                    }
                }
            }
        }

        //Eliminamos de la lista total aquellas que ya estan en el stack de abajo
        private void eliminarDeToda(Carta aux)
        {
            foreach (var i in todasCartas)
            {
                if (aux.Palo == i.Palo && aux.Rango == i.Rango)
                {

                    todasCartas.Remove(i);
                    break;
                }
            }
            
        }

        //Barajar la llista de toda
        private void barajarToda()
        {
            List<Carta> auxLista = new List<Carta>();
           // todasCartas.Clear();
            Random num = new Random();
            while(todasCartas.Count > 0)
            {
                int val = num.Next(0, todasCartas.Count - 1);
                auxLista.Add(todasCartas[val]);      //Agregamos de manera aleatoria
                todasCartas.RemoveAt(val);              //Removemos ene el indeice indicado
            }

            todasCartas.Clear();
            todasCartas = auxLista;
        }

        private void agregarEnStack(int bocaAbajo, int abajo, int izquierda, Stack stack)
        {
            if (stack == stack1)
            {
                bocaAbajo--;
            }
            for (int j = 1; j <= bocaAbajo + 1; j++)
            {
                Carta carta = comprobar();
                carta.Top = abajo;
                carta.Left = izquierda;
                carta.StackPosicion = Convert.ToInt16(j);
                carta.Stack = stack;
                if (j == 1 && izquierda == 5 && abajo == 150)   //izquierda=5 es la primera fila de Stack
                {
                    carta.FaceUp =true;
                    carta.Jugable = true;
                }
                else if (j == bocaAbajo + 1)       //Es decir el ultimo elemnto de la fila
                {
                    carta.FaceUp = true;
                    carta.Jugable = true;
                }

                PictureBox imagen = new PictureBox();
                if (carta.FaceUp)
                {
                    imagen.Image = (Image)libreriaImagenes.GetObject(carta.informacion());  //Obtengo la familia
                }
                else
                {
                    imagen.Image = (Image)libreriaImagenes.GetObject("cardback");  //Obtengo la familia
                }

                //PictureBox p = 
                imagen.Height = imagen.Image.Height;
                imagen.Width = imagen.Image.Width;
                imagen.Tag = carta;
                imagen.Top = carta.Top;
                imagen.Left = carta.Left;
                imagen.BorderStyle = BorderStyle.FixedSingle;

                stack.AddCartas(carta);
                imagen.Visible = true;
                Controls.Add(imagen);
                imagen.BringToFront();              //Para que se coloque al frente, el orden es importante

                imagen.MouseDown += Imagen_mousedown;
                imagen.MouseMove += Imagen_MouseMove;
                imagen.MouseUp += Imagen_MouseUp;
                abajo = abajo + 20;
                pictures.Add(imagen);
            }
        }

        private Carta Barajar()
        {
            Carta cartaAux;
            Random aleatorio = new Random();
            int valorCarta = aleatorio.Next(1, 14);
            int familiaCarta = aleatorio.Next(1, 4);

            switch (familiaCarta)
            {
                case 1:
                    cartaAux = new Carta("c", (short)valorCarta);
                    return cartaAux;
                case 2:
                    cartaAux = new Carta("d", (short)valorCarta);
                    return cartaAux;
                case 3:
                    cartaAux = new Carta("h", (short)valorCarta);
                    return cartaAux;
                case 4:
                    cartaAux = new Carta("s", (short)valorCarta);
                    return cartaAux;
                default:
                    return null;
            }

        }

        private Carta comprobar()    //Nuevo = true
        {
            bool estadoRepetido = false;
            Carta aux;
            // Thread.Sleep(200);                                               //Dormimos para que no se generen valores repetidos al anterior.
            do
            {
                estadoRepetido = false; ;
                aux = Barajar();
                foreach (var i in cartasStackAbajo)
                {
                    //Console.WriteLine("AUx= " + aux.Palo + " " + aux.Rango + " Comparo con: " + i.Palo + " " + i.Rango);
                    if (aux.Palo == i.Palo && aux.Rango == i.Rango || aux.Rango==1)
                    {
                        // Console.WriteLine("Coincidencias");
                        estadoRepetido = true;
                        break;
                    }
                }

                //Console.WriteLine(imagenes.Count);
                if (estadoRepetido == false)   //Es decir si es nuevo
                {
                    eliminarDeToda(aux);
                    cartasStackAbajo.Add(aux);

                }

            } while (estadoRepetido);


            return aux;
        }
        #endregion estadoInicial
       
        #region metodosClick
        private void ClickMano(object sender, EventArgs e)
        {
            Console.WriteLine(todasCartas.Count);
            if (contadorPedirMano >= todasCartas.Count)
            {
                Console.WriteLine("Reiniciamos el contador!!!");
                contadorPedirMano = 0;
                // Controls.Remove(imagenParaPoner);
                foreach (PictureBox item in picturesMano)//Borra el duplicado que sobra
                {
                    
                        Controls.Remove(item);
                        
                    
                }
                picturesMano.Clear();
            }
            //Console.WriteLine(todasCartas.Count);

            if (todasCartas.Count != 0)
            {
                Stack stackMano = new Stack();
                PictureBox imagenParaPoner = new PictureBox();

                cartaMano = todasCartas[contadorPedirMano];

                cartaMano.Clickable = true;
                cartaMano.FaceUp = true;
                cartaMano.Jugable = true;
                cartaMano.StackPosicion = 1;
                cartaMano.Top = 35;
                cartaMano.Left = 75;

                stackMano.Top = 35;
                stackMano.Left = 75;
                stackMano.AddCartas(cartaMano);
                cartaMano.Stack = stackMano;


                imagenParaPoner.Image = (Image)libreriaImagenes.GetObject(cartaMano.informacion());  //Obtengo la familia          
                imagenParaPoner.Top = 35;
                imagenParaPoner.Left = 75;
                imagenParaPoner.Height = imagenParaPoner.Image.Height;
                imagenParaPoner.Width = imagenParaPoner.Image.Width;
                imagenParaPoner.Visible = true;
                imagenParaPoner.Tag = cartaMano;

                Controls.Add(imagenParaPoner);
                imagenParaPoner.BringToFront();

                imagenParaPoner.MouseDown += Imagen_mousedown;
                imagenParaPoner.MouseMove += Imagen_MouseMove;
                imagenParaPoner.MouseUp += Imagen_MouseUp;

                picturesMano.Add(imagenParaPoner);


                contadorPedirMano++;
                contadorClick++;

            }


        }

        private void ClickBotonNuevo(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea empezar una nueva partida?", "SOLITARIO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                inicioJuego();
            }
            
            
        }
        private void ModoFacil(object sender, EventArgs e)
        {
            //DialogResult = MessageBox.Show("Enserio vas a caer tan bajo??", "SOLITARIO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (MessageBox.Show("¿Es enserio?", "SOLITARIO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                agregarModoFacil();
            }
            else
            {
                MessageBox.Show("Me alegro de tu decision!!", "SOLITARIO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }


        #endregion metodosClick

        #region ModoUltraFacil
        private void agregarModoFacil()
        {
            //Controls.Clear();
            stack1Arriba.Cartas.Clear();
            stack2Arriba.Cartas.Clear();
            stack3Arriba.Cartas.Clear();
            stack4Arriba.Cartas.Clear();
            stack1.Cartas.Clear();
            stack2.Cartas.Clear();
            stack3.Cartas.Clear();
            stack4.Cartas.Clear();
            stack5.Cartas.Clear();
            stack6.Cartas.Clear();
            stack7.Cartas.Clear();
            stack1.TOS = 0;
            stack2.TOS = 0;
            stack3.TOS = 0;
            stack4.TOS = 0;
            stack5.TOS = 0;
            stack6.TOS = 0;
            stack7.TOS = 0;

            foreach (PictureBox item in picturesMano)//Borra el duplicado que sobra
            {
                Controls.Remove(item);
            }
            foreach (PictureBox item in pictures)//Borra el duplicado que sobra
            {
                Controls.Remove(item);
            }
            int auxAbajo = 150;
            int auxIzquierda = 5;
            int aux = 1;
            cartasStackAbajo.Clear();
            cartasStackMano.Clear();
            todasCartas.Clear();
            Carta auxToda;
            for (int i = 13; i >= 1; i--)
            {


                //= new Carta();
                for (int j = 1; j <= 4; j++)
                {
                    PictureBox imagen = new PictureBox();
                    switch (j)
                    {
                        case 1:

                            auxToda = new Carta("c", (short)i);
                            auxToda.Top = auxAbajo;
                            auxToda.Left = auxIzquierda;
                            auxToda.StackPosicion = Convert.ToInt16(aux);
                            auxToda.Stack = stack1;

                            if (i == 1)
                            {
                                auxToda.FaceUp = true;
                                imagen.Image = (Image)libreriaImagenes.GetObject(auxToda.informacion());
                            }
                            else
                            {
                                auxToda.FaceUp = false;
                                imagen.Image = (Image)libreriaImagenes.GetObject("cardback");
                            }

                            auxToda.Jugable = true;
                            //auxToda.FaceUp = true;
                            stack1.AddCartas(auxToda);
                            //imagen.Image = (Image)libreriaImagenes.GetObject(auxToda.informacion());
                            imagen.Height = imagen.Image.Height;
                            imagen.Width = imagen.Image.Width;
                            imagen.Tag = auxToda;
                            imagen.Top = auxToda.Top;
                            imagen.Left = auxToda.Left;
                            imagen.BorderStyle = BorderStyle.FixedSingle;
                            Controls.Add(imagen);
                            imagen.BringToFront();              //Para que se coloque al frente, el orden es importante

                            imagen.MouseDown += Imagen_mousedown;
                            imagen.MouseMove += Imagen_MouseMove;
                            imagen.MouseUp += Imagen_MouseUp;
                            pictures.Add(imagen);
                            cartasStackAbajo.Add(auxToda);
                            break;
                        case 2:
                            auxToda = new Carta("d", (short)i);
                            auxToda.Top = auxAbajo;
                            auxToda.Left = auxIzquierda;
                            auxToda.StackPosicion = Convert.ToInt16(aux);
                            auxToda.Stack = stack2;
                            auxToda.FaceUp = true;

                            if (i == 1)
                            {
                                auxToda.FaceUp = true;
                                imagen.Image = (Image)libreriaImagenes.GetObject(auxToda.informacion());
                            }
                            else
                            {
                                auxToda.FaceUp = false;
                                imagen.Image = (Image)libreriaImagenes.GetObject("cardback");
                            }

                            auxToda.Jugable = true;
                            //auxToda.FaceUp = true;
                            //imagen.Image = (Image)libreriaImagenes.GetObject(auxToda.informacion());
                            stack2.AddCartas(auxToda);
                            imagen.Height = imagen.Image.Height;
                            imagen.Width = imagen.Image.Width;
                            imagen.Tag = auxToda;
                            imagen.Top = auxToda.Top;
                            imagen.Left = auxToda.Left;
                            imagen.BorderStyle = BorderStyle.FixedSingle;
                            Controls.Add(imagen);
                            imagen.BringToFront();              //Para que se coloque al frente, el orden es importante

                            imagen.MouseDown += Imagen_mousedown;
                            imagen.MouseMove += Imagen_MouseMove;
                            imagen.MouseUp += Imagen_MouseUp;
                            pictures.Add(imagen);

                            cartasStackAbajo.Add(auxToda);
                            break;
                        case 3:
                            auxToda = new Carta("h", (short)i);
                            auxToda.Top = auxAbajo;
                            auxToda.Left = auxIzquierda;
                            auxToda.StackPosicion = Convert.ToInt16(aux);
                            auxToda.Stack = stack3;

                            if (i == 1)
                            {
                                auxToda.FaceUp = true;
                                imagen.Image = (Image)libreriaImagenes.GetObject(auxToda.informacion());
                            }
                            else
                            {
                                auxToda.FaceUp = false;
                                imagen.Image = (Image)libreriaImagenes.GetObject("cardback");
                            }

                            auxToda.Jugable = true;
                            //auxToda.FaceUp = true;
                            stack3.AddCartas(auxToda);
                            //imagen.Image = (Image)libreriaImagenes.GetObject(auxToda.informacion());
                            imagen.Height = imagen.Image.Height;
                            imagen.Width = imagen.Image.Width;
                            imagen.Tag = auxToda;
                            imagen.Top = auxToda.Top;
                            imagen.Left = auxToda.Left;
                            imagen.BorderStyle = BorderStyle.FixedSingle;
                            Controls.Add(imagen);
                            imagen.BringToFront();              //Para que se coloque al frente, el orden es importante

                            imagen.MouseDown += Imagen_mousedown;
                            imagen.MouseMove += Imagen_MouseMove;
                            imagen.MouseUp += Imagen_MouseUp;
                            pictures.Add(imagen);

                            cartasStackAbajo.Add(auxToda);
                            break;
                        case 4:
                            auxToda = new Carta("s", (short)i);
                            auxToda.Top = auxAbajo;
                            auxToda.Left = auxIzquierda;
                            auxToda.StackPosicion = Convert.ToInt16(aux);
                            auxToda.Stack = stack4;

                            if (i == 1)
                            {
                                auxToda.FaceUp = true;
                                imagen.Image = (Image)libreriaImagenes.GetObject(auxToda.informacion());
                            }
                            else
                            {
                                auxToda.FaceUp = false;
                                imagen.Image = (Image)libreriaImagenes.GetObject("cardback");
                            }

                            auxToda.Jugable = true;
                            //auxToda.FaceUp = true;
                            stack4.AddCartas(auxToda);
                            //imagen.Image = (Image)libreriaImagenes.GetObject(auxToda.informacion());
                            imagen.Height = imagen.Image.Height;
                            imagen.Width = imagen.Image.Width;
                            imagen.Tag = auxToda;
                            imagen.Top = auxToda.Top;
                            imagen.Left = auxToda.Left;
                            imagen.BorderStyle = BorderStyle.FixedSingle;
                            Controls.Add(imagen);
                            imagen.BringToFront();              //Para que se coloque al frente, el orden es importante

                            imagen.MouseDown += Imagen_mousedown;
                            imagen.MouseMove += Imagen_MouseMove;
                            imagen.MouseUp += Imagen_MouseUp;
                            pictures.Add(imagen);

                            cartasStackAbajo.Add(auxToda);
                            break;
                    }

                    auxIzquierda = auxIzquierda + 70;
                }
                auxIzquierda = 5;
                aux++;
                auxAbajo = auxAbajo + 20;
            }
        }
        #endregion ModoUltraFacil


        #region movimiento
        private void Imagen_MouseUp(object sender, MouseEventArgs e)
        {
            _MouseDown = false;
            PictureBox picture = sender as PictureBox;
            Carta card = picture.Tag as Carta;
            if (!card.Jugable)
            {
                return;
            }
            if (_Movimiento)
            {
                ProcesarDropCarta(picture);
                _Movimiento = false;
            }

            PartidaGanada();
        }

        private void Imagen_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;

            PictureBox picture = sender as PictureBox;
            Carta card = picture.Tag as Carta;
            Console.WriteLine(card.Rango + card.Palo + " Top=" + card.Top + " Left=" + card.Left + "  S=" + card.StackPosicion);
            if (_MouseDown)  // Compruebo si estoy haciendo click
            {
                picture.Top = y + picture.Top - _DeltaY;
                picture.Left = x + picture.Left - _DeltaX;
                picture.BringToFront();
                _MoverCartas(picture);
            }
            _Movimiento = true;
        }


        private void Imagen_mousedown(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;
            PictureBox picture = sender as PictureBox;
            Carta card = picture.Tag as Carta;

            if (!card.Jugable)
            {
                return;
            }
            _MouseDown = true;
            _DeltaX = x;
            _DeltaY = y;
        }
        #endregion movimiento

        #region Metodos
      
        public void ProcesarDropCarta(PictureBox picture)
        {
            Carta card = picture.Tag as Carta;

            double cardCenter = 0;
            double pilaCentro = 0;
            Carta tempCard = null;
            Stack pilaAnterior = null;
            short cardIndex = 0;
            Carta[] cardsToMove = new Carta[15];
            short moved = 0;

            //pilaAnterior = card.Stack;


            //if (OrigenValido(card))
            //{
                //Console.WriteLine("Origen Valido");
                pilaAnterior = card.Stack;
                // Calcular el centro de la tarjeta en la posición actual
                cardCenter = picture.Left + picture.Width / 2.0;
                // El destino es la parte de arriba
                if ((picture.Top + picture.Height) < _Pilas[1].Top && card.StackPosicion == pilaAnterior.Cartas.Count) //Stacks de arriba
                {
                    Console.WriteLine("Estoy arriba");
                    foreach (Stack pila in _PilasArriba)
                    {
                        Stack stack = pila;
                        Console.WriteLine(pila.Left.ToString());
                        pilaCentro = pila.Left + picture.Width / 2.0;
                        short stackpos = Convert.ToInt16(pila.Cartas.Count() + 1); //posicion de carta 
                                                                                   
                        // Dentro de la mitad del ancho de la tarjeta                                                          
                        if (System.Math.Abs(cardCenter - pilaCentro) < picture.Width / 2.0)
                        {
                            // Movimiento valido?
                            if (ObjetivoValido(pila, card,true))
                            {

                                card.Left = pila.Left;
                                card.Top = pila.Top;
                               
                                picture.Left = card.Left;
                                picture.Top = card.Top;
                                picture.BringToFront();
                                card.Stack = pila;
                              
                                card.StackPosicion = Convert.ToInt16(pila.Cartas.Count()+1); ;
                                pilaAnterior.RemovedCard();//Borrar la carta de la pila anterior
                                pila.AddCartas(card);

                                ActualizarCarta(card);
                                if (pilaAnterior.TopCard != null)
                                {
                                    if (pilaAnterior.TopCard.FaceUp == false)
                                    {
                                        pilaAnterior.TurnUpTopCard();
                                    }
                                }
                                if (!picture.Contains(picture))
                                {
                                    pictures.Add(picture);  //Agreagmos el picture box a la lista si este viene de la posicion mano
                                }
                                picturesMano.Remove(picture);   //Para q no se elimine al momento de poner PedirMano
                                eliminarDeToda(card);     //Elimino de la lista de arriba
                                MostrarImagenes();
                                return;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                //El destino es la parte de arriba
                if ((picture.Top + picture.Height) > _Pilas[1].Top) //Stacks de abajo
                {
                Console.WriteLine("estoy arriba");
                    // Encontrar la pila mas cercana de abajo
                    foreach (Stack pila in _Pilas)
                    {
                        Stack stack = pila;
                        Console.WriteLine(pila.Left.ToString());
                        pilaCentro = pila.Left + picture.Width / 2.0;
                        int gap2 = 0; //Sirve para separar cartas cuando se llevan varias
                        short stackpos = Convert.ToInt16(pila.Cartas.Count() + 1); //poscicion de carta 
                                                                                   //
                                                                                   // Dentro de la mitad del ancho de la tarjeta
                        if (System.Math.Abs(cardCenter - pilaCentro) < picture.Width / 2.0)
                        {

                            //
                            // Movimiento valido?
                            if (ObjetivoValido(pila, card,false)) //Se envia falso para comprobar los stacks de abajo
                            {

                                card.Left = pila.Left;
                                if (pila.Cartas.Count != 0)//en caso de que no exista elementos en la lista
                                {
                                    card.Top = pila.Cartas.Last().Top + 20;
                                }
                                else
                                {
                                    card.Top = pila.Top;
                                }
                                picture.Left = card.Left;
                                picture.Top = card.Top;
                                picture.BringToFront();
                                moved = 0;

                                for (cardIndex = Convert.ToInt16(pilaAnterior.Cartas.Count); cardIndex >= card.StackPosicion; cardIndex--)
                                {
                                    moved = Convert.ToInt16(moved + 1);
                                    cardsToMove[moved] = pilaAnterior.RemovedCard();
                                    Console.WriteLine(cardsToMove[moved].Rango + cardsToMove[moved].Palo + "Top=" + cardsToMove[moved].Top + "Left=" + cardsToMove[moved].Left);


                                }

                                for (cardIndex = moved; cardIndex >= 1; cardIndex--)
                                {
                                    cardsToMove[cardIndex].Left = card.Left;
                                    cardsToMove[cardIndex].Top = card.Top + gap2;
                                    cardsToMove[cardIndex].Stack = pila;
                                    cardsToMove[cardIndex].StackPosicion = stackpos;
                                    gap2 += 20;
                                    pila.AddCartas(cardsToMove[cardIndex]);
                                    stackpos += 1;
                                    ActualizarCarta(cardsToMove[cardIndex]);
                                }

                                if (pilaAnterior.TopCard != null)
                                {

                                    if (pilaAnterior.TopCard.FaceUp == false)
                                    {
                                        pilaAnterior.TurnUpTopCard();
                                    }
                                }
                                pictures.Add(picture);  //Agreagmos al stack de abajo

                                picturesMano.Remove(picture);   //Para q no se elimine al momento de poner PedirMano
                                eliminarDeToda(card);     //Elimino de la lista de arriba
                                MostrarImagenes();

                                return;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                
            //}
            //

            // Movimiento Ilegal. Regresar la carta(s)
            for (cardIndex = card.StackPosicion; cardIndex <= pilaAnterior.Cartas.Count; cardIndex++)
            {
                tempCard = pilaAnterior.Cartas[cardIndex - 1];
                ActualizarCarta(tempCard);

            }

        }

        private bool ObjetivoValido(Stack pile, Carta card, bool Stack_Arriba_Abajo)
        {
            //Stack_Arriba_Abajo   abajo=falso   ;   arriba=verdadero
            bool tempValidTarget = false;

            if (Stack_Arriba_Abajo)//En caso que sean los stacks de arriba
            {
                if (pile.Cartas.Count == 0 && card.Rango == 1) //en caso de que el stack este vacio  y  que la carta se una K
                {
                    return true;
                }
                if (pile.Cartas.Count() != 0)
                {
                    if (pile.Cartas.Last().Rango == card.Rango - 1 && pile.Cartas.Last().Palo == card.Palo)
                    {
                        return true;
                    }
                }

                return false;
            }
            else
            {
                if (pile.Cartas.Count == 0 && card.Rango == 13) //en caso de que el stack este vacio  y  que la carta se una K
                {
                    return true;

                }
                if (pile.Cartas.Count() != 0)// En caso de que la lista no este vacia se comprueba el orden
                {
                    if (pile.Cartas.Last().Rango == card.Rango + 1)
                    {
                        switch (pile.Cartas.Last().Palo)
                        {
                            case "s":
                                if (card.Palo == "h") return true;
                                else if (card.Palo == "d") return true;
                                break;
                            case "c":
                                if (card.Palo == "h") return true;
                                else if (card.Palo == "d") return true;
                                break;
                            case "d":
                                if (card.Palo == "s") return true;
                                else if (card.Palo == "c") return true;
                                break;
                            case "h":
                                if (card.Palo == "s") return true;
                                else if (card.Palo == "c") return true;
                                break;
                            default:
                                break;
                        }
                        return false;
                    }
                }
            }


           

            return tempValidTarget;
        }

        private bool OrigenValido(Carta card)
        {
            short cardIndex = 0;
            Carta nextCard = null;
            int lastRank = 0;

            if (card.StackPosicion == card.Stack.Cartas.Count)
            {
                return true;
            }

            // Se chequea que las tarjetas siguientes esten en orden
            /*lastRank = card.Rango;
            for (cardIndex = Convert.ToInt16(card.StackPosicion + 1); cardIndex <= card.Stack.Cartas.Count; cardIndex++)
            {
                nextCard = card.Stack.Cartas[cardIndex - 1];

                if (nextCard.Rango + 1 != lastRank)
                {
                    SystemSounds.Exclamation.Play();
                    //************************************8
                    return false;
                }
                lastRank = nextCard.Rango;
            }*/
            return true;
        }

        #endregion Metodos

        #region Imagen
        private void _MoverCartas(PictureBox picture)
        {
            int gap = 20;
            Carta carta = picture.Tag as Carta;
            foreach (PictureBox item in pictures)
            {
                Carta cart = item.Tag as Carta;
                if (cart != null)
                {
                    if (cart.Stack == carta.Stack && carta.StackPosicion < cart.StackPosicion)
                    {
                        item.Left = picture.Left;
                        item.Top = picture.Top + gap;
                        //gap += 20;
                        item.BringToFront();
                    }
                }
                
            }
        }
        private void ActualizarCarta(Carta carta)
        {
            foreach (PictureBox item in Controls.OfType<PictureBox>())
            {
                Carta cart = item.Tag as Carta;

                if (cart == carta)
                {
                    item.Left = cart.Left;
                    item.Top = cart.Top;
                    item.Tag = carta;
                    item.BringToFront();
                }

            }
        }
        private void MostrarImagenes()
        {
            foreach (PictureBox item in Controls.OfType<PictureBox>())
            {
                Carta card = item.Tag as Carta;
                if (card!=null)
                {
                    if (!card.FaceUp)
                    {
                        item.Image = (Image)libreriaImagenes.GetObject("cardback");
                    }
                    else
                    {
                        item.Image = (Image)libreriaImagenes.GetObject("_" + Convert.ToString(card.Rango) + card.Palo);
                    }
                }
               

            }
        }
        private void ColocarControlesPrederteminados()
        {
            PictureBox imagenBaraja = new PictureBox();
            PictureBox arriba1 = new PictureBox();
            PictureBox arriba2 = new PictureBox();
            PictureBox arriba3 = new PictureBox();
            PictureBox arriba4 = new PictureBox();
            PictureBox pila1 = new PictureBox();
            PictureBox pila2 = new PictureBox();
            PictureBox pila3 = new PictureBox();
            PictureBox pila4 = new PictureBox();
            PictureBox pila5 = new PictureBox();
            PictureBox pila6 = new PictureBox();
            PictureBox pila7 = new PictureBox();
            //CARTAS

            imagenBaraja.Image = (Image)libreriaImagenes.GetObject("cardback");
            imagenBaraja.Top = 35;
            imagenBaraja.Left = 5;
            imagenBaraja.Height = imagenBaraja.Image.Height;
            imagenBaraja.Width = imagenBaraja.Image.Width;
            imagenBaraja.Visible = true;
            Controls.Add(imagenBaraja);
                      
            arriba1.Image = (Image)libreriaImagenes.GetObject("CartaVacia");   //Falta añadir otra imagen al Resources
            arriba1.Top = 35;
            arriba1.Left = 215;   //se debe sumar 70 para el otro
            arriba1.Height = imagenBaraja.Image.Height;
            arriba1.Width = imagenBaraja.Image.Width;
            arriba1.Visible = true;
            Controls.Add(arriba1);
          

            arriba2.Image = (Image)libreriaImagenes.GetObject("CartaVacia");   //Falta añadir otra imagen al Resources
            arriba2.Top = 35;
            arriba2.Left = 285;   //se debe sumar 70 para el otro
            arriba2.Height = imagenBaraja.Image.Height;
            arriba2.Width = imagenBaraja.Image.Width;
            arriba2.Visible = true;
            Controls.Add(arriba2);
           

            arriba3.Image = (Image)libreriaImagenes.GetObject("CartaVacia");   //Falta añadir otra imagen al Resources
            arriba3.Top = 35;
            arriba3.Left = 355;   //se debe sumar 70 para el otro
            arriba3.Height = imagenBaraja.Image.Height;
            arriba3.Width = imagenBaraja.Image.Width;
            arriba3.Visible = true;
            Controls.Add(arriba3);
          

            arriba4.Image = (Image)libreriaImagenes.GetObject("CartaVacia");   //Falta añadir otra imagen al Resources
            arriba4.Top = 35;
            arriba4.Left = 425;   //se debe sumar 70 para el otro
            arriba4.Height = imagenBaraja.Image.Height;
            arriba4.Width = imagenBaraja.Image.Width;
            arriba4.Visible = true;
            Controls.Add(arriba4);

            pila1.Image = (Image)libreriaImagenes.GetObject("CartaVacia");   //Falta añadir otra imagen al Resources
            pila1.Top = 150;
            pila1.Left = 5;   //se debe sumar 70 para el otro
            pila1.Height = imagenBaraja.Image.Height;
            pila1.Width = imagenBaraja.Image.Width;
            pila1.Visible = true;
            Controls.Add(pila1);

            pila2.Image = (Image)libreriaImagenes.GetObject("CartaVacia");   //Falta añadir otra imagen al Resources
            pila2.Top = 150;
            pila2.Left = 75;   //se debe sumar 70 para el otro
            pila2.Height = imagenBaraja.Image.Height;
            pila2.Width = imagenBaraja.Image.Width;
            pila2.Visible = true;
            Controls.Add(pila2);

            pila3.Image = (Image)libreriaImagenes.GetObject("CartaVacia");   //Falta añadir otra imagen al Resources
            pila3.Top = 150;
            pila3.Left = 145;   //se debe sumar 70 para el otro
            pila3.Height = imagenBaraja.Image.Height;
            pila3.Width = imagenBaraja.Image.Width;
            pila3.Visible = true;
            Controls.Add(pila3);

            pila4.Image = (Image)libreriaImagenes.GetObject("CartaVacia");   //Falta añadir otra imagen al Resources
            pila4.Top = 150;
            pila4.Left = 215;   //se debe sumar 70 para el otro
            pila4.Height = imagenBaraja.Image.Height;
            pila4.Width = imagenBaraja.Image.Width;
            pila4.Visible = true;
            Controls.Add(pila4);

            pila5.Image = (Image)libreriaImagenes.GetObject("CartaVacia");   //Falta añadir otra imagen al Resources
            pila5.Top = 150;
            pila5.Left = 285;   //se debe sumar 70 para el otro
            pila5.Height = imagenBaraja.Image.Height;
            pila5.Width = imagenBaraja.Image.Width;
            pila5.Visible = true;
            Controls.Add(pila5);

            pila6.Image = (Image)libreriaImagenes.GetObject("CartaVacia");   //Falta añadir otra imagen al Resources
            pila6.Top = 150;
            pila6.Left = 355;   //se debe sumar 70 para el otro
            pila6.Height = imagenBaraja.Image.Height;
            pila6.Width = imagenBaraja.Image.Width;
            pila6.Visible = true;
            Controls.Add(pila6);

            pila7.Image = (Image)libreriaImagenes.GetObject("CartaVacia");   //Falta añadir otra imagen al Resources
            pila7.Top = 150;
            pila7.Left = 425;   //se debe sumar 70 para el otro
            pila7.Height = imagenBaraja.Image.Height;
            pila7.Width = imagenBaraja.Image.Width;
            pila7.Visible = true;
            Controls.Add(pila7);


            //BOTONES

            Button btnNuevo = new Button();
            btnNuevo.Text = "Nuevo Juego";
            btnNuevo.Top = 35;
            btnNuevo.Left = 500;
            btnNuevo.Width = 164;
            btnNuevo.Height = 51;
            btnNuevo.Visible = true;
            btnNuevo.BackColor = Color.White;
            btnNuevo.Click += ClickBotonNuevo;
            Controls.Add(btnNuevo);

            Button btnMano = new Button();
            btnMano.Text = "Pedir mano";
            btnMano.Top = 86;
            btnMano.Left = 500;
            btnMano.Width = 164;
            btnMano.Height = 51;
            btnMano.Visible = true;
            btnMano.BackColor = Color.White;
            btnMano.Click += ClickMano;
            Controls.Add(btnMano);

            Button btnFacil = new Button();
            btnFacil.Text = "Modo Extra Facil";
            btnFacil.Top = 137;
            btnFacil.Left = 500;
            btnFacil.Width = 164;
            btnFacil.Height = 51;
            btnFacil.Visible = true;
            btnFacil.BackColor = Color.White;
            btnFacil.Click += ModoFacil;
            Controls.Add(btnFacil);

            arriba1.Image = (Image)libreriaImagenes.GetObject("CartaVacia");   //Falta añadir otra imagen al Resources
            arriba1.Top = 35;
            arriba1.Left = 215;   //se debe sumar 70 para el otro
            arriba1.Height = imagenBaraja.Image.Height;
            arriba1.Width = imagenBaraja.Image.Width;
            arriba1.Visible = true;
            Controls.Add(arriba1);


        }

        #endregion Imagen

        #region AvisoGanar
        private bool Gane()
        {
            // bool ganador = true;
            foreach (var i in _Pilas)
            {
                if (i.Cartas.Count != 0)
                {
                    return false;
                }
            }

            return true;
        }

        private void PartidaGanada()
        {
            if (Gane())
            {
                MessageBox.Show("Felicidades Crack has ganado!!", "Solitario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (MessageBox.Show("Deseas Jugar otra partida?", "Solitario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    inicioJuego();
                }
                else
                {
                    Application.Exit();
                }
            }
        }
        #endregion AvisoGanar


    }
}
