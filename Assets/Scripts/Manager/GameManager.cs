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
}
