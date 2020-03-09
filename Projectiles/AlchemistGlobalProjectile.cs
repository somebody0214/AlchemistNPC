using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using AlchemistNPC.Projectiles;
using System.IO;
using AlchemistNPC.NPCs;
using Terraria.ModLoader.IO;

namespace AlchemistNPC.Projectiles
{
	public class AlchemistGlobalProjectile : GlobalProjectile
	{
		public bool firstTime = true;
		public static int counter = 0;

		public static int[] npcOwner = Enumerable.Repeat(-1, Main.maxProjectiles).ToArray();

		public override bool InstancePerEntity
		{
			get { return true; }
		}

		public override void SetDefaults(Projectile projectile)
		{
			if (AlchemistNPC.BastScroll == true && projectile.thrown == true)
			{
				projectile.tileCollide = false;
			}
			if (projectile.type == 358)
			{
				projectile.damage = 1;
				projectile.friendly = true;
			}
			if(Main.netMode != 2 && projectile.hostile && Main.myPlayer < 255)
			{
				// TODO: when an npc shoot a projectile who spawn projectiles, set them all to this npc
				npcOwner[projectile.whoAmI] = ModGlobalNPC.npcNow;
			}
		}

		public override bool OnTileCollide(Projectile projectile, Vector2 oldVelocity)
		{
			if (projectile.aiStyle == 88 && projectile.knockBack == .5f || (projectile.knockBack >= .2f && projectile.knockBack < .5f))
			{
				if (projectile.velocity.X != oldVelocity.X)
				{
					projectile.velocity.X = -oldVelocity.X;
					if (Math.Abs(projectile.velocity.X) <= 4)
					{
						projectile.velocity.X *= 2;
					}
				}
				if (projectile.velocity.Y != oldVelocity.Y)
				{
					projectile.velocity.Y = -oldVelocity.Y;
					if (Math.Abs(projectile.velocity.Y) <= 4)
					{
						projectile.velocity.Y *= 2;
					}
				}
				return true;
			}
			return true;
		}

		public override bool? CanHitNPC(Projectile projectile, NPC target)
		{
			if (projectile.aiStyle == 88 && ((projectile.knockBack == .5f || projectile.knockBack == .4f) || (projectile.knockBack >= .4f && projectile.knockBack < .5f)) && target.immune[projectile.owner] > 0)
			{
				return false;
			}
			return null;
		}

		public void createBee(Projectile projectile)
		{
			Player player = Main.player[projectile.owner];
			Vector2 vel = new Vector2(0, -1);
			float rand = Main.rand.NextFloat() * 6.283f;
			vel = vel.RotatedBy(rand);
			vel *= 5f;
			Projectile.NewProjectile(
				player.position.X,
				player.position.Y,
				vel.X,
				vel.Y,
				mod.ProjectileType("Bees"),
				projectile.damage / 2,
				0,
				projectile.owner
			);
		}

		public void createNAG(Projectile projectile)
		{
			Projectile.NewProjectile(
				projectile.Center.X,
				projectile.Center.Y,
				projectile.velocity.X,
				projectile.velocity.Y,
				mod.ProjectileType("NyctosythiaArrowGhost"),
				projectile.damage,
				0,
				Main.myPlayer
			);
		}

		public void createNBG(Projectile projectile)
		{
			Projectile.NewProjectile(
				projectile.Center.X,
				projectile.Center.Y,
				projectile.velocity.X,
				projectile.velocity.Y,
				mod.ProjectileType("NyctosythiaBulletGhost"),
				projectile.damage,
				0,
				Main.myPlayer
			);
		}

		public override void ModifyHitPlayer(Projectile projectile, Player target, ref int damage, ref bool crit)
		{
			if(projectile.whoAmI >= 0 || projectile.whoAmI < Main.maxProjectiles)
			{
				var owner = npcOwner[projectile.whoAmI];
				if (owner > -1 && Main.npc[owner].HasBuff(mod.BuffType("CurseOfLight")) && Main.rand.Next(4) == 0)
				{
					damage /= 2;
				}
				if (owner > -1 && Main.npc[owner].HasBuff(mod.BuffType("SymbolOfPain")))
				{
					damage -= damage/4;
				}
			}
		}

		public override Color? GetAlpha(Projectile projectile, Color lightColor)
        {
			for (int k = 0; k < 255; k++)
			{
				Player player = Main.player[k];
				if (player.active)
				{
					if (player.HasBuff(mod.BuffType("GreaterDangersense")))
					{
						if (projectile.hostile && !projectile.friendly)
						{
							Lighting.AddLight(projectile.Center, 1f, 1f, 0f);
							return Color.Yellow;
						}
					}
				}
			}
			return base.GetAlpha(projectile, lightColor);
        }
		
