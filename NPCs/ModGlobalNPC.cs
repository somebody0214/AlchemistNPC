using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ReLogic.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Events;
using Terraria.GameContent.Tile_Entities;
using Terraria.GameContent.UI;
using Terraria.GameInput;
using Terraria.Graphics.Capture;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ObjectData;
using Terraria.Social;
using Terraria.UI;
using Terraria.UI.Chat;
using Terraria.UI.Gamepad;
using Terraria.Utilities;
using Terraria.World.Generation;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using AlchemistNPC;

namespace AlchemistNPC.NPCs
{
	public class ModGlobalNPC : GlobalNPC
	{
		public bool banned = false;
		public bool light = false;
		public bool chaos = false;
		public bool rainbowdust = false;
		public bool electrocute = false;
		public bool corrosion = false;
		public bool twilight = false;
		public bool justitiapale = false;
		public int S = 0;
		public int C = 0;
		public bool N1 = false;
		public bool N2 = false;
		public bool N3 = false;
		public bool N4 = false;
		public bool N5 = false;
		public bool N6 = false;
		public bool N7 = false;
		public bool N8 = false;
		public bool N9 = false;
		public static int npcNow;

		public override bool PreAI(NPC npc)
		{
			for (int k = 0; k < 255; k++)
			{
				Player player = Main.player[k];
				if (player.active)
				{
					if (player.HasBuff(mod.BuffType("NULL")))
					{
						return false;
					}
				}
			}
			npcNow = npc.whoAmI;
			return true;
		}

		public static int kc = 0;
		public static bool ks = false;
		public bool cheat = false;
		public bool i1 = false;
		public bool i2 = false;
		public bool i3 = false;
		public int bc = 0;
		public int bc2 = 0;
		public bool start = false;
		public bool intermission1 = false;
		public bool stop1 = false;
		public bool intermission2 = false;
		public bool stop2 = false;
		public bool phase2 = false;
		public bool phase3 = false;
		
		public override bool InstancePerEntity
		{
			get
			{
				return true;
			}
		}

		public override bool CheckDead(NPC npc)
		{
			if (npc.townNPC && npc.HasBuff(mod.BuffType("IField")))
			{
				int respawn = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, npc.type);
				Main.npc[respawn].buffImmune[mod.BuffType("IField")] = false;
				Main.npc[respawn].AddBuff(mod.BuffType("IField"), 3600);
				return true;
				
			}
			return base.CheckDead(npc);
		}

		public override void ModifyHitByItem(NPC npc, Player player, Item item, ref int damage, ref float knockback, ref bool crit)
		{
			if (item.type == mod.ItemType("EdgeOfChaos"))
			{
				S++;
			}
			if (item.type == mod.ItemType("HolyAvenger"))
			{
				C++;
			}
			if (item.type == mod.ItemType("LightOfCeraSumat"))
			{
				C+= 3;
			}
			if (npc.HasBuff(mod.BuffType("CurseOfLight")))
			{
				damage += damage / 5;
			}
			if (npc.HasBuff(mod.BuffType("SymbolOfPain")))
			{
				damage += damage/4;
			}
			if (player.HasBuff(mod.BuffType("ExecutionersEyes")))
			{
				damage += (damage/20)*3;
			}
		}

