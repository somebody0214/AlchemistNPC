using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Items.Misc
{
	public class WardingToken : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Warding Token");
			Tooltip.SetDefault("While this is in your inventory, your next accessory reforge would be ''Warding''"
			+"\nReforging priorities: Menacing->Lucky->Violent->Warding"
			+"\nConsumes in process");
			DisplayName.AddTranslation(GameCulture.Russian, "Значок Защиты");
            Tooltip.AddTranslation(GameCulture.Russian, "Если находится в инвентаре, ваше следующая перековка аксессуара будет ''Защитный''\nБудет потрачен в процессе");
			DisplayName.AddTranslation(GameCulture.Chinese, "护佑重铸币");
			Tooltip.AddTranslation(GameCulture.Chinese, "放置于物品栏时, 饰品下一次重铸时词缀变为'护佑'\n重铸优先级: 险恶->幸运->暴力->护佑\n在过程中将会被消耗");
        }

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 250000;
			item.rare = 7;
		}
	}
}
