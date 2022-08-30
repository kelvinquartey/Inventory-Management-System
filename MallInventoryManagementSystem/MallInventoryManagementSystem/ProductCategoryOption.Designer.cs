﻿namespace MallInventoryManagementSystem
{
    partial class ProductCategoryOption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductCategoryOption));
            this.labelClose = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonProducts = new System.Windows.Forms.Button();
            this.buttonCategories = new System.Windows.Forms.Button();
            this.labelInvent = new System.Windows.Forms.Label();
            this.pictureBoxShopriteLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShopriteLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // labelClose
            // 
            this.labelClose.AutoSize = true;
            this.labelClose.BackColor = System.Drawing.Color.DarkRed;
            this.labelClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClose.ForeColor = System.Drawing.Color.White;
            this.labelClose.Location = new System.Drawing.Point(392, -1);
            this.labelClose.Name = "labelClose";
            this.labelClose.Size = new System.Drawing.Size(34, 32);
            this.labelClose.TabIndex = 26;
            this.labelClose.Text = "X";
            this.labelClose.Click += new System.EventHandler(this.labelClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(235, 370);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 25);
            this.label2.TabIndex = 25;
            this.label2.Text = "PRODUCTS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 370);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 25);
            this.label1.TabIndex = 24;
            this.label1.Text = "CATEGORIES";
            // 
            // buttonProducts
            // 
            this.buttonProducts.Image = ((System.Drawing.Image)(resources.GetObject("buttonProducts.Image")));
            this.buttonProducts.Location = new System.Drawing.Point(240, 247);
            this.buttonProducts.Name = "buttonProducts";
            this.buttonProducts.Size = new System.Drawing.Size(119, 103);
            this.buttonProducts.TabIndex = 23;
            this.buttonProducts.UseVisualStyleBackColor = true;
            this.buttonProducts.Click += new System.EventHandler(this.buttonProducts_Click);
            // 
            // buttonCategories
            // 
            this.buttonCategories.Image = ((System.Drawing.Image)(resources.GetObject("buttonCategories.Image")));
            this.buttonCategories.Location = new System.Drawing.Point(60, 247);
            this.buttonCategories.Name = "buttonCategories";
            this.buttonCategories.Size = new System.Drawing.Size(119, 103);
            this.buttonCategories.TabIndex = 22;
            this.buttonCategories.UseVisualStyleBackColor = true;
            this.buttonCategories.Click += new System.EventHandler(this.buttonCategories_Click);
            // 
            // labelInvent
            // 
            this.labelInvent.AutoSize = true;
            this.labelInvent.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInvent.ForeColor = System.Drawing.Color.Red;
            this.labelInvent.Location = new System.Drawing.Point(19, 102);
            this.labelInvent.Name = "labelInvent";
            this.labelInvent.Size = new System.Drawing.Size(374, 29);
            this.labelInvent.TabIndex = 21;
            this.labelInvent.Text = "INVENTORY MANAGEMENT SYSTEM";
            // 
            // pictureBoxShopriteLogo
            // 
            this.pictureBoxShopriteLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBoxShopriteLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxShopriteLogo.Image")));
            this.pictureBoxShopriteLogo.Location = new System.Drawing.Point(161, 13);
            this.pictureBoxShopriteLogo.Name = "pictureBoxShopriteLogo";
            this.pictureBoxShopriteLogo.Size = new System.Drawing.Size(88, 86);
            this.pictureBoxShopriteLogo.TabIndex = 20;
            this.pictureBoxShopriteLogo.TabStop = false;
            // 
            // ProductCategoryOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 513);
            this.Controls.Add(this.labelClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonProducts);
            this.Controls.Add(this.buttonCategories);
            this.Controls.Add(this.labelInvent);
            this.Controls.Add(this.pictureBoxShopriteLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProductCategoryOption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProductCategoryOption";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShopriteLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonProducts;
        private System.Windows.Forms.Button buttonCategories;
        private System.Windows.Forms.Label labelInvent;
        private System.Windows.Forms.PictureBox pictureBoxShopriteLogo;
    }
}