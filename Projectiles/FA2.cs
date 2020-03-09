using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;

namespace AlchemistNPC.Projectiles
{
	public class FA2 : ModProjectile
	{
		public static int CloudChosenType = 0;
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flask of the Alchemist (Flame)");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(510);
			projectile.magic = false;
			projectile.thrown = true;
			projectile.aiStyle = 2;
		}
		
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 107);
			Gore.NewGore(projectile.Center, projectile.oldVelocity * 0.2f, 704, 1f);
			Gore.NewGore(projectile.Center, projectile.oldVelocity * 0.2f, 705, 1f);
			if (projectile.owner == Main.myPlayer)
			{
				int num2 = Main.rand.Next(20, 31);
				for (int index = 0; index < num2; ++index)
				{
					Vector2 vector2 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
					vector2.Normalize();
					vector2 *= Main.rand.Next(10, 201) * 0.01f;
					switch (Main.rand.Next(3))
					{
						case 0: CloudChosenType = mod.ProjectileType("FA21");
						break;
						case 1: CloudChosenType = mod.ProjectileType("FA22");
						break;
						case 2: CloudChosenType = mod.ProjectileType("FA23");
						break;
					}
					int proj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vector2.X*2.5f, vector2.Y*2.5f, CloudChosenType, projectile.damage, 1f, projectile.owner, 0.0f, Main.rand.Next(-45, 1));
					Main.projectile[proj].usesLocalNPCImmunity = true;
					Main.projectile[proj].localNPCHitCooldown = 30;
				}
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[projectile.owner] = 1;
			if (!Main.hardMode)
			{
			target.AddBuff(BuffID.OnFire, 180);
			}
			if (Main.hardMode && !NPC.downedMoonlord)
			{
			target.AddBuff(BuffID.CursedInferno, 180);
			}
			if (NPC.downedMoonlord)
			{
			target.AddBuff(BuffID.Daybreak, 180);
			}
		}
	}
}
