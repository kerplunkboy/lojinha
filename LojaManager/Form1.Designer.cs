namespace LojaManager
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.txtDataCadastro = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dgvContatos = new System.Windows.Forms.DataGridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.txtCodigoContato = new System.Windows.Forms.TextBox();
            this.txtClienteContato = new System.Windows.Forms.TextBox();
            this.txtTipoContato = new System.Windows.Forms.TextBox();
            this.txtDadosContato = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(441, 150);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(563, 53);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(100, 20);
            this.txtCodigo.TabIndex = 1;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(563, 80);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(137, 20);
            this.txtNome.TabIndex = 2;
            // 
            // txtTipo
            // 
            this.txtTipo.Location = new System.Drawing.Point(563, 107);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.Size = new System.Drawing.Size(54, 20);
            this.txtTipo.TabIndex = 3;
            // 
            // txtDataCadastro
            // 
            this.txtDataCadastro.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDataCadastro.Location = new System.Drawing.Point(563, 134);
            this.txtDataCadastro.Name = "txtDataCadastro";
            this.txtDataCadastro.Size = new System.Drawing.Size(100, 20);
            this.txtDataCadastro.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(459, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Código";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(459, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nome";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(459, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tipo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(459, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Data de Cadastro";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(625, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Gravar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(463, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Novo";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(544, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "Apagar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dgvContatos
            // 
            this.dgvContatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContatos.Location = new System.Drawing.Point(12, 197);
            this.dgvContatos.Name = "dgvContatos";
            this.dgvContatos.ReadOnly = true;
            this.dgvContatos.Size = new System.Drawing.Size(441, 150);
            this.dgvContatos.TabIndex = 12;
            this.dgvContatos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContatos_CellEnter);
            this.dgvContatos.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContatos_CellLeave);
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(Loja.Classes.Cliente);
            // 
            // txtCodigoContato
            // 
            this.txtCodigoContato.Location = new System.Drawing.Point(561, 201);
            this.txtCodigoContato.Name = "txtCodigoContato";
            this.txtCodigoContato.ReadOnly = true;
            this.txtCodigoContato.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoContato.TabIndex = 13;
            // 
            // txtClienteContato
            // 
            this.txtClienteContato.Location = new System.Drawing.Point(561, 227);
            this.txtClienteContato.Name = "txtClienteContato";
            this.txtClienteContato.ReadOnly = true;
            this.txtClienteContato.Size = new System.Drawing.Size(100, 20);
            this.txtClienteContato.TabIndex = 14;
            // 
            // txtTipoContato
            // 
            this.txtTipoContato.Location = new System.Drawing.Point(561, 254);
            this.txtTipoContato.Name = "txtTipoContato";
            this.txtTipoContato.Size = new System.Drawing.Size(100, 20);
            this.txtTipoContato.TabIndex = 15;
            // 
            // txtDadosContato
            // 
            this.txtDadosContato.Location = new System.Drawing.Point(563, 280);
            this.txtDadosContato.Name = "txtDadosContato";
            this.txtDadosContato.Size = new System.Drawing.Size(100, 20);
            this.txtDadosContato.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(460, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Código";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(460, 233);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Cliente";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(460, 260);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Tipo";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(463, 286);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Dados contato";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 356);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDadosContato);
            this.Controls.Add(this.txtTipoContato);
            this.Controls.Add(this.txtClienteContato);
            this.Controls.Add(this.txtCodigoContato);
            this.Controls.Add(this.dgvContatos);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDataCadastro);
            this.Controls.Add(this.txtTipo);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtTipo;
        private System.Windows.Forms.DateTimePicker txtDataCadastro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dgvContatos;
        private System.Windows.Forms.TextBox txtCodigoContato;
        private System.Windows.Forms.TextBox txtClienteContato;
        private System.Windows.Forms.TextBox txtTipoContato;
        private System.Windows.Forms.TextBox txtDadosContato;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}

