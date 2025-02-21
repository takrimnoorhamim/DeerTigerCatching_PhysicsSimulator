using UnityEngine;

public class AnimalCatchingManagement : MonoBehaviour
{
    public float tigerInitialVelocity;
    public float deerInitialVelocity;

    public float tigerAcceleration;
    public float deerAcceleration;

    private float tigerCurrentVelocity, deerCurrentVelocity;

    public Transform tigerTransform, deerTransform;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tigerCurrentVelocity = tigerInitialVelocity;
        deerCurrentVelocity = deerInitialVelocity;

        float initialDistance = deerTransform.position.x - tigerTransform.position.x;

        CalculateCatchTime (initialDistance);

    }

    
    void FixedUpdate()
    {
        tigerCurrentVelocity += tigerAcceleration * Time.fixedDeltaTime;
        tigerTransform.Translate ( Vector3.right * tigerCurrentVelocity * Time.fixedDeltaTime);

        deerCurrentVelocity += deerAcceleration * Time.fixedDeltaTime;
        deerTransform.Translate(Vector3.right * deerCurrentVelocity * Time.fixedDeltaTime);

        if (tigerTransform.position.x >= deerTransform.position.x)
        {
            print("Bagh Horin ke dhore felse!");
            Time.timeScale = 0;
        }

    }

    void CalculateCatchTime ( float h )
    {
        float a = 0.5f * (tigerAcceleration - deerAcceleration);
        float b = (tigerInitialVelocity - deerInitialVelocity);
        float c = - h;

        float discriminent = b * b - 4 * a * c;

        if (discriminent < 0)
        {
            print("Bagh kokhono horin take dhorte parbe na");
        }
        else
        {
            float timeToCatch = (-b + Mathf.Sqrt(discriminent)) / (2 * a);
            print("Dhorte Somoy lagbe " + timeToCatch);
        }

    }

}
