namespace CamPabuc.UI
{
    partial class OptionDetailForm
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
            this.lblOptionName = new System.Windows.Forms.Label();
            this.txtOptionValue = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblOptionName
            // 
            this.lblOptionName.AutoSize = true;
            this.lblOptionName.Location = new System.Drawing.Point(6, 5);
            this.lblOptionName.Name = "lblOptionName";
            this.lblOptionName.Size = new System.Drawing.Size(38, 15);
            this.lblOptionName.TabIndex = 0;
            this.lblOptionName.Text = "label1";
            // 
            // txtOptionValue
            // 
            this.txtOptionValue.Location = new System.Drawing.Point(6, 23);
            this.txtOptionValue.Name = "txtOptionValue";
            this.txtOptionValue.Size = new System.Drawing.Size(257, 23);
            this.txtOptionValue.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(188, 52);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Kaydet";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // OptionDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 86);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtOptionValue);
            this.Controls.Add(this.lblOptionName);
            this.Name = "OptionDetailForm";
            this.Text = "OptionDetailForm";
            this.Load += new System.EventHandler(this.OptionDetailForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblOptionName;
        private TextBox txtOptionValue;
        private Button btnSave;
    }
}