using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Biblioteca
{
    public class DataAccess : IDisposable
    {
        private readonly SqlConnection conexaoSql;


        /// <summary>
        /// Construtor da classe.
        /// </summary>
        public DataAccess()
        {
            try
            {
                //AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", Application.StartupPath + @"temp\Tim.config");
                var conexao = ConfigurationManager.ConnectionStrings["QbinConnection"].ConnectionString;
                conexaoSql = new SqlConnection(conexao);
                conexaoSql.Open();
                //MessageBox.Show("Consegui!");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }

        }

        /// <summary>
        /// Este método é usado para  executar commandos do sql como : Insert,Update e Delete.
        /// </summary>
        /// <param name="sqlQuery">O comando sql a ser executado.</param>
        public void ExecutarComando(string sqlQuery)
        {
            try
            {
                var comando = new SqlCommand
                {
                    CommandText = sqlQuery,
                    CommandType = CommandType.Text,
                    Connection = conexaoSql
                };

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());

            }

        }

        /// <summary>
        /// Este método é usado para  executar commandos sql de letura de dados como : Select.
        /// </summary>
        /// <param name="sqlQuery">O comando sql a ser executado.</param>
        /// <returns>Retorna uma DataReader.</returns>
        public SqlDataReader ExecutarComandoReader(string sqlQuery)
        {
            try
            {
                var comando = new SqlCommand
                {
                    CommandText = sqlQuery,
                    CommandType = CommandType.Text,
                    Connection = conexaoSql
                };

                return comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
                return null;
            }

        }

        /// <summary>
        /// Este método é usado para  executar commandos sql que retorna apenas um valor como : Select.
        /// </summary>
        /// <param name="sqlQuery">O comando sql a ser executado.</param>
        /// <returns>Retorna um valor de tipo string.</returns>
        public string ExecutarComandoEscalar(string sqlQuery)
        {
            try
            {
                var comando = new SqlCommand
                {
                    CommandText = sqlQuery,
                    CommandType = CommandType.Text,
                    Connection = conexaoSql
                };

                var valor = comando.ExecuteScalar();

                return valor.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
                return null;
            }

        }

        /// <summary>
        /// Este método é usado para  executar commandos sql que retorna uma DataTable como : Select, select...Inner join.
        /// </summary>
        /// <param name="sqlQuery">O comando sql a ser executado.</param>
        /// <returns>Retorna uma DataTable.</returns>
        public DataTable ExecutarComandoAdapter(string sqlQuery)
        {
            try
            {
                var comando = new SqlCommand(sqlQuery, conexaoSql);
                var adaptador = new SqlDataAdapter(comando);
                var dados = new DataTable();

                adaptador.Fill(dados);

                return dados;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
                return null;
            }

        }

        /// <summary>
        /// Metodo que finaliza a conexão depois de fechar a classe.
        /// </summary>
        public void Dispose()
        {
            try
            {
                if (conexaoSql.State == ConnectionState.Open)
                    conexaoSql.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
