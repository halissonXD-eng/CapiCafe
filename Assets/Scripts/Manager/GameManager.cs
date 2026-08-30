using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    private void Awake() 
    {
        if(instance == null)
        {
            instance = this;
        }    
        else
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }

    public void CambioEscena(int Escena)
    {
        SceneManager.LoadScene(Escena);
    }

    //este srive para cuando se carga la escena el tiempo vuelva a la velocidad normal
    public void CambioEscenaTiempo(int Escena)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(Escena);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
