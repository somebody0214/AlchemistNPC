using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Summoning
{
	public class RealityPiercer : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Reality Piercer");
			Tooltip.SetDefault("Makes Explorer to come into unobserved world.");
			DisplayName.AddTranslation(GameCulture.Russian, "Прорыватель Реальности");
            Tooltip.AddTranslation(GameCulture.Russian, "Позволяет Исследовательнице прийти в необследованный мир.");

            DisplayName.AddTranslation(GameCulture.Chinese, "真实锐眼");
            Tooltip.AddTranslation(GameCulture.Chinese, "允许探险家来到未被观察的世界");
		}

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.maxStack = 30;
			item.value = 5000000;
			item.rare = 11;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = 4;
			item.consumable = true;
			item.makeNPC = (short)mod.NPCType("Explorer");
		}

		public override void HoldItem(Player player)
		{
		Player.tileRangeX += 600;
        Player.tileRangeY += 600;
		}
		
		public override bool CanUseItem(Player player)
		{
			Vector2 vector2 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
			return (!NPC.AnyNPCs(mod.NPCType("Explorer")) && !Collision.SolidCollision(vector2, player.width, player.height));
		}

		public override void OnConsumeItem(Player player)
		{
			Main.NewText("An Explorer has come.", 255, 255, 255);
		}
	}
}