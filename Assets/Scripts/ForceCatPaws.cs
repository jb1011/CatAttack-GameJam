using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceCatPaws : MonoBehaviour
{
    [SerializeField]
    private float ForcePaw;

    public BoolVariable IsHitting;
    private void Start()
    {
        IsHitting.Value = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Object")
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * ForcePaw);
            StartCoroutine("IsHit");
        }
    }

    IEnumerator IsHit()
    {
        IsHitting.Value = true;
        yield return new WaitForSeconds(3f);
        IsHitting.Value = false;
    }


}
