using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamge : MonoBehaviour
{
    bool damge = true;

    public KeyCode attackKey = KeyCode.Mouse0; // زر الماوس المستخدم للضرب

    private void Update()
    {
        // التحقق إذا تم النقر على زر الماوس المحدد
        if (Input.GetKeyDown(attackKey))
        {
            //Destroy(gameObject); // تدمير العدو
            damge = true;
            StartCoroutine(playerAttack());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if ( other.tag == "Melee" && damge)
            Destroy(gameObject); // damge method
    }

    IEnumerator playerAttack ()
    {
        yield return new WaitForSeconds(1f);
        damge = false;
    }
}
