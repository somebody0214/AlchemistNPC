using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Misc
{
	class MannafromHeaven : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Manna from Heaven");
			Tooltip.SetDefault("Makes you permanently Well Fed");
			DisplayName.AddTranslation(GameCulture.Russian, "Манна Небесная");
			Tooltip.AddTranslation(GameCulture.Russian, "Делает вас постоянно сытым");
			DisplayName.AddTranslation(GameCulture.Chinese, "天赐食粮");
			Tooltip.AddTranslation(GameCulture.Chinese, "使你获得永久的'吃饱喝足'效果");

        }

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.LifeFruit);
			item.width = 26;
			item.height = 14;
			item.value = 25000000;
		}

		public override bool CanUseItem(Player player)
		{
			return player.GetModPlayer<AlchemistNPCPlayer>().WellFed < 1;
		}

		public override bool UseItem(Player player)
		{
			player.GetModPlayer<AlchemistNPCPlayer>().WellFed += 1;
			return true;
		}
	}
}
