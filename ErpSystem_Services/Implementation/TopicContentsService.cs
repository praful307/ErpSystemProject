using ErpSystem_Models;
using ErpSystem_Services.Interface;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem_Services.Implementation
{
    public class TopicContentsService : ITopicContentsService
    {
        SqlConnection con = new SqlConnection(ConnectionString.Connection);
        public void AddTopicContent(TopicContentsModel topicContent)
        {
          con.Open();
            using(SqlCommand cmd= new SqlCommand("sp_TopicContents", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "insert");
                cmd.Parameters.AddWithValue("@TopicId", topicContent.TopicId);         
                cmd.Parameters.AddWithValue("@ContentId", topicContent.ContentId);         
                cmd.Parameters.AddWithValue("@ContentName", topicContent.ContentName);
                cmd.Parameters.AddWithValue("@Description", topicContent.ContentDescription);
   
             
                cmd.ExecuteNonQuery();

            }
        }

        public void DeleteTopicContent(int contentId)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.Connection))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("sp_TopicContents", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                
                    cmd.Parameters.AddWithValue("@Action", "delete");
                    cmd.Parameters.AddWithValue("@ContentId", contentId);

                
                     cmd.Parameters.AddWithValue("@TopicId", DBNull.Value);
                     cmd.Parameters.AddWithValue("@ContentName", DBNull.Value);
                     cmd.Parameters.AddWithValue("@Description", DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<TopicContentsModel> GetAllTopicContents()
        {
            con.Close();
            List<TopicContentsModel> lst = new List<TopicContentsModel>();
            con.Open();
            using(SqlCommand cmd= new SqlCommand("sp_FetchTopiContent",con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ContentId", 0);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    lst.Add(new TopicContentsModel
                    {
                        ContentId = Convert.ToInt32(dr["ContentId"].ToString()),
                        ContentName = dr["ContentName"].ToString(),
                        ContentDescription = dr["ContentDescription"].ToString(),
                        TopicId = Convert.ToInt32(dr["TopicId"].ToString()),
                        TopicName = dr["TopicName"].ToString()
                    });

                }
            }
            return lst;
        }

        public Task<List<ContentModel>> GetContentsByCourseId(int courseId)
        {
            con.Close();
            List<ContentModel> lst = new List<ContentModel>();
            con.Open();
            using(SqlCommand cmd= new SqlCommand("sp_FetchCourseWiseTopicAndContents",con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CourseId", courseId);
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    lst.Add(new ContentModel
                    {

                        CourseId = Convert.ToInt32(dr["CourseId"].ToString()),
                        CourseName = dr["CourseName"].ToString(),                
                 
                        CourseDecsription = dr["CourseName"].ToString(),                   
                     
                        TopicId = Convert.ToInt32(dr["CourseId"].ToString()),
                        TopicDescription = dr["CourseName"].ToString(),
                        TopicName = dr["CourseName"].ToString(),
                        ContentId = Convert.ToInt32(dr["CourseId"].ToString()),
                        ContentName = dr["CourseName"].ToString(),
                        ContentDescription = dr["CourseName"].ToString()


                    });
                }
            }
            return Task.FromResult(lst);
        }

        public TopicContentsModel GetTopicContentById(int contentId)
        {
           
            con.Close();
            TopicContentsModel contents = null;
            con.Open();
            using(SqlCommand cmd= new SqlCommand("sp_FetchTopiContent",con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ContentId", contentId);
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    contents = new TopicContentsModel()
                    {
                        ContentId = Convert.ToInt32(dr["ContentId"].ToString()),
                        TopicId = Convert.ToInt32(dr["TopicId"].ToString()),
                        ContentName= dr["ContentName"].ToString(),
                        TopicName= dr["TopicName"].ToString(),
                        ContentDescription = dr["ContentDescription"].ToString()
                        
                    };

                }
            }
            return   contents;
        }

        public void RestoreTopiContent(int contentId)
        {
            con.Close();
            con.Open();
            using (SqlCommand cmd = new SqlCommand("sp_TopicContents", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "restore");
                cmd.Parameters.AddWithValue("@ContentId", contentId);


                int cnt = cmd.ExecuteNonQuery();

            }
        }

        public Task<List<ContentModel>> TopciWiseContents(int topicId)
        {
            con.Close();
            List<ContentModel> lst = new List<ContentModel>();
            con.Open();
            using (SqlCommand cmd = new SqlCommand("sp_FetchTopic", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TopicId", topicId);
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    lst.Add(new ContentModel
                    {
                        TopicId = Convert.ToInt32(dr["CourseId"].ToString()),
                        TopicDescription = dr["CourseName"].ToString(),
                        TopicName = dr["CourseName"].ToString(),
                        ContentId = Convert.ToInt32(dr["CourseId"].ToString()),
                        ContentName = dr["CourseName"].ToString(),
                        ContentDescription = dr["CourseName"].ToString()


                    });
                }          
            }
            return Task.FromResult(lst);
        }

        public void UdpdateTopicContent(TopicContentsModel topiContent)
        {
            con.Close();
            con.Open();
            using (SqlCommand cmd = new SqlCommand("sp_TopicContents", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "update");
                cmd.Parameters.AddWithValue("@ContentId", topiContent.ContentId);
                cmd.Parameters.AddWithValue("@TopicId", topiContent.TopicId);
                cmd.Parameters.AddWithValue("@ContentName", topiContent.ContentName);
                cmd.Parameters.AddWithValue("@Description", topiContent.ContentDescription);               

                cmd.ExecuteNonQuery();

            }
        }
    }
}
