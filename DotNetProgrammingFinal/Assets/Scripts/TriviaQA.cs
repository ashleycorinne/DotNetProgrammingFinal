using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;
using Mono.Data.Sqlite;

public class TriviaQA {

	public List<TriviaQuestion> TriviaQuestions { get; set; }

    public bool IsCorrectAnswer(int id, char guess)
    {
        TriviaQuestion q = TriviaQuestions.Where(x => x.Id == id).FirstOrDefault();
        if (q!= null && q.Answer == guess)
            return true;
        return false;
    }

    public TriviaQuestion GetRandomTriviaQuestion()
    {
        TriviaQuestion q = new TriviaQuestion() ;
        if (TriviaQuestions.Count > 0)
        {
            q = TriviaQuestions[0];
            TriviaQuestions.RemoveAt(0);
            return TriviaQuestions[0];
        }
        return q;
    }

  

    public void GetTriviaQuestions()
    {
		string connectionString = "URI=file:" + Application.dataPath + "/TRIVIA_MAZE.sqlite";

		using (SqliteConnection connection = new SqliteConnection (connectionString)) {
			connection.Open ();

			using (SqliteCommand command = connection.CreateCommand ()) {
				command.CommandText = "SELECT * FROM QUESTIONS WHERE ID=105";

				using (SqliteDataReader reader = command.ExecuteReader ()) {
					while (reader.Read ()) {
						Debug.Log ("ID: " + reader ["ID"]);
						Debug.Log ("First Question: " + reader ["QUESTION"]);
						Debug.Log ("First Answer: " + reader ["ANS_A"]);
						Debug.Log ("Second Answer: " + reader ["ANS_B"]);
						Debug.Log ("Third Answer: " + reader ["ANS_C"]);
						Debug.Log ("Fourth Answer: " + reader ["ANS_D"]);
						Debug.Log ("Actual Answer: " + reader ["ANSWER"]);
					}

					reader.Close ();
				}
			}

			connection.Close ();
		}
    }

    public class TriviaQuestion
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public char Answer { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }

    }
}

