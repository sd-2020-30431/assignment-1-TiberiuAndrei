using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Managers.Reports
{
    public abstract class AbstractReportFactory
    {
        public abstract WeeklyReport createWeeklyReport(long uid);
        public abstract MonthlyReport createMonthlyReport(long uid);

    }
}
