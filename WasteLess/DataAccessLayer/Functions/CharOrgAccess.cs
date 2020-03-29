using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities;
using DataAccessLayer.DataContext;
using System.Linq;

namespace DataAccessLayer.Functions
{
    public class CharOrgAccess
    {
        //returns the current available charity organisations
        public List<CharOrg> getCharOrgList()
        {
            using (var _dcm = new DatabaseConnectionManager())
            {
                IEnumerable<CharOrg> charOrgList = (from x in _dcm.CharOrgs select x);
                return charOrgList.ToList();
            }

        }

    }

}
