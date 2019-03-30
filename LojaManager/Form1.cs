using Loja.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LojaManager
{
    public partial class Form1 : Form
    {
        BindingSource dados = new BindingSource();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.SelectionMode= DataGridViewSelectionMode.FullRowSelect;
            
            dados.DataSource = new BindingList<Cliente>(new Cliente().GetAll());
            dataGridView1.DataSource = dados;

            dados.CurrentItemChanged += dados_CurrentItemChanged;

            txtCodigo.DataBindings.Add("Text", dados, "Codigo", true, DataSourceUpdateMode.OnPropertyChanged);
            txtNome.DataBindings.Add("Text", dados, "Nome", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTipo.DataBindings.Add("Text", dados, "Tipo", true, DataSourceUpdateMode.OnPropertyChanged);
            txtDataCadastro.DataBindings.Add("Text", dados, "DataCadastro", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        void dados_CurrentItemChanged(object sender, EventArgs e)
        {
            dgvContatos.DataSource = ((Cliente)dados.Current).Contatos;

        }

        void dados_CurrentChanged(object sender, EventArgs e)
        {
            //dgvContatos.DataSource = ((Cliente)dados.Current).Contatos;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ((Cliente)dados.Current).Gravar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dados.Add(new Cliente());
            dados.MoveLast();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente apagar este cliente?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                ((Cliente)dados.Current).Delete();
                dados.RemoveCurrent();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvContatos_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgvContatos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (txtClienteContato.DataBindings.Count > 0)
                txtClienteContato.DataBindings.RemoveAt(0);

            if (((Loja.Classes.Cliente)dados.Current).Contatos != null)
                txtClienteContato.DataBindings.Add("Text", (Loja.Classes.Contato)(((Loja.Classes.Cliente)dados.Current).Contatos.ToArray()[dgvContatos.CurrentRow.Index]), "Cliente", true, DataSourceUpdateMode.OnPropertyChanged);

            txtClienteContato.Refresh();
        }

    }
}
