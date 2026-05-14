using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // MUST have 'public' here, or Unity will hide it!
    public void PlayGame() 
    { 
        SceneManager.LoadScene("SampleScene"); 
    }
}