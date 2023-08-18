using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public void PauseQuit()
    {
        UIManager.Instance.Pause();
    }

    public void MenuPrincipal()
    {
        UIManager.Instance.ChangeScene("MainMenu");
    }

    public void PauseRestart() {
        //aqui debria haber una instancia del game controller que reinicie todo
        Debug.Log("boton reiniciar presionado");
    }

    public void Jugar()
    {
        UIManager.Instance.ChangeScene("Game");
    }

    public void Opciones()
    {
        Debug.Log("boton Opciones presionado");
    }

    public void Creditos()
    {
        Debug.Log("boton Creditos presionado");
    }
}
