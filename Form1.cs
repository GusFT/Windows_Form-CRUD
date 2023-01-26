using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PO0_exp_modeloprotrabalho
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btExibir_Click(object sender, EventArgs e)
        {
            ConexaoString stringconexao = new ConexaoString();
            string conexao = stringconexao.ConnString();

            NpgsqlConnection con = new NpgsqlConnection(conexao); // cria conexão com o banco
            con.Open(); // abre conexão com o banco

            DataTable dt = new DataTable(); // obj que pode conter tabelas

            string commandText = "SELECT * FROM cliente order by id_cliente";

            using (NpgsqlDataAdapter adapt = new NpgsqlDataAdapter(commandText, con)) // faz ligação em bd  e o datatable
            {
                adapt.Fill(dt);
            }

            dGV.DataSource = dt;

            con.Close(); // fecha a conexao com o banco

        }

        private void btInserir_Click(object sender, EventArgs e)
        {
            Pessoa objPessoa = new Pessoa(mtbCpf.Text, tbNome.Text, Convert.ToDouble(tbSalario.Text));

            ConexaoString stringconexao = new ConexaoString();
            string conexao = stringconexao.ConnString();

            NpgsqlConnection con = new NpgsqlConnection(conexao); // cria conexão com o banco
            con.Open(); // abre conexão com o banco


            string commandText = String.Format("INSERT INTO cliente(cpf_cliente, nome_cliente, salario_cliente, credito_cliente)" +
                                                "values('{0}','{1}',{2},{3})", objPessoa.Cpf, objPessoa.Nome, objPessoa.Salario, objPessoa.calcCredito());
            
            using (NpgsqlCommand pgsqlCommand = new NpgsqlCommand(commandText, con))
            {
                pgsqlCommand.ExecuteNonQuery();
            }

            con.Close();

            MessageBox.Show("Cadastro inserido com sucesso: ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimparTextBox();
        }
        
        
        public void LimparTextBox()
        {
            mtbCpf.Text = String.Empty;
            tbNome.Text = String.Empty;
            tbSalario.Text = String.Empty;

        }

        private void dGV_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            mtbCpf.Text = Convert.ToString(dGV.Rows[e.RowIndex].Cells[1].Value);
            tbNome.Text = Convert.ToString(dGV.Rows[e.RowIndex].Cells[2].Value);
            tbSalario.Text = Convert.ToString(dGV.Rows[e.RowIndex].Cells[3].Value);
        }

        private void btAtualizar_Click(object sender, EventArgs e)
        {
            Pessoa objPessoa = new Pessoa(mtbCpf.Text, tbNome.Text, Convert.ToDouble(tbSalario.Text));

            ConexaoString stringconexao = new ConexaoString();
            string conexao = stringconexao.ConnString();

            NpgsqlConnection con = new NpgsqlConnection(conexao); // cria conexão com o banco
            con.Open(); // abre conexão com o banco

            string cpf = mtbCpf.Text;
            string commandText = String.Format("UPDATE cliente SET cpf_cliente = '" + objPessoa.Cpf + "' , nome_cliente = '" +
                                                objPessoa.Nome + "' , salario_cliente = " + objPessoa.Salario + " , credito_cliente = " +
                                                objPessoa.calcCredito() + " where cpf_cliente = '" + cpf + "'");

            using (NpgsqlCommand pgsqlCommand = new NpgsqlCommand(commandText, con))
            {
                pgsqlCommand.ExecuteNonQuery();
            }

            con.Close();

            MessageBox.Show("Cadastro atualizado com sucesso: ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimparTextBox();
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {

            ConexaoString stringconexao = new ConexaoString();

            string conexao = stringconexao.ConnString();

            NpgsqlConnection con = new NpgsqlConnection(conexao); // cria conexão com o banco

            con.Open(); // abre conexão com o banco

            string cpf = mtbCpf.Text;

            string commandText = String.Format("DELETE FROM cliente where cpf_cliente = '{0}'", cpf);

                using (NpgsqlCommand pgsqlCommand = new NpgsqlCommand(commandText, con))
                {
                    pgsqlCommand.ExecuteNonQuery();
                }

            con.Close();

            MessageBox.Show("Cadastro excluido com sucesso: ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimparTextBox();
        }
    }
}

