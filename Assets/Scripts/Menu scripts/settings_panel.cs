using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settings_panel : MonoBehaviour
{
    [SerializeField] private Text volume_txt;
    [SerializeField] public Slider volumeSlider;

    void volume() {
        int currentVolume = (int)volumeSlider.value;
            volume_txt.text = ""+ currentVolume;
        }
}
