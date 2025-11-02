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
    public class ProgramQuestionServices : IProgramQuestionServices
    {

        SqlConnection con = new SqlConnection(ConnectionString.Connection);
        public void AddContentProgramQuestion(TopicAndContentWiseProgramQuestionsModel programQuestion)
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand("sp_ContentProgramQuestions", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "insert");
                cmd.Parameters.AddWithValue("@ProgramQuestionId", programQuestion.ProgramQuestionId);
                cmd.Parameters.AddWithValue("@ContentId", programQuestion.ContentId);
                cmd.Parameters.AddWithValue("@Question", programQuestion.Question);
                cmd.Parameters.AddWithValue("@Flag", 0);
                int cnt = cmd.ExecuteNonQuery();

            }
        }

        public void DeleteContentProgramQuestion(int programQuestionId)
        {
            con.Close();
            con.Open();
            using (SqlCommand cmd = new SqlCommand("sp_ContentProgramQuestions", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "delete");
                cmd.Parameters.AddWithValue("@ProgramQuestionId", programQuestionId);
   
                int cnt = cmd.ExecuteNonQuery();

            }
        }

        public Task<List<TopicAndContentWiseProgramQuestionsModel>> GetAllContentProgramQuestions()
        {
            con.Close();
            List<TopicAndContentWiseProgramQuestionsModel> lst = new List<TopicAndContentWiseProgramQuestionsModel>();

            con.Open();
            using (SqlCommand cmd = new SqlCommand("sp_FetchContentProgramQuestions", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "insert");
                cmd.Parameters.AddWithValue("@ProgramQuestionId", 0);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) 
                {

                    lst.Add(new TopicAndContentWiseProgramQuestionsModel
                    {
                        ProgramQuestionId = Convert.ToInt32(dr["ProgramQuestionId"].ToString()),
                        ContentId = Convert.ToInt32(dr["ContentId"].ToString()),
                        Question = dr["Question"].ToString(),
                        ContentName = dr["ContentName"].ToString(),
                        ContentDescription = dr["ContentDescription"].ToString(),



                    });
                }
            }return Task.FromResult(lst);
        }

        public Task<TopicAndContentWiseProgramQuestionsModel> GetContentProgramQuestionById(int programQuestionId)
        {
            throw new NotImplementedException();
        }

        public Task<List<TopicAndContentWiseProgramQuestionsModel>> GetProgramingQuestionsByTopictId(int topicId)
        {
            con.Close();
            List<TopicAndContentWiseProgramQuestionsModel> lst = new List<TopicAndContentWiseProgramQuestionsModel>();

            con.Open();
            using (SqlCommand cmd = new SqlCommand("sp_FetchTopicWiseProgramQuestions", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TopicId", topicId);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    lst.Add(new TopicAndContentWiseProgramQuestionsModel
                    {
                        TopicId = Convert.ToInt32(dr["TopicId"].ToString()),
                        TopicName = dr["TopicName"].ToString(),
                        ContentId = Convert.ToInt32(dr["ContentId"].ToString()),
                        ContentName = dr["ContentName"].ToString(),
                        ContentDescription = dr["ContentDescription"].ToString(),
                        ProgramQuestionId = Convert.ToInt32(dr["ProgramQuestionId"].ToString()),
                        Question = dr["Question"].ToString()





                    });
                }
            }
            return Task.FromResult(lst);
        }

        public Task<List<TopicAndContentWiseProgramQuestionsModel>> GetProgramingQuestionsContentId(int contentId)
        {
            con.Close();
            List<TopicAndContentWiseProgramQuestionsModel> lst = new List<TopicAndContentWiseProgramQuestionsModel>();

            con.Open();
            using (SqlCommand cmd = new SqlCommand("sp_ContentWiseProgramQuestions", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
             
                cmd.Parameters.AddWithValue("@ContentId", contentId);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) 
                {

                    lst.Add(new TopicAndContentWiseProgramQuestionsModel
                    {
                        ContentId = Convert.ToInt32(dr["ContentId"].ToString()),
                        ContentName = dr["ContentName"].ToString(),
                        ContentDescription = dr["ContentDescription"].ToString(),
                        ProgramQuestionId = Convert.ToInt32(dr["ProgramQuestionId"].ToString()),
                   
                        Question = dr["Question"].ToString()
                  
                      



                    });
                }
            }
            return Task.FromResult(lst);
        }

        public void RestoreContentProgramQuestion(int programQuestionId)
        {
            con.Close();
            con.Open();
            using (SqlCommand cmd = new SqlCommand("sp_ContentProgramQuestions", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "restore");
                cmd.Parameters.AddWithValue("@ProgramQuestionId", programQuestionId);

                int cnt = cmd.ExecuteNonQuery();

            }
        }

        public void UpdateContentProgramQuestion(TopicAndContentWiseProgramQuestionsModel programQuestion)
        {
            con.Close();
            con.Open();
            using (SqlCommand cmd = new SqlCommand("sp_ContentProgramQuestions", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "update");
                cmd.Parameters.AddWithValue("@ProgramQuestionId", programQuestion.ProgramQuestionId);
                cmd.Parameters.AddWithValue("@ContentId", programQuestion.ContentId);
                cmd.Parameters.AddWithValue("@Question", programQuestion.Question);
                cmd.Parameters.AddWithValue("@Flag", 0);
                int cnt = cmd.ExecuteNonQuery();

            }
        }
    }
}
