namespace CamPabuc.UI
{
    partial class ShoeDetailForm
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
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nmrSize = new System.Windows.Forms.NumericUpDown();
            this.cmbGenre = new System.Windows.Forms.ComboBox();
            this.txtQualityCode = new System.Windows.Forms.TextBox();
            this.txtDetails = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nmrQuantity = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbManufacturer = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbColor = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbMaterial = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblShoeBarcode = new System.Windows.Forms.Label();
            this.nmrPrice = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.nmrSalePrice = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.btnGenerateBarcode = new System.Windows.Forms.Button();
            this.btnAddManufacturer = new System.Windows.Forms.Button();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.btnAddMaterial = new System.Windows.Forms.Button();
            this.btnAddColor = new System.Windows.Forms.Button();
            this.cbSetStock = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nmrSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrSalePrice)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(454, 381);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 17;
            this.btnClear.Text = "Temizle";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(373, 381);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Kaydet";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cins:";
            // 
            // nmrSize
            // 
            this.nmrSize.Location = new System.Drawing.Point(353, 65);
            this.nmrSize.Name = "nmrSize";
            this.nmrSize.Size = new System.Drawing.Size(112, 23);
            this.nmrSize.TabIndex = 10;
            // 
            // cmbGenre
            // 
            this.cmbGenre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGenre.FormattingEnabled = true;
            this.cmbGenre.Items.AddRange(new object[] {
            "Zenne",
            "Merdane"});
            this.cmbGenre.Location = new System.Drawing.Point(88, 35);
            this.cmbGenre.Name = "cmbGenre";
            this.cmbGenre.Size = new System.Drawing.Size(135, 23);
            this.cmbGenre.TabIndex = 0;
            // 
            // txtQualityCode
            // 
            this.txtQualityCode.Location = new System.Drawing.Point(88, 93);
            this.txtQualityCode.Name = "txtQualityCode";
            this.txtQualityCode.Size = new System.Drawing.Size(135, 23);
            this.txtQualityCode.TabIndex = 3;
            // 
            // txtDetails
            // 
            this.txtDetails.Location = new System.Drawing.Point(88, 183);
            this.txtDetails.Multiline = true;
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.Size = new System.Drawing.Size(441, 192);
            this.txtDetails.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Kalite Kodu:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(294, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Numara:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Detaylar:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(314, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Stok:";
            // 
            // nmrQuantity
            // 
            this.nmrQuantity.Location = new System.Drawing.Point(353, 94);
            this.nmrQuantity.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nmrQuantity.Name = "nmrQuantity";
            this.nmrQuantity.Size = new System.Drawing.Size(135, 23);
            this.nmrQuantity.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "Üretici:";
            // 
            // cmbManufacturer
            // 
            this.cmbManufacturer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbManufacturer.FormattingEnabled = true;
            this.cmbManufacturer.Items.AddRange(new object[] {
            "Zenne",
            "Merdane"});
            this.cmbManufacturer.Location = new System.Drawing.Point(88, 64);
            this.cmbManufacturer.Name = "cmbManufacturer";
            this.cmbManufacturer.Size = new System.Drawing.Size(135, 23);
            this.cmbManufacturer.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(311, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 15);
            this.label7.TabIndex = 1;
            this.label7.Text = "Renk:";
            // 
            // cmbColor
            // 
            this.cmbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColor.FormattingEnabled = true;
            this.cmbColor.Items.AddRange(new object[] {
            "Zenne",
            "Merdane"});
            this.cmbColor.Location = new System.Drawing.Point(353, 35);
            this.cmbColor.Name = "cmbColor";
            this.cmbColor.Size = new System.Drawing.Size(135, 23);
            this.cmbColor.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 15);
            this.label8.TabIndex = 1;
            this.label8.Text = "Kategori";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Items.AddRange(new object[] {
            "Zenne",
            "Merdane"});
            this.cmbCategory.Location = new System.Drawing.Point(88, 122);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(135, 23);
            this.cmbCategory.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(26, 154);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 15);
            this.label9.TabIndex = 1;
            this.label9.Text = "Materyal:";
            // 
            // cmbMaterial
            // 
            this.cmbMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaterial.FormattingEnabled = true;
            this.cmbMaterial.Items.AddRange(new object[] {
            "Zenne",
            "Merdane"});
            this.cmbMaterial.Location = new System.Drawing.Point(88, 151);
            this.cmbMaterial.Name = "cmbMaterial";
            this.cmbMaterial.Size = new System.Drawing.Size(135, 23);
            this.cmbMaterial.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(35, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 15);
            this.label10.TabIndex = 9;
            this.label10.Text = "Barkod:";
            // 
            // lblShoeBarcode
            // 
            this.lblShoeBarcode.AutoSize = true;
            this.lblShoeBarcode.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblShoeBarcode.Location = new System.Drawing.Point(88, 5);
            this.lblShoeBarcode.Name = "lblShoeBarcode";
            this.lblShoeBarcode.Size = new System.Drawing.Size(0, 20);
            this.lblShoeBarcode.TabIndex = 9;
            // 
            // nmrPrice
            // 
            this.nmrPrice.DecimalPlaces = 2;
            this.nmrPrice.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nmrPrice.Location = new System.Drawing.Point(353, 123);
            this.nmrPrice.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nmrPrice.Name = "nmrPrice";
            this.nmrPrice.Size = new System.Drawing.Size(135, 23);
            this.nmrPrice.TabIndex = 12;
            this.nmrPrice.ThousandsSeparator = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(287, 125);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 15);
            this.label12.TabIndex = 5;
            this.label12.Text = "Alış Fiyatı:";
            // 
            // nmrSalePrice
            // 
            this.nmrSalePrice.DecimalPlaces = 2;
            this.nmrSalePrice.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nmrSalePrice.Location = new System.Drawing.Point(353, 154);
            this.nmrSalePrice.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nmrSalePrice.Name = "nmrSalePrice";
            this.nmrSalePrice.Size = new System.Drawing.Size(135, 23);
            this.nmrSalePrice.TabIndex = 13;
            this.nmrSalePrice.ThousandsSeparator = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(282, 154);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 15);
            this.label13.TabIndex = 8;
            this.label13.Text = "Satış Fiyatı:";
            // 
            // btnGenerateBarcode
            // 
            this.btnGenerateBarcode.Location = new System.Drawing.Point(248, 381);
            this.btnGenerateBarcode.Name = "btnGenerateBarcode";
            this.btnGenerateBarcode.Size = new System.Drawing.Size(119, 23);
            this.btnGenerateBarcode.TabIndex = 16;
            this.btnGenerateBarcode.Text = "Barkod Oluştur";
            this.btnGenerateBarcode.UseVisualStyleBackColor = true;
            this.btnGenerateBarcode.Click += new System.EventHandler(this.btnGenerateBarcode_Click);
            // 
            // btnAddManufacturer
            // 
            this.btnAddManufacturer.Location = new System.Drawing.Point(229, 63);
            this.btnAddManufacturer.Name = "btnAddManufacturer";
            this.btnAddManufacturer.Size = new System.Drawing.Size(22, 23);
            this.btnAddManufacturer.TabIndex = 2;
            this.btnAddManufacturer.Text = "+";
            this.btnAddManufacturer.UseVisualStyleBackColor = true;
            this.btnAddManufacturer.Click += new System.EventHandler(this.btnAddManufacturer_Click);
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.Location = new System.Drawing.Point(229, 121);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(22, 23);
            this.btnAddCategory.TabIndex = 5;
            this.btnAddCategory.Text = "+";
            this.btnAddCategory.UseVisualStyleBackColor = true;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // btnAddMaterial
            // 
            this.btnAddMaterial.Location = new System.Drawing.Point(229, 150);
            this.btnAddMaterial.Name = "btnAddMaterial";
            this.btnAddMaterial.Size = new System.Drawing.Size(22, 23);
            this.btnAddMaterial.TabIndex = 7;
            this.btnAddMaterial.Text = "+";
            this.btnAddMaterial.UseVisualStyleBackColor = true;
            this.btnAddMaterial.Click += new System.EventHandler(this.btnAddMaterial_Click);
            // 
            // btnAddColor
            // 
            this.btnAddColor.Location = new System.Drawing.Point(494, 34);
            this.btnAddColor.Name = "btnAddColor";
            this.btnAddColor.Size = new System.Drawing.Size(22, 23);
            this.btnAddColor.TabIndex = 9;
            this.btnAddColor.Text = "+";
            this.btnAddColor.UseVisualStyleBackColor = true;
            this.btnAddColor.Click += new System.EventHandler(this.btnAddColor_Click);
            // 
            // cbSetStock
            // 
            this.cbSetStock.AutoSize = true;
            this.cbSetStock.Location = new System.Drawing.Point(472, 63);
            this.cbSetStock.Name = "cbSetStock";
            this.cbSetStock.Size = new System.Drawing.Size(57, 19);
            this.cbSetStock.TabIndex = 18;
            this.cbSetStock.Text = "Takım";
            this.cbSetStock.UseVisualStyleBackColor = true;
            this.cbSetStock.CheckedChanged += new System.EventHandler(this.cbSetStock_CheckedChanged);
            // 
            // ShoeDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(541, 412);
            this.Controls.Add(this.cbSetStock);
            this.Controls.Add(this.btnAddColor);
            this.Controls.Add(this.btnAddMaterial);
            this.Controls.Add(this.btnAddCategory);
            this.Controls.Add(this.btnAddManufacturer);
            this.Controls.Add(this.lblShoeBarcode);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nmrSalePrice);
            this.Controls.Add(this.nmrQuantity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDetails);
            this.Controls.Add(this.txtQualityCode);
            this.Controls.Add(this.cmbMaterial);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbColor);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbManufacturer);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbGenre);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nmrPrice);
            this.Controls.Add(this.nmrSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGenerateBarcode);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClear);
            this.MaximizeBox = false;
            this.Name = "ShoeDetailForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Yeni Ayakkabı";
            this.Load += new System.EventHandler(this.ShoeDetailForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nmrSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrSalePrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnClear;
        private Button btnSave;
        private Label label1;
        private NumericUpDown nmrSize;
        private ComboBox cmbGenre;
        private TextBox txtQualityCode;
        private TextBox txtDetails;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private NumericUpDown nmrQuantity;
        private Label label6;
        private ComboBox cmbManufacturer;
        private Label label7;
        private ComboBox cmbColor;
        private Label label8;
        private ComboBox cmbCategory;
        private Label label9;
        private ComboBox cmbMaterial;
        private Label label10;
        private Label lblShoeBarcode;
        private NumericUpDown nmrPrice;
        private Label label12;
        private NumericUpDown nmrSalePrice;
        private Label label13;
        private Button btnGenerateBarcode;
        private Button btnAddManufacturer;
        private Button btnAddCategory;
        private Button btnAddMaterial;
        private Button btnAddColor;
        private CheckBox cbSetStock;
    }
}