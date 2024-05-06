using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TextScaleHandler : MonoBehaviour
{
    RectTransform m_RectTransform;
    [SerializeField] Scrollbar fontSizeSlider; //reference to Font Slider object
    private float lastSliderValue; //records the last slider value
    private float newFontSize;

    void Start()
    {

        m_RectTransform = GetComponent<RectTransform>();
        fontSizeSlider.onValueChanged.AddListener(delegate { ChangeFontSize(); });

        lastSliderValue = fontSizeSlider.value; //initialize the last slider value
    }

  

    public void ChangeFontSize()
    {
        // Get the current font size from the slider value
        float sliderValue = fontSizeSlider.value;

        // Determine if the slider value changed in the positive direction
        bool sliderIncreased = sliderValue > lastSliderValue;
        bool sliderDecreased = sliderValue < lastSliderValue;

        // Update the last slider value
        lastSliderValue = sliderValue;


        // Iterate through all loaded scenes
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            GameObject[] rootObjects = scene.GetRootGameObjects();

            // Find all TextMeshProUGUI objects in the scene
            foreach (GameObject rootObject in rootObjects)
            {
                TextMeshProUGUI[] textMeshes = rootObject.GetComponentsInChildren<TextMeshProUGUI>(true);

                if (sliderIncreased)
                {
                    // Change the Font Size for each TextMeshProUGUI object found
                    foreach (TextMeshProUGUI textMesh in textMeshes)
                    {
                        // Get the original font size
                        float originalFontSize = textMesh.fontSize;

                        // Calculate the new font size based on the scrollbar value change direction
                        newFontSize = originalFontSize + 20;

                        // Apply the new font size (make sure it doesn't go below 0)
                        textMesh.fontSize = (int)Mathf.Max(0, newFontSize);
                    }
                }
                if (sliderDecreased)
                {
                    // Change the Font Size for each TextMeshProUGUI object found
                    foreach (TextMeshProUGUI textMesh in textMeshes)
                    {
                        // Get the original font size
                        float originalFontSize = textMesh.fontSize;

                        // Calculate the new font size based on the scrollbar value change direction
                        newFontSize = originalFontSize - 20;

                        // Apply the new font size (make sure it doesn't go below 0)
                        textMesh.fontSize = (int)Mathf.Max(0, newFontSize);
                    }
                }

            }
        }

    }
}