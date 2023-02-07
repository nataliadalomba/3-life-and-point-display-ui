using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager instance;
    [SerializeField] private TextMeshProUGUI pointText;

    private int pointScore;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        pointText.text = pointScore.ToString();
    }

    public void AddPoint() {
        pointScore++;
        pointText.text = pointScore.ToString();
    }
}
