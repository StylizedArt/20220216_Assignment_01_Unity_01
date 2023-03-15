using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : HealthWithUI
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Die()
    {
        base.Die();
        // LevelManager.instance.UIManager
        anim.SetBool("Dead", true);
        LevelManager.instance.PlayerDeath(GetComponent<PlayerData>().playerNumber);
    }
}
