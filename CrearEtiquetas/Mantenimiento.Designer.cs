namespace CrearEtiquetas
{
    partial class Mantenimiento
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
            this.label28 = new System.Windows.Forms.Label();
            this.cboServer = new System.Windows.Forms.ComboBox();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_connect = new System.Windows.Forms.Button();
            this.txt_user = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txt_localhost = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(56, 23);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(41, 13);
            this.label28.TabIndex = 23;
            this.label28.Text = "Server:";
            // 
            // cboServer
            // 
            this.cboServer.FormattingEnabled = true;
            this.cboServer.Location = new System.Drawing.Point(103, 15);
            this.cboServer.Name = "cboServer";
            this.cboServer.Size = new System.Drawing.Size(303, 21);
            this.cboServer.TabIndex = 14;
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(103, 129);
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '*';
            this.txt_password.Size = new System.Drawing.Size(303, 20);
            this.txt_password.TabIndex = 18;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(41, 136);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(56, 13);
            this.label27.TabIndex = 22;
            this.label27.Text = "Password:";
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(275, 181);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(102, 23);
            this.btn_cancel.TabIndex = 21;
            this.btn_cancel.Text = "Save";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.Btn_cancel_Click);
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(103, 181);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(110, 23);
            this.btn_connect.TabIndex = 20;
            this.btn_connect.Text = "Connect";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.Btn_connect_Click);
            // 
            // txt_user
            // 
            this.txt_user.Location = new System.Drawing.Point(103, 89);
            this.txt_user.Name = "txt_user";
            this.txt_user.Size = new System.Drawing.Size(303, 20);
            this.txt_user.TabIndex = 16;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(65, 96);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(32, 13);
            this.label26.TabIndex = 19;
            this.label26.Text = "User:";
            // 
            // txt_localhost
            // 
            this.txt_localhost.Location = new System.Drawing.Point(103, 55);
            this.txt_localhost.Name = "txt_localhost";
            this.txt_localhost.Size = new System.Drawing.Size(303, 20);
            this.txt_localhost.TabIndex = 15;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(41, 62);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Database:";
            // 
            // Mantenimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 219);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.cboServer);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.txt_user);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.txt_localhost);
            this.Controls.Add(this.label11);
            this.Name = "Mantenimiento";
            this.Text = "Mantenimiento";
            this.Load += new System.EventHandler(this.Mantenimiento_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ComboBox cboServer;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.TextBox txt_user;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txt_localhost;
        private System.Windows.Forms.Label label11;
    }
}