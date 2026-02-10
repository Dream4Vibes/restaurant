namespace RestaurantControls
{
    partial class ProductCard
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.picImage = new System.Windows.Forms.PictureBox();
            this.LblDescription = new System.Windows.Forms.Label();
            this.ChkSelect = new System.Windows.Forms.CheckBox();
            this.AddPortionButton = new System.Windows.Forms.Button();
            this.DeleteCardButton = new System.Windows.Forms.Button();
            this.ReducePortionButtom = new System.Windows.Forms.Button();
            this.lblPriceCard = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // picImage
            // 
            this.picImage.Location = new System.Drawing.Point(0, 0);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(133, 107);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImage.TabIndex = 0;
            this.picImage.TabStop = false;
            // 
            // LblDescription
            // 
            this.LblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblDescription.Location = new System.Drawing.Point(139, 41);
            this.LblDescription.Name = "LblDescription";
            this.LblDescription.Size = new System.Drawing.Size(195, 23);
            this.LblDescription.TabIndex = 1;
            this.LblDescription.Text = "label1";
            // 
            // ChkSelect
            // 
            this.ChkSelect.AutoSize = true;
            this.ChkSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChkSelect.Location = new System.Drawing.Point(139, 3);
            this.ChkSelect.Name = "ChkSelect";
            this.ChkSelect.Size = new System.Drawing.Size(82, 20);
            this.ChkSelect.TabIndex = 3;
            this.ChkSelect.Text = "Выбрать";
            this.ChkSelect.UseVisualStyleBackColor = true;
            // 
            // AddPortionButton
            // 
            this.AddPortionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddPortionButton.Location = new System.Drawing.Point(393, 67);
            this.AddPortionButton.Name = "AddPortionButton";
            this.AddPortionButton.Size = new System.Drawing.Size(24, 24);
            this.AddPortionButton.TabIndex = 4;
            this.AddPortionButton.Text = "+";
            this.AddPortionButton.UseVisualStyleBackColor = true;
            this.AddPortionButton.Click += new System.EventHandler(this.AddPortionButton_Click);
            // 
            // DeleteCardButton
            // 
            this.DeleteCardButton.Location = new System.Drawing.Point(445, 41);
            this.DeleteCardButton.Name = "DeleteCardButton";
            this.DeleteCardButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteCardButton.TabIndex = 5;
            this.DeleteCardButton.Text = "Удалить";
            this.DeleteCardButton.UseVisualStyleBackColor = true;
            this.DeleteCardButton.Click += new System.EventHandler(this.DeleteCardButton_Click);
            // 
            // ReducePortionButtom
            // 
            this.ReducePortionButtom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ReducePortionButtom.Location = new System.Drawing.Point(310, 67);
            this.ReducePortionButtom.Name = "ReducePortionButtom";
            this.ReducePortionButtom.Size = new System.Drawing.Size(24, 24);
            this.ReducePortionButtom.TabIndex = 6;
            this.ReducePortionButtom.Text = "-";
            this.ReducePortionButtom.UseVisualStyleBackColor = true;
            this.ReducePortionButtom.Click += new System.EventHandler(this.ReducePortionButtom_Click);
            // 
            // lblPriceCard
            // 
            this.lblPriceCard.AutoSize = true;
            this.lblPriceCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPriceCard.Location = new System.Drawing.Point(329, 39);
            this.lblPriceCard.Name = "lblPriceCard";
            this.lblPriceCard.Size = new System.Drawing.Size(70, 25);
            this.lblPriceCard.TabIndex = 8;
            this.lblPriceCard.Text = "label1";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblQuantity.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblQuantity.Location = new System.Drawing.Point(350, 64);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(24, 25);
            this.lblQuantity.TabIndex = 9;
            this.lblQuantity.Text = "1";
            // 
            // ProductCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblPriceCard);
            this.Controls.Add(this.ReducePortionButtom);
            this.Controls.Add(this.DeleteCardButton);
            this.Controls.Add(this.AddPortionButton);
            this.Controls.Add(this.ChkSelect);
            this.Controls.Add(this.LblDescription);
            this.Controls.Add(this.picImage);
            this.Name = "ProductCard";
            this.Size = new System.Drawing.Size(523, 110);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Label LblDescription;
        private System.Windows.Forms.CheckBox ChkSelect;
        private System.Windows.Forms.Button AddPortionButton;
        private System.Windows.Forms.Button DeleteCardButton;
        private System.Windows.Forms.Button ReducePortionButtom;
        private System.Windows.Forms.Label lblPriceCard;
        private System.Windows.Forms.Label lblQuantity;
    }
}
