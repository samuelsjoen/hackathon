public class Question
{
    public string Text { get; set; }
    public string Answer { get; set; }

    public List<Question> FollowupQuestions { get; set; }

    public Question(string text, string answer, List<Question> followupQuestions)
    {
        Text = text;
        Answer = answer;
        FollowupQuestions = followupQuestions;
    }
}