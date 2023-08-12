using System.Runtime.Serialization.Formatters.Binary;

namespace Yggdrasil.Server.Game.Stats;

[Serializable]
public class EvolvedForms
{
    private EvolvedForm[] _forms;

    public int Count => _forms.Length;

    public EvolvedForm this[int index]
    {
        get => _forms[index];
        set => _forms[index] = value;
    }
    
    public EvolvedForms(int count = 4)
    {
        _forms = Enumerable.Repeat(new EvolvedForm(), count).ToArray();
    }
}