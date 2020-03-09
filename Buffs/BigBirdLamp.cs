using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class BigBirdLamp : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Big Bird's Lamp");
			Description.SetDefault("Character is emitting light, all damage & crit chance are increased by 5%, attacks remove some of the enemy defense");
			Main.buffNoSave[Type] = true;
			Main.debuff[Type] = false;
			canBeCleared = true;
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Лампа Большой Птицы");
            Description.AddTranslation(GameCulture.Russian, "Персонаж светится, весь урон и шанс крита повышаются на 5%, атаки повреждают часть брони противника");

            DisplayName.AddTranslation(GameCulture.Chinese, "大鸟灯");
            Description.AddTranslation(GameCulture.Chinese, "你会发光~~~ \n增加5%全伤害和暴击率, 攻击摧毁敌人护甲");
        }
		public override void Update(Player player, ref int buffIndex)
		{
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).trigger == true)
			{
			Lighting.AddLight((int)((double)player.position.X + (double)(player.width / 2)) / 16, (int)((double)player.position.Y + (double)(player.height / 2)) / 16, 3f, 3f, 3f);
			}
			else
			{
			}
		}
	}
}
