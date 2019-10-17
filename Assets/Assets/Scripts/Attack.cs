using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    //Vurup vurmadığının testi çiçin bool değişkeni
    private bool _canDamage=true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit" + other.name);
        IDamagable hit = other.GetComponent<IDamagable>();
        if (hit != null)
        {
            if (_canDamage == true) { 
            hit.Damage();
                _canDamage = false;
                StartCoroutine(ResetDamage());
            }
        }
    }
    IEnumerator ResetDamage()
    {
        yield return new WaitForSeconds(0.5f);
        _canDamage = true;
    }
}
