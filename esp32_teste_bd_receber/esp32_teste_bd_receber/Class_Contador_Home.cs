using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esp32_teste_bd_receber
{
    internal class Class_Contador_Home:Conexao
    {
        private string idCartao_home;
        private string datadia_home;
        private string status_home;
        private int qtdHojeV;
        private int qtdHojeI;
        private int qtdHojeG;
        private int qtdHojeGTo;



        public string IdCartao_home { get => idCartao_home; set => idCartao_home = value; }
        public string Datadia_home { get => datadia_home; set => datadia_home = value; }
        public string Status_home { get => status_home; set => status_home = value; }
        public int QtdHojeV { get => qtdHojeV; set => qtdHojeV = value; }
        public int QtdHojeI { get => qtdHojeI; set => qtdHojeI = value; }
        public int QtdHojeG { get => qtdHojeG; set => qtdHojeG = value; }
        public int QtdHojeGTo { get => qtdHojeGTo; set => qtdHojeGTo = value; }

        public DataTable consulta_teste_geral()
        {
            this.abrirConexao();
            string mSQL = "SELECT * FROM controlador";

            MySqlCommand cmd = new MySqlCommand(mSQL, conectar);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);


            DataTable dt = new DataTable();
            da.Fill(dt);
          
            this.fecharConexao();
            return dt;
        }

        public int contagem_registros_validos()
        {
            this.abrirConexao();

            string sqlCount = "SELECT COUNT(*) FROM controlador WHERE DATE(data_cont) ='" + this.Datadia_home + "' AND status_cont = 'valido'";

            MySqlCommand cmd = new MySqlCommand(sqlCount, conectar);

            // Executa a query e guarda o resultado na propriedade da classe
            this.qtdHojeV = Convert.ToInt32(cmd.ExecuteScalar());

            this.fecharConexao();

            return this.qtdHojeV;
        }
        public int contagem_registros_invalidos()
        {
            this.abrirConexao();

            string sqlCount = "SELECT COUNT(*) FROM controlador WHERE DATE(data_cont) ='" + this.Datadia_home + "' AND status_cont = 'invalido'";


            MySqlCommand cmd = new MySqlCommand(sqlCount, conectar);

            // Executa a query e guarda o resultado na propriedade da classe
            this.qtdHojeI = Convert.ToInt32(cmd.ExecuteScalar());

            this.fecharConexao();

            return this.qtdHojeI;
        }
        public int contagem_registros_geral()
        {
            this.abrirConexao();

            string sqlCount = "SELECT COUNT(*) FROM controlador WHERE DATE(data_cont) = '" + this.Datadia_home + "'";

            MySqlCommand cmd = new MySqlCommand(sqlCount, conectar);

            // Executa a query e guarda o resultado na propriedade da classe
            this.QtdHojeG = Convert.ToInt32(cmd.ExecuteScalar());

            this.fecharConexao();

            return this.QtdHojeG;
        }
        public int contagem_registros_geral_total()
        {
            this.abrirConexao();

            string sqlCount = "SELECT COUNT(*) FROM controlador ";

            MySqlCommand cmd = new MySqlCommand(sqlCount, conectar);

            // Executa a query e guarda o resultado na propriedade da classe
            this.QtdHojeGTo = Convert.ToInt32(cmd.ExecuteScalar());

            this.fecharConexao();

            return this.QtdHojeGTo;
        }

        public void inserir_dado_cartao()
        {
            string sql = "INSERT INTO controlador(cartao_id_cont,status_cont) VALUES  ('" + this.idCartao_home + "' , '" + this.status_home + "')";
            if (abrirConexao() == true)

            {
                MySqlCommand cmd = new MySqlCommand(sql, conectar);
                cmd.ExecuteNonQuery();
                fecharConexao();
            }

        }

        public DataTable consulta_por_dia()
        {

            this.abrirConexao();
            string mSQL = "SELECT * FROM controlador WHERE DATE(data_cont) = '" + this.Datadia_home + "'";

            MySqlCommand cmd = new MySqlCommand(mSQL, conectar);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);


            DataTable dt = new DataTable();
            da.Fill(dt);

            this.fecharConexao();
            return dt;
        }


    }
}
    