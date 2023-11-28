using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; //add a biblioteca se nao n funfa

namespace pergunta_e_resposta
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // uma string para conectar no banco xampp

        string conexaoString = "server=localhost;user=root;password=;database=Pergunta_Resposta;";

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            //criando variaveis

            string pergunta = "";
            string alternativa_a = "", alternativa_b = "", alternativa_c = "", alternativa_d = "";

            long ultimoID = 0;

            //dando valores

            pergunta = rtxPergunta.Text;

            alternativa_a = txbAlternativaA.Text;
            alternativa_b = txbAlternativaB.Text;
            alternativa_c = txbAlternativaC.Text;
            alternativa_d = txbAlternativaD.Text;

            using (MySqlConnection conexao = new MySqlConnection(conexaoString)) //conectando o comando smp sera assim
            {
                conexao.Open();

                string scriptinsert = "INSERT INTO Perguntas (Nome, Pergunta, Acertos, Tipo) VALUE (@Nome, @Pergunta, @Tipo)"; //comando do xampp inserir ddos na tabela

                using (MySqlCommand comando = new MySqlCommand(scriptinsert, conexao)) // comando
                {
                    comando.Parameters.AddWithValue("@Nome", "Gui"); //@pergunta eh o nome da tabela e a segunda "" eh o texto que vou inserir
            
                    comando.Parameters.AddWithValue("@Pergunta", pergunta);

                    comando.Parameters.AddWithValue("@Tipo", "c.gerais");

                    comando.ExecuteNonQuery();

                     ultimoID = comando.LastInsertedId;

                }

                string scriptinsertalternativa = "INSERT INTO alternativas (alternativa_a, alternativa_b, ALTERNATIVA_C, alternativa_d, ID_pergunta) VALUE (@alternativa_a, @alternativa_b, @ALTERNATIVA_C, @alternativa_d, @ID_pergunta)";

                using (MySqlCommand comando = new MySqlCommand(scriptinsertalternativa, conexao))
                {
                    comando.Parameters.AddWithValue("@alternativa_a", alternativa_a);

                    comando.Parameters.AddWithValue("@alternativa_b", alternativa_b);

                    comando.Parameters.AddWithValue("@ALTERNATIVA_C", alternativa_c);

                    comando.Parameters.AddWithValue("@alternativa_d", alternativa_d);

                    comando.Parameters.AddWithValue("@ID_pergunta", ultimoID);


                    comando.ExecuteNonQuery();


                    
                }



            }











            MessageBox.Show("Mensagem cadastrada com sucesso <3" + ultimoID.ToString());
        }
    }
}