		public override void AI(Projectile projectile)
		{
			Player player = Main.player[projectile.owner];
			
			if (projectile.aiStyle == 99 && ((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).MasterYoyoBag)
			{
				float num1 = ProjectileID.Sets.YoyosMaximumRange[projectile.type];
				num1 += num1 * 0.25f + 100f;
			}
			
			if (firstTime && !projectile.hostile && projectile.magic && (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).LilithEmblem == true) && projectile.type != mod.ProjectileType("Bees"))
			{
				for (int g = 0; g < 2; g++)
				{
					createBee(projectile);
				}
				firstTime = false;
			}

			if (firstTime && !projectile.hostile && projectile.type == mod.ProjectileType("NyctosythiaArrow"))
			{
				createNAG(projectile);
				firstTime = false;
			}

			if (firstTime && !projectile.hostile && projectile.type == mod.ProjectileType("NyctosythiaBullet"))
			{
				createNBG(projectile);
				firstTime = false;
			}

			if (projectile.type == mod.ProjectileType("DTH"))
			{
				if (Main.rand.Next(45) == 0)
				{
					for (int g = 0; g < 3; g++)
					{
						Vector2 vel = new Vector2(0, -1);
						float rand = Main.rand.NextFloat() * 6.283f;
						vel = vel.RotatedBy(rand);
						vel *= 3f;
						Projectile.NewProjectile(
						projectile.Center.X,
						projectile.Center.Y,
						vel.X,
						vel.Y,
						mod.ProjectileType("DTHL"),
						projectile.damage,
						0,
						Main.myPlayer
						);
					}
				}
			}
			if (projectile.aiStyle == 88 && projectile.knockBack == .5f || (projectile.knockBack >= .2f && projectile.knockBack < .5f))
			{
				projectile.hostile = false;
				projectile.friendly = true;
				projectile.melee = true;
				projectile.penetrate = -1;
				if ((projectile.knockBack >= .45f && projectile.knockBack < .5f) && projectile.oldVelocity != projectile.velocity && Main.rand.Next(0, 4) == 0)
				{
					projectile.knockBack -= .0125f;
					Vector2 vector83 = projectile.velocity.RotatedByRandom(.1f);
					Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vector83.X, vector83.Y, projectile.type, projectile.damage, projectile.knockBack - .025f, projectile.owner, projectile.velocity.ToRotation(), projectile.ai[1]);
				}
			}
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).TS == true && projectile.type == ProjectileID.NebulaArcanum)
			{
				projectile.penetrate = 1;
			}
		}

		public override void ModifyHitNPC(Projectile projectile, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			Player player = Main.player[projectile.owner];
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).SFU == true && projectile.minion && Main.rand.Next(10) == 0)
			{
				crit = true;
			}
			if (projectile.type == 358)
			{
				damage = 1;
			}
		}

		public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
		{
			Player player = Main.player[projectile.owner];
			if (projectile.minion && ((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).SF == true && target.immune[projectile.owner] > 2)
			{
				target.immune[projectile.owner] = 2;
			}
			if (projectile.type == 435 && !target.friendly)
			{
				target.immune[projectile.owner] = 1;
				target.AddBuff(mod.BuffType("Electrocute"), 300);
			}
			if ((projectile.type == 340) && ((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).Pandora == true)
			{
				target.immune[projectile.owner] = 1;
			}
			if ((projectile.type == 443) && ((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).XtraT == true)
			{
				target.AddBuff(mod.BuffType("Electrocute"), 300);
				target.immune[projectile.owner] = 2;
			}
			if ((projectile.type == 98) && ((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).Traps == true)
			{
				if (Main.expertMode)
				{
					projectile.damage += 40;
				}
				else
				{
					projectile.damage += 20;
				}
				target.immune[projectile.owner] = 1;
			}
			if ((projectile.type == 184) && ((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).Traps == true)
			{
				if (Main.expertMode)
				{
					projectile.damage += 40;
				}
				else
				{
					projectile.damage += 20;
				}
				target.immune[projectile.owner] = 1;
			}
			if ((projectile.type == 185) && ((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).Traps == true)
			{
				if (Main.expertMode)
				{
					projectile.damage += 40;
				}
				else
				{
					projectile.damage += 20;
				}
				target.immune[projectile.owner] = 3;
			}
			if ((projectile.type == 186) && ((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).Traps == true)
			{
				if (Main.expertMode)
				{
					projectile.damage += 20;
				}
				else
				{
					projectile.damage += 10;
				}
				target.immune[projectile.owner] = 1;
			}
			if ((projectile.type == 187) && ((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).Traps == true)
			{
				if (Main.expertMode)
				{
					projectile.damage += 40;
				}
				else
				{
					projectile.damage += 20;
				}
				target.immune[projectile.owner] = 2;
			}
			if ((projectile.type == 188) && ((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).Traps == true)
			{
				if (Main.expertMode)
				{
					projectile.damage += 40;
				}
				else
				{
					projectile.damage += 20;
				}
				target.immune[projectile.owner] = 2;
			}
			if ((projectile.type == 654) && ((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).Traps == true)
			{
				if (Main.expertMode)
				{
					projectile.damage += 40;
				}
				else
				{
					projectile.damage += 20;
				}
				target.immune[projectile.owner] = 2;
			}

			if (projectile.aiStyle == 88 && (projectile.knockBack >= .2f && projectile.knockBack <= .5f))
			{
				target.immune[projectile.owner] = 3;
			}
			
			if (player.HeldItem.type == mod.ItemType("TerrarianW") && projectile.type == 88)
			{
				target.immune[projectile.owner] = 1;
			}
		}
	}
}