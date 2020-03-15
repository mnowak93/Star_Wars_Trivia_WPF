
namespace SWTrivia
{
    class Question
    {
        private string questionTxt = "";
        private string correctAnwser = "";
        private bool used = false;


        public Question()
        {

        }

        public Question(string qTxt, string aTxt, string bTxt, string cTxt, string dTxt, string corAnwser)
        {
            questionTxt = qTxt + "\nA: " + aTxt + "\nB: " + bTxt + "\nC: " + cTxt + "\nD: " + dTxt;
            correctAnwser = corAnwser;
        }

        public string QuestionTxt
        {
            get { return questionTxt; }
        }

        public bool Used
        {
            get { return used; }
        }

        public bool CheckAnswer(string ch)
        {
            if (ch.ToUpper() == correctAnwser.ToUpper()) return true;
            else return false;
        }

        public void IsUsed()
        {
            used = true;
        }
    }
}