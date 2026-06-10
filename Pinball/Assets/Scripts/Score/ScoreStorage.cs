using UnityEngine;

public class ScoreStorage
{
    public ObservableValue<float> Score { get; set; }
    public ObservableValue<int> Combo { get; set; }
    
    private int score;
    private int combo = 1;

    public ScoreStorage()
    {
        Score = new ObservableValue<float>();
        Combo = new ObservableValue<int>();
    }
    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd * combo;
        combo++;
        
        Score.Value = score;
        Combo.Value = combo;
    }

    public void ClearCombo()
    {
        combo = 1;
        
        Combo.Value = combo;
    }
}
