using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(bool endless)
    {
        if (endless)
        {
            SceneManager.LoadScene("EndlessGame");
            return;
        }
        SceneManager.LoadScene("Level1");
    }
}
