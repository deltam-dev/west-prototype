using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    // UI Elements
    public TMP_Text hb_text;
    public Slider hb_slider;
    
    public void setMaxHealth(int maxHealth)
    {
        hb_slider.maxValue = maxHealth;
    }

    public void setHealth(int health)
    {
        hb_slider.value = health;
        hb_text.text = "" + health;
    }
}
