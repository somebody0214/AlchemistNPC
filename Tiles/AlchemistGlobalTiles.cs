using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ObjectData;
using System.Collections.Generic;

namespace AlchemistNPC.Tiles
{
	public class AlchemistGlobalTiles : GlobalTile
	{
		public override int[] AdjTiles(int type)
		{
			if (type == mod.TileType("MateriaTransmutator"))
			{
				Main.LocalPlayer.adjHoney = true;
				Main.LocalPlayer.adjLava = true;
				Main.LocalPlayer.adjWater = true;
				Main.LocalPlayer.alchemyTable = true;
			}
			if (type == mod.TileType("MateriaTransmutatorMK2"))
			{
				Main.LocalPlayer.adjHoney = true;
				Main.LocalPlayer.adjLava = true;
				Main.LocalPlayer.adjWater = true;
				Main.LocalPlayer.alchemyTable = true;
			}
			if (type == mod.TileType("SpecCraftPoint"))
			{
				Main.LocalPlayer.adjHoney = true;
				Main.LocalPlayer.adjLava = true;
				Main.LocalPlayer.adjWater = true;
			}
			if (type == mod.TileType("PreHMPenny"))
			{
				Main.LocalPlayer.alchemyTable = true;
			}
			return base.AdjTiles(type);
		}
	}
}