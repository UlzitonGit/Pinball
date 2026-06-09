using UnityEngine;

public class ScoreStorage
{
    public int Score => score;
    public int Combo => combo;
    
    private int score;
    private int combo = 1;


    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd * combo;
        combo++;
    }

    public void ClearCombo()
    {
        combo = 1;
    }
}
