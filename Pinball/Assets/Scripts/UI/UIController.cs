using TMPro;
using UnityEngine;
using Zenject;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI comboText;
    private int score;
    private ScoreStorage scoreStorage;
    
    [Inject]
    private void Construct(ScoreStorage _scoreStorage)
    {
        scoreStorage = _scoreStorage;
        _scoreStorage.Score.OnValueChanged += UpdateScore;
        _scoreStorage.Combo.OnValueChanged += UpdateCombo;
    }

    private void UpdateScore(float score)
    {
        scoreText.text = $"SCORE: {score}";
    }

    private void UpdateCombo(int combo)
    {
        comboText.text = $"COMBO: {combo}";
    }
}
