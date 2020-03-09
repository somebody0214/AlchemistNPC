using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Boosters
{
	class OgreBooster : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ogre booster");
			Tooltip.SetDefault("Increases defense and damage reduction by 5/5% and provides knockback immunity");
			DisplayName.AddTranslation(GameCulture.Russian, "Усилитель Огра");
			Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает защиту и сопротивление урону на 5/5% и даёт защиту от отбрасывания");
			DisplayName.AddTranslation(GameCulture.Chinese, "食人魔增益容器");
			Tooltip.AddTranslation(GameCulture.Chinese, "提升5防御和增加5%伤害减免并免疫击退");
        }

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.LifeFruit);
			item.consumable = false;
			item.value = 100000;
		}

		public override bool UseItem(Player player)
        {
			if (player.GetModPlayer<AlchemistNPCPlayer>().OgreBooster == 0)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().OgreBooster = 1;
				return true;
			}
			if (player.GetModPlayer<AlchemistNPCPlayer>().OgreBooster == 1)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().OgreBooster = 0;
				return true;
			}
			return base.UseItem(player);
		}
	}
}
