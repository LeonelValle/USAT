namespace MWTrace_beta
{
    partial class Ensamble_Etiquetado
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ensamble_Etiquetado));
            this.label1 = new System.Windows.Forms.Label();
            this.txt_imei = new System.Windows.Forms.TextBox();
            this.txt_sim = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lbl_serial = new System.Windows.Forms.Label();
            this.lbl_imei = new System.Windows.Forms.Label();
            this.lbl_sim = new System.Windows.Forms.Label();
            this.txt_serial = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_serialnumber = new System.Windows.Forms.Label();
            this.lbl_numeroempleado = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_registrados = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_firmware = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_revision = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(279, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IMEI/MODEM NUMBER:";
            // 
            // txt_imei
            // 
            this.txt_imei.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_imei.Location = new System.Drawing.Point(413, 46);
            this.txt_imei.Name = "txt_imei";
            this.txt_imei.Size = new System.Drawing.Size(535, 20);
            this.txt_imei.TabIndex = 1;
            this.txt_imei.TextChanged += new System.EventHandler(this.Txt_imei_TextChanged_1);
            // 
            // txt_sim
            // 
            this.txt_sim.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_sim.Location = new System.Drawing.Point(413, 98);
            this.txt_sim.Name = "txt_sim";
            this.txt_sim.Size = new System.Drawing.Size(535, 20);
            this.txt_sim.TabIndex = 3;
            this.txt_sim.TextChanged += new System.EventHandler(this.Txt_sim_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(279, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "SIM NUMBER:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(245, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Work Order:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(610, 187);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 26);
            this.button1.TabIndex = 6;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            this.button1.Enter += new System.EventHandler(this.Button1_Enter);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(15, 219);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Size = new System.Drawing.Size(1204, 288);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.TabStop = false;
            this.dataGridView1.VirtualMode = true;
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            // 
            // lbl_serial
            // 
            this.lbl_serial.AutoSize = true;
            this.lbl_serial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_serial.ForeColor = System.Drawing.Color.Red;
            this.lbl_serial.Location = new System.Drawing.Point(316, 7);
            this.lbl_serial.Name = "lbl_serial";
            this.lbl_serial.Size = new System.Drawing.Size(61, 16);
            this.lbl_serial.TabIndex = 5;
            this.lbl_serial.Text = "SERIAL";
            // 
            // lbl_imei
            // 
            this.lbl_imei.AutoSize = true;
            this.lbl_imei.Location = new System.Drawing.Point(416, 30);
            this.lbl_imei.Name = "lbl_imei";
            this.lbl_imei.Size = new System.Drawing.Size(13, 13);
            this.lbl_imei.TabIndex = 8;
            this.lbl_imei.Text = "0";
            // 
            // lbl_sim
            // 
            this.lbl_sim.AutoSize = true;
            this.lbl_sim.Location = new System.Drawing.Point(416, 82);
            this.lbl_sim.Name = "lbl_sim";
            this.lbl_sim.Size = new System.Drawing.Size(13, 13);
            this.lbl_sim.TabIndex = 9;
            this.lbl_sim.Text = "0";
            // 
            // txt_serial
            // 
            this.txt_serial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_serial.Location = new System.Drawing.Point(413, 154);
            this.txt_serial.Name = "txt_serial";
            this.txt_serial.Size = new System.Drawing.Size(535, 20);
            this.txt_serial.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(279, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "SERIAL NUMBER:";
            // 
            // lbl_serialnumber
            // 
            this.lbl_serialnumber.AutoSize = true;
            this.lbl_serialnumber.Location = new System.Drawing.Point(416, 131);
            this.lbl_serialnumber.Name = "lbl_serialnumber";
            this.lbl_serialnumber.Size = new System.Drawing.Size(13, 13);
            this.lbl_serialnumber.TabIndex = 11;
            this.lbl_serialnumber.Text = "0";
            this.lbl_serialnumber.Visible = false;
            // 
            // lbl_numeroempleado
            // 
            this.lbl_numeroempleado.AutoSize = true;
            this.lbl_numeroempleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_numeroempleado.ForeColor = System.Drawing.Color.Red;
            this.lbl_numeroempleado.Location = new System.Drawing.Point(921, 8);
            this.lbl_numeroempleado.Name = "lbl_numeroempleado";
            this.lbl_numeroempleado.Size = new System.Drawing.Size(59, 16);
            this.lbl_numeroempleado.TabIndex = 13;
            this.lbl_numeroempleado.Text = "numero";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(845, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "No. Emplyee:";
            // 
            // lbl_registrados
            // 
            this.lbl_registrados.AutoSize = true;
            this.lbl_registrados.Location = new System.Drawing.Point(77, 200);
            this.lbl_registrados.Name = "lbl_registrados";
            this.lbl_registrados.Size = new System.Drawing.Size(13, 13);
            this.lbl_registrados.TabIndex = 14;
            this.lbl_registrados.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Records:";
            // 
            // lbl_firmware
            // 
            this.lbl_firmware.AutoSize = true;
            this.lbl_firmware.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_firmware.ForeColor = System.Drawing.Color.Red;
            this.lbl_firmware.Location = new System.Drawing.Point(86, 79);
            this.lbl_firmware.Name = "lbl_firmware";
            this.lbl_firmware.Size = new System.Drawing.Size(71, 16);
            this.lbl_firmware.TabIndex = 17;
            this.lbl_firmware.Text = "Firmware";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Firmware:";
            // 
            // lbl_revision
            // 
            this.lbl_revision.AutoSize = true;
            this.lbl_revision.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_revision.ForeColor = System.Drawing.Color.Red;
            this.lbl_revision.Location = new System.Drawing.Point(86, 43);
            this.lbl_revision.Name = "lbl_revision";
            this.lbl_revision.Size = new System.Drawing.Size(69, 16);
            this.lbl_revision.TabIndex = 19;
            this.lbl_revision.Text = "Revision";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(29, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Revision:";
            // 
            // Ensamble_Etiquetado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 510);
            this.Controls.Add(this.lbl_revision);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lbl_firmware);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbl_registrados);
            this.Controls.Add(this.lbl_numeroempleado);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbl_serialnumber);
            this.Controls.Add(this.txt_serial);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_sim);
            this.Controls.Add(this.lbl_imei);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbl_serial);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_sim);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_imei);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Ensamble_Etiquetado";
            this.Text = "Ensamble_Etiquetado";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Ensamble_Etiquetado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_imei;
        private System.Windows.Forms.TextBox txt_sim;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lbl_serial;
        private System.Windows.Forms.Label lbl_imei;
        private System.Windows.Forms.Label lbl_sim;
        private System.Windows.Forms.TextBox txt_serial;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_serialnumber;
        private System.Windows.Forms.Label lbl_numeroempleado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_registrados;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_firmware;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_revision;
        private System.Windows.Forms.Label label10;
    }
}