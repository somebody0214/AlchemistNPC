using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class TwilightCD : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Twilight Cooldown");
			Description.SetDefault("You cannot use Twilight's special ability yet");
			Main.debuff[Type] = true;
			canBeCleared = false;
			DisplayName.AddTranslation(GameCulture.Russian, "Сумеречная Перезарядка");
			Description.AddTranslation(GameCulture.Russian, "Вы пока не можете использовать специальную способность Сумерек");
            DisplayName.AddTranslation(GameCulture.Chinese, "蕾蒂希娅冷却");
            Description.AddTranslation(GameCulture.Chinese, "无法使用蕾蒂希娅的特殊能力");
        }
	}
}
