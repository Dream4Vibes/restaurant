namespace RestorauntClient
{
    partial class MainForm
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MenuPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.MenuLable = new System.Windows.Forms.Label();
            this.AdminToolStrip = new System.Windows.Forms.ToolStrip();
            this.AddFoodToDB = new System.Windows.Forms.ToolStripButton();
            this.DeleteFoodFromDB = new System.Windows.Forms.ToolStripButton();
            this.MenuGridView = new System.Windows.Forms.DataGridView();
            this.MainControl = new System.Windows.Forms.TabControl();
            this.MainPage = new System.Windows.Forms.TabPage();
            this.AddToCartButtom = new System.Windows.Forms.Button();
            this.DescriptionPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.DescriptionLable = new System.Windows.Forms.Label();
            this.DescriptionText = new System.Windows.Forms.TextBox();
            this.PictureDishes = new System.Windows.Forms.PictureBox();
            this.CartPage = new System.Windows.Forms.TabPage();
            this.TotalOrderAmountLabel = new System.Windows.Forms.Label();
            this.CartLable = new System.Windows.Forms.Label();
            this.PlaceAnOrder = new System.Windows.Forms.Button();
            this.DeleteFromCart = new System.Windows.Forms.Button();
            this.CartFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.MenuPanel.SuspendLayout();
            this.AdminToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MenuGridView)).BeginInit();
            this.MainControl.SuspendLayout();
            this.MainPage.SuspendLayout();
            this.DescriptionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureDishes)).BeginInit();
            this.CartPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuPanel
            // 
            this.MenuPanel.Controls.Add(this.MenuLable);
            this.MenuPanel.Controls.Add(this.AdminToolStrip);
            this.MenuPanel.Controls.Add(this.MenuGridView);
            this.MenuPanel.Location = new System.Drawing.Point(0, 3);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(445, 574);
            this.MenuPanel.TabIndex = 0;
            // 
            // MenuLable
            // 
            this.MenuLable.AutoSize = true;
            this.MenuLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MenuLable.Location = new System.Drawing.Point(3, 0);
            this.MenuLable.Name = "MenuLable";
            this.MenuLable.Size = new System.Drawing.Size(240, 25);
            this.MenuLable.TabIndex = 0;
            this.MenuLable.Text = "Меню доступных блюд";
            // 
            // AdminToolStrip
            // 
            this.AdminToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddFoodToDB,
            this.DeleteFoodFromDB});
            this.AdminToolStrip.Location = new System.Drawing.Point(246, 0);
            this.AdminToolStrip.Name = "AdminToolStrip";
            this.AdminToolStrip.Size = new System.Drawing.Size(58, 25);
            this.AdminToolStrip.TabIndex = 2;
            this.AdminToolStrip.Text = "toolStrip1";
            // 
            // AddFoodToDB
            // 
            this.AddFoodToDB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AddFoodToDB.Image = ((System.Drawing.Image)(resources.GetObject("AddFoodToDB.Image")));
            this.AddFoodToDB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddFoodToDB.Name = "AddFoodToDB";
            this.AddFoodToDB.Size = new System.Drawing.Size(23, 22);
            this.AddFoodToDB.Text = "+";
            this.AddFoodToDB.Click += new System.EventHandler(this.AddFoodToDB_Click);
            // 
            // DeleteFoodFromDB
            // 
            this.DeleteFoodFromDB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DeleteFoodFromDB.Image = ((System.Drawing.Image)(resources.GetObject("DeleteFoodFromDB.Image")));
            this.DeleteFoodFromDB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteFoodFromDB.Name = "DeleteFoodFromDB";
            this.DeleteFoodFromDB.Size = new System.Drawing.Size(23, 22);
            this.DeleteFoodFromDB.Text = "-";
            this.DeleteFoodFromDB.Click += new System.EventHandler(this.DeleteFoodFromDB_Click);
            // 
            // MenuGridView
            // 
            this.MenuGridView.BackgroundColor = System.Drawing.Color.Moccasin;
            this.MenuGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MenuGridView.Location = new System.Drawing.Point(3, 28);
            this.MenuGridView.Name = "MenuGridView";
            this.MenuGridView.Size = new System.Drawing.Size(442, 546);
            this.MenuGridView.TabIndex = 1;
            this.MenuGridView.SelectionChanged += new System.EventHandler(this.MenuGridView_SelectionChanged);
            // 
            // MainControl
            // 
            this.MainControl.Controls.Add(this.MainPage);
            this.MainControl.Controls.Add(this.CartPage);
            this.MainControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainControl.Location = new System.Drawing.Point(0, 0);
            this.MainControl.Name = "MainControl";
            this.MainControl.SelectedIndex = 0;
            this.MainControl.Size = new System.Drawing.Size(1134, 712);
            this.MainControl.TabIndex = 3;
            // 
            // MainPage
            // 
            this.MainPage.BackColor = System.Drawing.Color.LightGreen;
            this.MainPage.Controls.Add(this.AddToCartButtom);
            this.MainPage.Controls.Add(this.DescriptionPanel);
            this.MainPage.Controls.Add(this.MenuPanel);
            this.MainPage.Location = new System.Drawing.Point(4, 25);
            this.MainPage.Name = "MainPage";
            this.MainPage.Padding = new System.Windows.Forms.Padding(3);
            this.MainPage.Size = new System.Drawing.Size(1126, 683);
            this.MainPage.TabIndex = 0;
            this.MainPage.Text = "Главная";
            // 
            // AddToCartButtom
            // 
            this.AddToCartButtom.BackColor = System.Drawing.Color.Moccasin;
            this.AddToCartButtom.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddToCartButtom.Location = new System.Drawing.Point(864, 475);
            this.AddToCartButtom.Name = "AddToCartButtom";
            this.AddToCartButtom.Size = new System.Drawing.Size(221, 83);
            this.AddToCartButtom.TabIndex = 5;
            this.AddToCartButtom.Text = "Добавить в корзину";
            this.AddToCartButtom.UseVisualStyleBackColor = false;
            this.AddToCartButtom.Click += new System.EventHandler(this.AddToCartButtom_Click);
            // 
            // DescriptionPanel
            // 
            this.DescriptionPanel.Controls.Add(this.DescriptionLable);
            this.DescriptionPanel.Controls.Add(this.DescriptionText);
            this.DescriptionPanel.Controls.Add(this.PictureDishes);
            this.DescriptionPanel.Location = new System.Drawing.Point(451, 6);
            this.DescriptionPanel.Name = "DescriptionPanel";
            this.DescriptionPanel.Size = new System.Drawing.Size(634, 568);
            this.DescriptionPanel.TabIndex = 4;
            // 
            // DescriptionLable
            // 
            this.DescriptionLable.AutoSize = true;
            this.DescriptionLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DescriptionLable.Location = new System.Drawing.Point(3, 0);
            this.DescriptionLable.Name = "DescriptionLable";
            this.DescriptionLable.Size = new System.Drawing.Size(266, 25);
            this.DescriptionLable.TabIndex = 0;
            this.DescriptionLable.Text = "Краткое описание блюда";
            // 
            // DescriptionText
            // 
            this.DescriptionText.BackColor = System.Drawing.Color.Moccasin;
            this.DescriptionText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DescriptionText.Location = new System.Drawing.Point(3, 28);
            this.DescriptionText.Multiline = true;
            this.DescriptionText.Name = "DescriptionText";
            this.DescriptionText.Size = new System.Drawing.Size(631, 247);
            this.DescriptionText.TabIndex = 3;
            // 
            // PictureDishes
            // 
            this.PictureDishes.Location = new System.Drawing.Point(3, 281);
            this.PictureDishes.Name = "PictureDishes";
            this.PictureDishes.Size = new System.Drawing.Size(378, 271);
            this.PictureDishes.TabIndex = 4;
            this.PictureDishes.TabStop = false;
            // 
            // CartPage
            // 
            this.CartPage.BackColor = System.Drawing.Color.LightGreen;
            this.CartPage.Controls.Add(this.TotalOrderAmountLabel);
            this.CartPage.Controls.Add(this.CartLable);
            this.CartPage.Controls.Add(this.PlaceAnOrder);
            this.CartPage.Controls.Add(this.DeleteFromCart);
            this.CartPage.Controls.Add(this.CartFlowPanel);
            this.CartPage.Location = new System.Drawing.Point(4, 25);
            this.CartPage.Name = "CartPage";
            this.CartPage.Padding = new System.Windows.Forms.Padding(3);
            this.CartPage.Size = new System.Drawing.Size(1126, 683);
            this.CartPage.TabIndex = 1;
            this.CartPage.Text = "Корзина";
            // 
            // TotalOrderAmountLabel
            // 
            this.TotalOrderAmountLabel.AutoSize = true;
            this.TotalOrderAmountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TotalOrderAmountLabel.Location = new System.Drawing.Point(8, 552);
            this.TotalOrderAmountLabel.Name = "TotalOrderAmountLabel";
            this.TotalOrderAmountLabel.Size = new System.Drawing.Size(75, 25);
            this.TotalOrderAmountLabel.TabIndex = 2;
            this.TotalOrderAmountLabel.Text = "Итого:";
            // 
            // CartLable
            // 
            this.CartLable.AutoSize = true;
            this.CartLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CartLable.Location = new System.Drawing.Point(3, 0);
            this.CartLable.Name = "CartLable";
            this.CartLable.Size = new System.Drawing.Size(158, 25);
            this.CartLable.TabIndex = 1;
            this.CartLable.Text = "Ваша Корзина";
            // 
            // PlaceAnOrder
            // 
            this.PlaceAnOrder.BackColor = System.Drawing.Color.Moccasin;
            this.PlaceAnOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PlaceAnOrder.Location = new System.Drawing.Point(804, 458);
            this.PlaceAnOrder.Name = "PlaceAnOrder";
            this.PlaceAnOrder.Size = new System.Drawing.Size(254, 72);
            this.PlaceAnOrder.TabIndex = 2;
            this.PlaceAnOrder.Text = "Оформить заказ";
            this.PlaceAnOrder.UseVisualStyleBackColor = false;
            this.PlaceAnOrder.Click += new System.EventHandler(this.PlaceAnOrder_Click);
            // 
            // DeleteFromCart
            // 
            this.DeleteFromCart.BackColor = System.Drawing.Color.Moccasin;
            this.DeleteFromCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeleteFromCart.Location = new System.Drawing.Point(804, 380);
            this.DeleteFromCart.Name = "DeleteFromCart";
            this.DeleteFromCart.Size = new System.Drawing.Size(254, 72);
            this.DeleteFromCart.TabIndex = 1;
            this.DeleteFromCart.Text = "Удалить из корзины";
            this.DeleteFromCart.UseVisualStyleBackColor = false;
            this.DeleteFromCart.Click += new System.EventHandler(this.DeleteFromCart_Click);
            // 
            // CartFlowPanel
            // 
            this.CartFlowPanel.AutoScroll = true;
            this.CartFlowPanel.BackColor = System.Drawing.Color.Moccasin;
            this.CartFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.CartFlowPanel.Location = new System.Drawing.Point(3, 28);
            this.CartFlowPanel.Name = "CartFlowPanel";
            this.CartFlowPanel.Size = new System.Drawing.Size(748, 521);
            this.CartFlowPanel.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 611);
            this.Controls.Add(this.MainControl);
            this.Name = "MainForm";
            this.Text = "Клиент Ресторана";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MenuPanel.ResumeLayout(false);
            this.MenuPanel.PerformLayout();
            this.AdminToolStrip.ResumeLayout(false);
            this.AdminToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MenuGridView)).EndInit();
            this.MainControl.ResumeLayout(false);
            this.MainPage.ResumeLayout(false);
            this.DescriptionPanel.ResumeLayout(false);
            this.DescriptionPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureDishes)).EndInit();
            this.CartPage.ResumeLayout(false);
            this.CartPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel MenuPanel;
        private System.Windows.Forms.Label MenuLable;
        private System.Windows.Forms.DataGridView MenuGridView;
        private System.Windows.Forms.TabControl MainControl;
        private System.Windows.Forms.TabPage MainPage;
        private System.Windows.Forms.TextBox DescriptionText;
        private System.Windows.Forms.TabPage CartPage;
        private System.Windows.Forms.FlowLayoutPanel DescriptionPanel;
        private System.Windows.Forms.Label DescriptionLable;
        private System.Windows.Forms.Button AddToCartButtom;
        private System.Windows.Forms.PictureBox PictureDishes;
        private System.Windows.Forms.Label CartLable;
        private System.Windows.Forms.FlowLayoutPanel CartFlowPanel;
        private System.Windows.Forms.Button PlaceAnOrder;
        private System.Windows.Forms.Button DeleteFromCart;
        private System.Windows.Forms.Label TotalOrderAmountLabel;
        private System.Windows.Forms.ToolStrip AdminToolStrip;
        private System.Windows.Forms.ToolStripButton AddFoodToDB;
        private System.Windows.Forms.ToolStripButton DeleteFoodFromDB;
    }
}

