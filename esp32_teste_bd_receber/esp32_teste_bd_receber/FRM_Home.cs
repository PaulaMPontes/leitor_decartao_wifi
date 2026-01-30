    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;

namespace esp32_teste_bd_receber
{
    public partial class FRM_Home : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        private bool conectado = false;
        private StreamReader reader; // variável da classe



        public FRM_Home()
        {
            InitializeComponent();
        }

        private void FRM_Home_Load(object sender, EventArgs e)
        {

        }

        private void btn_consulta_Click(object sender, EventArgs e)
        {

        }

        private void lbl_contadorpontos_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void lbl_contadorvalido_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_conectar_Click(object sender, EventArgs e)
        {
        }
        /*  Função aguarda_receber_dados()
*  Aguarda é retorno da mensagem até o tempo configurado no textBoxTempo 
*/

        private void aguarda_receber_dados()
        {
            // Cria o Stopwatch para medir o tempo de resposta
            Stopwatch sw = new Stopwatch();
            sw.Start();

            try
            {
                // Se o reader ainda não foi inicializado, cria usando a stream
                if (reader == null)
                    reader = new StreamReader(stream, Encoding.ASCII);

                while (true)
                {
                    // Só tenta ler se houver dados disponíveis
                    if (!stream.DataAvailable)
                    {
                        Thread.Sleep(10); // evita travar a CPU
                        continue;
                    }

                    string msg = reader.ReadLine()?.Trim();
                    if (string.IsNullOrEmpty(msg)) continue;

                    sw.Stop(); // para o cronômetro
                    string hora = DateTime.Now.ToString("HH:mm:ss");

                    // Ping respondido
                    if (msg == "pong")
                    {
                        Invoke(new Action(() =>
                            txt_receber.Text += $"[{hora}] Ping respondido em {sw.ElapsedMilliseconds} ms" + Environment.NewLine
                        ));
                    }

                    // UID recebido
                    else if (msg.StartsWith("UID:"))
                    {
                        Invoke(new Action(() => atualiza_textBoxRecebido(sw.ElapsedMilliseconds, msg)));
                    }

                    sw.Restart(); // reinicia para a próxima leitura
                }
            }
            catch (Exception ex)
            {
                sw.Stop();
                Invoke(new Action(() => txt_receber.Text += $"Erro: {ex.Message} em {sw.ElapsedMilliseconds} ms" + Environment.NewLine));
            }

        }


        /*  Função atualiza_textBoxRecebido()
         *  Altera o conteúdo do textBoxRecebido.
         *  Recebe como parâmentro o tempo de retorno em ms
         */
        private void atualiza_textBoxRecebido(long tempo, string recebido)
            {
            string hora = DateTime.Now.ToString("HH:mm:ss");
            string dia = DateTime.Now.ToString("yyyy-MM-dd");

            txt_receber.Text += $"[{hora}] Tempo: {tempo} ms - {recebido}" + Environment.NewLine;

            string uid = recebido.Substring(4).Trim(); // remove "UID:" e espaços

            Class_Contador_Home cch = new Class_Contador_Home
            {
                IdCartao_home = uid,
                Datadia_home = dia
            };

            try
            {
                cch.Status_home = "valido";
                cch.inserir_dado_cartao();
            }
            catch (Exception ex)
            {
                cch.Status_home = "invalido";
                try
                {
                    cch.inserir_dado_cartao();
                }
                catch (Exception bdEx)
                {
                    txt_receber.Invoke(new Action(() =>
                        txt_receber.Text += $"Erro BD: {bdEx.Message}" + Environment.NewLine));
                }
                txt_receber.Invoke(new Action(() =>
                    txt_receber.Text += $"Erro: {ex.Message}" + Environment.NewLine));
            }

            string cor = "red";
            int qtdHojeV = cch.contagem_registros_validos();

            if (qtdHojeV == 0) cor = "red";
            else if (qtdHojeV > 0 && qtdHojeV <= 2) cor = "green";
            else if (qtdHojeV > 3 && qtdHojeV <= 8) cor = "blue";
            else if (qtdHojeV > 9 && qtdHojeV <= 34) cor = "roxo";

            if (conectado)
            {
                try
                {
                    byte[] buffer = Encoding.ASCII.GetBytes(cor + "\n");
                    stream.Write(buffer, 0, buffer.Length);
                }
                catch (Exception ex)
                {
                    txt_receber.Invoke(new Action(() =>
                        txt_receber.Text += $"Erro enviando cor: {ex.Message}" + Environment.NewLine));
                }
            }
        }
            
            /*  Evento buttonEnviar_Click()
    *  Controla a ação de enviar dados. 
    */

            private void buttonLimpar_Click(object sender, EventArgs e)
            {
            }

            private void FRM_Home_FormClosing(object sender, FormClosingEventArgs e)
            {
                if (client != null)
                    if (client.Connected)
                        client.Close();
            }

