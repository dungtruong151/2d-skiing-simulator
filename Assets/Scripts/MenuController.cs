using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void LoadLevel(int level)
    {
        PlayerPrefs.SetInt("SelectedLevel", level);
        SceneManager.LoadScene("/Scenes/GameScene");      
    }
}
