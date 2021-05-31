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
    class DocumentsDAL
    {

        public void InsertDocument(byte[] buffer, string extension)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InsertDocument", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //SqlParameter paramdata = new SqlParameter("@Data", buffer);
                //SqlParameter paramext = new SqlParameter("@Extension", extension);

                
                cmd.Parameters.Add("@Data", SqlDbType.VarBinary).Value=buffer;
                cmd.Parameters.Add("@Extension", SqlDbType.VarChar).Value=extension;
                


                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public ObservableCollection<Document> GetAllDocuments()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllDocuments", con);
                ObservableCollection<Document> result = new ObservableCollection<Document>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Document d = new Document();
                    d.ID = (int)(reader[0]);
                    d.Buffer = (byte[])(reader[1]);
                    d.Extension = reader.GetString(2);

                    result.Add(d);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public void InsertDocumentToClass(Document document, Class cls)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InsertDocumentToClass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIDD = new SqlParameter("@DocumentID", document.ID);
                SqlParameter paramIDC = new SqlParameter("@ClasaID", cls.ClassID);

                cmd.Parameters.Add(paramIDD);
                cmd.Parameters.Add(paramIDC);






                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
