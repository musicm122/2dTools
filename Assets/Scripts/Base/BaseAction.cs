using System.Collections;
using UnityEngine;

namespace AssemblyCSharp.Assets.Scripts.Base
{
    public abstract class EntityAction : MonoBehaviour, IEntityAction
    {
        public float ActionCooldown = 1.0f;
        public float ActionTime = 1.0f;
        public bool IsActionCoolingDown;
        public bool IsPreformingAction;

        public virtual void PreformActionSequence()
        {
            if (!CanPreformAction()) return;
            IsPreformingAction = true;
            DoAction();
        }

        public virtual void DoAction()
        {
            StartCoroutine(WaitForActionToComplete());
        }

        public virtual void DoActionComplete()
        {
            StartCoroutine(WaitForActionCooldown());
        }

        public IEnumerator WaitForActionToComplete()
        {
            IsPreformingAction = true;
            yield return new WaitForSeconds(ActionTime);
            IsPreformingAction = false;
            DoActionComplete();
        }

        public IEnumerator WaitForActionCooldown()
        {
            IsActionCoolingDown = true;
            yield return new WaitForSeconds(ActionCooldown);
            IsActionCoolingDown = false;
        }

        public virtual void ActionCheck(Collider2D c)
        {
        }

        public virtual bool CanPreformAction()
        {
            return !IsActionCoolingDown && !IsPreformingAction;
        }
    }

}
