using System;
using System.Collections.Generic;
using System.Linq;
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
using MySql.Data.MySqlClient;

namespace Wpf_Estudos.Forms
{
    /// <summary>
    /// Lógica interna para CadastrarContato.xaml
    /// </summary>
    public partial class CadastrarContato : Window
    {
        private MySqlConnection _conexao;
        private string sexoDado;
        public CadastrarContato()
        {
            InitializeComponent();
            Conexao();
        }

        private void Conexao()
        {
            string conexaoString = "server=localhost;database=app_contato_db;user=root;password=root;port=3360;";
            _conexao = new MySqlConnection(conexaoString);

            _conexao.Open();
        }

        public void limparEspacos()
        {
            tbNome.Clear();
            tbTelefone.Clear();
            tbEmail.Clear();
        }

        private void btCadastrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var nome = tbNome.Text;
                var sexo = sexoDado;
                var email = tbEmail.Text;
                var telefone = tbTelefone.Text;
                DateTime? dataNascimento = null;

                if (dtpNascimento.SelectedDate != null)
                {
                    dataNascimento = (DateTime) dtpNascimento.SelectedDate;
                }

                if (nome != "" && sexo != "" && email != "" && telefone != "" && dataNascimento != null)
                {
                    var sql = "INSERT INTO contato (nome_con, sexo_con, email_con, telefone_con, data_nasc_con) VALUES (@_nome, @_sexo, @_email, @_telefone, @_dataNasc);";
                    var cmd = new MySqlCommand(sql, _conexao); 

                    cmd.Parameters.AddWithValue("@_nome", nome);
                    cmd.Parameters.AddWithValue("@_sexo", sexo);
                    cmd.Parameters.AddWithValue("@_email", email);
                    cmd.Parameters.AddWithValue("@_telefone", telefone);
                    cmd.Parameters.AddWithValue("@_dataNasc", dataNascimento?.ToString("yyyy-MM-dd"));

                    cmd.ExecuteNonQuery();

                    limparEspacos();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            sexoDado = "Masculino";
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            limparEspacos();
        }
    }
}
