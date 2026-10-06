using UnityEngine;
using Vuforia;

public class ARCombatController : MonoBehaviour
{
    public ObserverBehaviour marker1;
    public ObserverBehaviour marker2;
    public Animator animCactus1;
    public Animator animCactus2;
    public float distantaAtac = 0.3f;

    private int attackParam = Animator.StringToHash("isAttacking");

    void Update()
    {
        if (marker1.TargetStatus.Status == Status.TRACKED && 
            marker2.TargetStatus.Status == Status.TRACKED)
        {
            float distanta = Vector3.Distance(marker1.transform.position, marker2.transform.position);

            if (distanta <= distantaAtac)
            {
                // ataca si se uita unul la celalalt
                animCactus1.SetBool(attackParam, true);
                animCactus2.SetBool(attackParam, true);
                
                marker1.transform.GetChild(0).LookAt(marker2.transform);
                marker2.transform.GetChild(0).LookAt(marker1.transform);
            }
            else
            {
                // se opresc
                animCactus1.SetBool(attackParam, false);
                animCactus2.SetBool(attackParam, false);
            }
        }
        else
        {
            // daca ascund unul dintre markere se opresc
            animCactus1.SetBool(attackParam, false);
            animCactus2.SetBool(attackParam, false);
        }
    }
}