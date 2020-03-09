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
	public class TwilightBoost : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Twilight Boost");
			Description.SetDefault("You are immune to damage and deal 3x damage");
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Сумеречное Усиление");
			Description.AddTranslation(GameCulture.Russian, "Вы неуязвимы и наносите трёхкратный урон");
            DisplayName.AddTranslation(GameCulture.Chinese, "蕾蒂希娅增强");
            Description.AddTranslation(GameCulture.Chinese, "免疫伤害, 造成3倍伤害");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			if (player.HeldItem.type != mod.ItemType("Twilight"))
			{
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			player.immune = true;
			player.thrownDamage += 3f;
			player.meleeDamage += 3f;
			player.rangedDamage += 3f;
			player.magicDamage += 3f;
			player.minionDamage += 3f;
			if (ModLoader.GetMod("ThoriumMod") != null)
				{
				ThoriumBoosts(player);
				}
				if (ModLoader.GetMod("Redemption") != null)
				{
				RedemptionBoost(player);
				}
				if (ModLoader.GetMod("CalamityMod") != null)
				{
				CalamityBoost(player);
				}
		}
		
		private void CalamityBoost(Player player)
        {
			CalamityMod.CalPlayer.CalamityPlayer CalamityPlayer = player.GetModPlayer<CalamityMod.CalPlayer.CalamityPlayer>();
			CalamityPlayer.throwingDamage += 3f;
        }
		private readonly Mod Calamity = ModLoader.GetMod("CalamityMod");
		
		private void RedemptionBoost(Player player)
        {
			Redemption.Items.DruidDamageClass.DruidDamagePlayer RedemptionPlayer = player.GetModPlayer<Redemption.Items.DruidDamageClass.DruidDamagePlayer>();
			RedemptionPlayer.druidDamage += 3f;
        }
		private readonly Mod Redemption = ModLoader.GetMod("Redemption");
		
		private void ThoriumBoosts(Player player)
        {
            ThoriumMod.ThoriumPlayer ThoriumPlayer = player.GetModPlayer<ThoriumMod.ThoriumPlayer>();
            ThoriumPlayer.symphonicDamage += 3f;
			ThoriumPlayer.radiantBoost += 3f;
        }
		
		private readonly Mod Thorium = ModLoader.GetMod("ThoriumMod");
	}
}
