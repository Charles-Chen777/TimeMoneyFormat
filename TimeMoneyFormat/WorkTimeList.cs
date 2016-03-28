using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeMoneyFormat
{
    public class WorkTimeList
    {
        public WorkTimeList()
        {

        }
        private string startTime;
        private string endTime;
        private string recordSecond;

        public string StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }

        public string EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }

        public string RecordSecond
        {
            get { return recordSecond; }
            set { recordSecond = value; }
        }

    }
}
