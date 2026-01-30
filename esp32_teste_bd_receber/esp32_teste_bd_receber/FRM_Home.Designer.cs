namespace esp32_teste_bd_receber
{
    partial class FRM_Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_Home));
            this.textBoxTempo = new System.Windows.Forms.TextBox();
            this.buttonLimpar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_geral_total = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mtxt_data = new System.Windows.Forms.MaskedTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lbl_contadorpontos = new System.Windows.Forms.Label();
            this.lbl_contadorgeral = new System.Windows.Forms.Label();
            this.lbl_contadorinvalido = new System.Windows.Forms.Label();
            this.txt_receber = new System.Windows.Forms.TextBox();
            this.lbl_data = new System.Windows.Forms.Label();
            this.lbl_contadorvalido = new System.Windows.Forms.Label();
            this.txt_ip = new System.Windows.Forms.TextBox();
            this.dgv_lista_rgt = new System.Windows.Forms.DataGridView();
            this.lbl_statuspontos = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_status = new System.Windows.Forms.Label();
            this.lbl_contador = new System.Windows.Forms.Label();
            this.btn_conectar = new System.Windows.Forms.Button();
            this.btn_consulta = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_lista_rgt)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxTempo
            // 
            this.textBoxTempo.Location = new System.Drawing.Point(510, 445);
            this.textBoxTempo.Name = "textBoxTempo";
            this.textBoxTempo.Size = new System.Drawing.Size(111, 22);
            this.textBoxTempo.TabIndex = 71;
            this.textBoxTempo.Visible = false;
            // 
            // buttonLimpar
            // 
            this.buttonLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLimpar.Image = ((System.Drawing.Image)(resources.GetObject("buttonLimpar.Image")));
            this.buttonLimpar.Location = new System.Drawing.Point(159, 356);
            this.buttonLimpar.Name = "buttonLimpar";
            this.buttonLimpar.Size = new System.Drawing.Size(49, 36);
            this.buttonLimpar.TabIndex = 70;
            this.buttonLimpar.UseVisualStyleBackColor = true;
            this.buttonLimpar.Click += new System.EventHandler(this.buttonLimpar_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Eras Medium ITC", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 353);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 18);
            this.label5.TabIndex = 69;
            this.label5.Text = "Registrador ⇑";
            // 
            // lbl_geral_total
            // 
            this.lbl_geral_total.AutoSize = true;
            this.lbl_geral_total.Font = new System.Drawing.Font("Eras Medium ITC", 12F);
            this.lbl_geral_total.Location = new System.Drawing.Point(130, 407);
            this.lbl_geral_total.Name = "lbl_geral_total";
            this.lbl_geral_total.Size = new System.Drawing.Size(25, 23);
            this.lbl_geral_total.TabIndex = 68;
            this.lbl_geral_total.Text = "...";
            this.lbl_geral_total.Click += new System.EventHandler(this.lbl_geral_total_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Eras Medium ITC", 12F);
            this.label3.Location = new System.Drawing.Point(13, 407);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 23);
            this.label3.TabIndex = 67;
            this.label3.Text = "Total Geral:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Eras Medium ITC", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(147, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 15);
            this.label2.TabIndex = 66;
            this.label2.Text = "YYYY-MM-DD";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Eras Medium ITC", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 441);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(405, 15);
            this.label1.TabIndex = 65;
            this.label1.Text = "*Obs: os resultados em \"Contador\", se dão apenas pela data inserida.";
            // 
            // mtxt_data
            // 
            this.mtxt_data.Location = new System.Drawing.Point(150, 95);
            this.mtxt_data.Mask = "0000-00-00";
            this.mtxt_data.Name = "mtxt_data";
            this.mtxt_data.Size = new System.Drawing.Size(80, 22);
            this.mtxt_data.TabIndex = 64;
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(761, 407);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(57, 46);
            this.button1.TabIndex = 63;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // lbl_contadorpontos
            // 
            this.lbl_contadorpontos.AutoSize = true;
            this.lbl_contadorpontos.Font = new System.Drawing.Font("Eras Medium ITC", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_contadorpontos.Location = new System.Drawing.Point(110, 143);
            this.lbl_contadorpontos.Name = "lbl_contadorpontos";
            this.lbl_contadorpontos.Size = new System.Drawing.Size(149, 15);
            this.lbl_contadorpontos.TabIndex = 62;
            this.lbl_contadorpontos.Text = "Válido | Inválido | Geral";
            // 
            // lbl_contadorgeral
            // 
            this.lbl_contadorgeral.AutoSize = true;
            this.lbl_contadorgeral.Font = new System.Drawing.Font("Eras Medium ITC", 12F);
            this.lbl_contadorgeral.Location = new System.Drawing.Point(228, 168);
            this.lbl_contadorgeral.Name = "lbl_contadorgeral";
            this.lbl_contadorgeral.Size = new System.Drawing.Size(25, 23);
            this.lbl_contadorgeral.TabIndex = 61;
            this.lbl_contadorgeral.Text = "...";
            // 
            // lbl_contadorinvalido
            // 
            this.lbl_contadorinvalido.AutoSize = true;
            this.lbl_contadorinvalido.Font = new System.Drawing.Font("Eras Medium ITC", 12F);
            this.lbl_contadorinvalido.Location = new System.Drawing.Point(172, 168);
            this.lbl_contadorinvalido.Name = "lbl_contadorinvalido";
            this.lbl_contadorinvalido.Size = new System.Drawing.Size(25, 23);
            this.lbl_contadorinvalido.TabIndex = 60;
            this.lbl_contadorinvalido.Text = "...";
            // 
            // txt_receber
            // 
            this.txt_receber.Location = new System.Drawing.Point(13, 226);
            this.txt_receber.Multiline = true;
            this.txt_receber.Name = "txt_receber";
            this.txt_receber.Size = new System.Drawing.Size(336, 124);
            this.txt_receber.TabIndex = 59;
            // 
            // lbl_data
            // 
            this.lbl_data.AutoSize = true;
            this.lbl_data.Font = new System.Drawing.Font("Eras Medium ITC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_data.Location = new System.Drawing.Point(14, 95);
            this.lbl_data.Name = "lbl_data";
            this.lbl_data.Size = new System.Drawing.Size(130, 23);
            this.lbl_data.TabIndex = 58;
            this.lbl_data.Text = "Digite a data:";
            // 
            // lbl_contadorvalido
            // 
            this.lbl_contadorvalido.AutoSize = true;
            this.lbl_contadorvalido.Font = new System.Drawing.Font("Eras Medium ITC", 12F);
            this.lbl_contadorvalido.Location = new System.Drawing.Point(120, 168);
            this.lbl_contadorvalido.Name = "lbl_contadorvalido";
            this.lbl_contadorvalido.Size = new System.Drawing.Size(25, 23);
            this.lbl_contadorvalido.TabIndex = 57;
            this.lbl_contadorvalido.Text = "...";
            // 
            // txt_ip
            // 
            this.txt_ip.Location = new System.Drawing.Point(139, 9);
            this.txt_ip.Name = "txt_ip";
            this.txt_ip.Size = new System.Drawing.Size(111, 22);
            this.txt_ip.TabIndex = 56;
            // 
            // dgv_lista_rgt
            // 
            this.dgv_lista_rgt.AllowUserToAddRows = false;
            this.dgv_lista_rgt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_lista_rgt.Location = new System.Drawing.Point(400, 2);
            this.dgv_lista_rgt.Name = "dgv_lista_rgt";
            this.dgv_lista_rgt.RowHeadersVisible = false;
            this.dgv_lista_rgt.RowHeadersWidth = 51;
            this.dgv_lista_rgt.RowTemplate.Height = 24;
            this.dgv_lista_rgt.Size = new System.Drawing.Size(418, 348);
            this.dgv_lista_rgt.TabIndex = 55;
            // 
            // lbl_statuspontos
            // 
            this.lbl_statuspontos.AutoSize = true;
            this.lbl_statuspontos.Font = new System.Drawing.Font("Eras Medium ITC", 12F);
            this.lbl_statuspontos.Location = new System.Drawing.Point(82, 43);
            this.lbl_statuspontos.Name = "lbl_statuspontos";
            this.lbl_statuspontos.Size = new System.Drawing.Size(25, 23);
            this.lbl_statuspontos.TabIndex = 54;
            this.lbl_statuspontos.Text = "...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Eras Medium ITC", 12F);
            this.label4.Location = new System.Drawing.Point(14, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 23);
            this.label4.TabIndex = 53;
            this.label4.Text = "IP do ESP32:";
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.Font = new System.Drawing.Font("Eras Medium ITC", 12F);
            this.lbl_status.Location = new System.Drawing.Point(13, 43);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(68, 23);
            this.lbl_status.TabIndex = 52;
            this.lbl_status.Text = "Status:";
            // 
            // lbl_contador
            // 
            this.lbl_contador.AutoSize = true;
            this.lbl_contador.Font = new System.Drawing.Font("Eras Medium ITC", 12F);
            this.lbl_contador.Location = new System.Drawing.Point(14, 168);
            this.lbl_contador.Name = "lbl_contador";
            this.lbl_contador.Size = new System.Drawing.Size(100, 23);
            this.lbl_contador.TabIndex = 51;
            this.lbl_contador.Text = "Contador:";
            // 
            // btn_conectar
            // 
            this.btn_conectar.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_conectar.Image = ((System.Drawing.Image)(resources.GetObject("btn_conectar.Image")));
            this.btn_conectar.Location = new System.Drawing.Point(258, 2);
            this.btn_conectar.Name = "btn_conectar";
            this.btn_conectar.Size = new System.Drawing.Size(91, 36);
            this.btn_conectar.TabIndex = 50;
            this.btn_conectar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_conectar.UseVisualStyleBackColor = true;
            this.btn_conectar.Click += new System.EventHandler(this.btn_conectar_Click_1);
            // 
            // btn_consulta
            // 
            this.btn_consulta.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.btn_consulta.Image = ((System.Drawing.Image)(resources.GetObject("btn_consulta.Image")));
            this.btn_consulta.Location = new System.Drawing.Point(258, 85);
            this.btn_consulta.Name = "btn_consulta";
            this.btn_consulta.Size = new System.Drawing.Size(91, 41);
            this.btn_consulta.TabIndex = 49;
            this.btn_consulta.UseVisualStyleBackColor = true;
            this.btn_consulta.Click += new System.EventHandler(this.btn_consulta_Click_1);
            // 
            // FRM_Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 479);
            this.Controls.Add(this.textBoxTempo);
            this.Controls.Add(this.buttonLimpar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbl_geral_total);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mtxt_data);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbl_contadorpontos);
            this.Controls.Add(this.lbl_contadorgeral);
            this.Controls.Add(this.lbl_contadorinvalido);
            this.Controls.Add(this.txt_receber);
            this.Controls.Add(this.lbl_data);
            this.Controls.Add(this.lbl_contadorvalido);
            this.Controls.Add(this.txt_ip);
            this.Controls.Add(this.dgv_lista_rgt);
            this.Controls.Add(this.lbl_statuspontos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_status);
            this.Controls.Add(this.lbl_contador);
            this.Controls.Add(this.btn_conectar);
            this.Controls.Add(this.btn_consulta);
            this.Name = "FRM_Home";
            this.Text = "Interface Web";
            this.Load += new System.EventHandler(this.FRM_Home_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_lista_rgt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTempo;
        private System.Windows.Forms.Button buttonLimpar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_geral_total;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mtxt_data;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbl_contadorpontos;
        private System.Windows.Forms.Label lbl_contadorgeral;
        private System.Windows.Forms.Label lbl_contadorinvalido;
        private System.Windows.Forms.TextBox txt_receber;
        private System.Windows.Forms.Label lbl_data;
        private System.Windows.Forms.Label lbl_contadorvalido;
        private System.Windows.Forms.TextBox txt_ip;
        private System.Windows.Forms.DataGridView dgv_lista_rgt;
        private System.Windows.Forms.Label lbl_statuspontos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.Label lbl_contador;
        private System.Windows.Forms.Button btn_conectar;
        private System.Windows.Forms.Button btn_consulta;
    }
}