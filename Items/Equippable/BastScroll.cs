using System.Collections.Generic;
using System.Linq;
using System;
using Terraria;
using Terraria.UI;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Items.Equippable
{
	public class BastScroll : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bast's Scroll");
			Tooltip.SetDefault("'The strong shall hunt the weak — that is the law of nature! And my rule is law!'"
			+"\nGives effects of Master Ninja Gear"
			+"\nAllows to jump higher"
			+"\nAllows to jump 3 times"
			+"\nBonus jumps could be disabled by changing visibility of accessory"
			+"\n+10% damage reduction"
			+"\nIncreases melee/throwing damage and crits by 15%"
			+"\nMelee/throwing attacks destroy enemy defense (may not work with some weapons)"
			+"\nDefense destruction effect is global for all players"
			+"\nThrowing attacks go through tiles");
			DisplayName.AddTranslation(GameCulture.Russian, "Свиток Баст");
            Tooltip.AddTranslation(GameCulture.Russian, "''Сильные должны охотиться на слабых - таков закон природы! И моё слово - закон!''\nДаёт все эффекты Снаряжения Мастера Ниндзя\nПозволяет прыгать выше\nПозволяет прыгать 3 раза\nДополнительные прыжки можно отключить с помощью изменения видимости аксессуара\nУменьшает получаемый урон на 10%\nПовышает урон и шанс критической атаки оружия ближнего/метательного боя на 15%\nБлижние и метательные атаки разрушают броню противника (может не работать с некоторым оружием)\nЭффект разрушения брони распространяется на все игроков\nМетательные атаки проходят сквозь блоки");

            DisplayName.AddTranslation(GameCulture.Chinese, "巴斯特卷轴");
            Tooltip.AddTranslation(GameCulture.Chinese, "'强者猎杀弱者——那就是自然规律! 而我遵循规律!'\n给予忍者大师的效果\n让你跳的更高\n允许三段跳\n隐藏饰品可关闭三段跳\n增加10%伤害减免\n增加15%近战/投掷伤害和暴击\n攻击摧毁敌人护甲 (可能不适用于某些武器)\n穿甲效果在多人适用于所有玩家\n投掷物可穿越方块");
        }
	
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 20;
			item.value = 100000;
			item.rare = 11;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.AddBuff(mod.BuffType("BastScroll"), 60);
			player.GetModPlayer<AlchemistNPCPlayer>().Scroll = true;
			player.endurance += 0.1f;
			player.statDefense += 5;
			player.thrownDamage += 0.15f;
            player.meleeDamage += 0.15f;
			player.meleeCrit += 15;
            player.thrownCrit += 15;
			player.dash = 1;
			player.blackBelt = true;
            player.spikedBoots = 2;
			player.jumpBoost = true;
			player.noFallDmg = true;
			if (!hideVisual)
			{
            player.doubleJumpSandstorm = true;
            player.doubleJumpBlizzard = true;
			}
			Mod Calamity = ModLoader.GetMod("CalamityMod");
			if(Calamity != null)
			{
				Calamity.Call("AddRogueCrit", player, 15);
			}
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MasterNinjaGear);
			recipe.AddIngredient(ItemID.WarriorEmblem);
			recipe.AddIngredient(ItemID.Book);
			recipe.AddIngredient(ItemID.BlackInk, 10);
			recipe.AddIngredient(ItemID.VialofVenom, 10);
			recipe.AddIngredient(ItemID.SpectreBar, 20);
			recipe.AddIngredient(ItemID.Nanites, 10);
			recipe.AddIngredient(ItemID.FragmentSolar, 30);
			recipe.AddIngredient(ItemID.LunarBar, 25);
			recipe.AddIngredient(mod.ItemType("EmagledFragmentation"), 250);
			recipe.AddTile(mod.TileType("MateriaTransmutator"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}