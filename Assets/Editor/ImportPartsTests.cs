using NUnit.Framework;
using Helpers;
using System;
using System.IO;
using AssemblyCSharp.Assets.Scripts.Importer.PartFactory;
using Scripts.Importer.Parts;

namespace AssemblyCSharpEditor.Assets.Editor
{
    [TestFixture()]
    public class ImportPartsTests
    {
        private string GetPartDir(string fileName)
        {
            return Path.Combine(Environment.CurrentDirectory, "Assets/Editor/TestJson", fileName);
        }

        private string GetRunPartPath()
        {
            return GetPartDir("RunPart.json");
        }

        private string GetDashPartPath()
        {
            return GetPartDir("DashPart.json");
        }

        private string GetJumpPartPath()
        {
            return GetPartDir("JumpPart.json");
        }

        [Test]
        public void ThrowsIfRunPartImportPathNotFound()
        {
            Assert.Throws<FileNotFoundException>(() =>
            {
                var path = @"\fake\path";
                var part = ImportHelper.ImportFromJson(path);
            });
        }

        [Test]
        public void CreateRunPart()
        {
            var part = RunPartFactory.CreateRunPartInstance();
            Assert.IsInstanceOf<RunPart>(part);
            Assert.IsNotNull(part);
        }

        [Test]
        public void CreateRunPartFromJson()
        {
            var expectedGravity = 9.8f;
            var expectedMaxSpeed = 1f;

            var part = RunPartFactory.CreateRunPartWithGivenState(GetRunPartPath());

            Assert.AreEqual(expectedGravity, part.Gravity, "RunPart Gravity Should Match");
            Assert.AreEqual(expectedMaxSpeed, part.MaxSpeed, "RunPart MaxSpeed Should Match");

        }
    }
}