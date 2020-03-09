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

namespace AlchemistNPC.Items.Weapons
{
	public class SwordofArachna : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sword of Arachna");
			Tooltip.SetDefault("Infects enemies on first hit, releases spiders on second");
			DisplayName.AddTranslation(GameCulture.Russian, "Меч Арахны");
            Tooltip.AddTranslation(GameCulture.Russian, "Заражает противников при первом ударе, выпускает пауков при втором");
			DisplayName.AddTranslation(GameCulture.Chinese, "蛛王剑");
            Tooltip.AddTranslation(GameCulture.Chinese, "第一次击中感染敌人, 第二次释放蜘蛛");
		}

		public override void SetDefaults()
		{
			item.damage = 21;
			item.melee = true;
			item.crit = 10;
			item.width = 52;
			item.height = 52;
			item.useTime = 35;
			item.useAnimation = 35;
			item.useStyle = 1;
			item.value = 10000;
			item.rare = 2;
            item.knockBack = 4;
            item.autoReuse = true;
			item.UseSound = SoundID.Item1;
			item.scale = 1.5f;
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			if (target.HasBuff(mod.BuffType("Infested")))
			{
				Vector2 vel2 = new Vector2(-1, -1);
				vel2 *= 3f;
				int p1 = Projectile.NewProjectile(target.position.X-30, target.position.Y-30, vel2.X, vel2.Y, 379, damage/2, 0, Main.myPlayer);
				Main.projectile[p1].usesLocalNPCImmunity = true;
				Main.projectile[p1].localNPCHitCooldown = 1;
				Vector2 vel4 = new Vector2(1, -1);
				vel4 *= 3f;
				int p2 = Projectile.NewProjectile(target.position.X+30, target.position.Y-30, vel4.X, vel4.Y, 379, damage/2, 0, Main.myPlayer);
				Main.projectile[p2].usesLocalNPCImmunity = true;
				Main.projectile[p2].localNPCHitCooldown = 1;
				Vector2 vel6 = new Vector2(0, -1);
				vel6 *= 3f;
				int p3 = Projectile.NewProjectile(target.position.X, target.position.Y-30, vel6.X, vel6.Y, 379, damage/2, 0, Main.myPlayer);
				Main.projectile[p3].usesLocalNPCImmunity = true;
				Main.projectile[p3].localNPCHitCooldown = 1;
				Vector2 vel7 = new Vector2(-1, 0);
				vel7 *= 3f;
				int p4 = Projectile.NewProjectile(target.position.X-30, target.position.Y, vel7.X, vel7.Y, 379, damage/2, 0, Main.myPlayer);
				Main.projectile[p4].usesLocalNPCImmunity = true;
				Main.projectile[p4].localNPCHitCooldown = 1;
				Vector2 vel8 = new Vector2(1, 0);
				vel8 *= 3f;
				int p5 = Projectile.NewProjectile(target.position.X+30, target.position.Y, vel8.X, vel8.Y, 379 ,damage/2, 0, Main.myPlayer);
				Main.projectile[p5].usesLocalNPCImmunity = true;
				Main.projectile[p5].localNPCHitCooldown = 1;
				player.ClearBuff(BuffType<Buffs.Infested>());
			}
			else target.AddBuff(mod.BuffType("Infested"), 180);
		}
	}
}
