using NUnit.Framework;
using Helpers;
using System;
using System.IO;
using UnityEngine;

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
                var part = ImportHelper.ImportFromJson<RunPart>(path);
            });
        }

        [Test]
        public void ReturnRunPartFromJson()
        {
            var currentPath = GetRunPartPath();
            var part = ImportHelper.ImportFromJson<RunPart>(currentPath);
            Assert.IsNotNull(part);
        }

        [Test]
        public void ShouldPopulateRunPartWithValuesFromJson()
        {
            var currentPath = GetRunPartPath();
            var part = ImportHelper.ImportFromJson<RunPart>(currentPath);
            Assert.IsNotNull(part.MaxSpeed, "MaxSpeed Should Be Populated");
            Assert.IsNotNull(part.Gravity, "Gravity Should Be Populated");
        }

        [Test]
        public void ReturnJumpPartFromJson()
        {
            var currentPath = GetJumpPartPath();
            var part = ImportHelper.ImportFromJson<RunPart>(currentPath);
            Assert.IsNotNull(part);
        }

        [Test]
        public void ShouldPopulateJumpPartWithValuesFromJson()
        {
            var currentPath = GetJumpPartPath();
            var part = ImportHelper.ImportFromJson<JumpPart>(currentPath);
            Assert.IsNotNull(part.Gravity, "Gravity Should Be Populated");
        }

        [Test]
        public void ReturnDashPartFromJson()
        {
            var currentPath = GetDashPartPath();
            var part = ImportHelper.ImportFromJson<RunPart>(currentPath);
            Assert.IsNotNull(part);
        }

        [Test]
        public void ShouldPopulateDashPartWithValuesFromJson()
        {
            var currentPath = GetJumpPartPath();
            var part = ImportHelper.ImportFromJson<DashPart>(currentPath);
            Assert.IsNotNull(part.Gravity, "Gravity Should Be Populated");
        }

    }
}