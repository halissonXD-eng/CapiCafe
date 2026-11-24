using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public Fader _fader;

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
    void Start()
    {
        _fader = GameObject.Find("Fade").GetComponent<Fader>();
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

    public void CambiarEscenaConFade(int escena)
    {
        StartCoroutine(CambioFade(escena));
    }

    public IEnumerator CambioFade(int Escena)
    {
        _fader.FadeIn(0.8f);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(Escena);
    } 

    public void ExitGame()
    {
        Application.Quit();
    }
}
