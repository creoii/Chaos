using System.Collections.Generic;
using System;

[Serializable]
public class Transition
{
    public string name;
    public string[] nextPhases;

    public Transition(string name, string[] nextPhases)
    {
        this.name = name;
        this.nextPhases = nextPhases;
    }

    public static Transition Override(Transition one, Transition two)
    {
        return new Transition(
            two.name == null ? one.name : two.name,
            two.nextPhases == null ? one.nextPhases : two.nextPhases
        );
    }
}
