using ErpSystem_Models;
using ErpSystem_Services.Interface;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem_Services.Implementation
{
    public class McqsQuestionsService : IMcqsQuestionsService
    {
        SqlConnection con = new SqlConnection(ConnectionString.Connection);
        public void AddContentMcqsQuestions(ContentMcqsQuestionsModel mcqsQuestions)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_ContentMcqsQuestions", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "insert");
            cmd.Parameters.AddWithValue("@McqsQuestionId", mcqsQuestions.McqsQuestionId);
            cmd.Parameters.AddWithValue("@ContentId", mcqsQuestions.ContentId);
            cmd.Parameters.AddWithValue("@Question", mcqsQuestions.Question);
            cmd.Parameters.AddWithValue("@OptionA", mcqsQuestions.OptionA);
            cmd.Parameters.AddWithValue("@OptionB", mcqsQuestions.OptionB);
            cmd.Parameters.AddWithValue("@OptionC", mcqsQuestions.OptionC);
            cmd.Parameters.AddWithValue("@OptionD", mcqsQuestions.OptionD);
            cmd.Parameters.AddWithValue("@CorrectOption", mcqsQuestions.CorrectAnswer);
            cmd.Parameters.AddWithValue("@Explanation", mcqsQuestions.AnswerExplaination);
            int cnt = cmd.ExecuteNonQuery();
        }

        public void DeleteContentMcqsQuestions(int mcqsQuestionId)
        {
            con.Close();
            con.Open();
            using(SqlCommand cmd= new SqlCommand("sp_ContentMcqsQuestions",con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "delete");
                cmd.Parameters.AddWithValue("@McqsQuestionId", mcqsQuestionId);
                int cnt = cmd.ExecuteNonQuery();
            }
        }

        public Task<List<ContentMcqsQuestionsModel>> GetAllContentMcqsQuestions()
        {
            con.Close();
            List<ContentMcqsQuestionsModel> lst = new List<ContentMcqsQuestionsModel>();
            con.Open();
            using(SqlCommand cmd= new SqlCommand("sp_FetchContentMcqsQuestions", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AnswerId", 0);
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    lst.Add(new ContentMcqsQuestionsModel
                    {
                        McqsQuestionId = Convert.ToInt32(dr["InterviewQuestionId"].ToString()),
                        Question = dr["Question"].ToString(),
                        OptionA = dr["OptionA"].ToString(),
                        OptionB = dr["OptionB"].ToString(),
                        OptionC = dr["OptionC"].ToString(),
                        OptionD = dr["OptionD"].ToString(),
                        CorrectAnswer = Convert.ToInt32(dr["CorrectAnswer"].ToString()),
                        ContentId = Convert.ToInt32(dr["ContentId"].ToString()),
                        ContentName = dr["ContentName"].ToString()
                    });
                }

            }
            return Task.FromResult(lst);
        }

        public Task<List<ContentMcqsQuestionsModel>> GetContentWiseMcqsQuestion(int contentId)
        {
            con.Close();
            List<ContentMcqsQuestionsModel> lst = new List<ContentMcqsQuestionsModel>();
            con.Open();
            using(SqlCommand cmd= new SqlCommand("sp_ContentWiseMcqsQuestions",con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ContentId", contentId);
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    lst.Add(new ContentMcqsQuestionsModel
                    {
                        ContentId = Convert.ToInt32(dr["ContentId"].ToString()),
                        ContentName = dr["ContentName"].ToString(),
                        McqsQuestionId = Convert.ToInt32(dr["InterviewQuestionId"].ToString()),
                        Question = dr["Question"].ToString(),
                        OptionA = dr["OptionA"].ToString(),
                        OptionB = dr["OptionB"].ToString(),
                        OptionC = dr["OptionC"].ToString(),
                        OptionD = dr["OptionD"].ToString(),
                        CorrectAnswer = Convert.ToInt32(dr["CorrectAnswer"].ToString())
                      
                    });

                }

            }
            return Task.FromResult(lst);
        }

        public Task<ContentMcqsQuestionsModel> GetMcqsQuestionsById(int mcqsQuestionId)
        {
            //    con.Close();
            //    ContentMcqsQuestionsModel contentquetion = null;
            //    con.Open();
            //    using(SqlCommand cmd= new SqlCommand("sp_FetchContentMcqsQuestions",con))
            //    {
            //        cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //        cmd.Parameters.AddWithValue("McqsQuestionId", mcqsQuestionId);
            //        SqlDataReader dr = cmd.ExecuteNonQuery();
            //        while(dr.Read())
            //        {

            //            contentquetion = new ContentMcqsQuestionsModel()
            //            {

            //                ContentId = Convert.ToInt32(dr["ContentId"].ToString()),
            //                ContentName = dr["ContentName"].ToString(),
            //                McqsQuestionId = Convert.ToInt32(dr["InterviewQuestionId"].ToString()),
            //                Question = dr["Question"].ToString(),
            //                OptionA = dr["OptionA"].ToString(),
            //                OptionB = dr["OptionB"].ToString(),
            //                OptionC = dr["OptionC"].ToString(),
            //                OptionD = dr["OptionD"].ToString(),
            //                CorrectAnswer = Convert.ToInt32(dr["CorrectAnswer"].ToString())

            //            };

            //        }
            //    }

            //    return Task.FromResult(contentquetion);

            throw new NotImplementedException();
        }

        public Task<List<ContentMcqsQuestionsModel>> GetTopicWiseInterviewQuestionsById(int topicId)
        {
            con.Close();
            List<ContentMcqsQuestionsModel> lst = new List<ContentMcqsQuestionsModel>();
            con.Open();
            using (SqlCommand cmd = new SqlCommand("sp_ContentWiseMcqsQuestions", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("TopicId", topicId);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lst.Add(new ContentMcqsQuestionsModel
                    {
                        TopicId = Convert.ToInt32(dr["ContentId"].ToString()),
                        TopicName = dr["ContentId"].ToString(),
                        ContentId = Convert.ToInt32(dr["ContentId"].ToString()),
                        ContentName = dr["ContentName"].ToString(),
                        McqsQuestionId = Convert.ToInt32(dr["InterviewQuestionId"].ToString()),
                        Question = dr["Question"].ToString(),
                        OptionA = dr["OptionA"].ToString(),
                        OptionB = dr["OptionB"].ToString(),
                        OptionC = dr["OptionC"].ToString(),
                        OptionD = dr["OptionD"].ToString(),
                        CorrectAnswer = Convert.ToInt32(dr["CorrectAnswer"].ToString())

                    });

                }

            }
            return Task.FromResult(lst);

        }

        public void RestoreContentMcqsQuestions(int mcqsQuestionId)
        {
            throw new NotImplementedException();
        }

        public void UpdateContentMcqsQuestions(ContentMcqsQuestionsModel mcqsQuestions)
        {
            throw new NotImplementedException();
        }

      
    }
}
