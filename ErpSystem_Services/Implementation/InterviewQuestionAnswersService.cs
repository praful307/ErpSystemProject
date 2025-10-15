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
    public class InterviewQuestionAnswersService : IInterviewQuestionAnswersService
    {
        SqlConnection con = new SqlConnection(ConnectionString.Connection);
        public void AddInterviewQuestionAnswer(InterviewQuestionAnswersModel interviewQuestionAnswer)
        {
            con.Open();
            using(SqlCommand cmd= new SqlCommand("sp_InterviewQuestionAnswers",con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "insert");
                cmd.Parameters.AddWithValue("@InterviewQuestionId", interviewQuestionAnswer.InterviewQuestionId);
                cmd.Parameters.AddWithValue("@InterviewAnswers", interviewQuestionAnswer.InterviewAnswers);
                cmd.Parameters.AddWithValue("@AnswerExplaination", interviewQuestionAnswer.AnswerExplaintion);
                int cnt = cmd.ExecuteNonQuery();
            }
        }

        public void DeleteInterviewQuestionAnswer(int answerId)
        {
            con.Close();
            con.Open();
            using (SqlCommand cmd = new SqlCommand("sp_InterviewQuestionAnswers", con))
            {
                cmd.Parameters.AddWithValue("@Action", "delete");
                cmd.Parameters.AddWithValue("@AnswerId", answerId);
                int cnt = cmd.ExecuteNonQuery();

            }
        }

        public Task<List<InterviewQuestionAnswersModel>> GetAllInterviewQuestionAnswers()
        {
            con.Close();
            List<InterviewQuestionAnswersModel> lat = new List<InterviewQuestionAnswersModel>();
            con.Open();
            using (SqlCommand cmd = new SqlCommand("sp_FetchInterviewQuestionAnswers", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AnswerId", 0);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int topicid = Convert.ToInt32(dr["TopicId"].ToString());
                    string topicname = dr["TopicName"].ToString();
                    string Description = dr["Description"].ToString();
                    InterviewQuestionAnswersModel tm = new InterviewQuestionAnswersModel()
                    {
                        AnswerId = Convert.ToInt32(dr["AnswerId"].ToString()),
                        InterviewAnswers= dr["InterviewAnswers"].ToString(),
                        AnswerExplaintion= dr["AnswerExplaintion"].ToString(),
                        InterviewQuestionId = Convert.ToInt32(dr["InterviewQuestionId"].ToString()),
                        InterviewQuestion = dr["InterviewQuestion"].ToString(),
                        QuestionExplaintion = dr["QuestionExplaination"].ToString(),

                    };
                    lat.Add(tm);
                }


            }
            return Task.FromResult(lat);
        }

        public Task<List<InterviewQuestionAnswersModel>> GetInterviewAnswerByQuestionId(int interviewQuestionId)
        {
            con.Close();
            List<InterviewQuestionAnswersModel> lat = new List<InterviewQuestionAnswersModel>();
            con.Open();
            using (SqlCommand cmd = new SqlCommand("sp_FetchInterviewQuestionAnswers", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@InterviewQuestionId", interviewQuestionId);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int topicid = Convert.ToInt32(dr["TopicId"].ToString());
                    string topicname = dr["TopicName"].ToString();
                    string Description = dr["Description"].ToString();
                    InterviewQuestionAnswersModel tm = new InterviewQuestionAnswersModel()
                    {
                        AnswerId = Convert.ToInt32(dr["AnswerId"].ToString()),
                        InterviewAnswers = dr["InterviewAnswers"].ToString(),
                        AnswerExplaintion = dr["AnswerExplaintion"].ToString(),
                        InterviewQuestionId = Convert.ToInt32(dr["InterviewQuestionId"].ToString()),
                        InterviewQuestion = dr["InterviewQuestion"].ToString(),
                        QuestionExplaintion = dr["QuestionExplaination"].ToString(),

                    };
                    lat.Add(tm);
                }


            }
            return Task.FromResult(lat);
        }

        public Task<InterviewQuestionAnswersModel> GetInterviewQuestionAnswerById(int answerId)
        {
            throw new NotImplementedException();
        }

        public void RetoreInterviewQuestionAnswer(int answerId)
        {
            con.Close();
            con.Open();
            using (SqlCommand cmd = new SqlCommand("sp_InterviewQuestionAnswers", con))
            {
                cmd.Parameters.AddWithValue("@Action", "restore");
                cmd.Parameters.AddWithValue("@AnswerId", answerId);
                int cnt = cmd.ExecuteNonQuery();

            }
        }

        public void UpdateInterviewQuestionAnswer(InterviewQuestionAnswersModel interviewQuestionAnswer)
        {
            con.Close();
            con.Open();
            using (SqlCommand cmd = new SqlCommand("sp_InterviewQuestionAnswers", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "update");
                cmd.Parameters.AddWithValue("@AnswerId", interviewQuestionAnswer.AnswerId);
                cmd.Parameters.AddWithValue("@InterviewQuestionId", interviewQuestionAnswer.InterviewQuestionId);
                cmd.Parameters.AddWithValue("@InterviewAnswers", interviewQuestionAnswer.InterviewAnswers);
                cmd.Parameters.AddWithValue("@AnswerExplaination", interviewQuestionAnswer.AnswerExplaintion);
                int cnt = cmd.ExecuteNonQuery();
            }
        }
    }
}
