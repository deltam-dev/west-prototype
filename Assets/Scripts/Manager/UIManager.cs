using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;

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
        Time.timeScale = 0f;

    }

}
