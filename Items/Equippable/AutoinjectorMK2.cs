using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.UI;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Equippable
{
	public class AutoinjectorMK2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Autoinjector MK2");
			Tooltip.SetDefault("Provides life regeneration, lowers cooldown of healing potions and increases length of invincibility after taking hit"
				+ "\nAdds 15% to all damage and 10% to all critical chances"
				+ "\nGives all effects of Universal Combination"
				+ "\nGives effects of modded Combinations as well"
				+ "\nHiding visual disables Thorium and Spirit buffs"
				+ "\nLowers critical strike chance reduction of Memer's Riposte");
				DisplayName.AddTranslation(GameCulture.Russian, "Автоинъектор MK2");
            Tooltip.AddTranslation(GameCulture.Russian, "Усиливает регенерацию \nУменьшает откат зелий лечения \nУвеличивает период неуязвимости после получения урона\nДобавляет 15% ко всем видам урона и 10% ко всем шансам критического удара\nДаёт эффект Комбинации Универсала\nТакже даёт эффекты модовых Комбинаций\nМожно отключить эффекты модовых баффов Ториума и Спирита с помощью изменения видимости\nПонижает уменьшение шанса критического удара Ответа Мемеру");

            DisplayName.AddTranslation(GameCulture.Chinese, "自动注射器");
            Tooltip.AddTranslation(GameCulture.Chinese, "提供生命回复, 降低治疗药水的冷却时间, 延长收到伤害后的无敌时间\n增加15%全伤害和10%全伤害的暴击率\n给予万能药剂包buff（包含坦克药剂包、魔法药剂包、射手药剂包以及召唤师药剂包）\n同样给予所有模组药剂包的效果\n调节饰品可见度来关闭瑟银和魂灵的Buff\n减少'Memer的反击'给予的暴击率降低效果");
        }
	
		public override void SetDefaults()
		{
			item.stack = 1;
			item.width = 26;
			item.height = 26;
			item.value = 1000000;
			item.rare = 11;
			item.accessory = true;
			item.defense = 4;
			item.lifeRegen = 2;
			item.expert = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).AutoinjectorMK2 = true;
			player.allDamage += 0.15f;
			player.meleeCrit += 10;
            player.rangedCrit += 10;
            player.magicCrit += 10;
            player.thrownCrit += 10;
			player.pStone = true;
			player.longInvince = true;
			player.AddBuff(mod.BuffType("UniversalComb"), 2);
			if (ModLoader.GetMod("CalamityMod") != null)
			{
			player.AddBuff(mod.BuffType("CalamityComb"), 2);
			Mod Calamity = ModLoader.GetMod("CalamityMod");
			if(Calamity != null)
			{
				Calamity.Call("AddRogueCrit", player, 10);
			}
			}
			if (ModLoader.GetMod("Redemption") != null)
			{
			RedemptionBoost(player);
			}
			if (ModLoader.GetMod("ThoriumMod") != null)
			{
			ThoriumBoosts(player);
			}
			if (!hideVisual)
			{
				if (ModLoader.GetMod("SpiritMod") != null)
				{
				player.AddBuff(mod.BuffType("SpiritComb"), 2);
				}
				if (ModLoader.GetMod("ThoriumMod") != null)
				{
				player.AddBuff(mod.BuffType("ThoriumComb"), 2);
				}
			}
		}
		
		private void RedemptionBoost(Player player)
        {
			Redemption.Items.DruidDamageClass.DruidDamagePlayer RedemptionPlayer = player.GetModPlayer<Redemption.Items.DruidDamageClass.DruidDamagePlayer>();
            RedemptionPlayer.druidCrit += 10;
        }
		private void ThoriumBoosts(Player player)
        {
            ThoriumMod.ThoriumPlayer ThoriumPlayer = player.GetModPlayer<ThoriumMod.ThoriumPlayer>();
            ThoriumPlayer.symphonicCrit += 10;
            ThoriumPlayer.radiantCrit += 10;
        }
	}
}
