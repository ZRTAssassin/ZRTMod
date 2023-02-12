using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using ZRTMod.Projectiles;

namespace ZRTMod.Items.Weapons
{
    public class ZRTPrism : ModItem
    {
        // You can use a vanilla texture for your item by using the format: "Terraria/Item_<Item ID>".
        /*public override string Texture => "Terraria/Item_" + ItemID.LastPrism;*/
        public static Color OverrideColor = new Color(75, 0, 130);

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("ZRT LastPrism");
            Tooltip.SetDefault("A slightly different laser-firing Prism Ignores NPC immunity frames and fires 10 beams at once instead of 6.");
        }

        public override void SetDefaults()
        {
            // Start by using CloneDefaults to clone all the basic item properties from the vanilla Last Prism.
            // For example, this copies sprite size, use style, sell price, and the item being a magic weapon.

            Item.CloneDefaults(ItemID.LastPrism);
            Item.mana = 6;
            Item.damage = 20;
            Item.shoot = ModContent.ProjectileType<ZRTPrismHoldout>();
            Item.shootSpeed = 30f;

            // Change the item's draw color so that it is visually distinct from the vanilla Last Prism.
            Item.color = OverrideColor;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.HallowedBar, 10)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }

        // Because this weapon fires a holdout projectile, it needs to block usage if its projectile already exists.
        public override bool CanUseItem(Player player) => player.ownedProjectileCounts[ModContent.ProjectileType<ZRTPrismHoldout>()] <= 0;
    }
}
