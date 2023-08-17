
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class FireRatioBar : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text hb_text_fire_rate;
    public Slider hb_slider_fire_rate;

    public void setWaitFireShot()
    {
        hb_slider_fire_rate.value = 0;
        hb_text_fire_rate.text = "0";
    }


    public void setWaitFireShot(int value)
    {
        hb_slider_fire_rate.value = value;
        hb_text_fire_rate.text = value > 100 ? "100" : value.ToString();
    }
}
