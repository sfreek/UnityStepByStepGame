using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBarBehaviour : MonoBehaviour
{

    public Slider Slider;
    public Color low;
    public Color high;
    public Vector3 Offset;

    public void SetHealth(float health, float maxHelth)
    {
        Slider.gameObject.SetActive(health < maxHelth);
        Slider.value = health;
        Slider.maxValue = maxHelth;

        Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, Slider.normalizedValue);
    }

    // Update is called once per frame
    void Update()
    {
        Slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
    }
}