		public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (npc.HasBuff(mod.BuffType("CurseOfLight")))
			{
				damage += damage / 5;
			}
			if (npc.HasBuff(mod.BuffType("SymbolOfPain")))
			{
				damage += damage/4;
			}
			Player player = Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)];
			if (player.HasBuff(mod.BuffType("LaserBattery")) && projectile.type == 433)
			{
				projectile.ranged = true;
				if (Main.rand.Next(4) == 0)
				{
					crit = true;
				}
			}
			if (player.HasBuff(mod.BuffType("ExecutionersEyes")))
			{
				damage += (damage/20)*3;
			}
		}

		public override void ModifyHitPlayer(NPC npc, Player target, ref int damage, ref bool crit)
		{
			if (npc.HasBuff(mod.BuffType("CurseOfLight")) && Main.rand.Next(4) == 0)
			{
				damage /= 2;
			}
			if (npc.HasBuff(mod.BuffType("SymbolOfPain")))
			{
				damage -= damage/4;
			}
		}

		public override void GetChat(NPC npc, ref string chat)
		{
			string D1 = Language.GetTextValue("Mods.AlchemistNPC.D1");
			string D2 = Language.GetTextValue("Mods.AlchemistNPC.D2");
			string D3 = Language.GetTextValue("Mods.AlchemistNPC.D3");
			string D4 = Language.GetTextValue("Mods.AlchemistNPC.D4");
			string AD1 = Language.GetTextValue("Mods.AlchemistNPC.AD1");
			string AD2 = Language.GetTextValue("Mods.AlchemistNPC.AD2");
			string ADch1 = Language.GetTextValue("Mods.AlchemistNPC.ADch1");
			int Angela = NPC.FindFirstNPC(mod.NPCType("Operator"));
			int Dryad = NPC.FindFirstNPC(NPCID.Dryad);
			if (npc.type == NPCID.Dryad)
			{
				if (Angela >= 0 && Main.rand.NextBool(10))
				{
					switch (Main.rand.Next(4))
					{
						case 0:                                     
						chat = D1;
						break;
						default:
						chat = D2;
						break;
					}
				}
				if (Main.hardMode && Angela >= 0 && Main.rand.NextBool(10))
				{
					switch (Main.rand.Next(2))
					{
						case 0:                                     
						chat = D3;
						break;
						default:
						chat = D4;
						break;
					}
				}
			}
			if (npc.type == NPCID.ArmsDealer)
			{
				if (Angela >= 0 && Main.rand.NextBool(10))
				{
					switch (Main.rand.Next(2))
					{
						case 0:                                     
						chat = (AD1 + Main.npc[Dryad].GivenName + ADch1);
						break;
						default:
						chat = AD2;
						break;
					}
				}
			}
		}
		
		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			for (int k = 0; k < 255; k++)
			{
				Player player = Main.player[k];
				if (player.active)
				{
					if (type == mod.NPCType("Brewer") || type == mod.NPCType("Alchemist") || type == mod.NPCType("Young Brewer"))
					{
						for (nextSlot = 0; nextSlot < 40; ++nextSlot)
						{
							shop.item[nextSlot].shopCustomPrice *= AlchemistNPC.modConfiguration.PotsPriceMulti;
							if (ModLoader.GetMod("CalamityMod") != null)
							{
								if (AlchemistNPC.modConfiguration.RevPrices && CalamityModRevengeance)
								{
									shop.item[nextSlot].shopCustomPrice += shop.item[nextSlot].shopCustomPrice/2;
								}
							}
							if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).AlchemistCharmTier4)
							{
								shop.item[nextSlot].shopCustomPrice -= shop.item[nextSlot].shopCustomPrice/2;
							}
							else if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).AlchemistCharmTier3)
							{
								shop.item[nextSlot].shopCustomPrice -= ((shop.item[nextSlot].shopCustomPrice/20)*7);
							}
							else if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).AlchemistCharmTier2)
							{
								shop.item[nextSlot].shopCustomPrice -= shop.item[nextSlot].shopCustomPrice/4;
							}
							else if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).AlchemistCharmTier1)
							{
								shop.item[nextSlot].shopCustomPrice -= shop.item[nextSlot].shopCustomPrice/10;
							}
						}
					}
				}
			}
			if (ModLoader.GetMod("Tremor") != null)
			{
				if (type == ModLoader.GetMod("Tremor").NPCType("Lady Moon"))
				{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("DarkMass"));
					shop.item[nextSlot].shopCustomPrice = 7500;
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("CarbonSteel"));
					shop.item[nextSlot].shopCustomPrice = 10000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("Doomstone"));
					shop.item[nextSlot].shopCustomPrice = 25000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("NightmareBar"));
					shop.item[nextSlot].shopCustomPrice = 25000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("VoidBar"));
					shop.item[nextSlot].shopCustomPrice = 50000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("AngryShard"));
					shop.item[nextSlot].shopCustomPrice = 50000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("Phantaplasm"));
					shop.item[nextSlot].shopCustomPrice = 50000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("ClusterShard"));
					shop.item[nextSlot].shopCustomPrice = 50000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("DragonCapsule"));
					shop.item[nextSlot].shopCustomPrice = 50000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("HuskofDusk"));
					shop.item[nextSlot].shopCustomPrice = 100000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("NightCore"));
					shop.item[nextSlot].shopCustomPrice = 100000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("GoldenClaw"));
					shop.item[nextSlot].shopCustomPrice = 100000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("StoneDice"));
					shop.item[nextSlot].shopCustomPrice = 100000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("ConcentratedEther"));
					shop.item[nextSlot].shopCustomPrice = 100000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("Squorb"));
					shop.item[nextSlot].shopCustomPrice = 250000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("ToothofAbraxas"));
					shop.item[nextSlot].shopCustomPrice = 250000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("CosmicFuel"));
					shop.item[nextSlot].shopCustomPrice = 1000000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("EyeofOblivion"));
					shop.item[nextSlot].shopCustomPrice = 3000000;
					nextSlot++;
				}
			}
		}

		public override void SetDefaults(NPC npc)
		{
			if (npc.type == NPCID.Steampunker || npc.type == NPCID.Wizard || npc.type == NPCID.Guide || npc.type == NPCID.Nurse || npc.type == NPCID.Demolitionist || npc.type == NPCID.Merchant || npc.type == NPCID.DyeTrader || npc.type == NPCID.Dryad || npc.type == NPCID.DD2Bartender || npc.type == NPCID.ArmsDealer || npc.type == NPCID.Stylist || npc.type == NPCID.Painter || npc.type == NPCID.Angler || npc.type == NPCID.GoblinTinkerer || npc.type == NPCID.WitchDoctor || npc.type == NPCID.Clothier || npc.type == NPCID.Mechanic || npc.type == NPCID.PartyGirl || npc.type == NPCID.TaxCollector || npc.type == NPCID.Truffle || npc.type == NPCID.Pirate || npc.type == NPCID.Cyborg || npc.type == NPCID.SantaClaus)
			{
				if (NPC.downedMoonlord)
				{
					npc.lifeMax = 500;
				}
			}
			if (npc.type == mod.NPCType("Alchemist") || npc.type == mod.NPCType("Brewer") || npc.type == mod.NPCType("Young Brewer") || npc.type == mod.NPCType("Jeweler") || npc.type == mod.NPCType("Architect") || npc.type == mod.NPCType("Musician") || npc.type == mod.NPCType("Tinkerer"))
			{
				if (NPC.downedMoonlord)
				{
					npc.lifeMax = 500;
				}
			}
			if (ModLoader.GetMod("MaterialTraderNpc") != null)
			{
				if (npc.type == (ModLoader.GetMod("MaterialTraderNpc").NPCType("Jungle Trader")) || npc.type == (ModLoader.GetMod("MaterialTraderNpc").NPCType("Cavern Trader")) || npc.type == (ModLoader.GetMod("MaterialTraderNpc").NPCType("Cool Guy")) || npc.type == (ModLoader.GetMod("MaterialTraderNpc").NPCType("Desert Trader")) || npc.type == (ModLoader.GetMod("MaterialTraderNpc").NPCType("Dungeon Trader")) || npc.type == (ModLoader.GetMod("MaterialTraderNpc").NPCType("Evil Trader")) || npc.type == (ModLoader.GetMod("MaterialTraderNpc").NPCType("Hell Trader")) || npc.type == (ModLoader.GetMod("MaterialTraderNpc").NPCType("Holy Trader")) || npc.type == (ModLoader.GetMod("MaterialTraderNpc").NPCType("Ocean Trader")) || npc.type == (ModLoader.GetMod("MaterialTraderNpc").NPCType("Sky Trader")) || npc.type == (ModLoader.GetMod("MaterialTraderNpc").NPCType("Winter Trader")))
				{
					if (NPC.downedMoonlord)
					{
						npc.lifeMax = 500;
					}
				}
			}
			if (npc.type == NPCID.Unicorn)
			{
				Main.npcCatchable[npc.type] = true;
				npc.catchItem = (short)mod.ItemType("CaughtUnicorn");
			}
			if (npc.type == mod.NPCType("Alchemist"))
			{
				Main.npcCatchable[npc.type] = true;
				npc.catchItem = (short)mod.ItemType("AlchemistHorcrux");
			}
			if (npc.type == mod.NPCType("Brewer"))
			{
				Main.npcCatchable[npc.type] = true;
				npc.catchItem = (short)mod.ItemType("BrewerHorcrux");
			}
			if (npc.type == mod.NPCType("Architect"))
			{
				Main.npcCatchable[npc.type] = true;
				npc.catchItem = (short)mod.ItemType("ArchitectHorcrux");
			}
			if (npc.type == mod.NPCType("Jeweler"))
			{
				Main.npcCatchable[npc.type] = true;
				npc.catchItem = (short)mod.ItemType("JewelerHorcrux");
			}
			if (npc.type == mod.NPCType("Operator"))
			{
				Main.npcCatchable[npc.type] = true;
				npc.catchItem = (short)mod.ItemType("APMC");
			}
			if (npc.type == mod.NPCType("OtherworldlyPortal"))
			{
				Main.npcCatchable[npc.type] = true;
				npc.catchItem = (short)mod.ItemType("NotesBook");
			}
			if (npc.type == mod.NPCType("Explorer"))
			{
				Main.npcCatchable[npc.type] = true;
				npc.catchItem = (short)mod.ItemType("RealityPiercer");
			}
			if (npc.type == mod.NPCType("Musician"))
			{
				Main.npcCatchable[npc.type] = true;
				npc.catchItem = (short)mod.ItemType("MusicianHorcrux");
			}
			if (npc.type == mod.NPCType("Tinkerer"))
			{
				Main.npcCatchable[npc.type] = true;
				npc.catchItem = (short)mod.ItemType("TinkererHorcrux");
			}
		}

		public override void TownNPCAttackStrength(NPC npc, ref int damage, ref float knockback)
		{
			if (npc.type == NPCID.Steampunker || npc.type == NPCID.Wizard || npc.type == NPCID.Guide || npc.type == NPCID.Nurse || npc.type == NPCID.Demolitionist || npc.type == NPCID.Merchant || npc.type == NPCID.DyeTrader || npc.type == NPCID.Dryad || npc.type == NPCID.DD2Bartender || npc.type == NPCID.ArmsDealer || npc.type == NPCID.Stylist || npc.type == NPCID.Painter || npc.type == NPCID.Angler || npc.type == NPCID.GoblinTinkerer || npc.type == NPCID.WitchDoctor || npc.type == NPCID.Clothier || npc.type == NPCID.Mechanic || npc.type == NPCID.PartyGirl || npc.type == NPCID.TaxCollector || npc.type == NPCID.Truffle || npc.type == NPCID.Pirate || npc.type == NPCID.Cyborg || npc.type == NPCID.SantaClaus)
			{
				if (Main.hardMode && !NPC.downedMoonlord)
				{
					damage += 20;
				}
				if (NPC.downedMoonlord)
				{
					damage = 100;
				}
			}
		}

		public override void TownNPCAttackCooldown(NPC npc, ref int cooldown, ref int randExtraCooldown)
		{
			if (npc.type == NPCID.Steampunker)
			{
				if (NPC.downedMoonlord)
				{
					cooldown = 4;
					randExtraCooldown = 4;
				}
			}
			if (npc.type == NPCID.Steampunker)
			{
				if (NPC.downedMoonlord)
				{
					cooldown = 3;
					randExtraCooldown = 3;
				}
			}
			if (npc.type == NPCID.Guide)
			{
				if (NPC.downedMoonlord)
				{
					cooldown = 3;
				}
			}
		}

		public override void TownNPCAttackProj(NPC npc, ref int projType, ref int attackDelay)
		{
			if (npc.type == NPCID.ArmsDealer)
			{
				if (NPC.downedMoonlord)
				{
					attackDelay = 4;
					projType = ProjectileID.MoonlordBullet;
				}
			}
			if (npc.type == NPCID.Steampunker)
			{
				if (NPC.downedMoonlord)
				{
					attackDelay = 3;
					projType = ProjectileID.MoonlordBullet;
				}
			}
			if (npc.type == NPCID.Cyborg)
			{
				if (NPC.downedMoonlord)
				{
					attackDelay = 3;
					projType = ProjectileID.RocketSnowmanI;
				}
			}
			if (npc.type == NPCID.Wizard)
			{
				if (NPC.downedMoonlord)
				{
					projType = ProjectileID.CursedFlameFriendly;
				}
			}
			if (npc.type == NPCID.Guide)
			{
				if (NPC.downedMoonlord)
				{
					projType = ProjectileID.MoonlordArrow;
				}
			}
		}

		public override void DrawTownAttackGun(NPC npc, ref float scale, ref int item, ref int closeness)
		{
			if (npc.type == NPCID.ArmsDealer)
			{
				if (NPC.downedMoonlord)
				{
					item = ItemID.Megashark;
				}
			}
			if (npc.type == NPCID.Steampunker)
			{
				if (NPC.downedMoonlord)
				{
					scale = 1f;
					closeness = 4;
					item = ItemID.SDMG;
				}
			}
		}

		public override void BuffTownNPC(ref float damageMult, ref int defense)
		{
			if (Main.hardMode && !NPC.downedMoonlord)
			{
				defense += 30;
			}
			if (NPC.downedMoonlord)
			{
				defense += 80;
			}
		}

		public override void ResetEffects(NPC npc)
		{
			banned = false;
			light = false;
			corrosion = false;
			chaos = false;
			rainbowdust = false;
			electrocute = false;
			twilight = false;
			justitiapale = false;
			N1 = false;
			N2 = false;
			N3 = false;
			N4 = false;
			N5 = false;
			N6 = false;
			N7 = false;
			N8 = false;
			N9 = false;
		}

		public override void UpdateLifeRegen(NPC npc, ref int damage)
		{
			if (chaos)
			{
				npc.lifeRegen -= 3000 + S*500;
				if (damage < 299 + S*50)
				{
					damage = 300 + S*50;
				}
			}
			if (light)
			{
				if (!Main.hardMode)
				{
					npc.lifeRegen -= 5 + C;
					if (damage < 1 + C)
					{
						damage = 1 + C;
					}
				}
				if (Main.hardMode && !NPC.downedMoonlord)
				{
					npc.lifeRegen -= 50 + C*2;
					if (damage < 5 + C)
					{
						damage = 5 + C;
					}
				}
				if (Main.hardMode && NPC.downedMoonlord)
				{
					npc.lifeRegen -= 500 + C*4;
					if (damage < 50 + C*2)
					{
						damage = 50 + C*2;
					}
				}
			}
			if (banned)
			{
				npc.lifeRegen -= 999999;
				if (damage < 9999)
				{
					damage = 9999;
				}
			}
			if (corrosion)
			{
				npc.lifeRegen -= 500;
				if (damage < 49)
				{
					damage = 50;
				}
			}
			if (justitiapale)
			{
				npc.lifeRegen -= 2000;
				if (damage < 199)
				{
					damage = 200;
				}
			}
			if (electrocute)
			{
				npc.lifeRegen -= 1000;
				if (damage < 99)
				{
					damage = 100;
				}
			}
			if (twilight)
			{
				npc.lifeRegen -= 5000;
				if (damage < 499)
				{
					damage = 500;
				}
			}
		}

		public override void DrawEffects(NPC npc, ref Color drawColor)
		{
			if (npc.HasBuff(mod.BuffType("ChaosState")))
			{
				npc.color = new Color(255, 0, 255, 100);
				Lighting.AddLight(npc.position, 1f, 0f, 1f);
			}
			if (corrosion)
			{
				if (Main.rand.Next(4) < 3)
				{
					int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, mod.DustType("RainbowDust"), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 1.8f;
					Main.dust[dust].velocity.Y -= 0.5f;
					if (Main.rand.Next(4) == 0)
					{
						Main.dust[dust].noGravity = false;
						Main.dust[dust].scale *= 0.5f;
					}
				}
				Lighting.AddLight(npc.position, 1f, 1f, 1f);
			}
			if (npc.HasBuff(mod.BuffType("ArmorDestruction")))
			{
				if (Main.rand.Next(4) < 2)
				{
					int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, mod.DustType("BastScroll"), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 1.8f;
					Main.dust[dust].velocity.Y -= 0.5f;
					if (Main.rand.Next(3) == 0)
					{
						Main.dust[dust].noGravity = false;
						Main.dust[dust].scale *= 0.5f;
					}
				}
				Lighting.AddLight(npc.position, 1f, 1f, 1f);
			}
			if (npc.HasBuff(mod.BuffType("CurseOfLight")))
			{
				npc.color = new Color(255, 255, 255, 100);
				Lighting.AddLight(npc.position, 1f, 1f, 1f);
			}
			if (npc.HasBuff(mod.BuffType("SymbolOfPain")))
			{
				npc.color = new Color(255, 10, 10, 100);
				Lighting.AddLight(npc.position, 1f, 1f, 1f);
			}
			for (int k = 0; k < 255; k++)
			{
				Player player = Main.player[k];
				if (player.active && player.HasBuff(mod.BuffType("GreaterDangersense")))
				{
					if (npc.type == 112)
					{
						npc.color = new Color(255, 255, 0, 100);
						Lighting.AddLight(npc.position, 1f, 1f, 0f);
					}
				}
			}
			if (justitiapale)
			{
				if (Main.rand.Next(4) < 2)
				{
					int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, mod.DustType("JustitiaPale"), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 1.8f;
					Main.dust[dust].velocity.Y -= 0.5f;
					if (Main.rand.Next(3) == 0)
					{
						Main.dust[dust].noGravity = false;
						Main.dust[dust].scale *= 0.5f;
					}
				}
			}
			if (electrocute)
			{
				if (Main.rand.Next(4) < 2)
				{
					int num2 = Main.rand.Next(5, 10);
					for (int index1 = 0; index1 < num2; ++index1)
					{
						int index2 = Dust.NewDust(npc.Center, 0, 0, 226, 0.0f, 0.0f, 100, new Color(), 0.5f);
						Main.dust[index2].velocity *= 1.6f;
						--Main.dust[index2].velocity.Y;
						Main.dust[index2].position = Vector2.Lerp(Main.dust[index2].position, npc.Center, 0.5f);
						Main.dust[index2].noGravity = true;
					}
				}
			}
			if (twilight)
			{
				if (Main.rand.Next(4) < 2)
				{
					int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, mod.DustType("JustitiaPale"), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 1.8f;
					Main.dust[dust].velocity.Y -= 0.5f;
					if (Main.rand.Next(3) == 0)
					{
						Main.dust[dust].noGravity = false;
						Main.dust[dust].scale *= 0.5f;
					}
				}
			}
		}
		
		public override bool PreNPCLoot(NPC npc)
		{
			string barrierWeek = Language.GetTextValue("Mods.AlchemistNPC.barrierWeek");
			string Eclipse = Language.GetTextValue("Mods.AlchemistNPC.Eclipse");
			
			if (npc.type == NPCID.MoonLordCore)
			{
				if (!NPC.downedMoonlord)
				{
					Main.NewText(barrierWeek, 255, 255, 255);
					Main.NewText(Eclipse, 255, 50, 50);
				}
			}
			if (npc.type == NPCID.EyeofCthulhu)
			{
				if (!NPC.downedBoss1)
				{
					npc.DropItemInstanced(npc.position, npc.Size, mod.ItemType("AlchemistCharmTier1"));
				}
			}
			if (AlchemistNPCWorld.foundAntiBuffMode)
			{
				if (npc.type == NPCID.KingSlime)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("KingSlimeBooster"));
				}
				if (npc.type == NPCID.EyeofCthulhu)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EyeOfCthulhuBooster"));
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BrokenBooster1"));
				}
				if (npc.type == NPCID.EaterofWorldsHead && !NPC.AnyNPCs(NPCID.EaterofWorldsTail))
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EaterOfWorldsBooster"));
				}
				if (npc.type == NPCID.EaterofWorldsTail && !NPC.AnyNPCs(NPCID.EaterofWorldsHead))
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EaterOfWorldsBooster"));
				}
				if (npc.type == NPCID.BrainofCthulhu)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BrainOfCthulhuBooster"));
				}
				if (npc.type == NPCID.QueenBee)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("QueenBeeBooster"));
				}
				if (npc.type == NPCID.SkeletronHead)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SkeletronBooster"));
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BrokenBooster2"));
				}
				if (npc.type == NPCID.WallofFlesh)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("WoFBooster"));
				}
				if (npc.type == NPCID.SkeletronPrime)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PrimeBooster"));
				}
				if (npc.type == NPCID.Spazmatism && !NPC.AnyNPCs(NPCID.Retinazer))
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TwinsBooster"));
				}
				if (npc.type == NPCID.Retinazer && !NPC.AnyNPCs(NPCID.Spazmatism))
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TwinsBooster"));
				}
				if (npc.type == NPCID.TheDestroyer)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DestroyerBooster"));
				}
				if (npc.type == NPCID.Plantera)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PlanteraBooster"));
				}
				if (npc.type == NPCID.Golem)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GolemBooster"));
				}
				if (npc.type == NPCID.DukeFishron)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FishronBooster"));
				}
				if (npc.type == NPCID.CultistBoss)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CultistBooster"));
				}
				if (npc.type == NPCID.MoonLordCore)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MoonLordBooster"));
				}
				if (npc.type == NPCID.DD2DarkMageT1 || npc.type == NPCID.DD2DarkMageT3)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarkMageBooster"));
				}
				if (npc.type == NPCID.DD2OgreT2 || npc.type == NPCID.DD2OgreT3)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("OgreBooster"));
				}
				if (npc.type == NPCID.DD2Betsy)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BetsyBooster"));
				}
				if (npc.type == 471)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GSummonerBooster"));
				}
				if (npc.type == 243)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IceGolemBooster"));
				}
				if (npc.type == 170 || npc.type == 171 || npc.type == 180)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PigronBooster"));
				}
				if (npc.type == 395)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MartianSaucerBooster"));
				}
				for (int k = 0; k < 255; k++)
				{
					Player player = Main.player[k];
					if (player.active)
					{
						AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
						if (modPlayer.CultistBooster == 1)
						{
							if ((npc.type == 402 || npc.type == 405 || npc.type == 407 || npc.type == 409 || npc.type == 411) && Main.rand.NextBool(5))
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FragmentStardust, 1);
							}
							if ((npc.type == 412 || npc.type == 415 || npc.type == 416 || npc.type == 417 || npc.type == 418 || npc.type == 419) && Main.rand.NextBool(5))
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FragmentSolar, 1);
							}
							if ((npc.type == 420 || npc.type == 421 || npc.type == 423 || npc.type == 424) && Main.rand.NextBool(5))
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FragmentNebula, 1);
							}
							if ((npc.type == 425 || npc.type == 426 || npc.type == 427 || npc.type == 429) && Main.rand.NextBool(5))
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FragmentVortex, 1);
							}
						}
					}
				}
			}
			for (int k = 0; k < 255; k++)
			{
				Player player = Main.player[k];
				if (player.active)
				{
					AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
					if (npc.type == NPCID.MoonLordCore && modPlayer.PGSWear)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("KnucklesUgandaDoll"));
					}
					if (Main.expertMode && AlchemistNPC.modConfiguration.CoinsDrop)
					{
						if (ModLoader.GetMod("SpiritMod") != null)
						{
							if (npc.type == (ModLoader.GetMod("SpiritMod").NPCType("Infernon")))
							{
								int number = Main.rand.Next(6,9);
								modPlayer.RCT2 += number;
								if (Main.netMode == 2) SyncPlayerVariables(player);
								if (Main.netMode == NetmodeID.SinglePlayer) Main.NewText("Player " + player.name + " got " + number + " tier 2 Reversity coins and now has " + modPlayer.RCT2 + " in total.", 255, 255, 255);
								else NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Player " + player.name + " got " + number + " tier 2 Reversity coins and now has " + modPlayer.RCT2 + " in total."), new Color(255, 255, 255));
							}
						}
						if (npc.type == NPCID.DD2DarkMageT1 || npc.type == NPCID.DD2DarkMageT3)
						{
							int number = Main.rand.Next(12,15);
							modPlayer.RCT1 += number;
							if (Main.netMode == 2) SyncPlayerVariables(player);
							if (Main.netMode == NetmodeID.SinglePlayer) Main.NewText("Player " + player.name + " got " + number + " tier 1 Reversity coins and now has " + modPlayer.RCT1 + " in total.", 255, 255, 255);
							else NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Player " + player.name + " got " + number + " tier 1 Reversity coins and now has " + modPlayer.RCT1 + " in total."), new Color(255, 255, 255));
						}
						if (npc.type == NPCID.DD2OgreT2 || npc.type == NPCID.DD2OgreT3)
						{
							int number = Main.rand.Next(3,6);
							modPlayer.RCT3 += number;
							if (Main.netMode == 2) SyncPlayerVariables(player);
							if (Main.netMode == NetmodeID.SinglePlayer) Main.NewText("Player " + player.name + " got " + number + " tier 3 Reversity coins and now has " + modPlayer.RCT3 + " in total.", 255, 255, 255);
							else NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Player " + player.name + " got " + number + " tier 3 Reversity coins and now has " + modPlayer.RCT3 + " in total."), new Color(255, 255, 255));
						}
						if (npc.type == NPCID.DD2Betsy)
						{
							int number = Main.rand.Next(3,6);
							modPlayer.RCT4 += number;
							if (Main.netMode == 2) SyncPlayerVariables(player);
							if (Main.netMode == NetmodeID.SinglePlayer) Main.NewText("Player " + player.name + " got " + number + " tier 4 Reversity coins and now has " + modPlayer.RCT4 + " in total.", 255, 255, 255);
							else NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Player " + player.name + " got " + number + " tier 4 Reversity coins and now has " + modPlayer.RCT4 + " in total."), new Color(255, 255, 255));
						}
						if (npc.type == NPCID.MoonLordCore)
						{
							int number = Main.rand.Next(12,15);
							modPlayer.RCT4 += number;
							if (Main.netMode == 2) SyncPlayerVariables(player);
							if (Main.netMode == NetmodeID.SinglePlayer) Main.NewText("Player " + player.name + " got " + number + " tier 4 Reversity coins and now has " + modPlayer.RCT4 + " in total.", 255, 255, 255);
							else NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Player " + player.name + " got " + number + " tier 4 Reversity coins and now has " + modPlayer.RCT4 + " in total."), new Color(255, 255, 255));
						}
					}
				}
			}

			if (npc.type == NPCID.MoonLordCore)
			{
				if (AlchemistNPC.modConfiguration.TornNotesDrop)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TornNote9"));
				}
				if (AlchemistNPC.modConfiguration.TinkererSpawn)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube3"), 3);
				}
			}
			return base.PreNPCLoot(npc);
		}

		public void SyncPlayerVariables(Player player)
		{
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
			ModPacket packet = mod.GetPacket();
			packet.Write((byte)AlchemistNPC.AlchemistNPCMessageType.SyncPlayerVariables);
			packet.Write((byte)player.whoAmI);
			packet.Write(modPlayer.RCT1);
			packet.Write(modPlayer.RCT2);
			packet.Write(modPlayer.RCT3);
			packet.Write(modPlayer.RCT4);
			packet.Write(modPlayer.RCT5);
			packet.Write(modPlayer.RCT6);
			packet.Write(modPlayer.BBP);
			packet.Write(modPlayer.SnatcherCounter);
			packet.Send();
		}

		public override void NPCLoot(NPC npc)
		{
			if (npc.type == 541)
			{
				if (!AlchemistNPCWorld.downedSandElemental) 
				{
					AlchemistNPCWorld.downedSandElemental = true;
					if (Main.netMode == NetmodeID.Server) 
					{
						NetMessage.SendData(MessageID.WorldData);
					}
				}
			}
			if (ModLoader.GetMod("CalamityMod") != null)
			{
				if (CalamityModDownedDOG && npc.type == 327)
				{
					if (!AlchemistNPCWorld.downedDOGPumpking) {
						AlchemistNPCWorld.downedDOGPumpking = true;
					if (Main.netMode == NetmodeID.Server) {
						NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
					}
					}
				}
				
				if (CalamityModDownedDOG && npc.type == 345)
				{
					if (!AlchemistNPCWorld.downedDOGIceQueen) {
						AlchemistNPCWorld.downedDOGIceQueen = true;
					if (Main.netMode == NetmodeID.Server) {
						NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
						}
					}
				}
			}
			if (WorldGen.crimson)
			{
				if ((npc.type == 239 || npc.type == 240) && Main.rand.NextBool(10))
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SpiderFangarang"));
				}
			}
			if (!WorldGen.crimson)
			{
				if ((npc.type == 164 || npc.type == 165) && Main.rand.NextBool(10))
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SpiderFangarang"));
				}
			}
			if ((npc.type == 236 || npc.type == 237) && Main.rand.NextBool(20))
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FangBallista"));
			}
			if ((npc.type == 164 || npc.type == 165) && Main.rand.NextBool(20))
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SwordofArachna"));
			}
			if (npc.lifeMax >= 25000 && npc.boss && Main.rand.Next(20) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PerfectionToken"));
			}
			if (npc.lifeMax >= 75000 && npc.boss && NPC.downedMoonlord && Main.rand.Next(200) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Devilsknife"));
			}
			if (npc.lifeMax >= 75000 && npc.boss && NPC.downedMoonlord && Main.rand.Next(33) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("WailOfBanshee"));
			}
			if (npc.lifeMax >= 75000 && npc.boss && NPC.downedMoonlord && Main.rand.Next(33) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ExecutionersEyes"));
			}
			if (npc.lifeMax >= 75000 && npc.boss && NPC.downedMoonlord && Main.rand.Next(33) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SymbolOfPain"));
			}
			if (npc.lifeMax >= 75000 && npc.boss && NPC.downedMoonlord && Main.rand.Next(33) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MeteorSwarm"));
			}
			if (npc.lifeMax >= 75000 && npc.boss && NPC.downedMoonlord && Main.rand.Next(33) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CloakOfFear"));
			}
			if (npc.type == NPCID.WallofFlesh)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("LuckCharm"));
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PHD"));
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BrokenDimensionalCasket"));
			}
			if (!npc.SpawnedFromStatue)
			{
				if (Main.rand.Next(25000) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("HolyAvenger"), 1, false, 81);
				}
				if (Main.rand.Next(25000) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Penetrator"), 1, false, 82);
				}
				if (Main.rand.Next(25000) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TomeOfOrder"), 1, false, 83);
				}
				if (Main.rand.Next(25000) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FlaskoftheAlchemist"), 1, false, 82);
				}
				if (Main.rand.Next(25000) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CounterMatter"), 1, false);
				}
				if (Main.rand.Next(33333) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CrackedCrown"), 1, false);
				}
			}
			
			if (npc.type == NPCID.DungeonGuardian)
			{
				if (!Main.expertMode)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EmagledFragmentation"), Main.rand.Next(20, 30));
					if (Main.rand.Next(10) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("OtherworldlyAmulet"));
					}
				}
				if (Main.expertMode)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EmagledFragmentation"), Main.rand.Next(40, 50));
					if (Main.rand.Next(5) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("OtherworldlyAmulet"));
					}
				}
			}
			if (npc.type == NPCID.EyeofCthulhu && AlchemistNPC.modConfiguration.TornNotesDrop)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TornNote1"));
			}
			if (npc.type == NPCID.BrainofCthulhu && AlchemistNPC.modConfiguration.TornNotesDrop)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TornNote2"));
			}
			if (npc.type == NPCID.EaterofWorldsHead && !NPC.AnyNPCs(NPCID.EaterofWorldsTail) && AlchemistNPC.modConfiguration.TornNotesDrop)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TornNote2"));
			}
			if (npc.type == NPCID.EaterofWorldsTail && !NPC.AnyNPCs(NPCID.EaterofWorldsHead) && AlchemistNPC.modConfiguration.TornNotesDrop)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TornNote2"));
			}
			if (npc.type == NPCID.SkeletronHead && AlchemistNPC.modConfiguration.TornNotesDrop)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TornNote3"));
			}
			if (npc.type == NPCID.SkeletronPrime && AlchemistNPC.modConfiguration.TornNotesDrop)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TornNote4"));
			}
			if (npc.type == NPCID.Spazmatism && !NPC.AnyNPCs(NPCID.Retinazer) && AlchemistNPC.modConfiguration.TornNotesDrop)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TornNote5"));
			}
			if (npc.type == NPCID.Retinazer && !NPC.AnyNPCs(NPCID.Spazmatism) && AlchemistNPC.modConfiguration.TornNotesDrop)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TornNote5"));
			}
			if (npc.type == NPCID.TheDestroyer && AlchemistNPC.modConfiguration.TornNotesDrop)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TornNote6"));
			}
			if (npc.type == NPCID.Plantera && AlchemistNPC.modConfiguration.TornNotesDrop)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TornNote7"));
			}
			if (npc.type == NPCID.Golem && AlchemistNPC.modConfiguration.TornNotesDrop)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TornNote8"));
			}
			if (npc.type == NPCID.Plantera)
			{
				if (Main.rand.Next(20) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Hive"), 1, false, 83);
				}
			}
			if (npc.type == NPCID.Golem)
			{
				if (Main.rand.Next(10) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Fuaran"));
				}
			}
			if (npc.boss && AlchemistNPC.modConfiguration.TinkererSpawn)
			{
				if (npc.type == NPCID.KingSlime)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube"));
				}
				if (npc.type == NPCID.EyeofCthulhu)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube"), 2);
				}
				if (npc.type == NPCID.BrainofCthulhu)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube"), 2);
				}
				if (npc.type == NPCID.EaterofWorldsHead && !NPC.AnyNPCs(NPCID.EaterofWorldsTail))
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube"), 2);
				}
				if (npc.type == NPCID.EaterofWorldsTail && !NPC.AnyNPCs(NPCID.EaterofWorldsHead))
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube"), 2);
				}
				if (npc.type == NPCID.QueenBee)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube"), 3);
				}
				if (npc.type == NPCID.SkeletronHead)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube"), 3);
				}
				if (npc.type == NPCID.WallofFlesh)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube2"), 2);
				}
				if (npc.type == NPCID.SkeletronPrime)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube2"), 3);
				}
				if (npc.type == NPCID.Spazmatism && !NPC.AnyNPCs(NPCID.Retinazer))
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube2"), 3);
				}
				if (npc.type == NPCID.Retinazer && !NPC.AnyNPCs(NPCID.Spazmatism))
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube2"), 3);
				}
				if (npc.type == NPCID.TheDestroyer)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube2"), 3);
				}
				if (npc.type == NPCID.Plantera)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube3"), 1);
				}
				if (npc.type == NPCID.Golem)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube3"), 2);
				}
				if (npc.type == NPCID.DukeFishron)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube3"), 2);
				}
				if (ModLoader.GetMod("CalamityMod") != null)
				{
					if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("DesertScourgeHead"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube"));
					if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("CrabulonIdle"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube"), 2);
					if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("HiveMindP2"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube"), 2);
					if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("PerforatorHive"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube"), 2);
					if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("SlimeGodCore"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube"), 3);
					if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("Cryogen"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube2"), 3);
					if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("BrimstoneElemental"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube2"), 3);
					if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("AquaticScourgeHead"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube2"), 3);
					if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("SoulSeeker"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube2"));
					if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("Leviathan"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube2"), 3);
					if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("AstrumAureus"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube3"), 2);
					if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("PlaguebringerGoliath"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube3"), 2);
				}
				if (ModLoader.GetMod("ThoriumMod") != null)
				{
					if (npc.type == (ModLoader.GetMod("ThoriumMod").NPCType("TheGrandThunderBirdv2"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube"));
					if (npc.type == (ModLoader.GetMod("ThoriumMod").NPCType("QueenJelly"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube"), 2);
					if (npc.type == (ModLoader.GetMod("ThoriumMod").NPCType("Viscount"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube"), 3);
					if (npc.type == (ModLoader.GetMod("ThoriumMod").NPCType("GraniteEnergyStorm"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube"), 3);
					if (npc.type == (ModLoader.GetMod("ThoriumMod").NPCType("TheBuriedWarrior"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube"), 3);
					if (npc.type == (ModLoader.GetMod("ThoriumMod").NPCType("ThePrimeScouter"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube"), 3);
					if (npc.type == (ModLoader.GetMod("ThoriumMod").NPCType("BoreanStriderPopped"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube2"), 2);
					if (npc.type == (ModLoader.GetMod("ThoriumMod").NPCType("FallenDeathBeholder2"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube2"), 2);
					if (npc.type == (ModLoader.GetMod("ThoriumMod").NPCType("LichHeadless"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube2"), 3);
					if (npc.type == (ModLoader.GetMod("ThoriumMod").NPCType("AbyssionReleased"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube3"), 2);
				}
				if (ModLoader.GetMod("ElementsAwoken") != null)
				{
					if (npc.type == (ModLoader.GetMod("ElementsAwoken").NPCType("Wasteland"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube"), 2);
					if (npc.type == (ModLoader.GetMod("ElementsAwoken").NPCType("Infernace"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube"), 3);
					if (npc.type == (ModLoader.GetMod("ElementsAwoken").NPCType("ScourgeFighter"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube2"), 2);
					if (npc.type == (ModLoader.GetMod("ElementsAwoken").NPCType("RegarothHead"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube2"), 2);
					if (npc.type == (ModLoader.GetMod("ElementsAwoken").NPCType("TheCelestial"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube3"));
					if (npc.type == (ModLoader.GetMod("ElementsAwoken").NPCType("Permafrost"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube3"));
					if (npc.type == (ModLoader.GetMod("ElementsAwoken").NPCType("Obsidious"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube3"));
					if (npc.type == (ModLoader.GetMod("ElementsAwoken").NPCType("Aqueous"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube3"), 2);
					if (npc.type == (ModLoader.GetMod("ElementsAwoken").NPCType("TheEye"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube3"));
					if (npc.type == (ModLoader.GetMod("ElementsAwoken").NPCType("AncientWyrmHead"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube3"));
					if (npc.type == (ModLoader.GetMod("ElementsAwoken").NPCType("TheGuardianFly"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube3"), 3);
				}
				if (ModLoader.GetMod("Redemption") != null)
				{
					if (npc.type == (ModLoader.GetMod("Redemption").NPCType("KingChicken"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube"));
					if (npc.type == (ModLoader.GetMod("Redemption").NPCType("Thorn"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube"));
					if (npc.type == (ModLoader.GetMod("Redemption").NPCType("TheKeeper"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube"), 2);
					if (npc.type == (ModLoader.GetMod("Redemption").NPCType("XenomiteCrystalPhase2"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube"), 3);
					if (npc.type == (ModLoader.GetMod("Redemption").NPCType("InfectedEye"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube2"), 2);
					if (npc.type == (ModLoader.GetMod("Redemption").NPCType("KSCharge"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube2"), 3);
					if (npc.type == (ModLoader.GetMod("Redemption").NPCType("VlitchCleaver"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube2"), 4);
					if (npc.type == (ModLoader.GetMod("Redemption").NPCType("VlitchWormHead"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube3"), 2);
				}
				if (ModLoader.GetMod("SacredTools") != null)
				{
					if (npc.type == (ModLoader.GetMod("SacredTools").NPCType("DecreeRun"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube"), 2);
					if (npc.type == (ModLoader.GetMod("SacredTools").NPCType("RalnekPhase3"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube"), 3);
					if (npc.type == (ModLoader.GetMod("SacredTools").NPCType("Jensen"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube"), 3);
					if (npc.type == (ModLoader.GetMod("SacredTools").NPCType("Araneas"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube2"));
					if (npc.type == (ModLoader.GetMod("SacredTools").NPCType("Raynare"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube2"), 3);
					if (npc.type == (ModLoader.GetMod("SacredTools").NPCType("Primordia2"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube3"), 2);
				}
				if (ModLoader.GetMod("SpiritMod") != null)
				{
					if (npc.type == (ModLoader.GetMod("SpiritMod").NPCType("Scarabeus"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube"));
					if (npc.type == (ModLoader.GetMod("SpiritMod").NPCType("ReachBoss"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube"), 2);
					if (npc.type == (ModLoader.GetMod("SpiritMod").NPCType("AncientFlyer"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube"), 3);
					if (npc.type == (ModLoader.GetMod("SpiritMod").NPCType("SteamRaiderHead"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube"), 3);
					if (npc.type == (ModLoader.GetMod("SpiritMod").NPCType("Dusking"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube2"), 3);
					if (npc.type == (ModLoader.GetMod("SpiritMod").NPCType("SpiritCore"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube2"), 3);
					if (npc.type == (ModLoader.GetMod("SpiritMod").NPCType("IlluminantMaster"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube2"), 3);
					if (npc.type == (ModLoader.GetMod("SpiritMod").NPCType("Atlas"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube3"), 2);
				}
				if (ModLoader.GetMod("Laugicality") != null)
				{
					if (npc.type == (ModLoader.GetMod("Laugicality").NPCType("DuneSharkron"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube"));
					if (npc.type == (ModLoader.GetMod("Laugicality").NPCType("Hypothema"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube"), 2);
					if (npc.type == (ModLoader.GetMod("Laugicality").NPCType("Ragnar"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube"), 2);
					if (npc.type == (ModLoader.GetMod("Laugicality").NPCType("AnDio3"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube"), 3);
					if (npc.type == (ModLoader.GetMod("Laugicality").NPCType("Slybertron"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube2"), 3);
					if (npc.type == (ModLoader.GetMod("Laugicality").NPCType("TheAnnihilator"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube2"), 3);
					if (npc.type == (ModLoader.GetMod("Laugicality").NPCType("SteamTrain"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube2"), 3);
					if (npc.type == (ModLoader.GetMod("Laugicality").NPCType("Etheria"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube3"), 3);
				}
				if (ModLoader.GetMod("pinkymod") != null)
				{
					if (npc.type == (ModLoader.GetMod("pinkymod").NPCType("DeserteerMelee"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube"), 2);
					if (npc.type == (ModLoader.GetMod("pinkymod").NPCType("MythrilSlime"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube2"), 2);
					if (npc.type == (ModLoader.GetMod("pinkymod").NPCType("Valdaris"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube2"), 3);
					if (npc.type == (ModLoader.GetMod("pinkymod").NPCType("GatekeeperHead"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube3"), 3);
				}
				if (ModLoader.GetMod("AAMod") != null)
				{
					if (npc.type == (ModLoader.GetMod("AAMod").NPCType("MushroomMonarch"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube"));
					if (npc.type == (ModLoader.GetMod("AAMod").NPCType("FeudalFungus"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube"));
					if (npc.type == (ModLoader.GetMod("AAMod").NPCType("GripOfChaosRed"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube"));
					if (npc.type == (ModLoader.GetMod("AAMod").NPCType("GripOfChaosBlue"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube"));
					if (npc.type == (ModLoader.GetMod("AAMod").NPCType("TruffleToad"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube"), 2);
					if (npc.type == (ModLoader.GetMod("AAMod").NPCType("Broodmother"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube"), 2);
					if (npc.type == (ModLoader.GetMod("AAMod").NPCType("Hydra"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube"), 2);
					if (npc.type == (ModLoader.GetMod("AAMod").NPCType("SerpentHead"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube"), 3);
					if (npc.type == (ModLoader.GetMod("AAMod").NPCType("Djinn"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube"), 3);
					if (npc.type == (ModLoader.GetMod("AAMod").NPCType("Saggitarius"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube"), 3);
					if (npc.type == (ModLoader.GetMod("AAMod").NPCType("Rajah"))) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaperTube3"), 3);
				}
			}
			
			for (int k = 0; k < 255; k++)
			{
				Player player = Main.player[k];
				if (player.active)
				{
					AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
					if (Main.expertMode && AlchemistNPC.modConfiguration.CoinsDrop)
					{
						int number = 0;
						int tier = 0;
						switch (npc.type)
						{
							case (NPCID.KingSlime): number = Main.rand.Next(1,3); tier = 1; break;
							case (NPCID.EyeofCthulhu): number = Main.rand.Next(3,6); tier = 1; break;
							case (NPCID.BrainofCthulhu): number = Main.rand.Next(6,9); tier = 1; break;
							case (NPCID.QueenBee): number = Main.rand.Next(9,12); tier = 1; break;
							case (NPCID.SkeletronHead): number = Main.rand.Next(12,15); tier = 1; break;
							case (NPCID.WallofFlesh): number = Main.rand.Next(4,6); tier = 2; break;
							case (NPCID.SkeletronPrime): number = Main.rand.Next(2,3); tier = 3; break;
							case (NPCID.TheDestroyer): number = Main.rand.Next(2,3); tier = 3; break;
							case (NPCID.Plantera): number = Main.rand.Next(5,6); tier = 3; break;
							case (NPCID.Golem): number = Main.rand.Next(2,3); tier = 4; break;
							case (NPCID.DukeFishron): number = Main.rand.Next(6,9); tier = 4; break;
							case (NPCID.CultistBoss): number = Main.rand.Next(6,9); tier = 4; break;
						}
						if (npc.type == NPCID.EaterofWorldsHead && !NPC.AnyNPCs(NPCID.EaterofWorldsTail)) {number = Main.rand.Next(6,9); tier = 1;}
						if (npc.type == NPCID.EaterofWorldsTail && !NPC.AnyNPCs(NPCID.EaterofWorldsHead)) {number = Main.rand.Next(6,9); tier = 1;}
						if (npc.type == NPCID.Spazmatism && !NPC.AnyNPCs(NPCID.Retinazer)) {number = Main.rand.Next(2,3); tier = 3;}
						if (npc.type == NPCID.Retinazer && !NPC.AnyNPCs(NPCID.Spazmatism)) {number = Main.rand.Next(2,3); tier = 3;}
						if (ModLoader.GetMod("CalamityMod") != null)
						{
							if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("DesertScourgeHead"))) {number = Main.rand.Next(1,3); tier = 1;}
							if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("CrabulonIdle"))) {number = Main.rand.Next(3,6); tier = 1;}
							if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("HiveMindP2"))) {number = Main.rand.Next(6,9); tier = 1;}
							if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("PerforatorHive"))) {number = Main.rand.Next(6,9); tier = 1;}
							if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("SlimeGodCore"))) {number = Main.rand.Next(2,3); tier = 2;}
							if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("Cryogen"))) {number = Main.rand.Next(6,9); tier = 2;}
							if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("BrimstoneElemental"))) {number = Main.rand.Next(3,6); tier = 3;}
							if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("AquaticScourgeHead"))) {number = Main.rand.Next(3,6); tier = 3;}
							if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("SoulSeeker"))) {number = Main.rand.Next(2,3); tier = 3;}
							if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("Leviathan"))) {number = Main.rand.Next(12,15); tier = 3;}
							if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("AstrumAureus"))) {number = Main.rand.Next(9,12); tier = 3;}
							if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("PlaguebringerGoliath"))) {number = Main.rand.Next(3,6); tier = 4;}
							if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("RavagerBody"))) {number = Main.rand.Next(3,6); tier = 4;}
							if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("AstrumDeusHeadSpectral"))) {number = Main.rand.Next(5,7); tier = 4;}
							if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("ProfanedGuardianBoss"))) {number = Main.rand.Next(6,9); tier = 5;}
							if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("ProfanedGuardianBoss2"))) {number = Main.rand.Next(6,9); tier = 4;}
							if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("ProfanedGuardianBoss3"))) {number = Main.rand.Next(6,9); tier = 4;}
							if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("Providence"))) {number = Main.rand.Next(12,15); tier = 5;}
							if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("CeaselessVoid"))) {number = 1; tier = 6;}
							if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("StormWeaverHeadNaked"))) {number = 1; tier = 6;}
							if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("Signus"))) {number = 1; tier = 6;}
							if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("Polterghast"))) {number = Main.rand.Next(6,9); tier = 6;}
							if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("DevourerofGodsHeadS"))) {number = Main.rand.Next(6,9); tier = 5;}
							if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("Bumblefuck"))) {number = Main.rand.Next(3,6); tier = 5;}
							if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("Yharon"))) {number = Main.rand.Next(12,15); tier = 6;}
							if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("SupremeCalamitas"))) {number = 66; tier = 6;}
						}
						if (ModLoader.GetMod("ThoriumMod") != null)
						{
							if (npc.type == (ModLoader.GetMod("ThoriumMod").NPCType("TheGrandThunderBirdv2"))) {number = Main.rand.Next(1,2); tier = 1;}
							if (npc.type == (ModLoader.GetMod("ThoriumMod").NPCType("QueenJelly"))) {number = Main.rand.Next(3,6); tier = 1;}
							if (npc.type == (ModLoader.GetMod("ThoriumMod").NPCType("Viscount"))) {number = Main.rand.Next(5,7); tier = 1;}
							if (npc.type == (ModLoader.GetMod("ThoriumMod").NPCType("GraniteEnergyStorm"))) {number = Main.rand.Next(6,9); tier = 1;}
							if (npc.type == (ModLoader.GetMod("ThoriumMod").NPCType("TheBuriedWarrior"))) {number = Main.rand.Next(6,9); tier = 1;}
							if (npc.type == (ModLoader.GetMod("ThoriumMod").NPCType("ThePrimeScouter"))) {number = Main.rand.Next(9,12); tier = 1;}
							if (npc.type == (ModLoader.GetMod("ThoriumMod").NPCType("BoreanStriderPopped"))) {number = Main.rand.Next(2,3); tier = 2;}
							if (npc.type == (ModLoader.GetMod("ThoriumMod").NPCType("FallenDeathBeholder2"))) {number = Main.rand.Next(3,6); tier = 2;}
							if (npc.type == (ModLoader.GetMod("ThoriumMod").NPCType("LichHeadless"))) {number = Main.rand.Next(3,6); tier = 3;}
							if (npc.type == (ModLoader.GetMod("ThoriumMod").NPCType("AbyssionReleased"))) {number = Main.rand.Next(3,6); tier = 4;}
							if (npc.type == (ModLoader.GetMod("ThoriumMod").NPCType("RealityBreaker"))) {number = 33; tier = 4;}
						}
						if (ModLoader.GetMod("ElementsAwoken") != null)
						{
							if (npc.type == (ModLoader.GetMod("ElementsAwoken").NPCType("Wasteland"))) {number = Main.rand.Next(3,5); tier = 1;}
							if (npc.type == (ModLoader.GetMod("ElementsAwoken").NPCType("Infernace"))) {number = Main.rand.Next(2,4); tier = 2;}
							if (npc.type == (ModLoader.GetMod("ElementsAwoken").NPCType("ScourgeFighter"))) {number = Main.rand.Next(5,7); tier = 3;}
							if (npc.type == (ModLoader.GetMod("ElementsAwoken").NPCType("RegarothHead"))) {number = Main.rand.Next(6,8); tier = 3;}
							if (npc.type == (ModLoader.GetMod("ElementsAwoken").NPCType("TheCelestial"))) {number = Main.rand.Next(3,5); tier = 4;}
							if (npc.type == (ModLoader.GetMod("ElementsAwoken").NPCType("Permafrost"))) {number = Main.rand.Next(5,7); tier = 4;}
							if (npc.type == (ModLoader.GetMod("ElementsAwoken").NPCType("Obsidious"))) {number = Main.rand.Next(5,7); tier = 4;}
							if (npc.type == (ModLoader.GetMod("ElementsAwoken").NPCType("Aqueous"))) {number = Main.rand.Next(7,10); tier = 4;}
							if (npc.type == (ModLoader.GetMod("ElementsAwoken").NPCType("TheEye"))) {number = Main.rand.Next(5,7); tier = 4;}
							if (npc.type == (ModLoader.GetMod("ElementsAwoken").NPCType("AncientWyrmHead"))) {number = Main.rand.Next(5,7); tier = 4;}
							if (npc.type == (ModLoader.GetMod("ElementsAwoken").NPCType("TheGuardianFly"))) {number = Main.rand.Next(10,12); tier = 4;}
							if (npc.type == (ModLoader.GetMod("ElementsAwoken").NPCType("Volcanox"))) {number = Main.rand.Next(4,7); tier = 5;}
							if (npc.type == (ModLoader.GetMod("ElementsAwoken").NPCType("ElderShadeWyrmHead"))) {number = Main.rand.Next(8,12); tier = 5;}
							if (npc.type == (ModLoader.GetMod("ElementsAwoken").NPCType("Azana"))) {number = Main.rand.Next(14,17); tier = 5;}
							if (npc.type == (ModLoader.GetMod("ElementsAwoken").NPCType("AncientAmalgam"))) {number = Main.rand.Next(25,30); tier = 5;}
						}
						if (ModLoader.GetMod("Redemption") != null)
						{
							if (npc.type == (ModLoader.GetMod("Redemption").NPCType("KingChicken"))) {number = Main.rand.Next(1,2); tier = 1;}
							if (npc.type == (ModLoader.GetMod("Redemption").NPCType("Thorn"))) {number = Main.rand.Next(3,6); tier = 1;}
							if (npc.type == (ModLoader.GetMod("Redemption").NPCType("TheKeeper"))) {number = Main.rand.Next(5,8); tier = 1;}
							if (npc.type == (ModLoader.GetMod("Redemption").NPCType("XenomiteCrystalPhase2"))) {number = Main.rand.Next(8,11); tier = 1;}
							if (npc.type == (ModLoader.GetMod("Redemption").NPCType("InfectedEye"))) {number = Main.rand.Next(4,7); tier = 2;}
							if (npc.type == (ModLoader.GetMod("Redemption").NPCType("KSEntrance"))) {number = Main.rand.Next(9,12); tier = 3;}
							if (npc.type == (ModLoader.GetMod("Redemption").NPCType("VlitchCleaver"))) {number = Main.rand.Next(1,2); tier = 3;}
							if (npc.type == (ModLoader.GetMod("Redemption").NPCType("VlitchWormHead"))) {number = Main.rand.Next(6,9); tier = 4;}
							if (npc.type == (ModLoader.GetMod("Redemption").NPCType("OmegaOblitDamaged"))) {number = Main.rand.Next(2,4); tier = 5;}
							if (npc.type == (ModLoader.GetMod("Redemption").NPCType("PatientZero"))) {number = Main.rand.Next(5,8); tier = 5;}
							if (npc.type == (ModLoader.GetMod("Redemption").NPCType("EaglecrestGolemPZ"))) {number = Main.rand.Next(6,9); tier = 5;}
							if (npc.type == (ModLoader.GetMod("Redemption").NPCType("ThornPZ"))) {number = Main.rand.Next(6,9); tier = 5;}
							if (npc.type == (ModLoader.GetMod("Redemption").NPCType("BigNebuleus"))) {number = Main.rand.Next(15,20); tier = 5;}
						}
						if (ModLoader.GetMod("SacredTools") != null)
						{
							if (npc.type == (ModLoader.GetMod("SacredTools").NPCType("DecreeRun"))) {number = Main.rand.Next(2,3); tier = 1;}
							if (npc.type == (ModLoader.GetMod("SacredTools").NPCType("RalnekPhase3"))) {number = Main.rand.Next(4,6); tier = 1;}
							if (npc.type == (ModLoader.GetMod("SacredTools").NPCType("Jensen"))) {number = Main.rand.Next(6,9); tier = 1;}
							if (npc.type == (ModLoader.GetMod("SacredTools").NPCType("Araneas"))) {number = Main.rand.Next(5,7); tier = 2;}
							if (npc.type == (ModLoader.GetMod("SacredTools").NPCType("Raynare"))) {number = Main.rand.Next(3,6); tier = 3;}
							if (npc.type == (ModLoader.GetMod("SacredTools").NPCType("Primordia2"))) {number = Main.rand.Next(2,4); tier = 4;}
							if (npc.type == (ModLoader.GetMod("SacredTools").NPCType("Abaddon"))) {number = Main.rand.Next(15,20); tier = 4;}
							if (npc.type == (ModLoader.GetMod("SacredTools").NPCType("AraghurHead"))) {number = Main.rand.Next(6,9); tier = 4;}
							if (npc.type == (ModLoader.GetMod("SacredTools").NPCType("Novaniel"))) {number = Main.rand.Next(3,6); tier = 5;}
							if (npc.type == (ModLoader.GetMod("SacredTools").NPCType("ErazorBoss"))) {number = Main.rand.Next(9,12); tier = 5;}
							if (npc.type == (ModLoader.GetMod("SacredTools").NPCType("SpookboiSpirit"))) {number = Main.rand.Next(20,30); tier = 5;}
						}
						if (ModLoader.GetMod("SpiritMod") != null)
						{
							if (npc.type == (ModLoader.GetMod("SpiritMod").NPCType("Scarabeus"))) {number = Main.rand.Next(2,3); tier = 1;}
							if (npc.type == (ModLoader.GetMod("SpiritMod").NPCType("ReachBoss"))) {number = Main.rand.Next(6,9); tier = 1;}
							if (npc.type == (ModLoader.GetMod("SpiritMod").NPCType("AncientFlyer"))) {number = Main.rand.Next(9,12); tier = 1;}
							if (npc.type == (ModLoader.GetMod("SpiritMod").NPCType("SteamRaiderHead"))) {number = Main.rand.Next(3,6); tier = 2;}
							if (npc.type == (ModLoader.GetMod("SpiritMod").NPCType("Dusking"))) {number = Main.rand.Next(3,6); tier = 3;}
							if (npc.type == (ModLoader.GetMod("SpiritMod").NPCType("SpiritCore"))) {number = Main.rand.Next(3,6); tier = 3;}
							if (npc.type == (ModLoader.GetMod("SpiritMod").NPCType("IlluminantMaster"))) {number = Main.rand.Next(6,9); tier = 3;}
							if (npc.type == (ModLoader.GetMod("SpiritMod").NPCType("Atlas"))) {number = Main.rand.Next(6,9); tier = 4;}
							if (npc.type == (ModLoader.GetMod("SpiritMod").NPCType("Overseer"))) {number = 33; tier = 4;}
						}
						if (ModLoader.GetMod("Laugicality") != null)
						{
							if (npc.type == (ModLoader.GetMod("Laugicality").NPCType("DuneSharkron"))) {number = Main.rand.Next(2,3); tier = 1;}
							if (npc.type == (ModLoader.GetMod("Laugicality").NPCType("Hypothema"))) {number = Main.rand.Next(6,9); tier = 1;}
							if (npc.type == (ModLoader.GetMod("Laugicality").NPCType("Ragnar"))) {number = Main.rand.Next(9,12); tier = 1;}
							if (npc.type == (ModLoader.GetMod("Laugicality").NPCType("AnDio3"))) {number = Main.rand.Next(4,6); tier = 2;}
							if (npc.type == (ModLoader.GetMod("Laugicality").NPCType("Slybertron"))) {number = Main.rand.Next(6,9); tier = 3;}
							if (npc.type == (ModLoader.GetMod("Laugicality").NPCType("TheAnnihilator"))) {number = Main.rand.Next(6,8); tier = 3;}
							if (npc.type == (ModLoader.GetMod("Laugicality").NPCType("SteamTrain"))) {number = Main.rand.Next(6,8); tier = 3;}
							if (npc.type == (ModLoader.GetMod("Laugicality").NPCType("Etheria"))) {number = 33; tier = 4;}
						}
						if (ModLoader.GetMod("pinkymod") != null)
						{
							if (npc.type == (ModLoader.GetMod("pinkymod").NPCType("DeserteerMelee"))) {number = Main.rand.Next(2,3); tier = 1;}
							if (npc.type == (ModLoader.GetMod("pinkymod").NPCType("MythrilSlime"))) {number = Main.rand.Next(3,5); tier = 3;}
							if (npc.type == (ModLoader.GetMod("pinkymod").NPCType("Valdaris"))) {number = Main.rand.Next(12,15); tier = 3;}
							if (npc.type == (ModLoader.GetMod("pinkymod").NPCType("GatekeeperHead"))) {number = Main.rand.Next(6,9); tier = 4;}
						}
						if (ModLoader.GetMod("AAMod") != null)
						{
							if (npc.type == (ModLoader.GetMod("AAMod").NPCType("MushroomMonarch"))) {number = Main.rand.Next(1,2); tier = 1;}
							if (npc.type == (ModLoader.GetMod("AAMod").NPCType("FeudalFungus"))) {number = Main.rand.Next(1,2); tier = 1;}
							if (npc.type == (ModLoader.GetMod("AAMod").NPCType("GripOfChaosRed"))) {number = Main.rand.Next(2,3); tier = 1;}
							if (npc.type == (ModLoader.GetMod("AAMod").NPCType("GripOfChaosBlue"))) {number = Main.rand.Next(2,3); tier = 1;}
							if (npc.type == (ModLoader.GetMod("AAMod").NPCType("TruffleToad"))) {number = Main.rand.Next(5,7); tier = 1;}
							if (npc.type == (ModLoader.GetMod("AAMod").NPCType("Broodmother"))) {number = Main.rand.Next(6,9); tier = 1;}
							if (npc.type == (ModLoader.GetMod("AAMod").NPCType("Hydra"))) {number = Main.rand.Next(6,9); tier = 1;}
							if (npc.type == (ModLoader.GetMod("AAMod").NPCType("SerpentHead"))) {number = Main.rand.Next(1,2); tier = 2;}
							if (npc.type == (ModLoader.GetMod("AAMod").NPCType("Djinn"))) {number = Main.rand.Next(1,2); tier = 2;}
							if (npc.type == (ModLoader.GetMod("AAMod").NPCType("Saggitarius"))) {number = Main.rand.Next(1,2); tier = 2;}
							if (npc.type == (ModLoader.GetMod("AAMod").NPCType("Rajah"))) {number = Main.rand.Next(4,6); tier = 4;}
							if (npc.type == (ModLoader.GetMod("AAMod").NPCType("DaybringerHead"))) {number = Main.rand.Next(15,20); tier = 4;}
							if (npc.type == (ModLoader.GetMod("AAMod").NPCType("NightcrawlerHead"))) {number = Main.rand.Next(15,20); tier = 4;}
							if (npc.type == (ModLoader.GetMod("AAMod").NPCType("Ashe"))) {number = Main.rand.Next(2,3); tier = 5;}
							if (npc.type == (ModLoader.GetMod("AAMod").NPCType("Haruka"))) {number = Main.rand.Next(2,3); tier = 5;}
							if (npc.type == (ModLoader.GetMod("AAMod").NPCType("Yamata"))) {number = Main.rand.Next(3,5); tier = 5;}
							if (npc.type == (ModLoader.GetMod("AAMod").NPCType("YamataA"))) {number = Main.rand.Next(4,6); tier = 5;}
							if (npc.type == (ModLoader.GetMod("AAMod").NPCType("Akuma"))) {number = Main.rand.Next(3,5); tier = 5;}
							if (npc.type == (ModLoader.GetMod("AAMod").NPCType("AkumaA"))) {number = Main.rand.Next(4,6); tier = 5;}
							if (npc.type == (ModLoader.GetMod("AAMod").NPCType("Zero"))) {number = Main.rand.Next(6,9); tier = 5;}
							if (npc.type == (ModLoader.GetMod("AAMod").NPCType("ZeroAwakened"))) {number = Main.rand.Next(7,10); tier = 5;}
							if (npc.type == (ModLoader.GetMod("AAMod").NPCType("ShenDoragon"))) {number = Main.rand.Next(10,15); tier = 6;}
							if (npc.type == (ModLoader.GetMod("AAMod").NPCType("ShenA"))) {number = Main.rand.Next(15,20); tier = 6;}
							if (npc.type == (ModLoader.GetMod("AAMod").NPCType("SupremeRajah"))) {number = 33; tier = 6;}
						}
						if (number > 0)
						{
							switch (tier)
							{
								case 1:	
									modPlayer.RCT1 += number; 
									if (Main.netMode == 2) SyncPlayerVariables(player);
									if (Main.netMode == NetmodeID.SinglePlayer) Main.NewText("Player " + player.name + " got " + number + " tier " + tier + " Reversity coins and now has " + modPlayer.RCT1 + " in total.", 255, 255, 255);
									else NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Player " + player.name + " got " + number + " tier " + tier + " Reversity coins and now has " + modPlayer.RCT1 + " in total."), new Color(255, 255, 255)); 
									break;
								case 2:	
									modPlayer.RCT2 += number;
									if (Main.netMode == 2) SyncPlayerVariables(player);
									if (Main.netMode == NetmodeID.SinglePlayer) Main.NewText("Player " + player.name + " got " + number + " tier " + tier + " Reversity coins and now has " + modPlayer.RCT2 + " in total.", 255, 255, 255);
									else NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Player " + player.name + " got " + number + " tier " + tier + " Reversity coins and now has " + modPlayer.RCT2 + " in total."), new Color(255, 255, 255)); 
									break;
								case 3:	
									modPlayer.RCT3 += number;
									if (Main.netMode == 2) SyncPlayerVariables(player);
									if (Main.netMode == NetmodeID.SinglePlayer) Main.NewText("Player " + player.name + " got " + number + " tier " + tier + " Reversity coins and now has " + modPlayer.RCT3 + " in total.", 255, 255, 255);
									else NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Player " + player.name + " got " + number + " tier " + tier + " Reversity coins and now has " + modPlayer.RCT3 + " in total."), new Color(255, 255, 255)); 
									break;
								case 4:	
									modPlayer.RCT4 += number;
									if (Main.netMode == 2) SyncPlayerVariables(player);
									if (Main.netMode == NetmodeID.SinglePlayer) Main.NewText("Player " + player.name + " got " + number + " tier " + tier + " Reversity coins and now has " + modPlayer.RCT4 + " in total.", 255, 255, 255);
									else NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Player " + player.name + " got " + number + " tier " + tier + " Reversity coins and now has " + modPlayer.RCT4 + " in total."), new Color(255, 255, 255)); 
									break;
								case 5:	
									modPlayer.RCT5 += number;
									if (Main.netMode == 2) SyncPlayerVariables(player);
									if (Main.netMode == NetmodeID.SinglePlayer) Main.NewText("Player " + player.name + " got " + number + " tier " + tier + " Reversity coins and now has " + modPlayer.RCT5 + " in total.", 255, 255, 255);
									else NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Player " + player.name + " got " + number + " tier " + tier + " Reversity coins and now has " + modPlayer.RCT5 + " in total."), new Color(255, 255, 255)); 
									break;
								case 6:	
									modPlayer.RCT6 += number;
									if (Main.netMode == 2) SyncPlayerVariables(player);
									if (Main.netMode == NetmodeID.SinglePlayer) Main.NewText("Player " + player.name + " got " + number + " tier " + tier + " Reversity coins and now has " + modPlayer.RCT6 + " in total.", 255, 255, 255);
									else NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Player " + player.name + " got " + number + " tier " + tier + " Reversity coins and now has " + modPlayer.RCT6 + " in total."), new Color(255, 255, 255)); 
									break;
							}
						}
					}
					if (player.HeldItem.type == mod.ItemType("ChristmasW") && Main.rand.NextBool(33))
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Present);
					}
					if (player.HasBuff(mod.BuffType("Snatcher")) && !npc.friendly && npc.type != 14 && npc.type != 135 && !npc.SpawnedFromStatue && npc.type != 1 && npc.type != 535)
					{
						modPlayer.SnatcherCounter++;
						if (Main.netMode == 2)
						SyncPlayerVariables(player);
					}
					if (player.HeldItem.type == mod.ItemType("BloodthirstyBlade") && !npc.SpawnedFromStatue)
					{
						if (!Main.hardMode && modPlayer.BBP < 2600)
						{
							if (!npc.boss && npc.type != 1 && npc.type != 535)
							{
								modPlayer.BBP++;
								if (Main.netMode == 2)
								SyncPlayerVariables(player);
							}
							
							if (npc.boss && npc.lifeMax <= 10000)
							{
								modPlayer.BBP += 25;
								if (Main.netMode == 2)
								SyncPlayerVariables(player);
							}
							
							if (npc.boss && npc.lifeMax > 10000)
							{
								modPlayer.BBP += 50;
								if (Main.netMode == 2)
								SyncPlayerVariables(player);
							}
						}
						if (Main.hardMode && modPlayer.BBP < 8900)
						{
							if (!npc.boss && npc.type != 1 && npc.type != 535 && Main.rand.NextBool(2))
							{
								modPlayer.BBP++;
								if (Main.netMode == 2)
								SyncPlayerVariables(player);
							}
							
							if (npc.boss && npc.lifeMax <= 10000)
							{
								modPlayer.BBP += 15;
								if (Main.netMode == 2)
								SyncPlayerVariables(player);
							}
							
							if (npc.boss && npc.lifeMax > 10000)
							{
								modPlayer.BBP += 30;
								if (Main.netMode == 2)
								SyncPlayerVariables(player);
							}
						}
						if (NPC.downedMoonlord)
						{
							if (!npc.boss && npc.type != 1 && npc.type != 535 && Main.rand.NextBool(3))
							{
								modPlayer.BBP++;
								if (Main.netMode == 2)
								SyncPlayerVariables(player);
							}
							
							if (npc.boss && npc.lifeMax <= 10000)
							{
								modPlayer.BBP += 10;
								if (Main.netMode == 2)
								SyncPlayerVariables(player);
							}
							
							if (npc.boss && npc.lifeMax > 10000)
							{
								modPlayer.BBP += 20;
								if (Main.netMode == 2)
								SyncPlayerVariables(player);
							}
						}
					}
					if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).Extractor && npc.boss == true && npc.lifeMax >= 50000 && (Main.rand.Next(3) == 0))
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SoulEssence"));
					}
					if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).Extractor && npc.boss == true && npc.lifeMax >= 55000 && (Main.rand.Next(10) == 0))
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("HateVial"));
					}
					if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).TimeTwist && npc.boss == false && Main.rand.NextBool(4))
					{
						npc.NPCLoot();
						break;
					}
				}
			}
		}
		
		public bool CalamityModRevengeance
		{
        get { return CalamityMod.World.CalamityWorld.revenge; }
        }
		public bool CalamityModDownedDOG
		{
		get { return CalamityMod.World.CalamityWorld.downedDoG; }
		}
		
		private readonly Mod Calamity = ModLoader.GetMod("CalamityMod");
		
		public override bool StrikeNPC(NPC npc, ref double damage, int defense, ref float knockback, int hitDirection, ref bool crit)
		{
			if (npc.type == mod.NPCType("Knuckles"))
			{
				Player player = Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)];
				if (player.HeldItem.type == ItemID.WaterGun)
				{
					defense = 0;
				}
				if (!player.GetModPlayer<AlchemistNPCPlayer>().MemersRiposte)
				{
					damage = 1;
					if (crit)
					{
						damage = 2;
					}
				}
				if (player.GetModPlayer<AlchemistNPCPlayer>().MemersRiposte)
				{
					damage = 2;
					if (crit)
					{
						damage = 4;
					}
				}
				return false;
			}
			return base.StrikeNPC(npc, ref damage, defense, ref knockback, hitDirection, ref crit);
		}
		
		public override void AI(NPC npc)
		{
			Player player = Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)];
			if (npc.type == mod.NPCType("Knuckles"))
			{
				if (!start)
				{
					npc.position.Y = player.position.Y - 350;
					npc.position.X = player.position.X;
					start = true;
				}
				if (ks == false)
				{
					kc++;
				}
				if (kc == 2)
				{
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPC.Common.UgandanKnucklesChat1"), 255, 255, 255);
				}
				if (kc < 180)
				{
					npc.velocity.X = 0f;
					npc.velocity.Y = 0f;
					npc.dontTakeDamage = true;
				}
				if (kc == 180)
				{
					Main.NewText("DEW U NO DE WEI?", 255, 0, 0);
					ks = true;
					npc.dontTakeDamage = false;
					kc++;
				}
			}
			if (npc.type == mod.NPCType("BillCipher"))
			{
				if (npc.life == npc.lifeMax && !start && player.name != "Bill")
				{
					npc.position.Y = player.position.Y - 300;
					npc.position.X = player.position.X;
					if (player.name == "Dipper" || player.name == "Mabel" || player.name == "Stanford" || player.name == "Stanlee" || player.name == "Stan")
					{
						Main.NewText(Language.GetTextValue("Mods.AlchemistNPC.Common.BillCipherChat4"), 10, 255, 10);	
					}
					else
					{
						Main.NewText(Language.GetTextValue("Mods.AlchemistNPC.Common.BillCipherChat5"), 10, 255, 10);
					}
					start = true;
				}
				if (npc.life <= npc.lifeMax*0.6f && !i1)
				{
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPC.Common.BillCipherChat6"), 10, 255, 10);
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("VoodooDoll"));
					i1 = true;
				}
				if (npc.life <= npc.lifeMax*0.4f && !i2)
				{
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPC.Common.BillCipherChat6"), 10, 255, 10);
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ScreamingHead"));
					i2 = true;
				}
				if (npc.life <= npc.lifeMax*0.2f && !i3)
				{
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPC.Common.BillCipherChat6"), 10, 255, 10);
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CursedMirror"));
					i3 = true;
				}
				if (npc.life <= (npc.lifeMax - npc.lifeMax/4) && !intermission1 && !stop1)
				{
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPC.Common.BillCipherChat7"), 30, 255, 30);
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPC.Common.BillCipherChat8"), 30, 255, 30);
					npc.dontTakeDamage = true;
					intermission1 = true;
				}
				if (intermission1 && !stop1)
				{
					npc.velocity.X = 0f;
					npc.velocity.Y = 0f;
					bc++;
					if (bc >= 300)
					{
						npc.life += 50000;
						npc.HealEffect(50000, true);
						npc.dontTakeDamage = false;
						stop1 = true;
						intermission1 = false;
					}
				}
				if (npc.life <= npc.lifeMax/2 && !phase2)
				{
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPC.Common.BillCipherChat9"), 150, 100, 30);
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPC.Common.BillCipherChat10"), 150, 100, 30);
					phase2 = true;
					for (int index1 = 0; index1 < 30; ++index1)
					{
					float X = npc.Center.X + Main.rand.Next(-2500, 2500);
					float Y = npc.Center.Y + Main.rand.Next(-2500, 2500);
					Projectile.NewProjectile(X, Y, 0f, 0f, mod.ProjectileType("Madness"), 200, 0, Main.myPlayer);
					}
				}
				if (npc.life <= npc.lifeMax/4 && !intermission2 && !stop2)
				{
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPC.Common.BillCipherChat11"), 210, 50, 20);
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPC.Common.BillCipherChat12"), 210, 50, 20);
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPC.Common.BillCipherChat13"), 210, 50, 10);
					npc.dontTakeDamage = true;
					intermission2 = true;
				}
				if (intermission2 && !stop2)
				{
					npc.velocity.X = 0f;
					npc.velocity.Y = 0f;
					bc2++;
					if (bc2 >= 300)
					{
						npc.life += 50000;
						npc.HealEffect(50000, true);
						npc.dontTakeDamage = false;
						stop2 = true;
						intermission2 = false;
					}
				}
				if (npc.life <= npc.lifeMax*0.15f && !phase3)
				{
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPC.Common.BillCipherChat14"), 255, 0, 0);
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPC.Common.BillCipherChat15"), 255, 0, 0);
					phase3 = true;
				}
			}
		}
	}
}
