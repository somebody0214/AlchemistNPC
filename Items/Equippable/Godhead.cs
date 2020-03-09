using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Equippable
{
	public class Godhead : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Godhead");
			Tooltip.SetDefault("''I am fear!''"
			+"\n''I see everything''"
			+"\n''No one can stop me now!''"
				+"\nGives effects of all 3 souls"
				+"\nIn addition, increases damage by 5% more and adds 5 defense");
				DisplayName.AddTranslation(GameCulture.Russian, "Godhead");
            Tooltip.AddTranslation(GameCulture.Russian, "''Я - страх''\n''Я вижу всё''\n''Никто меня теперь не остановит!''\nДаёт эффекты всех 3 душ\nДополнительно увеличивает урон на 5% и увеличивает защиту на 5");
            DisplayName.AddTranslation(GameCulture.Chinese, "神性");
            Tooltip.AddTranslation(GameCulture.Chinese, "''我就是恐惧!''\n''我无所不见!''\n''我无人可挡!''\n给予所有3种魂的效果\n此外, 增加5%伤害和5点防御");
        }
	
		public override void SetDefaults()
		{
			item.stack = 1;
			item.width = 30;
			item.height = 30;
			item.value = 100000;
			item.rare = 8;
			item.defense = 5;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("Fear2"), 0, 0, player.whoAmI);
			player.findTreasure = true;
			player.detectCreature = true;
			player.dangerSense = true;
			player.allDamage += 0.2f;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("SoulOfVision"));
			recipe.AddIngredient(mod.ItemType("SoulOfFear"));
			recipe.AddIngredient(mod.ItemType("SoulOfPower"));
			recipe.AddIngredient(ItemID.SoulofFright, 15);
			recipe.AddIngredient(ItemID.SoulofSight, 15);
			recipe.AddIngredient(ItemID.SoulofMight, 15);
			recipe.AddIngredient(ItemID.SoulofLight, 30);
			recipe.AddIngredient(ItemID.SoulofNight, 30);
			recipe.AddIngredient(ItemID.HallowedBar, 99);
			recipe.AddIngredient(mod.ItemType("MannaFromHeaven"));
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}