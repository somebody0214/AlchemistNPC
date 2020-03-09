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
using AlchemistNPC;

namespace AlchemistNPC.Items.Weapons
{
	public class UnchainedAkumu : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Unchained ''Akumu''");
			Tooltip.SetDefault("It means ''[c/FF00FF:nightmare]'' in Japanese"
			+"\nIts slice pierces through any amount of enemies on its way"
			+"\nLeft click launches a short travelling projectile"
			+"\nRight click slices the air in place"
			+"\nWhile at 35% HP or lower, Akumu generates projectile reflecting shield"
			+"\nWhile above 35% HP, Akumu releases flying minion");
			DisplayName.AddTranslation(GameCulture.Russian, "Освобождённая ''Акуму''");
            Tooltip.AddTranslation(GameCulture.Russian, "Это означает ''кошмар'' на Японском\nЕё удар пронзает любое количество врагов\nЗапускает снаряд по нажатию левой кнопки мыши\nРазрезает воздух на месте по нажатию правой кнопки мыши\nПри здоровье ниже 35% призывает отражающий снаряды щит\nПри здоровье выше 35% создаёт летающего прислужника");
			DisplayName.AddTranslation(GameCulture.Chinese, "解封 ''Akumu''");
			Tooltip.AddTranslation(GameCulture.Chinese, "在日语里, 'Akumu'的意思是'噩梦'"
			+"\n它的斩击能穿透经过的所有敌人"
			+"\n左键发射剑气"
			+"\n右键近距离攻击"
			+"\n生命值低于35%时, Akumu会生成反射抛射物的护盾"
			+"\n高于35%时, Akumu会释放飞行的奴仆");
        }

		public override void SetDefaults()
		{
			item.melee = true;
			item.damage = 250;
			item.width = 58;
			item.height = 50;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 1;
			item.value = 10000000;
			item.rare = 12;
			item.knockBack = 8;
			item.autoReuse = true;
			item.UseSound = SoundID.Item1;
			item.shoot = mod.ProjectileType("Akumu");
			item.shootSpeed = 8f;
		}
		
		public override void HoldItem(Player player)
		{
			if (player.statLife > player.statLifeMax2*0.35f)
			{
			player.AddBuff(mod.BuffType("TrueAkumuAttack"), 2);
			}
			if (player.statLife < player.statLifeMax2*0.35f)
			{
			((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).Akumu = true;
			player.AddBuff(mod.BuffType("TrueAkumu"), 2);
			}
		}
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				item.useTime = 30;
				item.useAnimation = 30;
			}
			else
			{
				item.useTime = 25;
				item.useAnimation = 25;
			}
			return base.CanUseItem(player);
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (player.altFunctionUse != 2)
			{
			item.noMelee = false;
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("AkumuThrow"), damage, knockBack, player.whoAmI);
			}
			if (player.altFunctionUse == 2)
			{
				item.noMelee = true;
				if (player.direction == 1)
				{
					Vector2 vel = new Vector2(0, 0);
					vel *= 0f;
					Projectile.NewProjectile(position.X, position.Y, vel.X, vel.Y, mod.ProjectileType("Akumu"), damage, knockBack, player.whoAmI);
				}
				if (player.direction == -1)
				{
					Vector2 vel = new Vector2(-1, 0);
					vel *= 0f;
					Projectile.NewProjectile(position.X, position.Y, vel.X, vel.Y, mod.ProjectileType("AkumuMirror"), damage, knockBack, player.whoAmI);
				}
			}
			return false;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Akumu");
			recipe.AddIngredient(null, "ChromaticCrystal", 5);
			recipe.AddIngredient(null, "SunkroveraCrystal", 5);
			recipe.AddIngredient(null, "NyctosythiaCrystal", 5);
			if (ModLoader.GetMod("CalamityMod") != null)
			{
			recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("UeliaceBar")), 10);
			recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("Phantoplasm")), 15);
			}
			if (ModLoader.GetMod("ThoriumMod") != null)
			{
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("OceanEssence")), 5);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("DeathEssence")), 5);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("InfernoEssence")), 5);
			}
			recipe.AddIngredient(null, "EmagledFragmentation", 150);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
