using UnityEngine;
using UnityEngine.UI;  // This is needed to use UI elements like Text

public class ScoreManager : MonoBehaviour
{
    public int score = 0;               // This holds the player’s score
    public Text scoreText;             // This will be linked to the UI Text in the Inspector

    public void AddPoint()
    {
        score ++;                         // Add point
        scoreText.text = "Score: " + score;      // Update UI text
    }
}
