using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;
using AlchemistNPC.Items.Weapons;

namespace AlchemistNPC.Projectiles
{
	public class RedWaveExp : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Red Wave Explosion");
			projectile.timeLeft = 40;
			projectile.light = 0.8f;
			Main.projFrames[projectile.type] = 7;
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.LaserMachinegunLaser);
			projectile.magic = false;
			projectile.melee = true;
			projectile.width = 98;
			projectile.height = 98;
			projectile.penetrate = 40;
			projectile.timeLeft = 40;
			projectile.tileCollide = false;
			aiType = ProjectileID.LaserMachinegunLaser;
		}
		
		public override void AI()
		{
			if (projectile.timeLeft < 40)
			{
				projectile.friendly = false;
			}
			if (projectile.frameCounter < 5)
				projectile.frame = 0;
			else if (projectile.frameCounter >= 5 && projectile.frameCounter < 10)
				projectile.frame = 1;
			else if (projectile.frameCounter >= 10 && projectile.frameCounter < 15)
				projectile.frame = 2;
			else if (projectile.frameCounter >= 15 && projectile.frameCounter < 20)
				projectile.frame = 3;
			else if (projectile.frameCounter >= 20 && projectile.frameCounter < 25)
				projectile.frame = 4;
			else if (projectile.frameCounter >= 25 && projectile.frameCounter < 30)
				projectile.frame = 5;
			else if (projectile.frameCounter >= 30 && projectile.frameCounter < 35)
				projectile.frame = 6;
			else
				projectile.frameCounter = 0;
			projectile.frameCounter++;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[projectile.owner] = 1;
		}
	
	}
}
