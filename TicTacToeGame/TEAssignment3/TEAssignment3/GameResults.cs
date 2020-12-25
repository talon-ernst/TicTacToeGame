using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAssignment3
{
    public class GameResults
    {

        public int gameID { get; set; }
        public string winner { get; set; }


        public GameResults()
        {

        }

        public GameResults(int _gameID, string _winner)
        {
            gameID = _gameID;
            winner = _winner;
        }

        public override string ToString()
        {
            return "Match: " + gameID + " " + winner;
        }

    }
}
