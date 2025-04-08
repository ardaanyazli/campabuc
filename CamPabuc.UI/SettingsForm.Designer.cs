namespace CamPabuc.UI
{
    partial class SettingsForm
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
            this.txtBarcodeWidth = new System.Windows.Forms.TextBox();
            this.txtBarcodeHeight = new System.Windows.Forms.TextBox();
            this.txtChildSizeRange = new System.Windows.Forms.TextBox();
            this.txtWomenSizeRange = new System.Windows.Forms.TextBox();
            this.txtMenSizeRange = new System.Windows.Forms.TextBox();
            this.txtDoubleQty = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnUpdateSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBarcodeWidth
            // 
            this.txtBarcodeWidth.Location = new System.Drawing.Point(58, 12);
            this.txtBarcodeWidth.Name = "txtBarcodeWidth";
            this.txtBarcodeWidth.Size = new System.Drawing.Size(100, 23);
            this.txtBarcodeWidth.TabIndex = 0;
            // 
            // txtBarcodeHeight
            // 
            this.txtBarcodeHeight.Location = new System.Drawing.Point(58, 43);
            this.txtBarcodeHeight.Name = "txtBarcodeHeight";
            this.txtBarcodeHeight.Size = new System.Drawing.Size(100, 23);
            this.txtBarcodeHeight.TabIndex = 1;
            // 
            // txtChildSizeRange
            // 
            this.txtChildSizeRange.Location = new System.Drawing.Point(58, 74);
            this.txtChildSizeRange.Name = "txtChildSizeRange";
            this.txtChildSizeRange.Size = new System.Drawing.Size(100, 23);
            this.txtChildSizeRange.TabIndex = 2;
            // 
            // txtWomenSizeRange
            // 
            this.txtWomenSizeRange.Location = new System.Drawing.Point(215, 12);
            this.txtWomenSizeRange.Name = "txtWomenSizeRange";
            this.txtWomenSizeRange.Size = new System.Drawing.Size(100, 23);
            this.txtWomenSizeRange.TabIndex = 3;
            // 
            // txtMenSizeRange
            // 
            this.txtMenSizeRange.Location = new System.Drawing.Point(215, 44);
            this.txtMenSizeRange.Name = "txtMenSizeRange";
            this.txtMenSizeRange.Size = new System.Drawing.Size(100, 23);
            this.txtMenSizeRange.TabIndex = 2;
            // 
            // txtDoubleQty
            // 
            this.txtDoubleQty.Location = new System.Drawing.Point(215, 75);
            this.txtDoubleQty.Name = "txtDoubleQty";
            this.txtDoubleQty.Size = new System.Drawing.Size(100, 23);
            this.txtDoubleQty.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "label1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "label1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(171, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "label1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(171, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "label1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(171, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 15);
            this.label6.TabIndex = 4;
            this.label6.Text = "label1";
            // 
            // btnUpdateSettings
            // 
            this.btnUpdateSettings.Location = new System.Drawing.Point(171, 104);
            this.btnUpdateSettings.Name = "btnUpdateSettings";
            this.btnUpdateSettings.Size = new System.Drawing.Size(144, 23);
            this.btnUpdateSettings.TabIndex = 5;
            this.btnUpdateSettings.Text = "Ayarları Güncelle";
            this.btnUpdateSettings.UseVisualStyleBackColor = true;
            this.btnUpdateSettings.Click += new System.EventHandler(this.btnUpdateSettings_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 136);
            this.Controls.Add(this.btnUpdateSettings);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDoubleQty);
            this.Controls.Add(this.txtMenSizeRange);
            this.Controls.Add(this.txtWomenSizeRange);
            this.Controls.Add(this.txtChildSizeRange);
            this.Controls.Add(this.txtBarcodeHeight);
            this.Controls.Add(this.txtBarcodeWidth);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtBarcodeWidth;
        private TextBox txtBarcodeHeight;
        private TextBox txtChildSizeRange;
        private TextBox txtWomenSizeRange;
        private TextBox txtMenSizeRange;
        private TextBox txtDoubleQty;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button btnUpdateSettings;
    }
}