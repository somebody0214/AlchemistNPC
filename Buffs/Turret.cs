using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class Turret : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("GLaDOS turret");
			Description.SetDefault("Turret is protecting you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Турель ГЛаДОС");
			Description.AddTranslation(GameCulture.Russian, "Турель защищает вас");
			DisplayName.AddTranslation(GameCulture.Chinese, "G姐炮塔");
            Description.AddTranslation(GameCulture.Chinese, "G姐炮塔保护着你");
        }

		public override void Update(Player player, ref int buffIndex)
		{
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Turret")] > 0)
			{
				modPlayer.turret = true;
			}
			if (!modPlayer.turret)
			{
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else
			{
				player.buffTime[buffIndex] = 18000;
			}
		}
	}
}