using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace ConnOracle.Models
{
    public class OracleDao
    {
        private string ConnectionString { get; set; }

        public OracleDao()
        {
            this.ConnectionString = WebConfigurationManager.ConnectionStrings["OracleDB"].ConnectionString;
        }

        public IEnumerable<INVLinesModel> GetInv(string invoice_num)
        {
            var data = new List<INVLinesModel>();

            string sqlStatement = @"select invoice_num,line_number,amount,account_segment,description
from WF_AP_INV_LINES_INTERFACE_HIS where invoice_num=:inv_num  order by line_number";

            using (var cn = new Oracle.ManagedDataAccess.Client.OracleConnection(this.ConnectionString))
            {
                cn.Open();
                var cmd = cn.CreateCommand();
                cmd.CommandText = sqlStatement;
                cmd.Parameters.Add(new Oracle.ManagedDataAccess.Client.OracleParameter("@nv_num", invoice_num));

                var dr = cmd.ExecuteReader();


                while (dr.Read())
                {
                    data.Add(new INVLinesModel
                    {
                        invoice_num = dr["invoice_num"].ToString(),
                        line_number = (dr["line_number"] == null) ? 0 : int.Parse(dr["line_number"].ToString()),
                        amount = int.Parse(dr["amount"].ToString()),
                        description = dr["description"].ToString(),
                        account_segment = dr["account_segment"].ToString()
                    });
                }
            }

            return data.Take(10);
        }
    }
}