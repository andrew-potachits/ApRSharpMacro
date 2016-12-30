using System;
using JetBrains.ReSharper.Feature.Services.LiveTemplates.Macros;
using NUnit.Framework;

namespace ApRSharpMacro.Tests
{
    [TestFixture]
    public class TextReplaceMacroTests
    {
        [Test]
        public void TestReplaceWithDot()
        {
            var parameters = new MacroParameterValueCollection();
            string input = String.Empty;
            parameters.Add(new DelegateMacroParameter(() => input));
            var addin = new ReplaceWhitespatesWithDotsMacroImpl(parameters);

            Assert.IsEmpty(addin.EvaluateQuickResult(null));

            input = "blah";
            Assert.AreEqual("blah", addin.EvaluateQuickResult(null));
            input = "blah Blah1";
            Assert.AreEqual("blah.Blah1", addin.EvaluateQuickResult(null));
            input = "blah-Blah2";
            Assert.AreEqual("blah.Blah2", addin.EvaluateQuickResult(null));
            input = "blah.Blah3";
            Assert.AreEqual("blah.Blah3", addin.EvaluateQuickResult(null));
            input = null;
            Assert.IsEmpty(addin.EvaluateQuickResult(null));
        }

        [Test]
        public void TestCapitalizeWords()
        {
            var parameters = new MacroParameterValueCollection();
            string input = String.Empty;
            parameters.Add(new DelegateMacroParameter(() => input));

            var addin = new CapitalizeWordsWithDotsMacroImpl(parameters);
            Assert.AreEqual(string.Empty, addin.EvaluateQuickResult(null));
            input = "blah";
            Assert.AreEqual("Blah", addin.EvaluateQuickResult(null));
            input = "blah blah";
            Assert.AreEqual("BlahBlah", addin.EvaluateQuickResult(null));
            input = "blah-blah2";
            Assert.AreEqual("BlahBlah2", addin.EvaluateQuickResult(null));
            input = "blah_blah3";
            Assert.AreEqual("BlahBlah3", addin.EvaluateQuickResult(null));
            input = "blah.blah4";
            Assert.AreEqual("BlahBlah4", addin.EvaluateQuickResult(null));
            input = null;
            Assert.IsEmpty(addin.EvaluateQuickResult(null));
        }
    }
}
