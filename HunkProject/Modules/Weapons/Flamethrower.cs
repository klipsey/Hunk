﻿using RoR2.Skills;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace HunkMod.Modules.Weapons
{
    public class Flamethrower : BaseWeapon<Flamethrower>
    {
        public override string weaponNameToken => "FLAMETHROWER";
        public override string weaponName => "Chemical Flamethrower";
        public override string weaponDesc => "8-round capacity 12-gauge pump-action shotgun. Its sturdy steel action makes this popular model reliable and easy to control.";
        public override string iconName => "texFlamethrowerIcon";
        public override GameObject crosshairPrefab => Modules.Assets.shotgunCrosshairPrefab;
        public override int magSize => 300;
        public override float reloadDuration => 2f;
        public override string ammoName => "Fuel";
        public override GameObject modelPrefab => Modules.Assets.mainAssetBundle.LoadAsset<GameObject>("mdlFlamethrower");
        public override HunkWeaponDef.AnimationSet animationSet => HunkWeaponDef.AnimationSet.SMG;
        public override bool storedOnBack => true;
        public override float damageFillValue => 1f;
        public override float rangefillValue => 0.2f;
        public override float fireRateFillValue => 1f;
        public override float reloadFillValue => 0.4f;
        public override float accuracyFillValue => 0.83f;

        public override SkillDef primarySkillDef => Modules.Skills.CreatePrimarySkillDef(
new EntityStates.SerializableEntityStateType(typeof(SkillStates.Hunk.Weapon.Flamethrower.Shoot)),
"Weapon",
"ROB_HUNK_BODY_SHOOT_SHOTGUN_NAME",
"ROB_HUNK_BODY_SHOOT_SHOTGUN_DESCRIPTION",
Modules.Assets.mainAssetBundle.LoadAsset<Sprite>("texShootIcon"),
false);
    }
}