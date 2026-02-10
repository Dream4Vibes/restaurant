using System;
using System.Windows.Forms;

namespace RestorauntClient 
{
    public partial class Check : Form
    {
        public Check()
        {
            InitializeComponent();
        }

        // Метод для передачи данных из главной формы
        public void SetReceiptText(string receiptContent)
        {
            rtbReceipt.Text = receiptContent;
        }

    

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}