using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ObjectLvl1 : MonoBehaviour
{
    private Rigidbody _rb;

    public IntVariable _pointsLvl1;

    private int _objectHP = 65;
    //public GameObject _player;

    [SerializeField]
    private Animator _animUI;

    [SerializeField]
    private GameObject _explosion;

    //[SerializeField]
    //private TextMeshProUGUI _tutoCompleted;


    //[SerializeField]
    //private GameObject _points;

    //[SerializeField]
    //private GameObject _player;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _pointsLvl1.Value = 0;

    }

    // Update is called once per frame
    void Update()
    {

        if (_pointsLvl1.Value <= 5000f)
        {
            if (_rb.velocity.y > 0.3f)
            {

                //Debug.Log(_rb.velocity.y);
                _pointsLvl1.Value += 1;
                _objectHP -= 1;


            }
            if (_rb.velocity.y > 0.7f)
            {
                //Debug.Log(_rb.velocity.y);
                _pointsLvl1.Value += 3;
            }
            if (_rb.velocity.y > 1f)
            {
                //Debug.Log(_rb.velocity.y);
                _pointsLvl1.Value += 5;
                _animUI.SetTrigger("GetsKicked");
                //Instantiate(_points, _player.transform.position, Quaternion.identity);
            }
        }

        if (_pointsLvl1.Value >= 5000)
        {
            //_tutoCompleted.alpha = 1;
            StartCoroutine("LevelCompleted");
            //_animUI.SetBool("TutoCompleted", true);
        }


        if (_objectHP <= 0)
        {
            StartCoroutine("DestroyObject");
        }
    }



    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(_explosion, gameObject.transform.position, Quaternion.identity);

        Destroy(gameObject);
    }

    IEnumerator LevelCompleted()
    {
        _animUI.SetBool("LevelCompleted", true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Menu");

    }
}
