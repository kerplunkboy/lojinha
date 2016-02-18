using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Loja.Classes.Cliente cli = new Loja.Classes.Cliente(1);
            //using (Classes.Cliente cli = new Classes.Cliente())
            //{
            //    cli.Codigo = 2;
            //    cli.Nome = "Pedrinho";
            //    cli.Tipo = 2;
            //    cli.DataCadastro = new DateTime(2015, 12, 10);
            //}
            //try
            //{
            //    cli.Codigo = 1;
            //    cli.Nome = "jOão".PrimeiraMaiuscula(true);
            //    cli.Tipo = 1;
            //    cli.DataCadastro = new DateTime(2015, 12, 1);
            //    cli.Dispose();
            //}
            //catch (ConsoleApplication1.Excecoes.ValidacaoException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //using (Classes.Cliente cli2 = new Classes.Cliente(5))
            //{
            //    cli2.Nome = "XYZ";
            //}

            //Classes.Contato contato = new Classes.Contato();
            //contato.Codigo = 1;
            //contato.DadosContato = "666-6666";
            //contato.Tipo = "Telefone";

            //Classes.Contato contato2 = new Classes.Contato();
            //contato2.Codigo = 2;
            //contato2.DadosContato = "satan@inferno.com.br";
            //contato2.Tipo = "E-mail";

            //cli.Contatos = new List<Classes.Contato>();
            //cli.Contatos.Add(contato);
            //cli.Contatos.Add(contato2);

            //cli.Gravar();
            //foreach (Classes.Contato cont in cli.Contatos)
            //{
            //    cont.Gravar();
            //}

            //foreach (Classes.Contato cont in cli.Contatos)
            //{
            //    Console.WriteLine(cont.DadosContato);
            //}

            //cli.Contatos.ForEach(cont => cont.Gravar());

            //Classes.Contato contadoBuscado = cli.Contatos.FirstOrDefault(x => x.Tipo == "Telefone");
            //Console.WriteLine(contadoBuscado.DadosContato);

            Console.ReadLine();
        }
    }
}
