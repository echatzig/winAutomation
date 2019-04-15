namespace SoftSrv
{
    partial class Form1
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
            this.lblScripts = new System.Windows.Forms.ListBox();
            this.btnRunScript = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblClients = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.brnLoadScript = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblScripts
            // 
            this.lblScripts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScripts.FormattingEnabled = true;
            this.lblScripts.Location = new System.Drawing.Point(3, 34);
            this.lblScripts.Name = "lblScripts";
            this.lblScripts.Size = new System.Drawing.Size(1011, 329);
            this.lblScripts.TabIndex = 0;
            // 
            // btnRunScript
            // 
            this.btnRunScript.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunScript.Location = new System.Drawing.Point(867, 524);
            this.btnRunScript.Name = "btnRunScript";
            this.btnRunScript.Size = new System.Drawing.Size(148, 42);
            this.btnRunScript.TabIndex = 1;
            this.btnRunScript.Text = "Run Script";
            this.btnRunScript.UseVisualStyleBackColor = true;
            this.btnRunScript.Click += new System.EventHandler(this.btnRunScript_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-2, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = " Action Scripts";
            // 
            // lblClients
            // 
            this.lblClients.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClients.FormattingEnabled = true;
            this.lblClients.Location = new System.Drawing.Point(3, 406);
            this.lblClients.Name = "lblClients";
            this.lblClients.Size = new System.Drawing.Size(1012, 95);
            this.lblClients.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-1, 379);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Registered Clients";
            // 
            // brnLoadScript
            // 
            this.brnLoadScript.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.brnLoadScript.Location = new System.Drawing.Point(3, 524);
            this.brnLoadScript.Name = "brnLoadScript";
            this.brnLoadScript.Size = new System.Drawing.Size(148, 42);
            this.brnLoadScript.TabIndex = 7;
            this.brnLoadScript.Text = "Load Script";
            this.brnLoadScript.UseVisualStyleBackColor = true;
            this.brnLoadScript.Click += new System.EventHandler(this.brnLoadScript_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 570);
            this.Controls.Add(this.brnLoadScript);
            this.Controls.Add(this.lblClients);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRunScript);
            this.Controls.Add(this.lblScripts);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lblScripts;
        private System.Windows.Forms.Button btnRunScript;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lblClients;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button brnLoadScript;
    }
}

