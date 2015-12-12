using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Server=.\sqlexpress;Database=loja;Trusted_Connection=True;
namespace Loja.Classes
{
    public class Contato
    {
        private int _codigo;
        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        private string _dadosContato;
        public string DadosContato
        {
            get { return _dadosContato; }
            set { _dadosContato = value; }
        }

        private string _tipo;
        public string Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        
        public void Gravar()
        {
            
            int x = 1;
           
        }
    }
}
