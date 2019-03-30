using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Reflection;
using System.Runtime.InteropServices;

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
        public void Dispose()
        {
            this.Gravar();
        }


    }
}
