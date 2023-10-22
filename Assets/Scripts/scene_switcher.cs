using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_switcher : MonoBehaviour
{
    public void scene_change(string scene_name)
    {
        SceneManager.LoadScene(scene_name); 
    }
}
