using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;


namespace AssemblyCSharpEditor.Assets.Editor
{
    [TestFixture()]
    public class ExamplePlayerTests
    {

        [Test]
        public void CanCreatePlayerObject()
        {
            // Use the Assert class to test conditions.
        }

        // A UnityTest behaves like a coroutine in PlayMode
        // and allows you to yield null to skip a frame in EditMode
        [UnityTest]
        public IEnumerator NewTestScriptWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // yield to skip a frame
            yield return null;
        }
    }

    /*
    public class MovementTests
    {
        [Test]
        public void MovementShouldOnlyAffectXAxis()
        {
            PlayerController pc = PlayerController.
            var beforePosition = pc.transform.position;
            pc.Move(pc.transform, Direction.Right, 1);
            Debug.Assert(Mathf.Approximately(beforePosition.y, pc.transform.position.y), "y position should be approximately the same ");
        }
    }
    */
}