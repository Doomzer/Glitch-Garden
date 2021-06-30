using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsDisplay : MonoBehaviour
{
    [SerializeField] int basrStarts = 400;
    int starts;
    Text starsText;

    // Start is called before the first frame update
    void Start()
    {
        starsText = GetComponent<Text>();
        starts = basrStarts - PlayerPrefsController.GetDifficulty() * 100;
        UpdateDisplay();
    }

    void UpdateDisplay()
    {  
        starsText.text = starts.ToString();
    }

    public void AddStars(int amount)
    {
        starts += amount;
        UpdateDisplay();
    }

    public void SpendStars(int amount)
    {
        if (starts >= amount)
        {
            starts -= amount;
            UpdateDisplay();
        }
    }

    public bool HaveEnoughStars(int amount)
    {
        return starts >= amount;
    }
}
