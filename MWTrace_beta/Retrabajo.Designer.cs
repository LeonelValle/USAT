namespace MWTrace_beta
{
    partial class Retrabajo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Retrabajo));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_Editar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_sacanmodem = new System.Windows.Forms.TextBox();
            this.txt_scansim = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_orden = new System.Windows.Forms.ComboBox();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_buscar = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_serial = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_scanmodem = new System.Windows.Forms.Label();
            this.lbl_scansim = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_problema = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(13, 267);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(875, 212);
            this.dataGridView1.TabIndex = 0;
            // 
            // btn_Editar
            // 
            this.btn_Editar.Location = new System.Drawing.Point(413, 238);
            this.btn_Editar.Name = "btn_Editar";
            this.btn_Editar.Size = new System.Drawing.Size(75, 23);
            this.btn_Editar.TabIndex = 1;
            this.btn_Editar.Text = "Editar";
            this.btn_Editar.UseVisualStyleBackColor = true;
            this.btn_Editar.Click += new System.EventHandler(this.Btn_Editar_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Filtro:";
            // 
            // txt_sacanmodem
            // 
            this.txt_sacanmodem.Location = new System.Drawing.Point(130, 163);
            this.txt_sacanmodem.Name = "txt_sacanmodem";
            this.txt_sacanmodem.Size = new System.Drawing.Size(298, 20);
            this.txt_sacanmodem.TabIndex = 4;
            this.txt_sacanmodem.TextChanged += new System.EventHandler(this.Txt_sacanmodem_TextChanged);
            // 
            // txt_scansim
            // 
            this.txt_scansim.Location = new System.Drawing.Point(130, 202);
            this.txt_scansim.Name = "txt_scansim";
            this.txt_scansim.Size = new System.Drawing.Size(298, 20);
            this.txt_scansim.TabIndex = 5;
            this.txt_scansim.TextChanged += new System.EventHandler(this.Txt_scansim_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "ScanModem:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "ScanSim:";
            // 
            // cb_orden
            // 
            this.cb_orden.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_orden.FormattingEnabled = true;
            this.cb_orden.Items.AddRange(new object[] {
            "Orden",
            "Serial Number",
            "Caja",
            "Pallette",
            "Scan Modem",
            "Scan Sim"});
            this.cb_orden.Location = new System.Drawing.Point(82, 13);
            this.cb_orden.Name = "cb_orden";
            this.cb_orden.Size = new System.Drawing.Size(298, 21);
            this.cb_orden.TabIndex = 8;
            // 
            // btn_buscar
            // 
            this.btn_buscar.Location = new System.Drawing.Point(178, 96);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(75, 23);
            this.btn_buscar.TabIndex = 9;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.Btn_buscar_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(403, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Buscar:";
            // 
            // txt_buscar
            // 
            this.txt_buscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_buscar.Location = new System.Drawing.Point(452, 14);
            this.txt_buscar.Name = "txt_buscar";
            this.txt_buscar.Size = new System.Drawing.Size(298, 20);
            this.txt_buscar.TabIndex = 10;
            this.txt_buscar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Txt_buscar_KeyUp);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Controls.Add(this.cb_orden);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_buscar);
            this.groupBox1.Controls.Add(this.txt_serial);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btn_buscar);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(54, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(795, 132);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Busqueda";
            // 
            // txt_serial
            // 
            this.txt_serial.Location = new System.Drawing.Point(82, 70);
            this.txt_serial.Name = "txt_serial";
            this.txt_serial.Size = new System.Drawing.Size(298, 20);
            this.txt_serial.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Serial Number:";
            // 
            // lbl_scanmodem
            // 
            this.lbl_scanmodem.AutoSize = true;
            this.lbl_scanmodem.Location = new System.Drawing.Point(127, 147);
            this.lbl_scanmodem.Name = "lbl_scanmodem";
            this.lbl_scanmodem.Size = new System.Drawing.Size(0, 13);
            this.lbl_scanmodem.TabIndex = 15;
            // 
            // lbl_scansim
            // 
            this.lbl_scansim.AutoSize = true;
            this.lbl_scansim.Location = new System.Drawing.Point(127, 186);
            this.lbl_scansim.Name = "lbl_scansim";
            this.lbl_scansim.Size = new System.Drawing.Size(0, 13);
            this.lbl_scansim.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(452, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Problema:";
            // 
            // txt_problema
            // 
            this.txt_problema.Location = new System.Drawing.Point(512, 163);
            this.txt_problema.Name = "txt_problema";
            this.txt_problema.Size = new System.Drawing.Size(298, 20);
            this.txt_problema.TabIndex = 17;
            // 
            // Retrabajo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 491);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_problema);
            this.Controls.Add(this.lbl_scansim);
            this.Controls.Add(this.lbl_scanmodem);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_scansim);
            this.Controls.Add(this.txt_sacanmodem);
            this.Controls.Add(this.btn_Editar);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Retrabajo";
            this.Text = "Retrabajo";
            this.Load += new System.EventHandler(this.Retrabajo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_Editar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_sacanmodem;
        private System.Windows.Forms.TextBox txt_scansim;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_orden;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_buscar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_serial;
        private System.Windows.Forms.Label lbl_scanmodem;
        private System.Windows.Forms.Label lbl_scansim;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_problema;
    }
}