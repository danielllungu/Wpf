using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using Scoala.Models.LoginDetails;
using System.Data;
using Scoala.Models.EntityLayer;

namespace Scoala.Models.DataAccess
{
    class ClassDAL
    {
        public ObservableCollection<Class> GetClasses()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllClasses", con);
                ObservableCollection<Class> result = new ObservableCollection<Class>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Class c = new Class();
                    c.ClassID = (int)(reader[0]);
                    c.ClassNumber = (int)(reader[1]);
                    c.Letter = reader.GetString(2);
                    c.Specialization = reader.GetString(3);
                    result.Add(c);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public void AddClass(int class_number, string letter, string specialization)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InsertClass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramNumber = new SqlParameter("@class_number", class_number);
                SqlParameter paramLetter = new SqlParameter("@letter", letter);
                SqlParameter paramSpec = new SqlParameter("@specialization", specialization);
                cmd.Parameters.Add(paramNumber);
                cmd.Parameters.Add(paramLetter);
                cmd.Parameters.Add(paramSpec);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public ObservableCollection<ClassesToStudentsLST> GetAllClassesToStudents()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllClassesToStudents", con);
                ObservableCollection<ClassesToStudentsLST> result = new ObservableCollection<ClassesToStudentsLST>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ClassesToStudentsLST c = new ClassesToStudentsLST();
                    c.StudentToClass.StudentID = (int)(reader[0]);
                    c.StudentToClass.ClassID = (int)(reader[1]);
                    c.Student.StudentID = (int)(reader[2]);
                    c.Student.Name = reader.GetString(3);
                    c.Class.ClassID = (int)(reader[4]);
                    c.Class.ClassNumber = (int)(reader[5]);
                    c.Class.Letter = reader.GetString(6);
                    c.Class.Specialization = reader.GetString(7);
                    
                    result.Add(c);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public void DeleteClass(Class cls)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteClass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramID = new SqlParameter("@idClasa", cls.ClassID);
                cmd.Parameters.Add(paramID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
