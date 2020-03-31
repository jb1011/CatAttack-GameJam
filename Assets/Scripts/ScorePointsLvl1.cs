using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePointsLvl1 : MonoBehaviour
{

    [SerializeField]
    private Transform _Bar;

    [SerializeField]
    private IntVariable CurrentScore;

    void Update()
    {
        _Bar.localScale = new Vector2((float)CurrentScore.Value / 5000f, 1);
    }
}
