using System;

public class EntityMoveScript
    : Entity
{
    const float kAcceleration = 2.0f;
    Transform transformComp;

    void OnCreate()
    {
        transformComp = GetComponent<Transform>();
    }

    void OnUpdate(float dt)
    {
        Vector3 newTranslation = new Vector3(transformComp.Translation);

        bool isShiftHeld = Input.IsKeyDown(KeyCode.LeftShift);
        float speedMultiplier = isShiftHeld ? 2.0f : 1.0f;

        // r/l
        if (Input.IsKeyDown(KeyCode.A))
        {
            newTranslation.x += kAcceleration * dt * speedMultiplier;
        }
        if (Input.IsKeyDown(KeyCode.D))
        {
            newTranslation.x -= kAcceleration * dt * speedMultiplier;
        }

        // fw/bw
        if (Input.IsKeyDown(KeyCode.S))
        {
            newTranslation.z += kAcceleration * dt * speedMultiplier;
        }
        if (Input.IsKeyDown(KeyCode.W))
        {
            newTranslation.z -= kAcceleration * dt * speedMultiplier;
        }

        // u/d
        if (Input.IsKeyDown(KeyCode.Q))
        {
            newTranslation.y += kAcceleration * dt;
        }
        if (Input.IsKeyDown(KeyCode.E))
        {
            newTranslation.y -= kAcceleration * dt;
        }

        transformComp.Translation = newTranslation;
    }
}