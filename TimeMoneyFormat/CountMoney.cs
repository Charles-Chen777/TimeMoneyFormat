using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeMoneyFormat
{
    public partial class CountMoney : Form
    {

        XmlOP XmlOperation = new XmlOP();
        public CountMoney()
        {
            InitializeComponent();
        }

        private void CountMoney_Load(object sender, EventArgs e)
        {
            int MonthPay = Convert.ToInt32(XmlOperation.GetMonthPay());
            int MonthWorkTime = Convert.ToInt32(XmlOperation.GetMonthWorkTime());
            int TotalSecond = Convert.ToInt32(XmlOperation.GetTotalSecond());
            double totalhour = TotalSecond / 60.0 / 60.0;
            double TransformMoney = (totalhour / MonthWorkTime) * MonthPay;
            this.label1.Text = "累计转换金钱：" + TransformMoney.ToString();
        }
    }
}
