using ErpSystem_Models;
using ErpSystem_Services.Interface;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem_Services.Implementation
{
    public class TopicService : ITopicService
    {
       SqlConnection con = new SqlConnection(ConnectionString.Connection);
        public void AddTopic(TopicsModel topic)
        {
            con.Open();
            using(SqlCommand cmd= new SqlCommand("sp_Topics",con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "insert");
                cmd.Parameters.AddWithValue("@TopicId", topic.TopicId);
                cmd.Parameters.AddWithValue("@TopicName", topic.TopicName);
                cmd.Parameters.AddWithValue("@Description", topic.TopicDescription);
                int cnt= cmd.ExecuteNonQuery();
                
            }
          
        }

        public void DeleteTopic(int topicId)
        {
            con.Close();
            con.Open();
            using(SqlCommand cmd= new SqlCommand("sp_Topics", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "delete");
                cmd.Parameters.AddWithValue("@TopicId",topicId);
                int cnt = cmd.ExecuteNonQuery();

            }
        }

        public List<TopicsModel> GetAllTopics()
        {
            List<TopicsModel> lat = new List<TopicsModel>();
            con.Close();
            con.Open();

            using (SqlCommand cmd = new SqlCommand("sp_FetchTopic", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TopicId", DBNull.Value); 

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        TopicsModel tm = new TopicsModel()
                        {
                            TopicId = Convert.ToInt32(dr["TopicId"]),
                            TopicName = dr["TopicName"].ToString(),
                            TopicDescription = dr["TopicDescription"].ToString()
                        };
                        lat.Add(tm);
                    }
                }
            }

            return lat;
        }


        public Task<List<ContentModel>> GetCourseWiseTopics(int courseId)
        {
            
            con.Close();
            List<ContentModel> lst = new List<ContentModel>();
            con.Open();
            using(SqlCommand cmd= new SqlCommand("sp_FetchCourseWiseTopic",con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CourseId", courseId);
                SqlDataReader dr = cmd.ExecuteReader();
               while(dr.Read())
                {
                    ContentModel cm = new ContentModel()
                    {
                        TopicId = Convert.ToInt32(dr["TopicId"].ToString()),
                        TopicName = dr["TopicName"].ToString(),
                        TopicDescription = dr["Description"].ToString(),
                        CourseId = Convert.ToInt32(dr["CourseId"].ToString()),
                        CourseName = dr["CourseName"].ToString(),

                    };
                    lst.Add(cm);

                }
            }
            return Task.FromResult(lst);

        }

        public TopicsModel GetTopicById(int topicId)
        {
            con.Close();
            TopicsModel topic = null;
            con.Open();
            using(SqlCommand cmd= new SqlCommand("sp_FetchTopic",con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TopicId", topicId);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    topic = new TopicsModel()
                    {
                        TopicId = Convert.ToInt32(dr["TopicId"].ToString()),
                        TopicName = dr["TopicName"].ToString(),
                        TopicDescription = dr["TopicDescription"].ToString()

                    };
                }
            }
            return topic;
        }

        public void RestoreTopic(int topicId)
        {
            con.Close();
            con.Open();
            using (SqlCommand cmd = new SqlCommand("sp_Topics", con))
            {
                cmd.Parameters.AddWithValue("@Action", "restore");
                cmd.Parameters.AddWithValue("@TopicId", topicId);
                cmd.ExecuteNonQuery();

            }
        }

        public void UpdateTopic(TopicsModel topic)
        {
            con.Close();
            con.Open();
            using (SqlCommand cmd = new SqlCommand("sp_Topics", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "update");
                cmd.Parameters.AddWithValue("@TopicId", topic.TopicId);
                cmd.Parameters.AddWithValue("@TopicName", topic.TopicName);
                cmd.Parameters.AddWithValue("@Description", topic.TopicDescription);
                cmd.ExecuteNonQuery();

            }
        }
    }
}
