using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    [SerializeField]
    private GameObject _createDestroyed;

    public void DestroyCreate()
    { 
        Instantiate(_createDestroyed, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }


}
