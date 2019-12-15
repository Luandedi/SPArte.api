using MySql.Data.MySqlClient;
using System;

namespace SPArte.api.Entities
{
    public class Conexao
    {
        public string mErro = "";
        /*// local 
           string connectionStrings = "Server=localhost;Database=sparte;Uid=root;Pwd=#$%@#$$DF#E;Allow User Variables=True;Default Command Timeout=3600;"*/
        //azure O usuario e senha esta no email 
        private string connectionStrings = "Server=dbartesp.mysql.database.azure.com; Port=3306; Database=sparte; Uid=usuaio; Pwd=Senha; SslMode=Preferred;";

        public MySqlConnection conn;

        public Conexao()
        {
            GetConexao();
        }

        // Verifica se existe erro
        public Boolean ExisteErro()
        {
            if (mErro.Length > 0)
            {
                return true;
            }
            return false;
        }
       
        private void GetConexao()
        {
            try
            {
                this.conn = new MySqlConnection(connectionStrings);
            }
            catch (Exception erro)
            {
                this.mErro = erro.Message;
                this.conn = null;
            }
        }
        public Boolean OpenConexao()
        {
            Boolean _return = true;
            try
            {
                conn.Open();
            }
            catch (MySqlException erro)
            {
                this.mErro = erro.Message;
                _return = false;
            }

            return _return;
        }
        public void CloseConexao()
        {
            conn.Close();
            conn.Dispose();
        }

    }
}
