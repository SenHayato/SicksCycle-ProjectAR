using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIButtonScript : MonoBehaviour
{
    public Button Button;
    public string BackScene;
    public string NextScene;

    public void BackAction()
    {
        SceneManager.LoadScene(BackScene);
    }

    public void NextAction()
    {
        SceneManager.LoadScene(NextScene);
    }
}
