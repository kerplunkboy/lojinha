using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Loja.Classes
{
    public partial class Contato : IDisposable
    {
        public void Insert()
        {
            using (SqlConnection cn = new SqlConnection("Server=.\\sqlexpress;Database=loja;Trusted_Connection=True;"))
            {
                SqlCommand cmd = this.GetInsertCommand();
                try
                {
                    cn.Open();
                }
                catch (Exception)
                {
                    throw;
                }
                cmd.Connection = cn;

                cmd.ExecuteNonQuery();
            }   
        }
        public void Update()
        {
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
                    cmd.CommandText = "Update Conato Set Cliente = @cliente, Tipo = @tipo, DadosContato = @dadoscontato Where Codigo = @codigo";
                    cmd.Connection = cn;

                    cmd.Parameters.AddWithValue("@codigo", this._codigo);
                    cmd.Parameters.AddWithValue("@cliente", this._cliente);
                    cmd.Parameters.AddWithValue("@tipo", this._tipo);
                    cmd.Parameters.AddWithValue("@dadoscontato", this._dadosContato);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        this._isModified = false;
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }
            }
        }
        public void Gravar()
        {
            if (this._isNew)
                Insert();
            else if (this._isModified)
                Update();
        }
        public void Apagar()
        {
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
                    cmd.CommandText = "Delete From Contato Where Codigo = @codigo";
                    cmd.Connection = cn;

                    cmd.Parameters.AddWithValue("@codigo", this._codigo);


                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }
            }
        }

        public Contato()
        {
            this._codigo = Proximo();
            this._isNew = true;
            this._isModified = false;
        }
        public Contato(int Codigo)
        {
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
                    cmd.CommandText = "Select * From Contato Where Codigo = @codigo";
                    cmd.Parameters.AddWithValue("@codigo", Codigo);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            this._codigo = dr.GetInt32(dr.GetOrdinal("Codigo"));
                            this._dadosContato = dr.GetString(dr.GetOrdinal("DadosContato"));
                            this._tipo = dr.GetString(dr.GetOrdinal("Tipo"));
                            this._cliente = dr.GetInt32(dr.GetOrdinal("Cliente"));
                        }
                    }
                    this._isNew = false;
                    this._isModified = false;
                }
            }

        }

        public static Int32 Proximo()
        {
            Int32 _return = 0;
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
                    cmd.CommandText = "Select Max(Codigo) + 1 From Contato";

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            _return = dr.GetInt32(0);
                        }
                    }

                }
            }
            return _return;
        }
        public static List<Contato> Todos(int Cliente)
        {
            List<Contato> _return = null;

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
                    cmd.CommandText = "Select * From Contato Where Cliente = @cliente";

                    cmd.Parameters.AddWithValue("@cliente", Cliente);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                Contato con = ConvertRowToEntity(dr);

                                if (_return == null)
                                    _return = new List<Contato>();

                                con._isNew = false;

                                _return.Add(con);
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

