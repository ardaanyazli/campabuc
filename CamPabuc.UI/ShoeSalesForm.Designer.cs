namespace CamPabuc.UI
{
    partial class ShoeSalesForm
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
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.nmrQty = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lstSales = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSalesTotal = new System.Windows.Forms.Label();
            this.btnShowTRY = new System.Windows.Forms.Button();
            this.btnShowDollar = new System.Windows.Forms.Button();
            this.btnShowEuro = new System.Windows.Forms.Button();
            this.btnSale = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nmrQty)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(67, 27);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(167, 23);
            this.txtBarcode.TabIndex = 0;
            this.txtBarcode.TextChanged += new System.EventHandler(this.txtBarcode_TextChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(240, 27);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(66, 24);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Ekle";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // nmrQty
            // 
            this.nmrQty.Location = new System.Drawing.Point(6, 27);
            this.nmrQty.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmrQty.Name = "nmrQty";
            this.nmrQty.Size = new System.Drawing.Size(55, 23);
            this.nmrQty.TabIndex = 2;
            this.nmrQty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Barkod";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Miktar";
            // 
            // lstSales
            // 
            this.lstSales.Enabled = false;
            this.lstSales.FormattingEnabled = true;
            this.lstSales.ItemHeight = 15;
            this.lstSales.Location = new System.Drawing.Point(6, 61);
            this.lstSales.Name = "lstSales";
            this.lstSales.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstSales.Size = new System.Drawing.Size(228, 229);
            this.lstSales.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(243, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Toplam:";
            // 
            // lblSalesTotal
            // 
            this.lblSalesTotal.AutoSize = true;
            this.lblSalesTotal.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSalesTotal.Location = new System.Drawing.Point(247, 90);
            this.lblSalesTotal.Name = "lblSalesTotal";
            this.lblSalesTotal.Size = new System.Drawing.Size(172, 45);
            this.lblSalesTotal.TabIndex = 6;
            this.lblSalesTotal.Text = "99999,99 ₺";
            // 
            // btnShowTRY
            // 
            this.btnShowTRY.Location = new System.Drawing.Point(298, 57);
            this.btnShowTRY.Name = "btnShowTRY";
            this.btnShowTRY.Size = new System.Drawing.Size(26, 24);
            this.btnShowTRY.TabIndex = 1;
            this.btnShowTRY.Text = "₺";
            this.btnShowTRY.UseVisualStyleBackColor = true;
            this.btnShowTRY.Click += new System.EventHandler(this.btnShowTRY_Click);
            // 
            // btnShowDollar
            // 
            this.btnShowDollar.Location = new System.Drawing.Point(330, 58);
            this.btnShowDollar.Name = "btnShowDollar";
            this.btnShowDollar.Size = new System.Drawing.Size(26, 24);
            this.btnShowDollar.TabIndex = 1;
            this.btnShowDollar.Text = "$";
            this.btnShowDollar.UseVisualStyleBackColor = true;
            this.btnShowDollar.Click += new System.EventHandler(this.btnShowDollar_Click);
            // 
            // btnShowEuro
            // 
            this.btnShowEuro.Location = new System.Drawing.Point(362, 58);
            this.btnShowEuro.Name = "btnShowEuro";
            this.btnShowEuro.Size = new System.Drawing.Size(26, 24);
            this.btnShowEuro.TabIndex = 1;
            this.btnShowEuro.Text = "€";
            this.btnShowEuro.UseVisualStyleBackColor = true;
            this.btnShowEuro.Click += new System.EventHandler(this.btnShowEuro_Click);
            // 
            // btnSale
            // 
            this.btnSale.Location = new System.Drawing.Point(240, 266);
            this.btnSale.Name = "btnSale";
            this.btnSale.Size = new System.Drawing.Size(128, 24);
            this.btnSale.TabIndex = 1;
            this.btnSale.Text = "Satışı Tamamla";
            this.btnSale.UseVisualStyleBackColor = true;
            this.btnSale.Click += new System.EventHandler(this.btnSale_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(389, 266);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(128, 24);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "İptal Et";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // ShoeSalesForm
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 333);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblSalesTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstSales);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nmrQty);
            this.Controls.Add(this.btnShowEuro);
            this.Controls.Add(this.btnShowDollar);
            this.Controls.Add(this.btnShowTRY);
            this.Controls.Add(this.btnSale);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtBarcode);
            this.Name = "ShoeSalesForm";
            this.Text = "Satış";
            ((System.ComponentModel.ISupportInitialize)(this.nmrQty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtBarcode;
        private Button btnAdd;
        private NumericUpDown nmrQty;
        private Label label1;
        private Label label2;
        private ListBox lstSales;
        private Label label3;
        private Label lblSalesTotal;
        private Button btnShowTRY;
        private Button btnShowDollar;
        private Button btnShowEuro;
        private Button btnSale;
        private Button btnClear;
    }
}