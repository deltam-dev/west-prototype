using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    public GameObject tl_hud;
    public GameObject prefab;

    int scale = 32;
    int offset = 32;

    void Start()
    {
        
    }

    public GameObject addRelic(int index) {
        GameObject relic = Instantiate(prefab, tl_hud.transform, false);
        relic.transform.localPosition = new Vector3(500 + (scale * index) + (offset * (index -1)), -40, 0);
        relic.transform.localScale = new Vector3(scale, scale, scale);
        return relic;
    }
}
