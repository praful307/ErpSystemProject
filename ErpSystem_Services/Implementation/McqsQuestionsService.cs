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
    public class McqsQuestionsService : IMcqsQuestionsService
    {
        SqlConnection con = new SqlConnection(ConnectionString.Connection);
        public void AddContentMcqsQuestions(TopicAndContentWiseMcqsQuestionsModel mcqsQuestions)
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
            using (SqlCommand cmd = new SqlCommand("sp_ContentMcqsQuestions", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "delete");
                cmd.Parameters.AddWithValue("@McqsQuestionId", mcqsQuestionId);
                int cnt = cmd.ExecuteNonQuery();
            }
        }

        public Task<List<TopicAndContentWiseMcqsQuestionsModel>> GetAllContentMcqsQuestions()
        {
            con.Close();
            List<TopicAndContentWiseMcqsQuestionsModel> lst = new List<TopicAndContentWiseMcqsQuestionsModel>();
            con.Open();
            using (SqlCommand cmd = new SqlCommand("sp_FetchContentMcqsQuestions", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AnswerId", 0);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lst.Add(new TopicAndContentWiseMcqsQuestionsModel
                    {
                        McqsQuestionId = Convert.ToInt32(dr["InterviewQuestionId"].ToString()),
                        Question = dr["Question"].ToString(),
                        OptionA = dr["OptionA"].ToString(),
                        OptionB = dr["OptionB"].ToString(),
                        OptionC = dr["OptionC"].ToString(),
                        OptionD = dr["OptionD"].ToString(),
                        CorrectAnswer = dr["CorrectAnswer"].ToString(),
                        ContentId = Convert.ToInt32(dr["ContentId"].ToString()),
                        ContentName = dr["ContentName"].ToString()
                    });
                }

            }
            return Task.FromResult(lst);
        }

        public Task<List<TopicAndContentWiseMcqsQuestionsModel>> GetContentWiseMcqsQuestion(int contentId)
        {
            con.Close();
            List<TopicAndContentWiseMcqsQuestionsModel> lst = new List<TopicAndContentWiseMcqsQuestionsModel>();
            con.Open();
            using (SqlCommand cmd = new SqlCommand("sp_ContentWiseMcqsQuestions", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ContentId", contentId);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lst.Add(new TopicAndContentWiseMcqsQuestionsModel
                    {
                        ContentId = Convert.ToInt32(dr["ContentId"].ToString()),
                        ContentName = dr["ContentName"].ToString(),
                        McqsQuestionId = Convert.ToInt32(dr["InterviewQuestionId"].ToString()),
                        Question = dr["Question"].ToString(),
                        OptionA = dr["OptionA"].ToString(),
                        OptionB = dr["OptionB"].ToString(),
                        OptionC = dr["OptionC"].ToString(),
                        OptionD = dr["OptionD"].ToString(),
                        CorrectAnswer = dr["CorrectAnswer"].ToString()

                    });

                }

            }
            return Task.FromResult(lst);
        }

        public async Task<TopicAndContentWiseMcqsQuestionsModel> GetMcqsQuestionsById(int mcqsQuestionId)
        {
            TopicAndContentWiseMcqsQuestionsModel contentQuestion = null;

            using (SqlConnection con = new SqlConnection(ConnectionString.Connection))
            {
                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("sp_FetchContentMcqsQuestions", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@McqsQuestionId", mcqsQuestionId);

                    using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
                    {
                        if (await dr.ReadAsync())
                        {
                            contentQuestion = new TopicAndContentWiseMcqsQuestionsModel()
                            {
                                ContentId = Convert.ToInt32(dr["ContentId"]),
                                ContentName = dr["ContentName"].ToString(),
                                McqsQuestionId = Convert.ToInt32(dr["McqsQuestionId"]), // fixed
                                Question = dr["Question"].ToString(),
                                OptionA = dr["OptionA"].ToString(),
                                OptionB = dr["OptionB"].ToString(),
                                OptionC = dr["OptionC"].ToString(),
                                OptionD = dr["OptionD"].ToString(),
                                CorrectAnswer = dr["CorrectAnswer"].ToString()
                            };
                        }
                    }
                }
            }

            return contentQuestion;
        }


        public Task<List<TopicAndContentWiseMcqsQuestionsModel>> GetTopicWiseInterviewQuestionsById(int topicId)
        {
            con.Close();
            List<TopicAndContentWiseMcqsQuestionsModel> lst = new List<TopicAndContentWiseMcqsQuestionsModel>();
            con.Open();
            using (SqlCommand cmd = new SqlCommand("sp_ContentWiseMcqsQuestions", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("TopicId", topicId);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lst.Add(new TopicAndContentWiseMcqsQuestionsModel
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
                        CorrectAnswer = dr["CorrectAnswer"].ToString()

                    });

                }

            }
            return Task.FromResult(lst);

        }

        public void RestoreContentMcqsQuestions(int mcqsQuestionId)
        {
            con.Close();
            con.Open();
            using (SqlCommand cmd = new SqlCommand("sp_ContentMcqsQuestions", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "restore");
                cmd.Parameters.AddWithValue("@@McqsQuestionId", mcqsQuestionId);


                int cnt = cmd.ExecuteNonQuery();

            }
        }

        public void UpdateContentMcqsQuestions(TopicAndContentWiseMcqsQuestionsModel mcqsQuestions)
        {
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ContentMcqsQuestions", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "update");
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


        }
    }
}