using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frmTablero
{
    public class Stack
    {
        private int _Top;
        private int _Left;
        private short _TOS; //Top del stack
        List<Carta> _Cartas = new List<Carta>(); 

        public Stack()
        {
            _TOS = 0;
        }

        public Stack(int Top, int Left)
        {
            _Top = Top;
            _Left = Left;
        }

        public Stack(int Top, int Left, List<Carta> Cartas)
        {
            _Top = Top;
            _Left = Left;
            _Cartas = Cartas;
        }

        public int Top { get => _Top; set => _Top = value; }
        public int Left { get => _Left; set => _Left = value; }
        public short TOS { get => _TOS; set => _TOS = value; }
        public List<Carta> Cartas { get => _Cartas; set => _Cartas = value; }
        
        public void AddCartas(Carta carta)
        {
            _TOS = Convert.ToInt16(_TOS + 1);
            _Cartas.Add(carta);
        }
        public Carta RemovedCard()
        {
            Carta tempRemovedCard = null;
            Carta card = null;

            if (_TOS == 0)
            {
                tempRemovedCard = null;
            }
            else
            {
                card = _Cartas[_TOS-1];
                tempRemovedCard = card;
                _Cartas.Remove(card);
                _TOS = Convert.ToInt16(_TOS - 1); ;
            }   
            return tempRemovedCard;
        }
        public Carta TopCard
        {
            get
            {
                Carta tempTopCard = null;
                if (_TOS > 0)
                {
                    tempTopCard = _Cartas[_TOS-1];
                }
                else
                {
                    tempTopCard = null;
                }
                return tempTopCard;
            }
        }
        public void TurnUpTopCard()
        {
            Carta card = null;
          
            if (_TOS > 0)
            {
                card = _Cartas[_TOS-1];
                card.FaceUp = true;
                card.Jugable = true;
            }

        }
    }
}
