namespace SaveData
{
    [System.Serializable]
    public class PlayerProfile
    {
        public string name;
        public int coins;
        public int maxScore;

        public PlayerProfile()
        {
            name = "Player";
            coins = 0;
            maxScore = 0;
        }
    }
}


