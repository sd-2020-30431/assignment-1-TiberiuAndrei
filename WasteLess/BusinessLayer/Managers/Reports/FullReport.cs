using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Managers.Reports
{
    public class FullReport
    {
        public WeeklyReport wr;
        public MonthlyReport mr;
        public FullReport(WeeklyReport wr, MonthlyReport mr)
        {
            this.wr = wr;
            this.mr = mr;
        }

    }

}
