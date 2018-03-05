using NUnit.Framework;
using Helpers;
using System;
using System.IO;

namespace AssemblyCSharpEditor.Assets.Editor
{
    [TestFixture()]
    public class ImportTests
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

        //Test for System.UnauthorizedAccessException
        [Test]
        public void ThrowsIfUnauthorizedPath()
        {
            Assert.Throws<UnauthorizedAccessException>(() =>
            {
                var jsonPath = @"/Users/terrancesmith/2dTools/Assets/Editor/TestJson";
                var part = ImportHelper.ImportFromJson<RunPart>(jsonPath);
            });
        }

        [Test]
        public void ReturnRunPartFromJson()
        {
            //fails
            var jsonPath = @"/Users/terrancesmith/2dTools/Assets/Editor/TestJson";
            var part = ImportHelper.ImportFromJson<RunPart>(jsonPath);
            Assert.IsNotNull(part);
        }

    }
}