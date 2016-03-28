using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Configuration;

namespace TimeMoneyFormat
{
    public partial class TimeMoneyFormat : Form
    {
        XmlOP XmlOperation = new XmlOP();
        public TimeMoneyFormat()
        {
            InitializeComponent();
        }

        public int NeedTime=0;
        public int MonthMoney = 0;
        public double HourMoney = 0.0;
        public int TimePass = 0;

        public string starttime = string.Empty;
        public string endtime = string.Empty;

        private void TimeMoneyFormat_Load(object sender, EventArgs e)
        {
            NeedTime = Convert.ToInt32(WORK.Text);//所需工时;
            MM.Text = XmlOperation.GetMonthPay();
            MonthMoney = Convert.ToInt32(MM.Text);//目前月薪;
            HourMoney=MonthMoney / Convert.ToDouble(NeedTime);
            HM.Text = HourMoney.ToString();
            MIM.Text = (HourMoney / 60.0).ToString();
            SM.Text = (HourMoney / 60.0 /60.0).ToString();
            label9.Text = DateTime.Now.ToString() + "   " +DateTime.Now.DayOfWeek.ToString()+"   第" +DateTime.Now.DayOfYear.ToString()+"天";

            starttime = DateTime.Now.ToString();

            int total = XmlOperation.GetTotalSecond();
            textBox6.Text = (total / 60.0 / 60.0).ToString();
            //MM.Text = XmlOperation.GetMonthPay();
            this.button2.Enabled = false;
        }
        private void WORK_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MoneyTime.Start();
            pictureBox1.Visible = true;
            this.button2.Enabled = true;
            this.button1.Enabled = false;
            this.comboBox1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MoneyTime.Stop();

            endtime = DateTime.Now.ToString();

            int FlowID = DateTimeFormat.ConvertDateTimeInt(DateTime.Now);

            string[] nodedetail = new string[5] { "Normal", FlowID.ToString(), starttime, endtime, TimePass.ToString() };
            XmlOperation.CreatXmlNode(nodedetail);

            DateTime start = Convert.ToDateTime(starttime);
            DateTime end = Convert.ToDateTime(endtime);

            string dateDiff = null;
            TimeSpan ts1 = new TimeSpan(start.Ticks);
            TimeSpan ts2 = new TimeSpan(end.Ticks);

            TimeSpan ts = ts1.Subtract(ts2).Duration();
            dateDiff = ts.Days.ToString() + "天" + ts.Hours.ToString() + "小时" + ts.Minutes.ToString() + "分钟" + ts.Seconds.ToString() + "秒";

            starttime = string.Empty;
            endtime = string.Empty;
            TimePass = 0;

            this.button2.Enabled = false;
            this.button1.Enabled = true;
            this.comboBox1.Enabled = true;

            MessageBox.Show("辛苦！本次计时结束,共工作：" + dateDiff, "Conclution");
        }

        private void MoneyTime_Tick(object sender, EventArgs e)
        {
            TimePass++;
            HasPass.Text = TimePass.ToString();
            MoneyProduce.Text = (TimePass * (HourMoney / 60.0 / 60.0)).ToString();
            label9.Text = DateTime.Now.ToString() + "   " + DateTime.Now.DayOfWeek.ToString() + "   第" + DateTime.Now.DayOfYear.ToString() + "天";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowWorkList sw = new ShowWorkList();
            sw.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.comboBox1.SelectedIndex==0)
            {
                MM.Text = XmlOperation.GetMonthPay();
            }
            else if(this.comboBox1.SelectedIndex==1)
            {
                MM.Text = (Convert.ToInt32(XmlOperation.GetMonthPay()) * 2).ToString(); ;         
            }
            MonthMoney = Convert.ToInt32(MM.Text);//目前月薪;
            HourMoney = MonthMoney / Convert.ToDouble(NeedTime);
            HM.Text = HourMoney.ToString();
            MIM.Text = (HourMoney / 60.0).ToString();
            SM.Text = (HourMoney / 60.0 / 60.0).ToString();


            int total = XmlOperation.GetTotalSecond();
            textBox6.Text = (total / 60.0 / 60.0).ToString();
        }
    }
}
