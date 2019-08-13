using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace BDHelper
{
    class Base_Connect
    {
        public static SqlConnection Connection = new SqlConnection();
        public static bool Connect()
        {
            Connection.ConnectionString = ConfigurationManager.ConnectionStrings["DbConnect"].ConnectionString;
            try
            {
                Connection.Open();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(@"Ошибка соединения с БД. " + e.Message, @"Ошибка",
               MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
