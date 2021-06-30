using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] int baseHealth = 3;
    int health;
    Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        health = baseHealth - PlayerPrefsController.GetDifficulty();
        healthText = GetComponent<Text>();
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        healthText.text = health.ToString();
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health > 0)
            UpdateDisplay();

        if (health <= 0)
        {
            FindObjectOfType<LevelController>().HandleLose();
        }
    }
}
