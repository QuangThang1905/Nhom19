namespace Nhom19
{
    partial class MyCart
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.BOOKID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CATEGORY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AUTHOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCart
            // 
            this.dgvCart.BackgroundColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BOOKID,
            this.Product,
            this.NAME,
            this.CATEGORY,
            this.AUTHOR});
            this.dgvCart.Location = new System.Drawing.Point(81, 72);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.ReadOnly = true;
            this.dgvCart.Size = new System.Drawing.Size(642, 242);
            this.dgvCart.TabIndex = 71;
            this.dgvCart.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCart_CellContentClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightCoral;
            this.button1.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(81, 11);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 34);
            this.button1.TabIndex = 158;
            this.button1.Text = "<- Back";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.LightCoral;
            this.button3.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(575, 342);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(148, 34);
            this.button3.TabIndex = 160;
            this.button3.Text = "Check Out";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // BOOKID
            // 
            this.BOOKID.HeaderText = "Variation";
            this.BOOKID.Name = "BOOKID";
            this.BOOKID.ReadOnly = true;
            this.BOOKID.Width = 120;
            // 
            // Product
            // 
            this.Product.HeaderText = "Product";
            this.Product.Name = "Product";
            this.Product.ReadOnly = true;
            this.Product.Width = 200;
            // 
            // NAME
            // 
            this.NAME.HeaderText = "Color";
            this.NAME.Name = "NAME";
            this.NAME.ReadOnly = true;
            // 
            // CATEGORY
            // 
            this.CATEGORY.HeaderText = "Size";
            this.CATEGORY.Name = "CATEGORY";
            this.CATEGORY.ReadOnly = true;
            // 
            // AUTHOR
            // 
            this.AUTHOR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AUTHOR.HeaderText = "Quantity";
            this.AUTHOR.Name = "AUTHOR";
            this.AUTHOR.ReadOnly = true;
            // 
            // MyCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 404);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvCart);
            this.Name = "MyCart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyCart";
            this.Load += new System.EventHandler(this.MyCart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn BOOKID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn CATEGORY;
        private System.Windows.Forms.DataGridViewTextBoxColumn AUTHOR;
    }
}