using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : SameMonoBehaviour
{
    [Header("HP Bar")]
    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;
    [SerializeField] protected SliderHP sliderHp;
    [SerializeField] protected FollowTarget followTarget;
    [SerializeField] protected Spawner spawner;

    protected virtual void FixedUpdate()
    {
        //this.CheckTargetIsDead();
        this.HPShowing();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSliderHP();
        this.LoadFollowTarget();
        this.LoadSpawner();
    }

    protected virtual void LoadSliderHP()
    {
        if (this.sliderHp != null) return;
        this.sliderHp = transform.GetComponentInChildren<SliderHP>();
        Debug.LogWarning(transform.name + ": LoadSliderHP", gameObject);
    }
    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = transform.parent.parent.GetComponent<Spawner>();
        Debug.LogWarning(transform.name + ": LoadSpawner", gameObject);
    }

    protected virtual void LoadFollowTarget()
    {
        if (this.followTarget != null) return;
        this.followTarget = transform.GetComponent<FollowTarget>();
        Debug.LogWarning(transform.name + ": LoadFollowTarget", gameObject);
    }

/*    protected virtual void CheckTargetIsDead()
    {
        bool isDead = this.shootableObjectCtrl.DamageReceiver.IsDead();
        if(isDead) this.spawner.Despawn(transform);
    }*/

    protected virtual void HPShowing()
    {
        if (this.shootableObjectCtrl == null) return;

        bool isDead = this.shootableObjectCtrl.DamageReceiver.IsDead();
        if (isDead)
        {
            this.spawner.Despawn(transform);
            return;
        }

        float hp = this.shootableObjectCtrl.DamageReceiver.HP;
        float maxHP = this.shootableObjectCtrl.DamageReceiver.HPMax;

        this.sliderHp.SetCurrentHP(hp);
        this.sliderHp.SetMaxHp(maxHP);
    }

    public virtual void SetObjectCtrl(ShootableObjectCtrl shootableObjectCtrl)
    {
        this.shootableObjectCtrl = shootableObjectCtrl;
    }

    public virtual void SetFollowTarget(Transform target)
    {
        this.followTarget.SetTarget(target);
    }
}
