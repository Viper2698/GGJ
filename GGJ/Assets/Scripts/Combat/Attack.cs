using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] float attackRange = 1f;

    Health target;
    float timeSinceAttack = Mathf.Infinity;

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        if (target.IsDead())
            return;
        bool optimalDistance = IsInRange(target.transform);

        Movement movement = GetComponent<Movement>();

        if (!optimalDistance)
        {
            movement.StartMovement(target.transform.position);
        }
        else
        {
            print("optimal distance");
            movement.Cancel();
            AttackAction();
        }

        timeSinceAttack += Time.deltaTime;
    }

    public void AttackCharacter(GameObject target)
    {
        this.target = target.GetComponent<Health>();
    }

    private void AttackAction()
    {
        transform.LookAt(target.transform);
        Cancel();
        //AttackAnimation();

    }

    public bool CanAttack(GameObject currentTarget)
    {
        if (currentTarget == null)
            return false;

        if (!GetComponent<Movement>().CanMoveTo(currentTarget.transform.position)
            && !IsInRange(currentTarget.transform))
            return false;

        return currentTarget.GetComponent<Health>() != null
            && !currentTarget.GetComponent<Health>().IsDead();
    }

    public void Cancel()
    {
        //StopAttackAnimation();
        GetComponent<Movement>().Cancel();
        //GameObject.FindWithTag("Player").tag = "asd";
        target = null;
    }

    void Hit()
    {
        target.TurnToBarrel();
        Cancel();
    }

    private bool IsInRange(Transform target)
    {
        return Vector3.Distance(target.position, transform.position)
            < attackRange;
    }
}
