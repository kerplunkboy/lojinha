using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Loja.Classes
{
    public partial class Cliente : Backwork<Cliente>, ICRUD
    {


        private int _codigo;
        [Key]
        [DisplayName("Código")]
        [DataObjectField(true, true, false)]
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
        [DataObjectField(false, false, true)]
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
        [DataObjectField(false, false, true)]
        public int? Tipo
        {
            get { return _tipo; }
            set { _tipo = value; this._isModified = true; }
        }

        private DateTime? _dataCadastro;
        [DisplayName("Data de cadastro")]
        [DataObjectField(false, false, true)]
        public DateTime? DataCadastro
        {
            get { return _dataCadastro; }
            set { _dataCadastro = value; this._isModified = true; }
        }

        public List<Contato> Contatos { get; set; }

        private bool _isNew;
        private bool _isModified;
        [Browsable(false)]
        public bool IsNew
        {
            get { return _isNew; }
        }
        [Browsable(false)]
        public bool IsModified
        {
            get { return _isModified; }
        }
    }
}
