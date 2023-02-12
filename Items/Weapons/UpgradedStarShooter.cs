using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using ZRTMod.Projectiles;
using Terraria;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using ZRTMod.Ammo;

namespace ZRTMod.Items.Weapons
{
    /// <summary>
	/// This weapon and its corresponding projectile showcase the CloneDefaults() method, which allows for cloning of other items.
	/// For this example, we shall copy the Meowmere and its projectiles with the CloneDefaults() method, while also changing them slightly.
	/// For a more detailed description of each item field used here, check out <see cref="ExampleSword" />.
	/// </summary>
	public class UpgradedStarShooter : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Super Duper Star Shooter");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            // This method right here is the backbone of what we're doing here; by using this method, we copy all of
            // the meowmere's SetDefault stats (such as Item.melee and Item.shoot) on to our item, so we don't have to
            // go into the source and copy the stats ourselves. It saves a lot of time and looks much cleaner; if you're
            // going to copy the stats of an item, use CloneDefaults().

            Item.CloneDefaults(ItemID.SuperStarCannon);

            // After CloneDefaults has been called, we can now modify the stats to our wishes, or keep them as they are.
            // For the sake of example, let's swap the vanilla Meowmere projectile shot from our item for our own projectile by changing Item.shoot:

            Item.shoot = ModContent.ProjectileType<ZRTHomingStar>(); // Remember that we must use ProjectileType<>() since it is a modded projectile!
            // Item.useAmmo = ModContent.ItemType<HomingStarAmmo>();                // Check out ExampleCloneProjectile to see how this projectile is different from the Vanilla Meowmere projectile.
            Item.UseSound = SoundID.Item9;

            // While we're at it, let's make our weapon's stats a bit stronger than the Meowmere, which can be done
            // by using math on each given stat.
            Item.noMelee = true;

            Item.damage *= 1; // Makes this weapon's damage double the super star cannon's damage.
            Item.shootSpeed *= 1f; // Makes this weapon's projectiles shoot 25% faster than the super star cannon's projectiles.
        }


        // makes shots appear out of muzzle exatlc
        /*        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
                {
                    Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;
                    if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
                    {
                        position += muzzleOffset;
                    }
                }*/

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.SuperStarCannon)
                .AddIngredient(ItemID.FallenStar, 999)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
