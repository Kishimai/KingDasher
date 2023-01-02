using UnityEngine; // GENERATED USING CHATGPT AND OPTIMIZED

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager Instance;
    public int HighScore;

    private void Awake(){
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else{
            Destroy(gameObject);
        }
    }

    private void Start(){
        HighScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    public void SaveHighScore(int score){
        if (score > HighScore){
            HighScore = score;
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
        }
    }
}
