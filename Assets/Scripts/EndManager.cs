using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

public class EndManager : MonoBehaviour
{
    void Start()
    {
        // 1. Grab the score from memory
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        
        // 2. FORCE the game to find the text object by its exact name
        GameObject textObj = GameObject.Find("FinalScoreText");

        if (textObj != null)
        {
            TextMeshProUGUI myText = textObj.GetComponent<TextMeshProUGUI>();
            if (myText != null)
            {
                myText.text = "FINAL SCORE: " + finalScore;
            }
        }
    }

    public void RestartGame() 
    { 
        SceneManager.LoadScene("Menu"); 
    }
}