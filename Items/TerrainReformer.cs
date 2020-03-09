using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.World.Generation;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
	public class TerrainReformer : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Terrain Reformer");
			Tooltip.SetDefault("The legendary terrain reforming device made by Ancients"
			+"\nLeft click for precise mining"
			+"\nRight click for digging extremely fast");
			DisplayName.AddTranslation(GameCulture.Russian, "Преобразователь Поверностей");
            Tooltip.AddTranslation(GameCulture.Russian, "Легендарное устройства ландшафтного дизайна, созданное Древними\nЛевый клик для точной добычи блоков\nПравый клик для быстрого разрывания земли");
		}

		public override void SetDefaults() {
			item.damage = 100;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 5;
			item.useAnimation = 10;
			item.pick = 225;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 100000;
			item.rare = 10;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.tileBoost += 5;
			item.useTurn = true;
		}
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		
		public override bool UseItem(Player player)
		{
			if (player.altFunctionUse != 2)
			{
				item.pick = 225;
				return true;
			}
			if (player.altFunctionUse == 2)
			{
				item.pick = 0;
				return true;
			}
			return base.UseItem(player);
		}

		public override void MeleeEffects(Player player, Rectangle hitbox) {
			if (Main.rand.NextBool(10)) {
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Electric);
			}
			if (player.altFunctionUse == 2 || (player.altFunctionUse != 2 && Main.mouseRight))
			{
				int range = 32;
				int minTileX = (int)(player.position.X / 16f - (float)range);
				int maxTileX = (int)(player.position.X / 16f + (float)range);
				int minTileY = (int)(player.position.Y / 16f - (float)range);
				int maxTileY = (int)(player.position.Y / 16f + (float)range);
				if (minTileX < 0) {
					minTileX = 0;
				}
				if (maxTileX > Main.maxTilesX) {
					maxTileX = Main.maxTilesX;
				}
				if (minTileY < 0) {
					minTileY = 0;
				}
				if (maxTileY > Main.maxTilesY) {
					maxTileY = Main.maxTilesY;
				}
				for (int i = minTileX; i < maxTileX; ++i)
				{
					for (int j = minTileY; j < maxTileY; ++j)
					{
						if (Main.tileDungeon[(int)Main.tile[i, j].type] || Main.tile[i, j].type == 88 || Main.tile[i, j].type == 21 || Main.tile[i, j].type == 26 || Main.tile[i, j].type == 107 || Main.tile[i, j].type == 108 || Main.tile[i, j].type == 111 || Main.tile[i, j].type == 226 || Main.tile[i, j].type == 237 || Main.tile[i, j].type == 221 || Main.tile[i, j].type == 222 || Main.tile[i, j].type == 223 || Main.tile[i, j].type == 211 || Main.tile[i, j].type == 404) continue;
						if (!Main.hardMode && Main.tile[i, j].type == 58) continue;
						if (!TileLoader.CanExplode(i, j)) continue;
						if (Main.tile[i, j].type == null) continue;
						if (!Main.tile[i, j].active()) continue;
						if (hitbox.Intersects(new Rectangle(i * 16, j * 16, 16, 16)))
						{
							WorldGen.KillTile(i, j, false, false, false);
						}
					}
				}
			}
		}
	}
}