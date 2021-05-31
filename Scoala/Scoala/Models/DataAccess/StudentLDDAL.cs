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
    class StudentLDDAL
    {
        public ObservableCollection<StudentLD> GetStudentsLoginDetails()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("StudentLoginDetails", con);
                ObservableCollection<StudentLD> result = new ObservableCollection<StudentLD>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    StudentLD s = new StudentLD();
                    s.StudentID = (int)(reader[0]);
                    s.Email = reader.GetString(1);
                    s.Password = reader.GetString(2);
                    //p.Address = reader.IsDBNull(2) ? null : reader[2].ToString();
                    result.Add(s);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public void AddStudent(string name)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InsertStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramNume = new SqlParameter("@name", name);
                cmd.Parameters.Add(paramNume);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public ObservableCollection<Student> GetStudents()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllStudents", con);
                ObservableCollection<Student> result = new ObservableCollection<Student>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Student s = new Student();
                    s.StudentID = (int)(reader[0]);
                    s.Name= reader.GetString(1);
                    
                    result.Add(s);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public void AddStudentToClass(Student student, Class cls)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InsertStudentToClass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIDElev = new SqlParameter("@idElev", student.StudentID);
                SqlParameter paramIDClasa = new SqlParameter("@idClasa", cls.ClassID);
                cmd.Parameters.Add(paramIDElev);
                cmd.Parameters.Add(paramIDClasa);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void AddStudentLD(Student s, string email, string password)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InsertStudentLoginDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramID = new SqlParameter("@idElev", s.StudentID);
                SqlParameter paramEmail = new SqlParameter("@email", email);
                SqlParameter paramPass = new SqlParameter("@password", password);
                cmd.Parameters.Add(paramID);
                cmd.Parameters.Add(paramEmail);
                cmd.Parameters.Add(paramPass);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateStudentToClass(Student student, Class cls)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("UpdateStudentToClass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIDElev = new SqlParameter("@idElev", student.StudentID);
                SqlParameter paramIDClasa = new SqlParameter("@idClasa", cls.ClassID);
                cmd.Parameters.Add(paramIDElev);
                cmd.Parameters.Add(paramIDClasa);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteStudentFromStudents(Student student)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteStudentFromStudents", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIDElev = new SqlParameter("@idElev", student.StudentID);
                cmd.Parameters.Add(paramIDElev);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteStudentFromLogin(Student student)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteStudentFromLogin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIDElev = new SqlParameter("@idElev", student.StudentID);
                cmd.Parameters.Add(paramIDElev);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteStudentFromMarks(Student student)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteStudentFromMarks", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIDElev = new SqlParameter("@idElev", student.StudentID);
                cmd.Parameters.Add(paramIDElev);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteStudentFromAbsences(Student student)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteStudentFromAbsences", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIDElev = new SqlParameter("@idElev", student.StudentID);
                cmd.Parameters.Add(paramIDElev);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteStudentFromClass(Student student)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteStudentFromClass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIDElev = new SqlParameter("@idElev", student.StudentID);
                cmd.Parameters.Add(paramIDElev);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateStudentName(Student student, string nume)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("UpdateStudentName", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIDElev = new SqlParameter("@idElev", student.StudentID);
                SqlParameter paramNume = new SqlParameter("@nume", nume);
                cmd.Parameters.Add(paramIDElev);
                cmd.Parameters.Add(paramNume);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }



    }
}
