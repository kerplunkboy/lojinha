using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Classes
{
    public partial class Cliente
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
        [DisplayName("Código")]
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
        [DisplayName("Nome do cliente")]
        public string Nome
        {
            get { return _nome; }
            set
            {
                _nome = value;
                this._isModified = true;
            }
        }

        private int? _tipo;
        [DisplayName("Tipo")]
        public int? Tipo
        {
            get { return _tipo; }
            set { _tipo = value; this._isModified = true; }
        }

        private DateTime? _dataCadastro;
        [DisplayName("Data de cadastro")]
        public DateTime? DataCadastro
        {
            get { return _dataCadastro; }
            set { _dataCadastro = value; this._isModified = true; }
        }

        public List<Contato> Contatos { get; set; }
    }
}
