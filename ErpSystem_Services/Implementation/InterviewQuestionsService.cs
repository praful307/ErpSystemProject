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
    public class InterviewQuestionsService : IInterviewQuestionsService
    {
        SqlConnection con = new SqlConnection(ConnectionString.Connection);
        public void AddInterviewQuestion(TopicAndContentWiseInterviewQuestionsModel interviewQuestion)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_InterviewQuestions", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "insert");
            cmd.Parameters.AddWithValue("@InterviewQuestionId", interviewQuestion.InterviewQuestionId);
            cmd.Parameters.AddWithValue("@ContentId", interviewQuestion.ContentId);
            cmd.Parameters.AddWithValue("@InterviewQuestion", interviewQuestion.InterviewQuestion);
            cmd.Parameters.AddWithValue("@Explaination", interviewQuestion.Explanation);
            int cnt = cmd.ExecuteNonQuery();

        }

        public void DeleteInterviewQuestion(int interviewQuestionId)
        {

            con.Close();
            con.Open();
            using(SqlCommand cmd= new SqlCommand("sp_InterviewQuestions",con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "delete");
                cmd.Parameters.AddWithValue("@InterviewQuestionId", interviewQuestionId);
                int cnt= cmd.ExecuteNonQuery();
            }
        }

        public Task<List<TopicAndContentWiseInterviewQuestionsModel>> GetAllInterviewQuestions()
        {
            con.Close();
            List<TopicAndContentWiseInterviewQuestionsModel> lst = new List<TopicAndContentWiseInterviewQuestionsModel>();
            con.Open();
            using (SqlCommand cmd = new SqlCommand("sp_FetchInterviewQuestions", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@InterviewQuestionId", 0);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    lst.Add(new TopicAndContentWiseInterviewQuestionsModel
                    {
                        InterviewQuestionId = Convert.ToInt32(dr["@InterviewQuestionId"].ToString()),
                        InterviewQuestion = dr["InterviewQuestion"].ToString(),
                        Explanation = dr["Explaination"].ToString(),
                        ContentId = Convert.ToInt32(dr["ContentId"].ToString()),
                        ContentName = dr["ContentName"].ToString(),
                        ContentDescription = dr["ContentDescription"].ToString(),
                    });

                }
            }
            return Task.FromResult(lst);
        }

        public Task<List<TopicAndContentWiseInterviewQuestionsModel>> GetContentWiseInterViewQuestion(int contentId)
        {
            con.Close();
            List<TopicAndContentWiseInterviewQuestionsModel> lst = new List<TopicAndContentWiseInterviewQuestionsModel>();
            con.Open();
            using (SqlCommand cmd = new SqlCommand("sp_ContentWiseInterviewQuestions", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ContentId", contentId);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    lst.Add(new TopicAndContentWiseInterviewQuestionsModel
                    {
                        ContentId = Convert.ToInt32(dr["ContentId"].ToString()),
                        ContentName = dr["ContentName"].ToString(),
                        ContentDescription = dr["ContentDescription"].ToString(),
                        InterviewQuestionId = Convert.ToInt32(dr["@InterviewQuestionId"].ToString()),
                        InterviewQuestion = dr["InterviewQuestion"].ToString(),
                        Explanation = dr["Explaination"].ToString()
                  
                    });

                }
            }
            return Task.FromResult(lst);
        }

        public Task<TopicAndContentWiseInterviewQuestionsModel> GetInterviewQuestionById(int InterviewQuestionId)
        {
            con.Close();
            TopicAndContentWiseInterviewQuestionsModel questions = null;
            con.Open();
            using (SqlCommand cmd = new SqlCommand("sp_FetchInterviewQuestions", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@InterviewQuestionId", InterviewQuestionId);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    questions = new TopicAndContentWiseInterviewQuestionsModel
                    {

                        InterviewQuestionId = Convert.ToInt32(dr["InterviewQuestionId"].ToString()),
                        InterviewQuestion = dr["InterviewQuestion"].ToString(),
                        Explanation = dr["Explaination"].ToString(),
                        ContentId = Convert.ToInt32(dr["ContentId"].ToString()),
                        ContentName = dr["ContentName"].ToString(),
                        ContentDescription = dr["ContentDescription"].ToString(),

                    };

                }
                return Task.FromResult(questions);

            }
        }

        public Task<List<TopicAndContentWiseInterviewQuestionsModel>> GetTopicWiseInterviewQuestions(int topicId)
        {
            con.Close();
            List<TopicAndContentWiseInterviewQuestionsModel> lst = new List<TopicAndContentWiseInterviewQuestionsModel>();
            con.Open();
            using (SqlCommand cmd = new SqlCommand("sp_ContentWiseInterviewQuestions", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TopicId", topicId);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    lst.Add(new TopicAndContentWiseInterviewQuestionsModel
                    {
                        TopicId = Convert.ToInt32(dr["TopicId"].ToString()),
                        TopicName = dr["TopicName"].ToString(),
                        ContentId = Convert.ToInt32(dr["ContentId"].ToString()),
                        ContentName = dr["ContentName"].ToString(),
                     
                        InterviewQuestionId = Convert.ToInt32(dr["@InterviewQuestionId"].ToString()),
                        InterviewQuestion = dr["InterviewQuestion"].ToString(),
                        Explanation = dr["InterviewExplaination"].ToString(),

                    });

                }
            }
            return Task.FromResult(lst);
        }

        public void RestoreInterviewQuestion(int InterviewQuestionId)
        {
            con.Close();
            con.Open();
            using (SqlCommand cmd = new SqlCommand("sp_InterviewQuestions", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action","restore");
                cmd.Parameters.AddWithValue("@InterviewQuestionId", InterviewQuestionId);
                int cnt = cmd.ExecuteNonQuery();
            }
        }

        public void UpdateInterviewQuestion(TopicAndContentWiseInterviewQuestionsModel interviewQuestion)
        {
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_InterviewQuestions", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "insert");
            cmd.Parameters.AddWithValue("@McqsQuestionId", interviewQuestion.InterviewQuestionId);
            cmd.Parameters.AddWithValue("@ContentId", interviewQuestion.ContentId);
            cmd.Parameters.AddWithValue("@InterviewQuestion", interviewQuestion.InterviewQuestion);
            cmd.Parameters.AddWithValue("@Explaination", interviewQuestion.Explanation);
            int cnt = cmd.ExecuteNonQuery();
        }
    }
}
