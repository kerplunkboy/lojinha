using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Classes
{
    interface ICRUD
    {
        bool IsNew { get; }
        bool IsModified { get; }
    }
    public abstract class Backwork<T> where T : Backwork<T>, new()
    {

        private static object ChangeType(object value, Type conversionType)
        {
            if (conversionType == null)
            {
                throw new ArgumentNullException("conversionType");
            }

            if (conversionType.IsGenericType &&
              conversionType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {

                if (value == null)
                {
                    return null;
                }

                System.ComponentModel.NullableConverter nullableConverter = new NullableConverter(conversionType);
                conversionType = nullableConverter.UnderlyingType;
            }
            return Convert.ChangeType(value, conversionType);
        }
        public static T ConvertRowToEntity(SqlDataReader dr)
        {
            T _return = new T();
            foreach (PropertyInfo pro in typeof(T).GetProperties().ToList())
            {
                try
                {
                    object valor = dr.GetValue(dr.GetOrdinal(pro.Name));
                    if (valor == DBNull.Value)
                    {
                        _return.GetType().GetProperty(pro.Name).SetValue(null, null);
                    }
                    else
                    {
                        valor = ChangeType(valor, pro.PropertyType);
                        _return.GetType().GetProperty(pro.Name).SetValue(_return, valor);
                    }
                }
                catch (Exception)
                {

                }

            }
            return _return;
        }
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
        public SqlCommand GetInsertCommand()
        {
            SqlCommand _return = new SqlCommand();
            _return.CommandText = "Insert Into {0} ({1}) Values ({2})";

            string tabela = typeof(T).Name;
            string campos = "";
            string valores = "";

            foreach (PropertyInfo pro in typeof(T).GetProperties().ToList().Where(
                p => p.GetCustomAttribute(typeof(DataObjectFieldAttribute)) != null))
            {
                campos += pro.Name + ", ";
                valores += "@" + pro.Name + ",";

                _return.Parameters.AddWithValue("@" + pro.Name, pro.GetValue(this));
            }

            campos = campos.Substring(0, campos.Length - 2);
            valores = valores.Substring(0, valores.Length - 1);

            _return.CommandText = string.Format(_return.CommandText, tabela, campos, valores);

            return _return;
        }
        public void Update()
        {
            using (SqlConnection cn = new SqlConnection("Server=.\\sqlexpress;Database=loja;Trusted_Connection=True;"))
            {
                SqlCommand cmd = this.GetUpdateCommand();
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
        public SqlCommand GetUpdateCommand()
        {
            SqlCommand _return = new SqlCommand();
            _return.CommandText = "Update {0} Set {1} Where {2}";

            string tabela = typeof(T).Name;
            string campos = "";
            string chave = "";

            foreach (PropertyInfo pro in typeof(T).GetProperties().ToList().Where(
                p => p.GetCustomAttribute(typeof(DataObjectFieldAttribute)) != null))
            {
                DataObjectFieldAttribute att = (DataObjectFieldAttribute)pro.GetCustomAttribute(typeof(DataObjectFieldAttribute));

                if (att.PrimaryKey == true)
                {
                    chave = pro.Name + "=@" + pro.Name;
                    _return.Parameters.AddWithValue("@" + pro.Name, pro.GetValue(this));
                }
                else
                {
                    campos += pro.Name + "=@" + pro.Name + ",";
                    _return.Parameters.AddWithValue("@" + pro.Name, pro.GetValue(this));
                }
            }
            campos = campos.Substring(0, campos.Length - 1);
            _return.CommandText = string.Format(_return.CommandText, tabela, campos, chave);

            return _return;
        }
        public void Delete()
        {
            using (SqlConnection cn = new SqlConnection("Server=.\\sqlexpress;Database=loja;Trusted_Connection=True;"))
            {
                SqlCommand cmd = this.GetDeleteCommand();
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
        public SqlCommand GetDeleteCommand()
        {
            SqlCommand _return = new SqlCommand();
            string tabela = typeof(T).Name;
            string chave = "";
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
                    cmd.CommandText = "Delete From {0} Where {1}";
                    cmd.Connection = cn;

                    foreach (PropertyInfo pro in typeof(T).GetProperties().ToList().Where(
                         p => p.GetCustomAttribute(typeof(DataObjectFieldAttribute)) != null))
                    {
                        DataObjectFieldAttribute att = (DataObjectFieldAttribute)pro.GetCustomAttribute(typeof(DataObjectFieldAttribute));
                        if (att.PrimaryKey)
                        {
                            chave = pro.Name + "=@" + pro.Name;
                            _return.Parameters.AddWithValue("@" + pro.Name, pro.GetValue(this));
                        }
                    }
                    _return.CommandText = string.Format(_return.CommandText, tabela, chave);
                }
            }
            return _return;
        }
        public Int32? Next()
        {
            Int32? _return = 0;
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
                    cmd.CommandText = "Select Max({0}) + 1 From {1}";


                    PropertyInfo pro = (PropertyInfo)typeof(T).GetProperties().ToList().FirstOrDefault(
                        p => p.GetCustomAttribute(typeof(DataObjectFieldAttribute)) != null);

                    cmd.CommandText = string.Format(cmd.CommandText, pro.Name, typeof(T).Name);

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
        public void Gravar()
        {
            if ((bool)typeof(T).GetProperty("IsNew").GetValue(this) == true)
                Insert();
            else if ((bool)typeof(T).GetProperty("IsModified").GetValue(this) == true)
                Update();


        }
        public List<T> GetAll()
        {
            List<T> _return = null;

            using (SqlCommand cmd = GetSelectCommand())
            {
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        _return = new List<T>();

                        while(dr.Read())
                        {
                            _return.Add(ConvertRowToEntity(dr));
                        }
                    }
                }
            }

            return _return;
        }
        public SqlCommand GetSelectCommand()
        {
            SqlCommand _return = null;

            try
            {
                _return = new SqlCommand();
                _return.CommandText = "Select * From {0}";
                _return.CommandText = string.Format(_return.CommandText, typeof(T).Name);
                _return.Connection = new SqlConnection();
                _return.Connection.ConnectionString = "Server=.\\sqlexpress;Database=loja;Trusted_Connection=True;";
                _return.Connection.Open();
            }
            catch (Exception)
            {
                throw;
            }
            return _return;
        }
        public T GetByPrimaryKey(object value)
        {
            T _return = null;
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
                    cmd.CommandText = "Select * From {0} Where {1}";
                    PropertyInfo pro = (PropertyInfo)typeof(T).GetProperties().ToList().FirstOrDefault(
                        p => p.GetCustomAttribute(typeof(DataObjectFieldAttribute)) != null);


                    cmd.Parameters.AddWithValue("@" + pro.Name, ChangeType(value, pro.PropertyType));
                    cmd.CommandText = string.Format(cmd.CommandText, typeof(T).Name, pro.Name + "=@" + pro.Name);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            _return = new T();
                            _return = ConvertRowToEntity(dr);
                        }
                    }

                }
            }
            return _return;
        }
        internal void SetSelf(T Entity)
        {
            foreach (PropertyInfo pro in Entity.GetType().GetProperties())
            {
                if (this.GetType().GetProperty(pro.Name).GetCustomAttribute(typeof(DataObjectFieldAttribute)) != null)
                    this.GetType().GetProperty(pro.Name).SetValue(this, pro.GetValue(Entity));
            }
        }
    }
}
