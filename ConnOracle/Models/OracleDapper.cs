using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Dapper;

namespace ConnOracle.Models
{
    public class OracleDapper
    {
        private string ConnectionString { get; set; }

        public OracleDapper()
        {
            this.ConnectionString = WebConfigurationManager.ConnectionStrings["OracleDB"].ConnectionString;
        }

        public IEnumerable<INVLinesModel> GetInv(string invoice_num)
        {

            string sqlStatement = @"select invoice_num,line_number,amount,account_segment,description
from WF_AP_INV_LINES_INTERFACE_HIS where invoice_num=:inv_num  order by line_number";

            using (var cn = new Oracle.ManagedDataAccess.Client.OracleConnection(this.ConnectionString))
            {
                var result = cn.Query<INVLinesModel>(sqlStatement, new
                {
                    inv_num = invoice_num
                });
                return result;
            }
        }
    }
}