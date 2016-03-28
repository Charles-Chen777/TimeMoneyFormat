using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Configuration;

namespace TimeMoneyFormat
{
    public class XmlOP
    {
        
        public List<WorkTimeList> GetXmlList()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\DataSource.xml");
            XmlNode root = doc.SelectSingleNode("WorkTimeList");//根节点
            XmlNodeList xnl = root.ChildNodes;//<Record>子节点集

            List<WorkTimeList> WorkTimeList = new List<WorkTimeList>();

            foreach (XmlNode xn1 in xnl)
            {
                WorkTimeList wt = new WorkTimeList();
                XmlElement xe = (XmlElement)xn1;
                XmlNodeList xn10 = xe.ChildNodes;
                wt.StartTime = xn10.Item(0).InnerText;
                wt.EndTime = xn10.Item(1).InnerText;
                wt.RecordSecond = xn10.Item(2).InnerText;
                WorkTimeList.Add(wt);
            }
            return WorkTimeList;
        }

        public void CreatXmlNode(string []nodeDetail)
        {
            int index=0;
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\DataSource.xml");
            XmlNode root = doc.SelectSingleNode("WorkTimeList");//根节点
            //创建子节点
            XmlElement rootAtt = doc.CreateElement("Record");
            XmlAttribute setType = doc.CreateAttribute("Type");
            XmlAttribute setFlowID = doc.CreateAttribute("FlowID");
            setType.InnerText = nodeDetail[index];
            index++;
            setFlowID.InnerText = nodeDetail[index];
            index++;
            rootAtt.SetAttributeNode(setType);
            rootAtt.SetAttributeNode(setFlowID);
            //创建二级子节点
            XmlElement starttime = doc.CreateElement("starttime");
            starttime.InnerText = nodeDetail[index];
            index++;
            rootAtt.AppendChild(starttime);
            XmlElement endtime = doc.CreateElement("endtime");
            endtime.InnerText = nodeDetail[index];
            index++;
            rootAtt.AppendChild(endtime);
            XmlElement recsecond = doc.CreateElement("recsecond");
            recsecond.InnerText = nodeDetail[index];
            index++;
            rootAtt.AppendChild(recsecond);
            //向WorkTimeList根节点添加
            root.AppendChild(rootAtt);
            doc.Save(@"..\..\DataSource.xml");
        }

        public int GetTotalSecond()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\DataSource.xml");
            XmlNode root = doc.SelectSingleNode("WorkTimeList");//根节点
            XmlNodeList xnl = root.ChildNodes;//<Record>子节点集

            int total = 0;

            foreach (XmlNode xn1 in xnl)
            {
                XmlElement xe = (XmlElement)xn1;
                XmlNodeList xn10 = xe.ChildNodes;
                total += Convert.ToInt32(xn10.Item(2).InnerText);
            }
            return total;
        }

        //APPconfig部分
        public string GetMonthPay()
        {
            //获得配置文件的全路径
            //string strFilePath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "App.config";  //需要检查该目录下是否存在此文件    
      
            XmlDocument doc = new XmlDocument();

            doc.Load(@"..\..\App.config");

            //找出名称为“add”的所有元素           
            XmlNodeList nodes = doc.GetElementsByTagName("add");

            return nodes[0].Attributes["value"].Value.ToString();​
        }

        public string GetMonthWorkTime()
        {
            //获得配置文件的全路径
            //string strFilePath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "App.config";  //需要检查该目录下是否存在此文件    

            XmlDocument doc = new XmlDocument();

            doc.Load(@"..\..\App.config");

            //找出名称为“add”的所有元素           
            XmlNodeList nodes = doc.GetElementsByTagName("add");

            return nodes[1].Attributes["value"].Value.ToString();
        }
    }
}
