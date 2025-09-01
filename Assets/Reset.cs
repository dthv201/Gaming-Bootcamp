using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Reset : MonoBehaviour
{

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

}