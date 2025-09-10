using UnityEngine;

public abstract class WeaponDecorator : IWeapon
{
    protected IWeapon _weapon;

    public WeaponDecorator (IWeapon weapon){
        _weapon = weapon;
    }

    public virtual void Fire(){
        _weapon.Fire();
    }
}
