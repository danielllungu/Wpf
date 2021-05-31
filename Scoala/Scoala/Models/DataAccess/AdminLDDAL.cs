using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using Scoala.Models.LoginDetails;
using System.Data;

namespace Scoala.Models.DataAccess
{
    class AdminLDDAL
    {
        public ObservableCollection<AdminLD> GetAdminsLoginDetails()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("AdminLoginDetails", con);
                ObservableCollection<AdminLD> result = new ObservableCollection<AdminLD>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AdminLD a = new AdminLD();
                    a.AdminID = (int)(reader[0]);
                    a.Email = reader.GetString(1);
                    a.Password = reader.GetString(2);
                    //p.Address = reader.IsDBNull(2) ? null : reader[2].ToString();
                    result.Add(a);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
