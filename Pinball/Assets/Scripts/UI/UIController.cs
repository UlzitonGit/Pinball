using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI comboText;
    [SerializeField] private TextMeshProUGUI ballsText;
    [SerializeField] private GameObject buttonSpawn;
    [SerializeField] private GameObject endGamePanel;
    [SerializeField] private Button endGameButton;
    private int score;
    private ScoreStorage scoreStorage;
    private BallsCurrencyController ballsCurrency;
    
    [Inject]
    private void Construct(ScoreStorage _scoreStorage, BallsCurrencyController _balls, SceneController _sceneController)
    {
        scoreStorage = _scoreStorage;
        ballsCurrency = _balls;
        _scoreStorage.Score.OnValueChanged += UpdateScore;
        _scoreStorage.Combo.OnValueChanged += UpdateCombo;
        _balls.Balls.OnValueChanged += UpdateBalls;
        _balls.CanSpawnNewBall.OnValueChanged += SpawnNewBallButton;
        endGameButton.onClick.AddListener(_sceneController.RestartGame);
        
        UpdateBalls(_balls.Balls.Value);
    }

    private void UpdateScore(float score)
    {
        scoreText.text = $"SCORE: {score}";
    }

    private void UpdateCombo(int combo)
    {
        comboText.text = $"COMBO: {combo}";
    }

    private void UpdateBalls(int balls)
    {
        ballsText.text = $"Balls remain: {balls}";
     
    }

    private void SpawnNewBallButton(bool spawn)
    {
        if (ballsCurrency.Balls.Value == 0)
        {
            endGamePanel.SetActive(true);
            return;
        }
        buttonSpawn.SetActive(spawn);
    }
}
