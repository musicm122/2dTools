using System.Collections;
using UnityEngine;

namespace AssemblyCSharp.Assets.Scripts.Base
{
    public interface IEntityAction
    {
        void ActionCheck(Collider2D c);
        bool CanPreformAction();
        void DoAction();
        void DoActionComplete();
        void PreformActionSequence();
        IEnumerator WaitForActionCooldown();
        IEnumerator WaitForActionToComplete();
    }
}