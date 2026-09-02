using UnityEngine;

public class DayNightCycle : MonoBehaviour {
    public float cycleDuration = 60.0f;

    public Light sun;

    public float dayIntensity = 1.2f;
    public Color daySunColor = Color.white;
    public Color dayAmbientColor =
        new Color(0.65f, 0.65f, 0.65f);

    public float nightIntensity = 0.05f;
    public Color nightSunColor =
        new Color(0.42f, 0.40f, 0.66f);

    public Color nightAmbientColor =
        new Color(0.09f, 0.08f, 0.18f);

    // All street lamps
    public Light[] streetLights;

    private float timer = 0.0f;
    private bool isDay = true;

    void Start() {
        StartDay();
    }

    void Update() {
        timer += Time.deltaTime;

        if (timer >= cycleDuration) {
            timer = 0.0f;

            if (isDay) {
                StartNight();
            } else {
                StartDay();
            }
        }
    }

    void StartDay() {
        isDay = true;

        sun.intensity = dayIntensity;
        sun.color = daySunColor;

        RenderSettings.ambientLight =
            dayAmbientColor;

        // Turn street lights off
        foreach (Light streetLight in streetLights) {
            streetLight.enabled = false;
        }
    }

    void StartNight() {
        isDay = false;

        sun.intensity = nightIntensity;
        sun.color = nightSunColor;

        RenderSettings.ambientLight =
            nightAmbientColor;

        // Turn street lights on
        foreach (Light streetLight in streetLights) {
            streetLight.enabled = true;
        }
    }
}