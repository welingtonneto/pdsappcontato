using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Wpf_Estudos.Forms
{
    /// <summary>
    /// Lógica interna para ListarContatos.xaml
    /// </summary>
    public partial class ListarContatos : Window
    {
        private MySqlConnection _conexao;

        public ListarContatos()
        {
            InitializeComponent();
            Conexao();
            Listar();
        }

        private void Conexao()
        {
            string conexaoString = "server=localhost;database=app_contato_db;user=root;password=root;port=3360;";
            _conexao = new MySqlConnection(conexaoString);

            _conexao.Open();
        }

        private void Listar()
        {
            string sql = "SELECT * FROM contato;";

            var comando = new MySqlCommand(sql, _conexao);
            var reader  = comando.ExecuteReader();
            var lista = new List<Object>();

            while (reader.Read())
            {

                var contato = new
                {
                    Nome = reader.GetString(1),
                    DataNascimento = reader.GetDateTime(2),
                    Sexo = reader.GetString(3),
                    Email = reader.GetString(4),
                    Telefone = reader.GetString(5)
                };
                lista.Add(contato);
            }
            dataGrid.ItemsSource = lista;


            //dgvContatos.DataSource = dataTable;

        }
    }
}
