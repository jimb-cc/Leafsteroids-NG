using UnityEngine;
using UnityEngine.SceneManagement;
 
public class startGameSwitcher : MonoBehaviour
{
    public void NextScene(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }
}
