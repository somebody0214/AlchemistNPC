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
	public class CAE : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.LaserMachinegunLaser);
			projectile.magic = false;
			projectile.ranged = true;
			projectile.width = 8;
			projectile.height = 56;
			projectile.penetrate = 30;
			projectile.timeLeft = 30;
			projectile.tileCollide = false;
			aiType = ProjectileID.LaserMachinegunLaser;
		}
		
		public override void AI()
		{
			if (Main.rand.Next(2) == 0)
				{
					Dust dust = Dust.NewDustDirect(projectile.position, projectile.height, projectile.width, mod.DustType("SA"),
						projectile.velocity.X, projectile.velocity.Y, 200, Scale: 1.2f);
					dust.velocity += projectile.velocity * 0.3f;
					dust.velocity *= 0.2f;
				}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[projectile.owner] = 1;
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
			}
		}
	
	}
}