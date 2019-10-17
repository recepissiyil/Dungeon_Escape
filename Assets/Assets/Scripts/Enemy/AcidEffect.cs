using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidEffect : MonoBehaviour
{
    private void Start()
    {
        // Acid oluştuktan 5 saniye sonra kendini yok et
        Destroy(this.gameObject, 5.0f);
    }
    public void Update()
    {
        //Acid effectimizin sağa doğru 3 metre hızla ötelenmesi
        //Translate belirlediğin yöne doğru hareketi sağlar
        transform.Translate(Vector3.right * 3 * Time.deltaTime);
    }
    //Acid'imizin Player ile temasında olacaklar
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Player'imizn sahip olduğu Tag'i belirttik.
        if (other.tag == "Player")
        {
            //Damage() IDamagable interface'inde muhafaza edildiği  için çağırdık
            IDamagable hit = GetComponent<IDamagable>();

            if (hit != null)
            {
                hit.Damage();
                Destroy(this.gameObject);
            }
        }
    }
}
