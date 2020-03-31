using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePoints : MonoBehaviour
{
    //[SerializeField]
    //private Image _currentScore;

    [SerializeField]
    private Transform _Bar;

    [SerializeField]
    private IntVariable CurrentScore;

    void Update()
    {
        _Bar.localScale = new Vector2((float)CurrentScore.Value / 400f, 1);
    }
}
