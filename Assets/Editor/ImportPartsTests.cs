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
            var fileName = "RunPart.json";
            var currentPath = Path.Combine(Environment.CurrentDirectory, "Assets/Editor/TestJson", fileName);
            Debug.Log("Path =" + currentPath + " Exists = " + File.Exists(currentPath));

            var part = ImportHelper.ImportFromJson<RunPart>(currentPath);
            Assert.IsNotNull(part);

        }
    }


}