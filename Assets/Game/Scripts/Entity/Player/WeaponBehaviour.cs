using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{
    [SerializeField] Animator weaponAnimator;
    // Start is called before the first frame update
    [SerializeField] float attackDelay;

    private float auxAttackDelay;
    void Start()
    {
        auxAttackDelay=attackDelay;
    }
    // Update is called once per frame
    void Update()
    {
        
    }


    public void attack()
    {
        weaponAnimator.SetTrigger("Attack");
    }
}
