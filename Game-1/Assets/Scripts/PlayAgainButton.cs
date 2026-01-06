using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainButton : MonoBehaviour
{
    /// <summary>
    /// Reloads the scene, allowing the player to play again
    /// </summary>
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
