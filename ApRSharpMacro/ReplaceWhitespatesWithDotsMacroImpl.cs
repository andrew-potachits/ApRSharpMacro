using System;
using System.Runtime.InteropServices;
using JetBrains.ReSharper.Feature.Services.LiveTemplates.Hotspots;
using JetBrains.ReSharper.Feature.Services.LiveTemplates.Macros;

namespace ApRSharpMacro
{
    [MacroImplementation(Definition = typeof(ReplaceWhitespatesWithDotsMacroDef))]
    public class ReplaceWhitespatesWithDotsMacroImpl : SimpleMacroImplementation
    {
        private readonly IMacroParameterValueNew _myArgument;

        public ReplaceWhitespatesWithDotsMacroImpl([Optional] MacroParameterValueCollection arguments)
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
            return string.Join(".", words);
        }
    }
}