            private void btn_conectar_Click_1(object sender, EventArgs e)
            {
                if (!conectado)
                {
                    // Só tenta conectar se o campo com o IP de conexão não for nulo.
                    if (!string.IsNullOrEmpty(txt_ip.Text))
                    {
                        // Configura botões, campos ...
                        client = new TcpClient();
                        txt_ip.Enabled = false;
                        textBoxTempo.Enabled = false;
                        btn_conectar.Enabled = false;
                        lbl_statuspontos.Text = "Conectando";
                        string[] strCon = txt_ip.Text.Split(':');            // Separa a string em IP e porta
                   
                        Stopwatch sw = new Stopwatch();
                        sw.Start();

                        try
                        {
                            client.Connect(strCon[0], Convert.ToInt32(strCon[1]));  // Conecta
                            sw.Stop();

                        // Se conectar
                        if (client.Connected)
                        {
                            stream = client.GetStream();
                            reader = new StreamReader(stream, Encoding.ASCII);
                            btn_conectar.Enabled = true;
                            lbl_statuspontos.Text = "Conectado";
                            conectado = true;

                            string hora = DateTime.Now.ToString("HH:mm:ss");
                            txt_receber.Text += "[" + hora + "] Conectado em " + sw.ElapsedMilliseconds + " ms" + Environment.NewLine;
                            Task.Run(() => aguarda_receber_dados());  // começa a ouvir mensagens do ESP32

                            }
                            // Se não conectar, avisa e reconfigura botões e campos.
                            else
                        {
                            btn_conectar.Enabled = true;
                            lbl_statuspontos.Text = "Desconectado";
                            textBoxTempo.Enabled = true;
                            txt_receber.Text = "Erro ao conectar.";
                            client.Close();
                            client = null;
                        }
                        }
                        catch(Exception ex)
                        {
                            sw.Stop();
                            lbl_statuspontos.Text = "Erro";
                            txt_receber.Text += "Falha ao conectar (" + ex.Message + ") em " + sw.ElapsedMilliseconds + " ms" + Environment.NewLine;
                        }

                    }
                }
                // Se não, desconecta
                else
                {
                    btn_conectar.Enabled = false;
                    lbl_statuspontos.Text = "Desconectando";
                    client.Close();
                    stream.Close();
                    client = null;
                    stream = null;
                    txt_ip.Enabled = true;
                    btn_conectar.Enabled = true;
                    textBoxTempo.Enabled = true;
                    lbl_statuspontos.Text = "Conectar";
                    conectado = false;
                }
            }

        private void btn_consulta_Click_1(object sender, EventArgs e)
        {
            Class_Contador_Home cch = new Class_Contador_Home();

            //acho q variavel tem q criar pra pegar o result

            string data = mtxt_data.Text.Replace("-", " ").Trim();

            //acho q variavel tem q criar pra pegar o result
            if (string.IsNullOrEmpty(data))
            {
                dgv_lista_rgt.DataSource = cch.consulta_teste_geral();
                dgv_lista_rgt.Columns["id_cont"].HeaderText = "ID";
                dgv_lista_rgt.Columns["cartao_id_cont"].HeaderText = "UID do Cartão";
                dgv_lista_rgt.Columns["data_cont"].HeaderText = "Data/Hora";
                dgv_lista_rgt.Columns["status_cont"].HeaderText = "Status";

                int qtdHojeGTo = cch.contagem_registros_geral_total();

                lbl_geral_total.Text = qtdHojeGTo.ToString();
                lbl_geral_total.Visible = true;
            }
            else
            {
                cch.Datadia_home = mtxt_data.Text;
                dgv_lista_rgt.DataSource = cch.consulta_por_dia();

                int qtdHojeV = cch.contagem_registros_validos();
                int qtdHojeI = cch.contagem_registros_invalidos();
                int qtdHojeG = cch.contagem_registros_geral();
              
                //duplicado pra atualiza conforme as duas consultas
                int qtdHojeGTo = cch.contagem_registros_geral_total();

                lbl_geral_total.Text = qtdHojeGTo.ToString();
                lbl_geral_total.Visible = true;

                // Mostra no Label
                lbl_contadorvalido.Text = qtdHojeV.ToString();
                lbl_contadorvalido.Visible = true;

                lbl_contadorinvalido.Text = qtdHojeI.ToString();
                lbl_contadorinvalido.Visible = true;

                lbl_contadorgeral.Text = qtdHojeG.ToString();
                lbl_contadorgeral.Visible = true;

            

                // Só envia se estiver conectado
                if (conectado)
                {
                    //encoding,converte texto p byte e vissversa;ascii, codificacao q usa 1byte por char;getbyte, converte string pra byte; yte[] é um tipo de variavel, pode ser declarado previamente 
                    byte[] buffer = Encoding.ASCII.GetBytes("ping\n");
                    stream.Write(buffer, 0, buffer.Length);

                    // Abre a função que aguarda o recebimento da mensagem em outra thread.
                    Task.Run(() => aguarda_receber_dados());
                }
            }
        }
            private void buttonLimpar_Click_1(object sender, EventArgs e)
            {
                txt_receber.Clear();

            }

            private void button1_Click_1(object sender, EventArgs e)
            {
                            Close();

            }

        private void lbl_geral_total_Click(object sender, EventArgs e)
        {

        }
    }

    }

