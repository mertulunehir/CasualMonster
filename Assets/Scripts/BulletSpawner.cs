using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    private Vector2 forceVector;

    public GameObject bulletPrefab;
    public float speed;
    public float delayTime;
    public bool isDoubleShot = false;

    public Transform parentTransform;

    [Header("Direction")]
    public bool isLeft;
    public bool isRight;
    public bool isMiddle;

    // Start is called before the first frame update

    private void OnEnable()
    {
        StartCoroutine(Shoot());
    }

    private void OnDisable()
    {
        StopCoroutine(Shoot());
    }
    IEnumerator Shoot()
    {

        CreateForceVector();
        
        
        WaitForSeconds delay1 = new WaitForSeconds(delayTime - (delayTime - 0.3f));
        WaitForSeconds delay2 = new WaitForSeconds(delayTime - 0.3f);
        WaitForSeconds delay = new WaitForSeconds(delayTime);


        while (true)
        {
            if (isDoubleShot)
            {
                GameObject go = Instantiate(bulletPrefab, gameObject.transform);
                go.GetComponent<Rigidbody2D>().AddForce(forceVector);
                go.transform.parent = parentTransform;

                yield return delay1;

                GameObject go1 = Instantiate(bulletPrefab, gameObject.transform);
                go1.GetComponent<Rigidbody2D>().AddForce(forceVector);
                go1.transform.parent = parentTransform;

                yield return delay2;

            }
            else
            {
                GameObject go = Instantiate(bulletPrefab, gameObject.transform);
                go.GetComponent<Rigidbody2D>().AddForce(forceVector);
                go.transform.parent = parentTransform;

                yield return delay;

            }

        }

    }

    private void CreateForceVector()
    {

        if (isLeft)
            forceVector = new Vector2(-1 * speed, 1 * speed);
        else if (isRight)
            forceVector = new Vector2(1 * speed, 1 * speed);
        else if (isMiddle)
            forceVector = new Vector2(0, speed + speed * Mathf.Sqrt(1));

    }
}
