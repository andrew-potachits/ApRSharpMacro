using JetBrains.ReSharper.Feature.Services.LiveTemplates.Macros;

namespace ApRSharpMacro
{
    [MacroDefinition("makedottedname", 
        LongDescription = "Replaces white spates in the name with dots ('new-name.with_space' becomes 'new.name.with.space'", 
        ShortDescription = "Value of {#0:another variable} replace with dots")]
    public class ReplaceWhitespatesWithDotsMacroDef : SimpleMacroDefinition
    {
        public override ParameterInfo[] Parameters => new[]
        {
            new ParameterInfo(ParameterType.VariableReference)
        };
    }
}
