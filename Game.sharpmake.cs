using System.IO;
using Sharpmake;

[module: Sharpmake.Include("Engine/Engine.sharpmake.cs")]

[Generate]
public class SharpGameProject : BaseGameProject
{
    public SharpGameProject()
        : base()
    {
        Name = "Mahjong";
    }
}

[Generate]
public class SharpGameSolution : BaseGameSolution
{
    public SharpGameSolution()
        : base()
    {
        Name = "Mahjong";
    }
}


//[Generate]
//public class ScriptGameSolution : BaseScriptingSolution
//{
//}


[Generate]
public class UserSharpmakeProject : SharpmakeProjectBase
{
    public UserSharpmakeProject() : base() { }
}

[Generate]
public class UserGameScript : GameScript
{
    public UserGameScript() : base() { }
}
