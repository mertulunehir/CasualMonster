using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject middleBulletSpawner;
    public GameObject[] sideBulletSpawners;

    public GameObject playerClone;
    public bool isCloneCreated = false;

    private float baseBulletSpeed;
    public float activePowerupCount = 0;
    public bool isClone = false;

    public static PlayerController Instance;

    // Start is called before the first frame update
    void Awake()
    {
        if (!isClone)
        {
            Instance = this;

            baseBulletSpeed = middleBulletSpawner.GetComponent<BulletSpawner>().speed;
        }     
    }

    public void CreatedClone(bool value)
    {
        if (value)
        {
            activePowerupCount++;
            playerClone.GetComponent<PlayerController>().middleBulletSpawner.GetComponent<BulletSpawner>().speed = middleBulletSpawner.GetComponent<BulletSpawner>().speed;
            playerClone.GetComponent<PlayerController>().middleBulletSpawner.GetComponent<BulletSpawner>().delayTime = middleBulletSpawner.GetComponent<BulletSpawner>().delayTime;
            playerClone.GetComponent<PlayerController>().middleBulletSpawner.GetComponent<BulletSpawner>().isDoubleShot = middleBulletSpawner.GetComponent<BulletSpawner>().isDoubleShot;
            playerClone.GetComponent<PlayerController>().middleBulletSpawner.GetComponent<BulletSpawner>().isDoubleShot = middleBulletSpawner.GetComponent<BulletSpawner>().isDoubleShot;

            if(sideBulletSpawners[0].activeSelf)
            {
                for(int i = 0; i < sideBulletSpawners.Length;i++)
                {
                    if (sideBulletSpawners[i].activeSelf)
                        playerClone.GetComponent<PlayerController>().sideBulletSpawners[i].SetActive(true);
                    playerClone.GetComponent<PlayerController>().sideBulletSpawners[i].GetComponent<BulletSpawner>().speed = sideBulletSpawners[i].GetComponent<BulletSpawner>().speed;
                    playerClone.GetComponent<PlayerController>().sideBulletSpawners[i].GetComponent<BulletSpawner>().delayTime = sideBulletSpawners[i].GetComponent<BulletSpawner>().delayTime;
                    playerClone.GetComponent<PlayerController>().sideBulletSpawners[i].GetComponent<BulletSpawner>().isDoubleShot = sideBulletSpawners[i].GetComponent<BulletSpawner>().isDoubleShot;
                    playerClone.GetComponent<PlayerController>().sideBulletSpawners[i].GetComponent<BulletSpawner>().isDoubleShot = sideBulletSpawners[i].GetComponent<BulletSpawner>().isDoubleShot;
                }
            }
            else
            {
                foreach(GameObject go in playerClone.GetComponent<PlayerController>().sideBulletSpawners)
                {
                    go.SetActive(false);
                }
            }  

            playerClone.transform.position = new Vector3(Random.Range(-2.31f,2.31f), Random.Range(-1.18f, 3.18f), 0);
            playerClone.SetActive(true);
        }
        else
        {
            if (playerClone.activeSelf)
            {
                activePowerupCount--;
                playerClone.SetActive(false);
            }
        }
    }

    public void SetSideArrows(bool value)
    {
        if (value)
        {
            activePowerupCount++;
            foreach (GameObject go in sideBulletSpawners)
            {
                go.SetActive(value);
            }
        }
        else
        {
            if (sideBulletSpawners[0].activeSelf == true)
            {
                activePowerupCount--;
                foreach (GameObject go in sideBulletSpawners)
                {
                    go.SetActive(value);
                }
            }
        }
    }

    public void SetDoubleShot(bool value)
    {
        if (value)
        {
            activePowerupCount++;
            middleBulletSpawner.GetComponent<BulletSpawner>().isDoubleShot = value;
            foreach (GameObject go in sideBulletSpawners)
            {
                go.GetComponent<BulletSpawner>().isDoubleShot = value;
            }
        }
        else
        {
            if (middleBulletSpawner.GetComponent<BulletSpawner>().isDoubleShot == true)
            {
                activePowerupCount--;
                middleBulletSpawner.GetComponent<BulletSpawner>().isDoubleShot = value;
                foreach (GameObject go in sideBulletSpawners)
                {
                    go.GetComponent<BulletSpawner>().isDoubleShot = value;
                }
            }
        }
    }


    public void SetSpeed(bool value)
    {
        if (value)
        {
            activePowerupCount++;
            middleBulletSpawner.SetActive(false);
            middleBulletSpawner.GetComponent<BulletSpawner>().delayTime = middleBulletSpawner.GetComponent<BulletSpawner>().delayTime / 2;
            middleBulletSpawner.SetActive(true);
            foreach (GameObject go in sideBulletSpawners)
            {
                if (go.gameObject.activeSelf)
                {
                    go.SetActive(false);
                    go.GetComponent<BulletSpawner>().delayTime = go.GetComponent<BulletSpawner>().delayTime / 2;
                    go.SetActive(true);
                }
                else
                    go.GetComponent<BulletSpawner>().delayTime = go.GetComponent<BulletSpawner>().delayTime / 2;
            }
        }
        else
        {
            if (middleBulletSpawner.GetComponent<BulletSpawner>().delayTime != 2)
            {
                activePowerupCount--;
                middleBulletSpawner.SetActive(false);
                middleBulletSpawner.GetComponent<BulletSpawner>().delayTime = middleBulletSpawner.GetComponent<BulletSpawner>().delayTime * 2;
                middleBulletSpawner.SetActive(true);
                foreach (GameObject go in sideBulletSpawners)
                {
                    if (go.gameObject.activeSelf)
                    {
                        go.SetActive(false);
                        go.GetComponent<BulletSpawner>().delayTime = go.GetComponent<BulletSpawner>().delayTime * 2;
                        go.SetActive(true);
                    }
                    else
                        go.GetComponent<BulletSpawner>().delayTime = go.GetComponent<BulletSpawner>().delayTime * 2;
                }
            }
        }
    }

    public void SetFasterBullets(bool value)
    {
        if (value)
        {
            activePowerupCount++;
            middleBulletSpawner.SetActive(false);
            middleBulletSpawner.GetComponent<BulletSpawner>().speed = baseBulletSpeed + baseBulletSpeed * 0.5f;
            middleBulletSpawner.SetActive(true);
            foreach (GameObject go in sideBulletSpawners)
            {
                if (go.gameObject.activeSelf)
                {
                    go.SetActive(false);
                    go.GetComponent<BulletSpawner>().speed = baseBulletSpeed + baseBulletSpeed * 0.5f;
                    go.SetActive(true);
                }
                else
                    go.GetComponent<BulletSpawner>().speed = baseBulletSpeed + baseBulletSpeed * 0.5f;
            }
        }
        else
        {
            if (middleBulletSpawner.GetComponent<BulletSpawner>().speed == baseBulletSpeed + baseBulletSpeed * 0.5f)
            {
                activePowerupCount--;
                middleBulletSpawner.SetActive(false);
                middleBulletSpawner.GetComponent<BulletSpawner>().speed = baseBulletSpeed;
                middleBulletSpawner.SetActive(true);
                foreach (GameObject go in sideBulletSpawners)
                {
                    if (go.gameObject.activeSelf)
                    {
                        go.SetActive(false);
                        go.GetComponent<BulletSpawner>().speed = baseBulletSpeed;
                        go.SetActive(true);
                    }
                    else
                        go.GetComponent<BulletSpawner>().speed = baseBulletSpeed;

                }
            }
        }
    }
}
