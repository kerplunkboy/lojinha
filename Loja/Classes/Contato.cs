using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Server=.\sqlexpress;Database=loja;Trusted_Connection=True;
namespace Loja.Classes
{
    public partial class Contato : Backwork<Contato>
    {
        private bool _isNew;

        [Browsable(false)]
        public bool IsNew
        {
            get { return _isNew; }
        }

        private bool _isModified;
        [Browsable(false)]
        public bool IsModified
        {
            get { return _isModified; }
        }
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
        private int _cliente;
        [Browsable(false)]
        public int Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }

    }
}
