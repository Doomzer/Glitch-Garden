using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    GameObject defenderParent;

    const string DEFENDER_PARENT_NAME = "Defenders";

    private void Start()
    {
        CreateDefenderParent();
    }

    void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if(!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown()
    {
        if(defender)
            AttemptToSpawn(GetSquareClicked());
    }

    public void AttemptToSpawn(Vector2 pos)
    {
        var starDisplay = FindObjectOfType<StarsDisplay>();
        int cost = defender.GetStarCost();
        if(starDisplay.HaveEnoughStars(cost))
        {
            SpawnDefender(pos);
            starDisplay.SpendStars(cost);
        }
    }

    Vector2 GetSquareClicked()
    {
        Vector2 pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(pos);
        return SnapToGrid(worldPos);
    }

    Vector2 SnapToGrid(Vector2 pos)
    {
        float newX = Mathf.RoundToInt(pos.x);
        float newY = Mathf.RoundToInt(pos.y);
        return new Vector2(newX, newY);
    }

    void SpawnDefender(Vector2 pos)
    {
        Defender newDefender = Instantiate(defender, pos, Quaternion.identity) as Defender;
        newDefender.transform.parent = defenderParent.transform;
    }

    public void SetDefender(Defender newDefender)
    {
        defender = newDefender;
    }
}
