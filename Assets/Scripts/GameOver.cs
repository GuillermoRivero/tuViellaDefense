using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public Text roundsText;

    void OnEnable()
    {
        Debug.Log("Number of rounds -> " + PlayerStats.Rounds);
        roundsText.text = PlayerStats.Rounds.ToString();
    }

    public void Retry() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu() {
        Debug.Log("Go to menu.");
    }
}
