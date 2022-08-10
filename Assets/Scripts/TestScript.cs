using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;


public struct Vector3
{
    public float X, Y, Z;

    public Vector3(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }
}

public class TestScript
{
    public float MyPublicFloatVar = 5.0f;

    private string m_Name = "Hello";
    public string Name
    {
        get => m_Name;
        set
        {
            m_Name = value;
            MyPublicFloatVar += 5.0f;
        }
    }
    Vector3 Position = new Vector3(1, 2, 3);
    public float TestFloatProperty
    {
        get; set;
    }

    public void PrintFloatVar()
    {
        Console.WriteLine("MyPublicFloatVar = {0:F}", MyPublicFloatVar);
        NativeLog("ENG - MyPublicFloatVar", 27);
        if (MyPublicFloatVar < 0)
        {
            CppFunc();
        }
        NativeLog_Vector(ref Position, out Vector3 outVec);
        Console.WriteLine("Normalized = {0:F}, {1:F}, {2:F}: L - {3:F}", outVec.X, outVec.Y, outVec.Z, Native_VectorLength(ref outVec));
        
    }

    private void IncrementFloatVar(float value)
    {
        MyPublicFloatVar += value;
    }
    [MethodImplAttribute(MethodImplOptions.InternalCall)]
    extern static void CppFunc();
    [MethodImplAttribute(MethodImplOptions.InternalCall)]
    extern static void NativeLog(string message, int number);
    [MethodImplAttribute(MethodImplOptions.InternalCall)]
    extern static void NativeLog_Vector(ref Vector3 vec, out Vector3 outVec);
    [MethodImplAttribute(MethodImplOptions.InternalCall)]
    extern static float Native_VectorLength(ref Vector3 vec);

}