using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SampleSFXSound : MonoBehaviour
{
    [SerializeField] Slider SFXslider;
    [SerializeField] AudioSource SFXAudioSource;
    [SerializeField] AudioClip jumpSound;

    private bool sliderPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        SFXslider.onValueChanged.AddListener(delegate { OnSliderValueChanged(); });

    }

    private void Update()
    {
        if (sliderPressed && Input.GetMouseButtonUp(0))

        {
            SFXAudioSource.PlayOneShot(jumpSound);
        }
    }

    void OnSliderValueChanged()
    {
        // Update the flag to indicate if the slider is being pressed
        sliderPressed = SFXslider.interactable;
    }
}
