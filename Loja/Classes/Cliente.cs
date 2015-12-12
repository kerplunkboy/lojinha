using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Classes
{
    public partial class Cliente
    {

        private bool _isNew;

        public bool IsNewm
        {
            get { return _isNew; }
        }

        private bool _isModified;
        public bool IsModified
        {
            get { return _isModified; }
        }

        private int _codigo;
        public int Codigo
        {
            get 
            { 
                return _codigo; 
            }
            set 
            { 
                if (value < 0)
                {
                    throw new Loja.Excecoes.ValidacaoException("O código do cliente não pode ser negativo");
                }
                _codigo = value;
                this._isModified = true;
            }
        }

        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set 
            {
                if (value.Length <= 3)
                    throw new Loja.Excecoes.ValidacaoException("O nome do cliente precisa ter no mínimo 4 caracteres");
                _nome = value;
                this._isModified = true;
            }
        }

        private int? _tipo;
        public int? Tipo
        {
            get { return _tipo; }
            set { _tipo = value; this._isModified = true; }
        }

        private DateTime? _dataCadastro;
        public DateTime? DataCadastro
        {
            get { return _dataCadastro; }
            set { _dataCadastro = value; this._isModified = true; }
        }

        public List<Contato> Contatos { get; set; }
    }
}
