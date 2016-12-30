using JetBrains.ReSharper.Feature.Services.LiveTemplates.Macros;

namespace ApRSharpMacro
{
    [MacroDefinition("makecapitalizedname", 
        LongDescription = "Removes the white spates in the name and capitalizes first letters ('new-name.with_space' becomes 'NewNameWithSpace'", 
        ShortDescription = "Value of {#0:another variable} capitalize words")]
    public class CapitalizeWordsWithDotsMacroDef : SimpleMacroDefinition
    {
        public override ParameterInfo[] Parameters => new[]
        {
            new ParameterInfo(ParameterType.VariableReference)
        };
    }
}