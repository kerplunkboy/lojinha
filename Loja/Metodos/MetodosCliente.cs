using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Reflection;

public static class MetodosExtensao
{
    public static int Metade(this int Valor)
    {
        return Valor / 2;
    }
    public static double Juros(this double Valor)
    {
        return Valor + 20;
    }
    public static string PrimeiraMaiuscula(this string Valor)
    {
        return Valor.Substring(0, 1).ToUpper() + Valor.Substring(1, Valor.Length - 1).ToLower();
    }
    public static string PrimeiraMaiuscula(this string Valor, bool UltimasMinusculas)
    {
        if (UltimasMinusculas)
        {
            return Valor.Substring(0, 1).ToUpper() + Valor.Substring(1, Valor.Length - 1).ToLower();
        }
        else
        {
            return Valor.Substring(0, 1).ToUpper() + Valor.Substring(1, Valor.Length - 1);
        }
    }
}

namespace Loja.Classes
{
    public partial class Cliente : IDisposable
    {

        public Cliente()
        {
            this._codigo = Convert.ToInt32(Next());
            this._isNew = true;
            this._isModified = false;
        }
        public Cliente(int Codigo)
        {
            SetSelf(GetByPrimaryKey(Codigo));
            this._isNew = false;
            this._isModified = false;
        }
        private void SetSelf(Cliente Entity)
        {
            foreach (PropertyInfo pro in Entity.GetType().GetProperties())
            {
                if (this.GetType().GetProperty(pro.Name).GetCustomAttribute(typeof(DataObjectFieldAttribute)) != null)
                    this.GetType().GetProperty(pro.Name).SetValue(this, pro.GetValue(Entity));
            }
        }
    
        public List<Cliente> Todos()
        {
            List<Cliente> _return = null;
            using (SqlConnection cn = new SqlConnection("Server=.\\sqlexpress;Database=loja;Trusted_Connection=True;"))
            {
                try
                {
                    cn.Open();
                }
                catch (Exception)
                {

                    throw;
                }
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cn;
                    cmd.CommandText = "Select * From Cliente";

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {

                                Cliente cli = ConvertRowToEntity(dr);
                                //cli._codigo = dr.GetInt32(dr.GetOrdinal("Codigo"));
                                //cli._nome = dr.GetString(dr.GetOrdinal("Nome"));
                                //cli._tipo = dr.GetInt32(dr.GetOrdinal("Tipo"));
                                //cli._dataCadastro = dr.GetDateTime(dr.GetOrdinal("DataCadastro"));

                                cli.Contatos = Contato.Todos(cli._codigo);

                                if (_return == null)
                                    _return = new List<Cliente>();

                                cli._isNew = false;

                                _return.Add(cli);
                            }

                        }
                    }
                }
            }

            return _return;
        }

        public void Dispose()
        {
            this.Gravar();
        }


    }
}
