using UnityEngine;

public abstract class MathFunction
{

    public float originX;

    public abstract float execute(float x);
    public abstract float derived(float x);
}

public class Parabolic : MathFunction
{
    public float height = 0f;
    float force = 0f;

    public Parabolic(float height= 0f, float force = 0f)
    {
        accumulate(height, force);
    }

    public void accumulate(float height=0f, float force = 0f)
    {
        this.height += height;
        this.force += force;
    }

    public override float execute(float x)
    {
        return -1 / force * Mathf.Pow(x - Mathf.Sqrt(height * force) - originX, 2) + height;
    }

    public override float derived(float x)
    {
        return -2f / force * (x - Mathf.Sqrt(height * force) - originX);
    }
}

public class Wave : MathFunction
{
    float frequency = 0f; 
    float strength = 0f;

    public Wave(float frequency = 0f, float strength = 0f)
    {
        accumulate(frequency, strength);
    }

    public void accumulate(float frequency=0f, float strength = 0f)
    {
        this.frequency += frequency;
        this.strength += strength;
    }

    public override float execute(float x)
    {
        return frequency * Mathf.Sin(strength * x );
    }

    public override float derived(float x)
    {
        return frequency * strength * Mathf.Cos(strength * x);
    }
}

public class Spike : MathFunction
{
    float pos = 0f;
    float height = 0f;
    float smoothness = 0f;

    public Spike(float pos = 0f, float height = 0f, float smoothness = 0f)
    {
        at(pos);
        accumulate(height, smoothness);
    }

    public void at(float pos)
    {
        this.pos = pos + 1 + smoothness;
    }

    public void accumulate(float height=0f, float smoothness=0f)
    {
        this.height += height;
        this.smoothness += smoothness;
    }

    public override float execute(float x)
    {
        return height * Mathf.Exp(-Mathf.Pow(x - pos + 1 + smoothness / 10, 2) / (2 * Mathf.Pow(smoothness, 2)));
    }

    public override float derived(float x)
    {
        float exponent = -Mathf.Pow(x - pos + 1 + smoothness / 10, 2) / (2 * Mathf.Pow(smoothness, 2));
        float expValue = Mathf.Exp(exponent);
        float derivative = -(height / Mathf.Pow(smoothness, 2)) * (x - pos + 1 + smoothness / 10) * expValue;
        return derivative;
    }
}

public class Arc : MathFunction
{
    float pos = 0f;
    float rayon = 0f;

    public Arc(float pos, float rayon)
    {
        at(pos);
        accumulate(rayon);
    }

    public void accumulate(float rayon = 0f)
    {
        this.rayon += rayon;
    }

    public void at(float pos)
    {
        this.pos = pos + 1;
    }

    public override float execute(float x)
    {
        return -Mathf.Sqrt(rayon * rayon - (x - pos) * (x - pos)) + rayon;
    }

    public override float derived(float x)
    {
        return 1f;
    }
}

public class Jump : MathFunction
{
    float pos = 0f;
    float strength = 0f;
    float smoothness = 0f;

    public Jump(float pos, float strength = 0f, float smoothness = 0f)
    {
        at(pos);
        accumulate(strength, smoothness);
    }

    public void at(float pos)
    {
        this.pos = pos + 1 + smoothness;
    }

    public void accumulePos(float pos)
    {
        this.pos += pos ;
    }

    public void accumulate(float strength = 0f, float smoothness = 0f)
    {
        this.strength += strength;
        this.smoothness += smoothness;
    }
    public override float execute(float x)
    {
        return strength / (1 + Mathf.Exp(-smoothness * (x - pos + 1 + smoothness / 10)));
    }

    public override float derived(float x)
    {
        float exponent = -smoothness * (x - pos + 1 + smoothness / 10);
        float expValue = Mathf.Exp(exponent);
        float denominator = 1 + expValue;
        float numerator = strength * smoothness * expValue;
        return numerator / (denominator * denominator);
    }
}

