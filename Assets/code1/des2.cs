using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class des2 : MonoBehaviour
{
    public GameObject destroyedVersion;
    public float explosionMinForce = 5;
    public float explosionMaxForce = 100;
    public float explosionForceRadius = 10;
    public float fragScaleFactor = 1;
    public GameObject explosionVFX;

    private GameObject fractObj;


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Explode();
            //Destroy(gameObject);
        }
    }

    void Explode()
    {
        transform.Translate(Vector3.right * 2.0f);    //¥k²¾
        transform.Translate(Vector3.forward * 9.0f); //«á²¾
        transform.Translate(Vector3.up * 9.0f);   //¤W²¾
        transform.Rotate(Vector3.forward * 90f);

        fractObj = Instantiate(destroyedVersion, transform.position, transform.rotation) as GameObject;

        foreach (Transform t in fractObj.transform)
        {
            var rb = t.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(Random.Range(explosionMinForce, explosionMaxForce), fractObj.transform.position, explosionForceRadius);

            StartCoroutine(Shrink(t, 2));
        }
        Destroy(fractObj, 5);

        if (explosionVFX != null)
        {
            GameObject exploVFX = Instantiate(explosionVFX, transform.position, transform.rotation) as GameObject;
            Destroy(exploVFX, 1);
        }
        Destroy(gameObject);
    }

    IEnumerator Shrink(Transform t, float delay)
    {
        yield return new WaitForSeconds(delay);

        Vector3 newScale = t.localScale;

        while (newScale.x >= 0)
        {
            newScale -= new Vector3(fragScaleFactor, fragScaleFactor, fragScaleFactor);

            t.localScale = newScale;
            yield return new WaitForSeconds(0.05f);
        }
    }

}