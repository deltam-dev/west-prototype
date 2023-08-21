using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    private bool estado = true;

    //CREAR EL SINGELTON
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<UIManager>();
                if (_instance != null)
                {
                    GameObject go = new GameObject();
                    go.name = typeof(UIManager).Name;
                    _instance = go.AddComponent<UIManager>();
                    DontDestroyOnLoad(go);
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //Metodos del UI Manager

    public void Crear()
    {
        UnityEngine.Debug.Log("El UIManager fue Creado");
    }
    public void ChangeScene(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }

    
    public void Pause()
    {
        GameObject canvasObject = GameObject.Find("CanvasController");
        Transform canvasPause = canvasObject.transform.Find("CanvasPause");


        if (canvasPause != null)
        {
            //si estdo es true se pausa 
            if (estado)
            {

                canvasPause.gameObject.SetActive(true);
                Time.timeScale = 0f;
                estado = !estado;
            }
            else
            {
                canvasPause.gameObject.SetActive(false);
                Time.timeScale = 1.0f;
                estado = !estado;
            }
        }
    }

}
