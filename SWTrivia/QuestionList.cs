using System.Collections.Generic;
using System.IO;

namespace SWTrivia
{
    class QuestionList
    {
        private List<Question> qLst= new List<Question>();

        public QuestionList (string path)
        {
            using (var reader = new StreamReader(path))
            {                
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    qLst.Add(new Question(values[0], values[1], values[2], values[3], values[4], values[5]));
                }
            }
        }

        public List<Question> QLst
        {
            get { return qLst; }
        }


    }
}
