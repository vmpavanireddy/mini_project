using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{
    public void playgame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
