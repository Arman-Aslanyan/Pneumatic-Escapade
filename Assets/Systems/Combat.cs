using UnityEngine;
using TMPro;

public class Combat : MonoBehaviour
{
    public float currentHP;
    public float maxHP;

    public bool i_frames;
    public TMP_Text HP;


    public float shakeTime;
    public float shakeIntensity;
    // Start is called before the first frame update
    void Start()
    {
        HP.text = ("HP: " + currentHP);
    }

    public void Update()
    {
    }
    public virtual void TakeDamage(float Damage)
    {
        if (i_frames == false)
        {
            CinemachineShake.Instance.ShakeCamera(shakeIntensity, shakeTime);
            currentHP -= Damage;
            HP.text = ("HP: " + currentHP);
        }

        if (currentHP <= 0)
        {
            Death();
        }
    }

    public virtual void Death()
    {
        Debug.Log("dead");
    }

    public virtual void SetI_Frames(bool enableI_Frames)
    {
        i_frames = enableI_Frames;
    }

}
