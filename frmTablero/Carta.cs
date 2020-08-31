using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frmTablero
{
    public class Carta
    {
        #region Parametros
        private string familia;
        private short rango;
        private int _Top;
        private int _Left;
        private bool _FaceUp;  
        private bool _Jugable;
        private bool _Clickable;
        private bool _Dragable;
        private Stack _Stack;
        private short _StackPosicion;

        public Carta(string familia, short rango)
        {
            this.familia = familia;
            this.rango = rango;
        }

        public Carta(string palo, short rango, int Top, int Left)
        {
            this.Palo = palo;
            this.Rango = rango;
            this.Top = Top;
            this.Left = Left;
        }

        public Carta(string palo, short rango, int Top, int Left, bool FaceUp)
        {
            this.Palo = palo;
            this.Rango = rango;
            this.Top = Top;
            this.Left = Left;
            this.FaceUp = FaceUp;
        }

        public string Palo { get => familia; set => familia = value; }
        public short Rango { get => rango; set => rango = value; }
        public int Top { get => _Top; set => _Top = value; }
        public int Left { get => _Left; set => _Left = value; }
        public bool FaceUp { get => _FaceUp; set => _FaceUp = value; }
        public bool Jugable { get => _Jugable; set => _Jugable = value; }
        public bool Clickable { get => _Clickable; set => _Clickable = value; }
        public bool Dragable { get => _Dragable; set => _Dragable = value; }
        public Stack Stack { get => _Stack; set => _Stack = value; }
        public short StackPosicion { get => _StackPosicion; set => _StackPosicion = value; }
        #endregion Parametros

        #region Metodos
        //Metodo para identificar la familia y el numero
        public string informacion()
        {
            return "_" + Rango + Palo;  //_1s ,2h
        }
        #endregion Metodos

    }
}
