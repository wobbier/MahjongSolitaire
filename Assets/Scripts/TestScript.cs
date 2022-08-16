using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public class TransformTest
    : Entity
{
    const float kAcceleration = 2.0f;

    Transform transformComp;
    float time = 0.0f;
    void OnCreate()
    {
        if (HasComponent<Transform>())
        {
            Console.WriteLine("FOUND TRANSFORM COMPONENT");
        }

        transformComp = GetComponent<Transform>();
    }

    void OnUpdate(float dt)
    {
        Vector3 newTranslation = new Vector3(transformComp.Translation);

        bool isShiftHeld = Input.IsKeyDown(KeyCode.LeftShift);
        float speedMultiplier = isShiftHeld ? kAcceleration : 1.0f;
        time += dt * speedMultiplier;
        newTranslation.y = (float)Math.Sin(time);

        transformComp.Translation = newTranslation;
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
        NativeLog_Vector(ref Position, out Vector3 outVec);
        Console.WriteLine("Normalized = {0:F}, {1:F}, {2:F}: L - {3:F}", outVec.x, outVec.y, outVec.z, Native_VectorLength(ref outVec));

    }

    private void IncrementFloatVar(float value)
    {
        MyPublicFloatVar += value;
    }
    [MethodImplAttribute(MethodImplOptions.InternalCall)]
    extern static void NativeLog(string message, int number);
    [MethodImplAttribute(MethodImplOptions.InternalCall)]
    extern static void NativeLog_Vector(ref Vector3 vec, out Vector3 outVec);
    [MethodImplAttribute(MethodImplOptions.InternalCall)]
    extern static float Native_VectorLength(ref Vector3 vec);

}