
public class DamageManager
{
    public static void GetDamaged(ref float hp, float atk)
    {
        hp -= atk;
        if (hp <= 0.0f) hp = 0.0f;
    }
}
