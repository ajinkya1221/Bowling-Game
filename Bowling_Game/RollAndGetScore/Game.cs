namespace RollAndGetScore
{
    interface IGame
    {
        void Roll(int currentScore);
        int GetScore();
    }

    public class Game:IGame
    {
        private readonly int[] _rollArray = new int[21];
        
        private int _currentRoll;
        private int _totalScore;
        private int _rollCount;

        public void Roll(int currentScore)
        {
            _rollArray[_currentRoll] = currentScore;
            _currentRoll++;
        }

        public int GetScore()
        {            
            for (int frameCount = 0; frameCount < 10; frameCount++)
            {                    
                if (IsStrike())
                {
                    _totalScore = _totalScore + GetFrameScore(_rollCount) + GetBonus(_rollCount);
                    _rollCount++;
                }                                    
                else if (IsSpare())
                {
                    _totalScore = _totalScore + GetFrameScore(_rollCount) + GetBonus(_rollCount);
                    _rollCount = _rollCount + 2;
                }                    
                else
                {
                    _totalScore = _totalScore + GetFrameScore(_rollCount) + GetBonus(_rollCount);
                    _rollCount = _rollCount + 2;
                }
            }
                return _totalScore;
        }

        private bool IsStrike()
        {
            if (_rollArray[_rollCount] == 10)
                return true;
            return false;
        }

        private bool IsSpare()
        {
            if (_rollArray[_rollCount] + _rollArray[_rollCount + 1] == 10)            
                return true;            
            return false;
        }

        private int GetFrameScore(int rollCount)
        {
            if (IsSpare() || IsStrike())            
                return 10;            
            return _rollArray[rollCount] + _rollArray[rollCount + 1];
        }

        private int GetBonus(int rollCount)
        {
            if (IsStrike())            
                return _rollArray[rollCount + 1] + _rollArray[rollCount + 2];            
            if(IsSpare())            
                return _rollArray[rollCount + 2];            
            return 0;
        }
    }
}
