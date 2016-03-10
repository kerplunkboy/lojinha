using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LojaManager
{
    public partial class ComsumindoWebAPI : Form
    {
        List<ClienteAPI> dados = null;
        public ComsumindoWebAPI()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            textBox1.Text = "Inserindo";
            Task<string> resultado = new ClienteAPI() { Codigo = 99, Nome = "Mariana", DataCadastro = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), Tipo = 7 }.Post();
            string res = await resultado;
            textBox1.Text = res;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Alterando";
            Task<string> resultado = new ClienteAPI() { Codigo = 99, Nome = DateTime.Now.Millisecond.ToString(), DataCadastro = DateTime.Now.ToUniversalTime(), Tipo = 7 }.Put(99);
            string res = await resultado;
            textBox1.Text = res;

        }

        private async void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Excluindo";
            Task<string> resultado = new ClienteAPI().Delete(99);
            string res = await resultado;
            textBox1.Text = res;

        }

        private async void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Buscando";
            Task<string> resultado = new ClienteAPI().Get("7");
            string res = await resultado;
            textBox1.Text = res.Desserialize().Nome;
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Buscando";
            Task<string> resultado = new ClienteAPI().Get("");
            string res = await resultado;
            List<ClienteAPI> lista = res.DesserializeList();
            textBox1.Text = lista.Count.ToString();
            dataGridView1.DataSource = lista;
        }
    }
}
