using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using Terraria.Localization;
using Terraria.World.Generation;
using AlchemistNPC;

namespace AlchemistNPC.Items.Weapons
{
	public class GoldenKnuckles : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Golden Knuckles");
			Tooltip.SetDefault("The weapon of the legendary grifter"
			+ "\nMay not look so tough, but hits hard");
			DisplayName.AddTranslation(GameCulture.Russian, "Золотой Кастет");
            Tooltip.AddTranslation(GameCulture.Russian, "Оружие легендарного мошенника\nМожет не выглядеть так уж сурово, но бьёт действительно сильно");
			DisplayName.AddTranslation(GameCulture.Chinese, "黄金指虎");
			Tooltip.AddTranslation(GameCulture.Chinese, "传奇骗术师的武器"
			+ "\n看起来不怎么牢固, 但是打人很疼");
        }

		public override void SetDefaults()
		{
			item.melee = true;
			item.damage = 666;
			item.width = 28;
			item.height = 28;
			item.useTime = 6;
			item.useAnimation = 6;
			item.useStyle = 1;
			item.value = 10000000;
			item.rare = 11;
            item.knockBack = 4;
            item.autoReuse = true;
			item.UseSound = SoundID.Item1;
			item.scale = 0.5f;
		}
		
		public override void ModifyHitNPC(Player player, NPC target, ref int damage, ref float knockback, ref bool crit)
		{
			damage *= 3;
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("Patience"), 120);
		}
	}
}
