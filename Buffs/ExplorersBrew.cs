using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class ExplorersBrew : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Explorer's Brew");
			Description.SetDefault("Grants all possible vision buffs, vastly increases mining speed and light radius around the player. Your attacks can Electrocute enemies"
			+"\nGrants effects of Gills, Flippers and Water Walking Potions");
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Варево Исследователя");
            Description.AddTranslation(GameCulture.Russian, "Даёт все возможные виды зрения, значительно увеличивает скорость копания.\nЗначительно увеличивает радиус света вокруг игрока и ваши атаки могут поразить врага Электрошоком\nТакже даёт эффекты Подводного Дыхания, Ласт и Хождения по воде");
            DisplayName.AddTranslation(GameCulture.Chinese, "探险者陈酿");
            Description.AddTranslation(GameCulture.Chinese, "获得所有感知效果, 极大增加召唤速度, 极大增加玩家周围的光照效果, 并且你的攻击会使敌人触电\n同时给予鱼鳃、脚蹼和水上行走药剂效果");
        }
		public override void Update(Player player, ref int buffIndex)
		{
			player.findTreasure = true;
			Lighting.AddLight((int)((double)player.position.X + (double)(player.width / 2)) / 16, (int)((double)player.position.Y + (double)(player.height / 2)) / 16, 3f, 3f, 3f);
			player.nightVision = true;
			player.detectCreature = true;
			player.pickSpeed -= 0.50f;
			player.dangerSense = true;
			player.gills = true;
			player.waterWalk = true;
			player.ignoreWater = true;
            player.accFlipper = true;
			player.buffImmune[mod.BuffType("ExplorerComb")] = true;
			player.buffImmune[4] = true;
			player.buffImmune[15] = true;
			player.buffImmune[109] = true;
			player.buffImmune[9] = true;
			player.buffImmune[11] = true;
			player.buffImmune[12] = true;
			player.buffImmune[17] = true;
			player.buffImmune[104] = true;
			player.buffImmune[111] = true;
			BuffLoader.Update(BuffID.Gills, player, ref buffIndex);
			BuffLoader.Update(BuffID.Flipper, player, ref buffIndex);
			BuffLoader.Update(BuffID.Shine, player, ref buffIndex);
		}
	}
}
