using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master volume";
    const string DIFFICULTY_KEY = "difficulty";

    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;

    const int MIN_DIFFICULTY = 0;
    const int MAX_DIFFICULTY = 2;

    public static void SetMasterVolume(float value)
    {
        if(value >= MIN_VOLUME && value <= MAX_VOLUME)
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, value);
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void SetDifficulty(int value)
    {
        if (value >= MIN_DIFFICULTY && value <= MAX_DIFFICULTY)
            PlayerPrefs.SetInt(DIFFICULTY_KEY, value);
    }

    public static int GetDifficulty()
    {
        return PlayerPrefs.GetInt(DIFFICULTY_KEY);
    }
}
