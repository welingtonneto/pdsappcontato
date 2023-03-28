using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppContatoForm
{
    public partial class ListarContato : Form
    {

        private MySqlConnection conexao;

        private MySqlCommand comando;
        public ListarContato()
        {
            InitializeComponent();

            Conexao();
            CarregarDados();
        }

        private void Conexao()
        {
            string conexaoString = "server=localhost;database=app_contato_bd;user=root;password=root;port=3360";
            conexao = new MySqlConnection(conexaoString);
            comando = conexao.CreateCommand();

            conexao.Open();
        }

        
        private void CarregarDados()
        {

            try
            {
                Conexao();
                string query = "Select * From contato_con";
                var comando = new MySqlCommand(query, conexao);
                var adaptador = new MySqlDataAdapter(comando);

                DataTable tabela = new DataTable();

                adaptador.Fill(tabela);
                dgvContato.DataSource = tabela;
            }
            catch (Exception ex)
            { MessageBox.Show("Ocorreram erros ao listar as informações!" + "Contrate a equipe de suporte o sitema. (cad 10)"); }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
