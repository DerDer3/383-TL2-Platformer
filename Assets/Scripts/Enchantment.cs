using UnityEngine;

public class Enchantment : WeaponDecorator
{
    public Enchantment(IWeapon weapon) : base(weapon){}

    public override void Fire(){
        base.Fire();
        Debug.Log("Magical Attack!");
    }
}
