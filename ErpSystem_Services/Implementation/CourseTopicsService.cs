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
    public class CourseTopicsService : ICourseTopicsService
    {
        SqlConnection con = new SqlConnection(ConnectionString.Connection);
        public void AddCourseTopic(CourseTopicsModel courseTopic)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.Connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_CourseTopics", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "insert");
                cmd.Parameters.AddWithValue("@CourseId", courseTopic.CourseId);
                cmd.Parameters.AddWithValue("@TopicId", courseTopic.TopicId );
                cmd.Parameters.AddWithValue("@CourseTopicId", courseTopic.CourseTopicId);
                cmd.ExecuteNonQuery();
            }

        }

        public void DeleteCourseTopic(int courseTopicId)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.Connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_CourseTopics", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "delete");
                cmd.Parameters.AddWithValue("@CourseTopicId",courseTopicId);             
                int cnt = cmd.ExecuteNonQuery();
            }
        }

        public List<CourseTopicsModel> GetCourseTopicById(int courseTopicId)
        {
            List<CourseTopicsModel> lst = new List<CourseTopicsModel>();

            using (SqlConnection con = new SqlConnection(ConnectionString.Connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("sp_FetchCourseTopics", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CourseTopicId", courseTopicId);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read()) 
                        {
                            lst.Add(new CourseTopicsModel
                            {
                                CourseTopicId = Convert.ToInt32(dr["CourseTopicId"]),
                                CourseId = Convert.ToInt32(dr["CourseId"]),
                                CourseName = dr["CourseName"].ToString(),
                                TopicId = Convert.ToInt32(dr["TopicId"]),
                                TopicName = dr["TopicName"].ToString()
                            });
                        }
                    }
                }
            }

            return lst;
        }



        public List<CourseTopicsModel> GetCourseTopics()
        {
            con.Close();
          List<CourseTopicsModel> lst = new List<CourseTopicsModel>();
            con.Open();
            using(SqlCommand cmd= new SqlCommand("sp_FetchCourseTopics",con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("CourseTopicId", 0);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while(dr.Read())
                    {
                        lst.Add(new CourseTopicsModel
                        {
                            CourseTopicId = Convert.ToInt32(dr["CourseTopicId"].ToString()),
                            CourseId = Convert.ToInt32(dr["CourseId"].ToString()),
                            CourseName = dr["CourseName"].ToString(),                      
                            TopicId = Convert.ToInt32(dr["TopicId"].ToString()),
                            TopicName = dr["TopicName"].ToString(),
                            //ContentId = Convert.ToInt32(dr["ContentId"].ToString()),
                            //ContentName = dr["ContentName"].ToString(),

                        });
                    }
                }

            }
            return lst;

        }

        public List<ContentModel> GetTopicAndContentByCourseId(int courseId)
        {
            con.Close();
            List<ContentModel> lst = new List<ContentModel>();
            con.Open();
            using (SqlCommand cmd = new SqlCommand("sp_FetchCourseWiseTopic", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("CourseId", courseId);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lst.Add(new ContentModel
                        {
                            CourseTopicId = Convert.ToInt32(dr["CourseTopicId"].ToString()),
                            CourseName = dr["CourseName"].ToString(),
                            TopicId = Convert.ToInt32(dr["TopicId"].ToString()),
                            TopicName = dr["TopicName"].ToString(),

                            ContentId = Convert.ToInt32(dr["ContentId"].ToString()),
                            ContentName = dr["ContentName"].ToString(),

                        });
                    }
                }

            }
            return lst;
        }

        public void RestoreCourseTopic(int courseTopicId)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.Connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_CourseTopics", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "update");
                cmd.Parameters.AddWithValue("@CourseTopicId", courseTopicId);
                int cnt = cmd.ExecuteNonQuery();
            }
        }

        public void UpdateCourseTopic(CourseTopicsModel courseTopic)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.Connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_CourseTopics", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "update");
                cmd.Parameters.AddWithValue("@CourseId", courseTopic.CourseId);
                cmd.Parameters.AddWithValue("@TopicId", courseTopic.TopicId);
                int cnt = cmd.ExecuteNonQuery();
            }
        }
    }
}
