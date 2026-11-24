using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Fader : MonoBehaviour
{
    public GameObject _FondoNegro;
    Image ImagenNegra;
    CanvasScaler _canvasScaler;
    RectTransform SliderNegro;

    public bool direccionSlider; //Por defecto siempre ira a la derecha

    public float Resolucion;
    public bool AlIniciar = false; //quieres tener un fundido a negro al inicar la escena?
    public float FundidoTiempoAlIniciar;
    // Start is called before the first frame update
    void Start()
    {
        if(_FondoNegro == null)
        {
            _FondoNegro = GameObject.Find("Fondo Negro");
        }
        _canvasScaler = GetComponent<CanvasScaler>();
        ImagenNegra = _FondoNegro.GetComponent<Image>();
        SliderNegro = GameObject.Find("Fondo Delizable").GetComponent<RectTransform>();

        Resolucion = _canvasScaler.referenceResolution.x;

        if(AlIniciar == true)
            ImagenNegra.color = new Color(0f,0f,0f,1f);
            FadeOut(FundidoTiempoAlIniciar);
    }

    // Pantalla Negra -> Normal
    public void FadeOut(float Time)
    {
        ImagenNegra.DOFade(0f,Time);
    }

    // Pantalla normal -> negro
    public void FadeIn(float Time)
    {
        ImagenNegra.DOFade(1f,Time);
    }

    // Pantalla Normal -> Negra -> Espera -> Normal
    public IEnumerator PigPogFade(float TimeIn_Out,float TimeWait)
    {
        FadeIn(TimeIn_Out);
        yield return new WaitForSeconds(TimeWait);
        FadeOut(TimeIn_Out);
    }

    // Pantalla Negra -> Espera -> Normal
    public IEnumerator FadeInWait(float Time, float TimeWait)
    {
        FadeIn(Time);
        yield return new WaitForSeconds(TimeWait);
    }

    public void MoveFade(bool direction)
    {
        if (direction!) //Empieza de derecha a izquierda
        {
            Move(-Resolucion,0.7f);
        }
        else //Empieza de iaquierda a derecha
        {
            Move(Resolucion,0.7f);
        }
    }

    void Move(float resolucion, float Time)
    {
        SliderNegro.localPosition = new Vector3 (resolucion,0,0);
        SliderNegro.DOLocalMoveX(-resolucion,Time).SetEase(Ease.InOutQuad);
    }

}
