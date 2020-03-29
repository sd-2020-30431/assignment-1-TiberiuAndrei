using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities;
using BusinessLayer.Models;
using DataAccessLayer.Functions;

namespace BusinessLayer.Managers
{
    public class CharOrgManager
    {
        //create clone model of CharOrg so I don not skip a layer by using database models
        //directly in views and controllers
        public BCharOrg convertToBCharOrg(CharOrg charOrg)
        {
            return new BCharOrg
            {
                Id = charOrg.Id,
                Address = charOrg.Address,
                Phone = charOrg.Phone
            };

        }

        //extracts the charity organisations from the database and converts to the clone model
        public List<BCharOrg> getBCharOrgList()
        {
            CharOrgAccess ca = new CharOrgAccess();

            List<CharOrg> charOrgList = ca.getCharOrgList();
            
            List<BCharOrg> bCharOrgList = new List<BCharOrg>();
            
            foreach (CharOrg c in charOrgList)
            {
                bCharOrgList.Add(convertToBCharOrg(c));
            }
            return bCharOrgList;

        }

    }

}
