using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpController : MonoBehaviour
{
    private bool isActivated = false;
    private Animator buttonAnimator;

    public Color disableColor;
    public Color enableColor;

    [Header("Assigned PowerUp")]
    public PowerUpController.PowerUps powerUp;

    // Start is called before the first frame update
    void Start()
    {
        buttonAnimator = GetComponent<Animator>();
        string chosenPowerUp = powerUp.ToString();
        switch (chosenPowerUp)
        {
            case "SideArrows":
                gameObject.GetComponent<Button>().onClick.AddListener(ValueChanger);
                gameObject.GetComponent<Button>().onClick.AddListener(()=>PlayerController.Instance.SetSideArrows(isActivated));

                break;
            case "DoubleShot":
                gameObject.GetComponent<Button>().onClick.AddListener(ValueChanger);
                gameObject.GetComponent<Button>().onClick.AddListener(() => PlayerController.Instance.SetDoubleShot(isActivated));

                break;
            case "Speed":
                gameObject.GetComponent<Button>().onClick.AddListener(ValueChanger);
                gameObject.GetComponent<Button>().onClick.AddListener(() => PlayerController.Instance.SetSpeed(isActivated));

                break;
            case "FasterBullets":
                gameObject.GetComponent<Button>().onClick.AddListener(ValueChanger);
                gameObject.GetComponent<Button>().onClick.AddListener(() => PlayerController.Instance.SetFasterBullets(isActivated));

                break;
            case "Clone":
                gameObject.GetComponent<Button>().onClick.AddListener(ValueChanger);
                gameObject.GetComponent<Button>().onClick.AddListener(() => PlayerController.Instance.CreatedClone(isActivated));

                break;
            default:

                break;
        }
    }

    // Update is called once per frame
    void ValueChanger()
    {
        if(PlayerController.Instance.activePowerupCount<3 || isActivated ==true)
        {
            isActivated = !isActivated;
            if (isActivated)
            {
                gameObject.GetComponent<Image>().color = enableColor;
                buttonAnimator.SetTrigger("enable");
            }
            else
            {
                gameObject.GetComponent<Image>().color = disableColor;
                buttonAnimator.SetTrigger("disable");

            }

        }
    }



    public enum PowerUps
    {
        SideArrows,
        DoubleShot,
        Speed,
        FasterBullets,
        Clone
    }
}
