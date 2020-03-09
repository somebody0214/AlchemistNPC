using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class BreathOfTheVoid : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 22222;
			item.magic = true;
			item.width = 38;
			item.height = 34;
			item.useTime = 5;
			item.useAnimation = 15;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 4;
			item.UseSound = SoundID.Item34;
			item.value = 10000000;
			item.rare = 11;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("BreathOfTheVoid");
			item.shootSpeed = 9f;
			item.channel = true;
			item.noUseGraphic = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Expiration");
			Tooltip.SetDefault("Feel the Breath of the Void");
			DisplayName.AddTranslation(GameCulture.Chinese, "限度之息");
			Tooltip.AddTranslation(GameCulture.Chinese, "感受虚空的气息");
        }
	}
}
