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
    class MastersDAL
    {
        public ObservableCollection<MastersToClass> GetMastersViewList()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetMastersToClass", con);
                ObservableCollection<MastersToClass> result = new ObservableCollection<MastersToClass>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MastersToClass m = new MastersToClass();

                    /*m.Teacher = new Teacher();
                    m.Subject = new Subject();
                    m.MasterToClass = new MasterToClass();
                    m.TeacherToSubject = new TeacherToSubject();*/

                    m.MasterToClass.TeacherID = (int)(reader[0]);
                    m.MasterToClass.ClassID = (int)(reader[1]);
                    m.MasterToClass.MasterID = (int)(reader[2]);

                    /*if (reader.IsDBNull(0))
                        m.MasterToClass.TeacherID = null;
                    else
                        

                    if (reader.IsDBNull(1))
                        m.MasterToClass.ClassID = null;
                    else
                    {
                       
                    }*/

                    m.Teacher.TeacherID = (int)(reader[3]);
                    m.Teacher.Name = reader.GetString(4);
                    m.Teacher.Phone = reader.GetString(5);
                    m.Class.ClassID = (int)(reader[6]);
                    m.Class.ClassNumber=(int)(reader[7]);
                    m.Class.Letter = reader.GetString(8);
                    m.Class.Specialization = reader.GetString(9);
                    m.TeacherToSubject.TeacherID= (int)(reader[10]);
                    m.TeacherToSubject.SubjectID = (int)(reader[11]);
                    m.TeacherToSubject.CuplajID = (int)(reader[12]);
                    m.Subject.SubjectID = (int)(reader[13]);
                    m.Subject.Name = reader.GetString(14);
                    result.Add(m);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public void SetMastersToClass(Teacher teacher, Class cls)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InsertMasterToClass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIDProf = new SqlParameter("@idProfesor", teacher.TeacherID);
                SqlParameter paramIDClasa = new SqlParameter("@idClasa", cls.ClassID);

                cmd.Parameters.Add(paramIDProf);
                cmd.Parameters.Add(paramIDClasa);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateMasterToClass(Teacher teacher, Class cls, MasterToClass master)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("UpdateMasterToClass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramID = new SqlParameter("@idDiriginte", master.MasterID);
                SqlParameter paramIDProf = new SqlParameter("@idProfesor", teacher.TeacherID);
                SqlParameter paramIDClasa = new SqlParameter("@idClasa", cls.ClassID);

                cmd.Parameters.Add(paramIDProf);
                cmd.Parameters.Add(paramIDClasa);
                cmd.Parameters.Add(paramID);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteAndAddMasterToClass(Teacher teacher, Class cls)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteAndAddMasterToClass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIDProf = new SqlParameter("@idProfesor", teacher.TeacherID);
                SqlParameter paramIDClasa = new SqlParameter("@idClasa", cls.ClassID);

                cmd.Parameters.Add(paramIDProf);
                cmd.Parameters.Add(paramIDClasa);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteMaster(MasterToClass master)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramID = new SqlParameter("@idDiriginte", master.MasterID);
                cmd.Parameters.Add(paramID);
        
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
