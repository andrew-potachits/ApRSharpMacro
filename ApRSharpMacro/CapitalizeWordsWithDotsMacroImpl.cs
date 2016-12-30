using System;
using System.Linq;
using System.Runtime.InteropServices;
using JetBrains.ReSharper.Feature.Services.LiveTemplates.Hotspots;
using JetBrains.ReSharper.Feature.Services.LiveTemplates.Macros;
using JetBrains.Util;

namespace ApRSharpMacro
{
    [MacroImplementation(Definition = typeof(CapitalizeWordsWithDotsMacroDef))]
    public class CapitalizeWordsWithDotsMacroImpl : SimpleMacroImplementation
    {
        private readonly IMacroParameterValueNew _myArgument;

        public CapitalizeWordsWithDotsMacroImpl([Optional] MacroParameterValueCollection arguments)
        {
            _myArgument = arguments.OptionalFirstOrDefault();
        }

        public override string EvaluateQuickResult(IHotspotContext context)
        {
            if (_myArgument != null)
                return Execute(_myArgument.GetValue());
            return null;
        }

        private string Execute(string text)
        {
            if (text == null)
                return string.Empty;
            if (text.Length > 0)
                text = ReplacesWhitespacesWithDots(text);
            return text;
        }

        private string ReplacesWhitespacesWithDots(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            var words = text.Split(new[] {" ", ".", "-", "_"}, StringSplitOptions.RemoveEmptyEntries);


            return string.Join(string.Empty, words.Select(s => s.Capitalize()));
        }
    }
}