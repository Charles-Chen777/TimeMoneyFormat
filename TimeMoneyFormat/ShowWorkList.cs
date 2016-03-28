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

namespace TimeMoneyFormat
{
    public partial class ShowWorkList : Form
    {
        public ShowWorkList()
        {
            InitializeComponent();
        }

        XmlOP XmlOperation = new XmlOP();

        private void ShowWorkList_Load(object sender, EventArgs e)
        {
            worklist.DataSource = XmlOperation.GetXmlList();
            this.textBox1.Text = DateTime.Now.ToString();
        }

        private void worklist_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (this.worklist.Rows.Count != 0)
            {
                for (int i = 0; i < this.worklist.Rows.Count; )
                {
                    this.worklist.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                    i += 2;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           List<WorkTimeList> WorkTimeList= XmlOperation.GetXmlList();
           string start = this.textBox1.Text;
           string end = this.textBox2.Text;
           int starttime = DateTimeFormat.ConvertDateTimeInt(Convert.ToDateTime(start));
           int endtime = DateTimeFormat.ConvertDateTimeInt(Convert.ToDateTime(end));
            List<WorkTimeList> Query=new List<WorkTimeList>();
            for(int i=0;i<WorkTimeList.Count;i++)
            {
                int temp_start = DateTimeFormat.ConvertDateTimeInt(Convert.ToDateTime(WorkTimeList[i].StartTime));
                int temp_end = DateTimeFormat.ConvertDateTimeInt(Convert.ToDateTime(WorkTimeList[i].EndTime));
                if (temp_start >= starttime && temp_end <= endtime)
                {
                    Query.Add(WorkTimeList[i]);
                }
            }
            worklist.DataSource = Query;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CountMoney cm = new CountMoney();
            cm.Show();
        }
    }
}
