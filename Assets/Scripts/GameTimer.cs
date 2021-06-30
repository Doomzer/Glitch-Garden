using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Level timer in sec.")]
    [SerializeField] float levelTime = 10f;
    bool levelFinished = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (levelFinished)
            return;

        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        bool timerFinish = (Time.timeSinceLevelLoad >= levelTime);

        if(timerFinish)
        {
            levelFinished = true;
            FindObjectOfType<LevelController>().LevelTimerFinished();
        }
    }
}
