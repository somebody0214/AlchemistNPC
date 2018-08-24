using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Events;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.World.Generation;
 
namespace AlchemistNPC.NPCs
{
	[AutoloadHead]
	public class Operator : ModNPC
	{
		public static bool OA = false;
		public static bool Shop1 = true;
		public static bool Shop2 = false;
		public static bool Shop3 = false;
		public static bool Shop4 = false;
		public static bool Shop5 = false;
		public static bool S1A = false;
		public static bool S2A = false;
		public static bool S3A = false;
		public static bool S4A = false;
		public static bool S5A = false;
		public override string Texture
		{
			get
			{
				return "AlchemistNPC/NPCs/Operator";
			}
		}

		public override bool Autoload(ref string name)
		{
			name = "Operator";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Operator");
			DisplayName.AddTranslation(GameCulture.Russian, "Оператор");
            DisplayName.AddTranslation(GameCulture.Chinese, "操作员");
            Main.npcFrameCount[npc.type] = 23;   
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 500;
			NPCID.Sets.AttackType[npc.type] = 1;
			NPCID.Sets.AttackTime[npc.type] = 45;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = -6;

            ModTranslation text = mod.CreateTranslation("EGOShop");
            text.SetDefault("EGO Equipment Shop        ");
            text.AddTranslation(GameCulture.Russian, "Магазин Э.П.О.С                ");
            text.AddTranslation(GameCulture.Chinese, "EGO 商店           ");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("BossDropsShop");
            text.SetDefault("Boss Drops & Materials Shop");
            text.AddTranslation(GameCulture.Russian, "Магазин лута Боссов и материалов");
            text.AddTranslation(GameCulture.Chinese, "Boss掉落物&材料商店");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("VanillaTreasureBagsShop");
            text.SetDefault("Vanilla Treasure Bags Shop");
            text.AddTranslation(GameCulture.Russian, "Магазин сумок немодовых Боссов");
            text.AddTranslation(GameCulture.Chinese, "原版宝藏袋商店    ");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("ModdedTreasureBagsShop");
            text.SetDefault("Modded Treasure Bags Shop");
            text.AddTranslation(GameCulture.Russian, "Магазин сумок модовых Боссов");
            text.AddTranslation(GameCulture.Chinese, "模组宝藏袋商店    ");
            mod.AddTranslation(text);
			text = mod.CreateTranslation("ModdedTreasureBagsShop2");
            text.SetDefault("Modded Treasure Bags Shop #2");
            text.AddTranslation(GameCulture.Russian, "Магазин сумок модовых Боссов #2");
            text.AddTranslation(GameCulture.Chinese, "模组宝藏袋商店#2    ");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("CycleShopO");
            text.SetDefault("Cycle shop");
            text.AddTranslation(GameCulture.Russian, "Сменить магазин");
            text.AddTranslation(GameCulture.Chinese, "切换商店");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("Angela");
            text.SetDefault("Angela");
            text.AddTranslation(GameCulture.Russian, "Анджела");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO1");
            text.SetDefault("How are you day, Manager? Can I help you?");
            text.AddTranslation(GameCulture.Russian, "Как ваш день, Управляющий? Могу я помочь вам?");
            text.AddTranslation(GameCulture.Chinese, "您好吗, 主管, 我能为您做什么?");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO2");
            text.SetDefault("That 'The Great Thunder Bird' doesn't seems so dangerous. I am only hoping that it is not the part of Apocalypse Bird...");
            text.AddTranslation(GameCulture.Russian, "Эта 'Великая Птица-Гром' не кажется такой уж опасной. Я только надеюсь, что она не является частью Птицы Апокалипсиса.");
            text.AddTranslation(GameCulture.Chinese, "那个'大雷鸟'看起来并不怎么危险. 我只希望它不是天启鸟的一部分...");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO3");
            text.SetDefault("Hello, Manager! Isn't this day silent, does it?");
            text.AddTranslation(GameCulture.Russian, "Приветствую, Управляющий! Тихий сегодня денёк, не правда ли?");
            text.AddTranslation(GameCulture.Chinese, "您好, 主管! 今天真安静, 不是么?");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO4");
            text.SetDefault("Do you want anything special, Manager?");
            text.AddTranslation(GameCulture.Russian, "Вам нужно что-нибудь особенное, Управляющий?");
            text.AddTranslation(GameCulture.Chinese, "您想要什么特别的东西吗, 主管?");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO5");
            text.SetDefault("Eater of Worlds is Abnomality with risk class TETH. And now it is contained. Do you need something from it?");
            text.AddTranslation(GameCulture.Russian, "Пожиратель Миров - это аномалия с уровнем угрозы TETH. Теперь он захвачен. Нужно ли вам что-нибудь от него?");
            text.AddTranslation(GameCulture.Chinese, "世界吞噬者为异常, 危险等级: TETH. 现在它已经被写入了. 您需要些来自它的物品吗?");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO6");
            text.SetDefault("If you manage to supress Ragnarok, then you could do everything imaginable.");
            text.AddTranslation(GameCulture.Russian, "Если тебе удастся одолеть Рагнарёк, то тогда ты способен на всё, что угодно.");
            text.AddTranslation(GameCulture.Chinese, "如果您成功阻止诸神黄昏, 那么您可以做您想做的一切.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO7");
            text.SetDefault("Eye of Cthtulhu is pretty strange creature. It seems like it is just a small part of something really dangerous. It would be better for us if it never escapes.");
            text.AddTranslation(GameCulture.Russian, "Глаз Ктулху - довольно странное создание. Похоже, что он является малой частью чего-то по настоящему опасного. Лучше никогда не позволяйте ему сбежать.");
            text.AddTranslation(GameCulture.Chinese, "克苏鲁之眼是个特别奇怪的生物. 它看起来像是个十分危险的东西的一部分. 如果它没有逃跑对我们来说更好.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO8");
            text.SetDefault("Brain of Cthulhu may look horrifying, but without its minions it can do literally nothing.");
            text.AddTranslation(GameCulture.Russian, "Мозг Ктулху может выглядеть пугающе, но без своих прислужников он не способен ни на что");
            text.AddTranslation(GameCulture.Chinese, "克苏鲁之脑也许看起来很吓人, 但是失去了它的爪牙它几乎什么都做不了.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO9");
            text.SetDefault("Something changed in this world, Manager. Evil is spreading even wider, but at the same time, my sensor system fixed birth of new biome, called Hallowed.");
            text.AddTranslation(GameCulture.Russian, "Что-то изменилось в этом мире, Управляющий. Зло разрастается ещё шире, но в то же время мои сенсоры зафиксировали рождение нового биома, называющегося Святым.");
            text.AddTranslation(GameCulture.Chinese, "这个世界出现了某种变动, 主管. 邪恶正在扩张, 但是与此同时, 我的传感系统发现了一个新生物群落诞生了, 叫做神圣之地.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO10");
            text.SetDefault("All these Mechanical Bosses... They definetly could have Trauma origin. What classification numbers will they get? I think they would be started as T-05-...");
            text.AddTranslation(GameCulture.Russian, "Все эти Механические Боссы... Они определённо могут иметь происхождение от Траумы. Какие классификационные номера они получат? Я полагаю, они будут начинаться с T-05-...");
            text.AddTranslation(GameCulture.Chinese, "所有的这些机械Boss... 他们肯定有创伤来源. 他们会得到什么分类号码? 我觉得可以从 T-05- 开始...");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO11");
            text.SetDefault("Goblins... Such a pathetic creatures. And the only useful things from them are just Spiky Balls and Harpoons.");
            text.AddTranslation(GameCulture.Russian, "Гоблины... Какие же жалкие создания. Единственные полезные вещи с них - это шипастые шары и Гарпуны.");
            text.AddTranslation(GameCulture.Chinese, "哥布林... 如此可怜的生物. 他们唯一有用的东西就是尖刺球和鱼叉链枪.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO12");
            text.SetDefault("Pretty strange Abnormal event... They all look as living creatures, but their 'Flying Dutchman' is definetly a ghost with HE risk class.");
            text.AddTranslation(GameCulture.Russian, "Довольно странное событие... Они все выглядят как живые существа, но вот их 'Летучий Голландец' - определённо призрак класса опасности HE.");
            text.AddTranslation(GameCulture.Chinese, "挺奇怪的异常事件... 他们都看起来像是活着的生物, 但是他们的 '飞翔荷兰人号' 的危险等级绝对有 HE.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO13");
            text.SetDefault("Martians come again. Last time they came, several big towns were destroyed. But, in our excuses, we could say that we weren't as ready, as now.");
            text.AddTranslation(GameCulture.Russian, "Марсиане прибыли вновь. Последний раз когда они прибыли, было разрушено несколько крупных городов. Но, в наше оправдание можно сказать, что мы не были так готовы, как сейчас.");
            text.AddTranslation(GameCulture.Chinese, "火星人又来了. 上次他们来的时候, 几个大城镇被毁灭了. 但是, 恕我直言, 我们可以说我们现在还没有准备好.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO14");
            text.SetDefault("Blood Moon? Isn't IT should happen one time in 666 years?");
            text.AddTranslation(GameCulture.Russian, "Кровавая Луна? Разве она не должна случаться один раз в 666 лет?");
            text.AddTranslation(GameCulture.Chinese, "血月? 这不应该每666年才发生一次吗?");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO15");
            text.SetDefault("All these strange cratures just keep coming and coming to this 'Beacon'... Hope we all will survive until Dawn.");
            text.AddTranslation(GameCulture.Russian, "Все эти странные существа продолжают прибывать и прибывать на этот 'Маяк'... Надеюсь, мы все доживём до рассвета.");
            text.AddTranslation(GameCulture.Chinese, "所有的这些奇怪生物一直冲过来, 冲向这个'信标'... 真希望我们能在黎明前活下来.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO16");
            text.SetDefault("Anyway, there are some reasons for optimism. Blood Moon attracks some creatures, which cannot be seen in normal conditions.");
            text.AddTranslation(GameCulture.Russian, "Как бы то ни было, есть причина и для оптимизма. Кровавая Луна привлекает некоторых созданий, которых нельзя увидеть при обычных условиях.");
            text.AddTranslation(GameCulture.Chinese, "无论怎样, 都有一些乐观的理由. 血月带来了一些生物, 平时我们都见不到的生物.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO17");
            text.SetDefault("I read a few manuscripts about creature, named Slime God. They say that he is one of the first creatures in this world.");
            text.AddTranslation(GameCulture.Russian, "Я прочитала несколько манускриптов о существе, именуемом Бог Слизней. В них говорится, что он является одним из первых созданий этого мира");
            text.AddTranslation(GameCulture.Chinese, "我阅读了一些关于一个生物的手稿, 叫做史莱姆之神. 他们说这是世界上第一个生物之一.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO18");
            text.SetDefault("Yharim... I am pretty sure I heard that name before. But my memory data is corrupted. Try asking Calamitas about him...");
            text.AddTranslation(GameCulture.Russian, "Ярим... Я уверена, что слышала это имя раньше. Но моя память повреждена. Попробуй узнать у Каламитас что-нибудь о нём...");
            text.AddTranslation(GameCulture.Chinese, "Yharim... 我很确定我曾经听过这个名字. 但是我的记忆数据已损坏. 试着去问问大山猪关于它的事情吧...");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO19");
            text.SetDefault("This carnivorous plant was really dangerous... At least HE Risk Class. Glad to see you again in one piece after all.");
            text.AddTranslation(GameCulture.Russian, "Этот плотоядный цветок был опасен на самом деле... Рада видеть, что ты не пострадал.");
            text.AddTranslation(GameCulture.Chinese, "这种肉食植物真的很危险...危险等级至少为 HE , 总之很高兴再次见到你平安归来");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO20");
            text.SetDefault("This ancient machine was holding celestial powers inside. With its death, world can change forever...");
            text.AddTranslation(GameCulture.Russian, "Эта древняя машина хранила в себе Небесные Силы. С её смертью, мир может измениться навсегда.");
            text.AddTranslation(GameCulture.Chinese, "这古老的机器拥有着巨大的天界之力. 随着它的死亡, 世界也发生了永远的改变...");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO21");
            text.SetDefault("An insect the size of the Queen Bee defies current methods of classification. I propose insects of this size be given a new classification MI-XX. It is a wonder that nobody has used them for their own means, let us be the first.");
            text.AddTranslation(GameCulture.Russian, "Размеры насекомого с Королеву Пчёл бросают вызов текущим методам класификации. Я предлагаю дать насекомому таких размеров новую классификацию MI-XX. Удивительно, что ещё никто не использовал их для себя.");
            text.AddTranslation(GameCulture.Chinese, "一个蜂后那么大的昆虫是不符合现在的分类标准的. 我建议为他建立一个新的分类 MI-XX. 很奇怪还没有人为了自己的意愿驱使它们, 那么让我们成为第一个吧.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO22");
            text.SetDefault("It appears I was wrong about the queen bees. Their memory storage contains the ramblings of a scientist who was blinded by ambition, who cruelly introduced the plague to them. Let us classify them as MP-0X.");
            text.AddTranslation(GameCulture.Russian, "Похоже, что я была неправа по поводу Королев Пчёл. Их память хранит бредовые мысли учёного, ослеплённого своими амбициями, того, кто жестоко заразил их чумой. Давайте классифицируем их как МР-0Х.");
			text.AddTranslation(GameCulture.Chinese, "看来我对蜂后的看法是错的. 它们的记忆中储存着一个被野心蒙蔽了双眼的科学家的漫谈, 他残酷地把瘟疫带给它们. 让我们把它们归类为MP-0X.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO23");
            text.SetDefault("According to my notes, this Coznix you speak of was a lesser Void Observer, classified as OB-V-01. There are greater threats waiting behind the veil of reality.");
            text.AddTranslation(GameCulture.Russian, "Согласно моим записям, этот Козникс, о котором ты говорил, является малым Созерцателем Пустоты, классифицированном как OB-V-01. Похоже, что существуют ещё большие опасности за Границей Реальности.");
			text.AddTranslation(GameCulture.Chinese, "根据我的记录, 你所说的那个克兹尼格斯是一个较弱的虚空巡查者, 被归类为OB-V-01. 在现实的面纱后面有着更大的威胁在等待着.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO24");
            text.SetDefault("This flying scouter..... curious. From the memory banks stored in the wreckage, this looks to have been a scouting ship for the Martians, to determine how hospitable Terraria is. I fear the pilot's last moments have been transmitted to the main Martian command centre.");
			text.AddTranslation(GameCulture.Russian, "Этот летающая тарелка... интересна. Согласно носителям данных с места крушения, это корабль-разведчик Марсиан, целью которого является проверка того, насколько мир Террарии подходит для жизни. Боюсь, что последним, что успел сделать пилот этого корабля, была отправка сообщения в Главный Командный Центр Марсиан.");           
			text.AddTranslation(GameCulture.Chinese, "这个飞行侦察者.....好奇. 从储存在残骸中的数据库来看, 这似乎是一艘为火星人而设的侦察船, 用来确定地球人的居住环境. 我担心飞行员最后看到的已经被上传到中央火星指挥中心.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO25");
            text.SetDefault("Turning a mages' power in on himself and trapping him within it is no easy task, but to observe cruelty of such magnitude..... Permafrost, former lord of the Ice Castle, may you see peace.");
            text.AddTranslation(GameCulture.Russian, "Обращение силы мага против его самого и его заключение ей же непростая задача, но видя такую жестокость... Вечный Хлад, бывший властелин Ледяного Замка, может ты теперь обретёшь покой.");
			text.AddTranslation(GameCulture.Chinese, "把一个法师的力量转移到自己身上并且用它困住他并非易事, 但是观察如此残酷的行为...永冻之土, 前冰堡之王, 愿你看到和平.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO26");
            text.SetDefault("The Starplate raider is a Genius Stardust Centipede, or a G-S-C3, popular with the Martian elite as lifelong companions and raiding partners. It must have wandered far from home, judging from the transmitter memory banks I recovered.");
            text.AddTranslation(GameCulture.Russian, "Звёздный Рейндер это Гениальная Сороконожка Звёздной Пыли или G-S-C3, известная среди Марсианской Элиты как долгоживущий компаньон и партнёры для рейдерских экспедиций. Похоже, она ушла очень далеко от дома, судя по блокам данных, что я смогла восстановить.");
			text.AddTranslation(GameCulture.Chinese, "星盘袭击者是个天才星尘蜈蚣, 或是G-S-C3, 作为终身伴侣和合作伙伴在火星精英中很受欢迎. 从我恢复出的巡航机的存储芯片来看, 他一定在离家很远的地方探索着");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO27");
            text.SetDefault("I took the time to analize the remains of this incredible creature. Every time it attacked, the entire planet seem to resonate within its will. I can do nothing but to worry about the consequences of its death. At least, you saved Terraria of certain doom..........again.");
            text.AddTranslation(GameCulture.Russian, "Я потратила некоторое время, чтобы проанализировать останки этого невероятного творения. Каждый раз, когда оно атаковало, вся планета резонировала против его воли. Я не могу сделать ничего, кроме как волноваться о последствиях его смерти. Во всяком случае, ты спас Террарию от незавидной судьбы...... вновь.");
			text.AddTranslation(GameCulture.Chinese, "我花了时间对这个不可思议的生物的遗体进行了分析, 每次它攻击的时候, 整个星球似乎都在它的意愿中产生共鸣, 我除了担心它的死亡的后果之外, 什么都做不了, 至少你又一次从末日中拯救了Terraria...又一次");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO28");
            text.SetDefault("Such an ancient presence is worth documenting - the material of its plates can withstand temperatures equal to the core of the Terrarian Sun! This will revolutionize containment procedures for ARS-0N prisoners if we can make materials half as resistant to heat!");
            text.AddTranslation(GameCulture.Russian, "Столь древняя сущность заслуживает документирования. Материалы её пластин могут выдержать температуру, равную ядру Солнца Террарии! Это революционизирует методы сдерживания для ARS-0N узников если мы сможем создать материалы, которые будут иметь хотя бы половину подобной стойкости.");
			text.AddTranslation(GameCulture.Chinese, "这样一个古老的存在是值得记录的--它外表的材料可以承受与地球太阳核心的温度相等的温度!如果我们能使材料具有一半的耐热性, 这将彻底改变对 ARS-0N 囚犯的控制装置!");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO29");
            text.SetDefault("Whoever made the Ravager deserves to be put in HI-MAX containment. All those tortured souls....... Well, at least you put them out of their misery.");
			text.AddTranslation(GameCulture.Russian, "Тот, кто создал Опустошителя, заслуживает быть заключённый в Камере Максимального Содержания. Все эти измученные души.... Ну, по крайней мере ты освободил их от бренного существования.");
			text.AddTranslation(GameCulture.Chinese, "那些制造毁灭魔像的人就应该被关进 HI-MAX 监狱中去. 这些可怜的灵魂受尽了折磨......好吧, 至少你将他们从痛苦之渊中解放出来");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO30");
            text.SetDefault("Interesting... those Bumblebirbs were actually meant to be clones of Yharon. I’m glad that experiment was a failure!");
            text.AddTranslation(GameCulture.Russian, "Интересно... Эти Птицешмели были запланированы как клоны Ярона. Как я рада, что этот эксперимент провалился.");
			text.AddTranslation(GameCulture.Chinese, "有意思...那些癫痫鸟实际上是丛林龙犽戎的克隆体. 我很高兴看到那些实验都失败了!");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO31");
            text.SetDefault("You were lucky that thing got complacent and didn't open a portal to the Sun on our heads. The sheer strength and intelligence it exhibited means I need to make a whole new category for the classification of Worms.");
			text.AddTranslation(GameCulture.Russian, "Какое счастье, что ты не открыл портал на Солнце над нашими головами. Эта абсолютная сила и интеллект, что он продемонстрировал, означают, что мне потребуется создать совершенно новую категорию для классификации Червей.");           
			text.AddTranslation(GameCulture.Chinese, "你很幸运, 那东西膨胀了, 没有直接在你头上开个直通太阳的传送门. 他所展示出的力量和智慧, 意味着我要对蠕虫的类别做一个全新的分类");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO32");
            text.SetDefault("I have my theories about the origin of this being, more than fear his soul (if he have one)... Irradiates negative energy, experimentation shown how in darkness this ''oblivion energy'', irradiated light but in light places irradiated shadow. I don't know where he came from but I know that whatever is his race, It must be contained at any cost!");
			text.AddTranslation(GameCulture.Russian, "У меня есть теории о происхождении этого существа, которые пугают меня даже больше, чем его душа (если она у него вообще есть)... Излучает негативную энергию, поглащает свет и создаёт тени. Не знаю, откуда он пришёл, но знаю, что кто бы он ни был, его нужно сдержать любой ценой!");           
			text.AddTranslation(GameCulture.Chinese, "对于这生物的起源我有些基本的猜测, 而不是单纯害怕他的灵魂(如果他有灵魂的话)...反辐射能量, 研究表明, 这种'湮灭能量'在黑暗中发出光芒, 在光明中辐射黑暗. 我不知道它是怎么来的, 但是我知道我们必须付出一切代价封印它.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO33");
            text.SetDefault("Supreme Calamity has been defeated but she speaks of a being even stronger than herself. We must hope that he hasn't taken notice of us yet.");
            text.AddTranslation(GameCulture.Russian, "Совершенная Каламитас была побеждена, но она говорила о существе, ещё более сильном, чем она сама. Мы можем лишь надеяться, что он ещё не обратил на нас внимания.");
			text.AddTranslation(GameCulture.Chinese, "至尊灾厄眼被击败了, 但是他说还有一个比他更为强大的存在, 我们必须祈祷他还没有注意到我们.");
            mod.AddTranslation(text);
        }

		public override void ResetEffects()
		{
		OA = false;
		S1A = false;
		S2A = false;
		S3A = false;
		S4A = false;
		S5A = false;
		}
		
		public override void SetDefaults()
		{
			npc.townNPC = true;
            npc.friendly = true;
            npc.width = 18;
            npc.height = 40;
            npc.aiStyle = 7;
            npc.damage = 10;
            npc.defense = 50;
            npc.lifeMax = 1000;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
			animationType = NPCID.Steampunker;
		}
		
		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			if (NPC.downedBoss2)
			{
			return true;
			}
			return false;
		}
 
		public override bool CheckConditions(int left, int right, int top, int bottom)
		{
			int score = 0;
			if (ModLoader.GetMod("AlchemistNPCContentDisabler") == null)
			{
				for (int x = left; x <= right; x++)
				{
					for (int y = top; y <= bottom; y++)
					{
						int type = Main.tile[x, y].type;
						if (type == mod.TileType("WingoftheWorld"))
						{
							score++;
						}
					}
				}
				
			}
			if (ModLoader.GetMod("AlchemistNPCContentDisabler") != null)
			{
			score = 1;
			}
			return score > 0;
		}
 
        public override string TownNPCName()
        {
            string Angela = Language.GetTextValue("Mods.AlchemistNPC.Angela");
			switch (WorldGen.genRand.Next(1))
            {
                case 0:
                    return Angela;
                default:
                    return Angela;
            }
        }
 
		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			if (!Main.hardMode)
			{
			damage = 20;
			}
			if (Main.hardMode && !NPC.downedMoonlord)
			{
			damage = 75;
			}
			if (NPC.downedMoonlord)
			{
			damage = 500;
			}
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 10;
			randExtraCooldown = 5;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			attackDelay = 10;
			if (ModLoader.GetMod("AlchemistNPCContentDisabler") == null)
			{
				if (!Main.hardMode)
				{
				projType = mod.ProjectileType("BB");
				}
				if (Main.hardMode && !NPC.downedMoonlord)
				{
				projType = mod.ProjectileType("FDB");
				}
				if (NPC.downedMoonlord)
				{
				projType = mod.ProjectileType("MB");
				}
			}
			if (ModLoader.GetMod("AlchemistNPCContentDisabler") != null)
			{
				if (!Main.hardMode)
				{
				projType = 14;
				}
				if (Main.hardMode && !NPC.downedMoonlord)
				{
				attackDelay = 10;
				projType = 279;
				}
				if (NPC.downedMoonlord)
				{
				attackDelay = 4;
				projType = 638;
				}
			}
		}

		public override void DrawTownAttackGun(ref float scale, ref int item, ref int closeness) //Allows you to customize how this town NPC's weapon is drawn when this NPC is shooting (this NPC must have an attack type of 1). Scale is a multiplier for the item's drawing size, item is the ID of the item to be drawn, and closeness is how close the item should be drawn to the NPC.
		{
			scale = 1f;
			closeness = 20;
			if (ModLoader.GetMod("AlchemistNPCContentDisabler") == null)
			{
				if (!Main.hardMode)
				{
				item = mod.ItemType("TheBeak");
				}
				if (Main.hardMode && !NPC.downedMoonlord)
				{
				item = mod.ItemType("FuneralofDeadButterflies");
				}
				if (NPC.downedMoonlord)
				{
				item = mod.ItemType("MagicBullet");
				}
			}
			if (ModLoader.GetMod("AlchemistNPCContentDisabler") != null)
			{
				if (!Main.hardMode)
				{
				item = ItemID.FlintlockPistol;
				}
				if (Main.hardMode && !NPC.downedMoonlord)
				{
				item = ItemID.Shotgun;
				}
				if (NPC.downedMoonlord)
				{
				item = ItemID.VortexBeater;
				}
			}
		}
		
		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
		}
 
 
        public override string GetChat()
        {                                           //npc chat
		string EntryO1 = Language.GetTextValue("Mods.AlchemistNPC.EntryO1");
		string EntryO2 = Language.GetTextValue("Mods.AlchemistNPC.EntryO2");
		string EntryO3 = Language.GetTextValue("Mods.AlchemistNPC.EntryO3");
		string EntryO4 = Language.GetTextValue("Mods.AlchemistNPC.EntryO4");
		string EntryO5 = Language.GetTextValue("Mods.AlchemistNPC.EntryO5");
		string EntryO6 = Language.GetTextValue("Mods.AlchemistNPC.EntryO6");
		string EntryO7 = Language.GetTextValue("Mods.AlchemistNPC.EntryO7");
		string EntryO8 = Language.GetTextValue("Mods.AlchemistNPC.EntryO8");
		string EntryO9 = Language.GetTextValue("Mods.AlchemistNPC.EntryO9");
		string EntryO10 = Language.GetTextValue("Mods.AlchemistNPC.EntryO10");
		string EntryO11 = Language.GetTextValue("Mods.AlchemistNPC.EntryO11");
		string EntryO12 = Language.GetTextValue("Mods.AlchemistNPC.EntryO12");
		string EntryO13 = Language.GetTextValue("Mods.AlchemistNPC.EntryO13");
		string EntryO14 = Language.GetTextValue("Mods.AlchemistNPC.EntryO14");
		string EntryO15 = Language.GetTextValue("Mods.AlchemistNPC.EntryO15");
		string EntryO16 = Language.GetTextValue("Mods.AlchemistNPC.EntryO16");
		string EntryO17 = Language.GetTextValue("Mods.AlchemistNPC.EntryO17");
		string EntryO18 = Language.GetTextValue("Mods.AlchemistNPC.EntryO18");
		string EntryO19 = Language.GetTextValue("Mods.AlchemistNPC.EntryO19");
		string EntryO20 = Language.GetTextValue("Mods.AlchemistNPC.EntryO20");
		string EntryO21 = Language.GetTextValue("Mods.AlchemistNPC.EntryO21");
		string EntryO22 = Language.GetTextValue("Mods.AlchemistNPC.EntryO22");
		string EntryO23 = Language.GetTextValue("Mods.AlchemistNPC.EntryO23");
		string EntryO24 = Language.GetTextValue("Mods.AlchemistNPC.EntryO24");
		string EntryO25 = Language.GetTextValue("Mods.AlchemistNPC.EntryO25");
		string EntryO26 = Language.GetTextValue("Mods.AlchemistNPC.EntryO26");
		string EntryO27 = Language.GetTextValue("Mods.AlchemistNPC.EntryO27");
		string EntryO28 = Language.GetTextValue("Mods.AlchemistNPC.EntryO28");
		string EntryO29 = Language.GetTextValue("Mods.AlchemistNPC.EntryO29");
		string EntryO30 = Language.GetTextValue("Mods.AlchemistNPC.EntryO30");
		string EntryO31 = Language.GetTextValue("Mods.AlchemistNPC.EntryO31");
		string EntryO32 = Language.GetTextValue("Mods.AlchemistNPC.EntryO32");
		string EntryO33 = Language.GetTextValue("Mods.AlchemistNPC.EntryO33");
		if (Main.bloodMoon)
			{
				switch (Main.rand.Next(3))
				{
				case 0:
				return EntryO14;
				case 1:
				return EntryO15;
				case 2:
				return EntryO16;
				}
			}
		if (Main.invasionType == 1)
			{
				return EntryO11;
			}
			if (Main.invasionType == 3)
			{
				return EntryO12;
			}
			if (Main.invasionType == 4)
			{
				return EntryO13;
			}
		if (Main.rand.Next(5) == 0)
		{
			if (!WorldGen.crimson)
			{
			return EntryO5;
			}
			if (WorldGen.crimson)
			{                
			return EntryO8;
			}
		}
		if (ModLoader.GetLoadedMods().Contains("CalamityMod") && NPC.downedBoss3)
		{
			if (Main.rand.Next(7) == 0)
			{
				return EntryO17;
			} 
		}
		if (NPC.downedPlantBoss)
		{
			if (Main.rand.Next(7) == 0)
			{
				return EntryO19;
			} 
		}
		if (NPC.downedGolemBoss)
		{
			if (Main.rand.Next(7) == 0)
			{
				return EntryO20;
			} 
		}
		if (ModLoader.GetLoadedMods().Contains("CalamityMod") && NPC.downedMoonlord)
		{
			if (Main.rand.Next(7) == 0)
			{
				return EntryO18;
			} 
		}
		if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
		{
			if (Main.rand.Next(6) == 0)
			{
				return EntryO2;
				
			} 
		}
		if (ModLoader.GetLoadedMods().Contains("ThoriumMod") && Main.hardMode)
		{
			if (Main.rand.Next(6) == 0)
			{
			return EntryO6;
			}
		}
		if (Main.rand.Next(5) == 0 && Main.hardMode)
			{
				switch (Main.rand.Next(2))
				{
                case 0:                                     
				return EntryO9;
                case 1:                                                      
				return EntryO10;
				}
			}
		if (Main.rand.Next(5) == 0 && NPC.downedQueenBee)
			{                                                 
			return EntryO21;
			}
		if (ModLoader.GetLoadedMods().Contains("CalamityMod") && Main.hardMode)
		{
			if (Main.rand.Next(5) == 0 && CalamityModDownedPlaguebringer)
				{                                                 
				return EntryO22;
				}
			if (Main.rand.Next(5) == 0 && CalamityModDownedCryogen)
				{                                                 
				return EntryO25;
				}
			if (Main.rand.Next(5) == 0 && CalamityModDownedProvidence)
				{                                                 
				return EntryO28;
				}
			if (Main.rand.Next(5) == 0 && CalamityModDownedRavager)
				{                                                 
				return EntryO29;
				}
			if (Main.rand.Next(5) == 0 && CalamityModDownedBirb)
				{                                                 
				return EntryO30;
				}
			if (Main.rand.Next(5) == 0 && CalamityModDownedDOG)
				{                                                 
				return EntryO31;
				}
			if (Main.rand.Next(5) == 0 && CalamityModDownedSCal)
				{                                                 
				return EntryO33;
				}
		}
		if (ModLoader.GetLoadedMods().Contains("ThoriumMod") && Main.hardMode)
		{
			if (Main.rand.Next(5) == 0 && ThoriumModDownedFallenBeholder)
				{                                                 
				return EntryO23;
				}
			if (Main.rand.Next(5) == 0 && ThoriumModDownedStarScout)
				{                                                 
				return EntryO24;
				}
		}
		if (ModLoader.GetLoadedMods().Contains("SacredTools") && Main.hardMode)
		{
			if (Main.rand.Next(5) == 0 && SacredToolsDownedAbbadon)
				{                  
				return EntryO32;
				}
		}
		if (ModLoader.GetLoadedMods().Contains("SpiritMod") && Main.hardMode)
		{
			if (Main.rand.Next(5) == 0 && SpiritModDownedStarplateRaider)
				{                                                 
				return EntryO26;
				}
			if (Main.rand.Next(5) == 0 && SpiritModDownedOverseer)
				{                                                 
				return EntryO27;
				}
		}
            switch (Main.rand.Next(4))
            {
                case 0:                                     
				return EntryO1;
                case 1:                                                      
				return EntryO3;
                case 2:
				return EntryO4;
                default:
				return EntryO7;
            }
        }
 
        public override void SetChatButtons(ref string button, ref string button2)
        {
		string EGOShop = Language.GetTextValue("Mods.AlchemistNPC.EGOShop");
		string BossDropsShop = Language.GetTextValue("Mods.AlchemistNPC.BossDropsShop");
		string VanillaTreasureBagsShop = Language.GetTextValue("Mods.AlchemistNPC.VanillaTreasureBagsShop");
		string ModdedTreasureBagsShop = Language.GetTextValue("Mods.AlchemistNPC.ModdedTreasureBagsShop");
		string ModdedTreasureBagsShop2 = Language.GetTextValue("Mods.AlchemistNPC.ModdedTreasureBagsShop2");
		string CycleShopO = Language.GetTextValue("Mods.AlchemistNPC.CycleShopO");
		if (Config.TS && Main.expertMode)
		{
			if (Shop1)
			{
			button = BossDropsShop;
			S5A = false;
			S1A = true;
			}
			if (Shop2)
			{
			button = EGOShop;
			S1A = false;
			S2A = true;
			}
			if (Shop3)
			{
			button = VanillaTreasureBagsShop;
			S2A = false;
			S3A = true;
			}
			if (Shop4)
			{
			button = ModdedTreasureBagsShop;
			S3A = false;
			S4A = true;
			}
			if (Shop5)
			{
			button = ModdedTreasureBagsShop2;
			S4A = false;
			S5A = true;
			}
			button2 = CycleShopO;
		}
			if (!Config.TS || !Main.expertMode)
			{
			button = BossDropsShop;
			button2 = EGOShop;
			}
			if (ModLoader.GetMod("AlchemistNPCContentDisabler") != null && Config.TS && Main.expertMode)
			{
			button = BossDropsShop;
			button2 = CycleShopO;
				if (Shop1)
				{
				button = BossDropsShop;
				S5A = false;
				S1A = true;
				}
				if (Shop3)
				{
				button = VanillaTreasureBagsShop;
				S2A = false;
				S3A = true;
				}
				if (Shop4)
				{
				button = ModdedTreasureBagsShop;
				S3A = false;
				S4A = true;
				}
				if (Shop5)
				{
				button = ModdedTreasureBagsShop2;
				S4A = false;
				S5A = true;
				}
			}
			if (ModLoader.GetMod("AlchemistNPCContentDisabler") != null && (!Config.TS || !Main.expertMode))
			{
			button = BossDropsShop;
			}
        }
 
        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
			{
				if (!Config.TS || !Main.expertMode)
					{
					Shop1 = true;
					Shop2 = false;
					shop = true;
					}
				if (Config.TS && Main.expertMode)
					{
					shop = true;
					}
				if (ModLoader.GetMod("AlchemistNPCContentDisabler") != null && (!Config.TS || !Main.expertMode))
				{
				Shop1 = true;
				shop = true;
				}
			}
			else
			{
				if (Config.TS && Main.expertMode)
				{
				if (Shop1 && S1A)
						{
						Shop2 = true;
						Shop1 = false;
						}
				if (Shop2 && S2A)
						{
						Shop3 = true;
						Shop2 = false;
						}
				if (Shop3 && S3A)
						{
						Shop4 = true;
						Shop3 = false;
						}
				if (Shop4 && S4A)
						{
						Shop5 = true;
						Shop4 = false;
						}
				if (Shop5 && S5A)
						{
						Shop1 = true;
						Shop5 = false;
						}
				}
				if (!Config.TS || !Main.expertMode)
					{
					Shop2 = true;
					Shop1 = false;
					shop = true;
					}
				if (ModLoader.GetMod("AlchemistNPCContentDisabler") != null && Config.TS && Main.expertMode)
				{
					if (Shop1 && S1A)
							{
							Shop3 = true;
							Shop1 = false;
							}
					if (Shop3 && S3A)
							{
							Shop4 = true;
							Shop3 = false;
							}
					if (Shop4 && S4A)
							{
							Shop5 = true;
							Shop4 = false;
							}
					if (Shop5 && S5A)
							{
							Shop1 = true;
							Shop5 = false;
							}
				}
			}
		}
 
		public bool CalamityModDownedGuardian
		{
		get { return CalamityMod.CalamityWorld.downedGuardians; }
		}
		public bool CalamityModDownedPlaguebringer
		{
		get { return CalamityMod.CalamityWorld.downedPlaguebringer; }
		}
		public bool CalamityModDownedRavager
		{
		get { return CalamityMod.CalamityWorld.downedScavenger; }
		}
		public bool CalamityModDownedBirb
		{
		get { return CalamityMod.CalamityWorld.downedBumble; }
		}
		public bool CalamityModDownedPolter
		{
		get { return CalamityMod.CalamityWorld.downedPolterghast; }
		}
		public bool CalamityModDownedDOG
		{
		get { return CalamityMod.CalamityWorld.downedDoG; }
		}
		public bool CalamityModDownedYharon
		{
		get { return CalamityMod.CalamityWorld.downedYharon; }
		}
		public bool CalamityModDownedSCal
		{
		get { return CalamityMod.CalamityWorld.downedSCal; }
		}
		public bool CalamityModDownedAstrum
		{
		get { return CalamityMod.CalamityWorld.downedStarGod; }
		}
		public bool CalamityModDownedSlimeGod
        {
        get { return CalamityMod.CalamityWorld.downedSlimeGod; }
        }
		public bool CalamityModDownedHiveMind
        {
        get { return CalamityMod.CalamityWorld.downedHiveMind; }
        }
        public bool CalamityModDownedPerforators
        {
        get { return CalamityMod.CalamityWorld.downedPerforator; }
        }
		public bool CalamityModDownedCalamitas
        {
        get { return CalamityMod.CalamityWorld.downedCalamitas; }
        }
		public bool CalamityModDownedProvidence
        {
        get { return CalamityMod.CalamityWorld.downedProvidence; }
        }
		public bool CalamityModDownedCryogen
		{
        get { return CalamityMod.CalamityWorld.downedCryogen; }
        }
		public bool CalamityModDownedLeviathan
        {
        get { return CalamityMod.CalamityWorld.downedLeviathan; }
        }
		public bool CalamityModDownedAstrageldon
        {
        get { return CalamityMod.CalamityWorld.downedAstrageldon; }
        }
 
		public bool ThoriumModDownedGTBird
        {
        get { return ThoriumMod.ThoriumWorld.downedThunderBird; }
        }
        public bool ThoriumModDownedQueenJelly
        {
        get { return ThoriumMod.ThoriumWorld.downedJelly; }
        }
		public bool ThoriumModDownedViscount
        {
        get { return ThoriumMod.ThoriumWorld.downedBat; }
        }
        public bool ThoriumModDownedStorm
        {
        get { return ThoriumMod.ThoriumWorld.downedStorm; }
        }
        public bool ThoriumModDownedChampion
        {
        get { return ThoriumMod.ThoriumWorld.downedChampion; }
        }
        public bool ThoriumModDownedStarScout
        {
        get { return ThoriumMod.ThoriumWorld.downedScout; }
        }
        public bool ThoriumModDownedBoreanStrider
        {
        get { return ThoriumMod.ThoriumWorld.downedStrider; }
        }
        public bool ThoriumModDownedFallenBeholder
        {
        get { return ThoriumMod.ThoriumWorld.downedFallenBeholder; }
        }
        public bool ThoriumModDownedLich
        {
        get { return ThoriumMod.ThoriumWorld.downedLich; }
        }
        public bool ThoriumModDownedAbyssion
        {
        get { return ThoriumMod.ThoriumWorld.downedDepthBoss; }
        }
        public bool ThoriumModDownedRagnarok
        {
        get { return ThoriumMod.ThoriumWorld.downedRealityBreaker; }
        }
		
		public bool SacredToolsDownedPumpkin
		{
        get { return SacredTools.ModdedWorld.downedPumpboi; }
        }
		public bool SacredToolsDownedHarpyPreHM
		{
        get { return SacredTools.ModdedWorld.downedHarpy; }
        }
		public bool SacredToolsDownedHarpyHM
		{
        get { return SacredTools.ModdedWorld.downedRaynare; }
        }
		public bool SacredToolsDownedAbbadon
		{
        get { return SacredTools.ModdedWorld.OblivionSpawns; }
        }
		public bool SacredToolsDownedAraghur
		{
        get { return SacredTools.ModdedWorld.FlariumSpawns; }
        }
		public bool SacredToolsDownedLunarians
		{
        get { return SacredTools.ModdedWorld.downedLunarians; }
        }
		public bool SacredToolsDownedChallenger
		{
        get { return SacredTools.ModdedWorld.downedChallenger; }
        }
		
		public bool SpiritModDownedScarabeus
		{
        get { return SpiritMod.MyWorld.downedScarabeus; }
        }
		public bool SpiritModDownedBane
		{
        get { return SpiritMod.MyWorld.downedReachBoss; }
        }
		public bool SpiritModDownedFlier
		{
        get { return SpiritMod.MyWorld.downedAncientFlier; }
        }
		public bool SpiritModDownedStarplateRaider
		{
        get { return SpiritMod.MyWorld.downedRaider; }
        }
		public bool SpiritModDownedInfernon
		{
        get { return SpiritMod.MyWorld.downedInfernon; }
        }
		public bool SpiritModDownedDusking
		{
        get { return SpiritMod.MyWorld.downedDusking; }
        }
		public bool SpiritModDownedEtherialUmbra
		{
        get { return SpiritMod.MyWorld.downedSpiritCore; }
        }
		public bool SpiritModDownedIlluminantMaster
		{
        get { return SpiritMod.MyWorld.downedIlluminantMaster; }
        }
		public bool SpiritModDownedAtlas
		{
        get { return SpiritMod.MyWorld.downedAtlas; }
        }
		public bool SpiritModDownedOverseer
		{
        get { return SpiritMod.MyWorld.downedOverseer; }
        }
		
		public bool EnigmaDownedSharkron
		{
        get { return Laugicality.LaugicalityWorld.downedDuneSharkron; }
        }
		public bool EnigmaDownedHypothema
		{
        get { return Laugicality.LaugicalityWorld.downedHypothema; }
        }
		public bool EnigmaDownedRagnar
		{
        get { return Laugicality.LaugicalityWorld.downedRagnar; }
        }
		public bool EnigmaDownedAnDio
		{
        get { return Laugicality.LaugicalityWorld.downedAnDio; }
        }
		public bool EnigmaDownedAnnihilator
		{
        get { return Laugicality.LaugicalityWorld.downedAnnihilator; }
        }
		public bool EnigmaDownedSlybertron
		{
        get { return Laugicality.LaugicalityWorld.downedSlybertron; }
        }
		public bool EnigmaDownedSteamTrain
		{
        get { return Laugicality.LaugicalityWorld.downedSteamTrain; }
        }
		public bool EnigmaDownedEtheria
		{
        get { return Laugicality.LaugicalityWorld.downedTrueEtheria; }
        }
		
		public override void SetupShop(Chest shop, ref int nextSlot)
		{
			for (int k = 0; k < 255; k++)
			{
				Player player = Main.player[k];
				if (player.active)
				{
					for (int j = 0; j < player.inventory.Length; j++)
					{
						if (player.inventory[j].type == mod.ItemType("OtherworldlyAmulet"))
						{
						OA = true;
						}
					}
				}
			}
			if (Shop1)
			{
				shop.item[nextSlot].SetDefaults (ItemID.Lens);
				shop.item[nextSlot].shopCustomPrice = 10000;
				nextSlot++;
				if (!WorldGen.crimson)
				{
				shop.item[nextSlot].SetDefaults (ItemID.DemoniteOre);
				shop.item[nextSlot].shopCustomPrice = 2500;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.ShadowScale);
				shop.item[nextSlot].shopCustomPrice = 10000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.RottenChunk);
				shop.item[nextSlot].shopCustomPrice = 10000;
				nextSlot++;
				}
				if (WorldGen.crimson)
				{
				shop.item[nextSlot].SetDefaults (ItemID.CrimtaneOre);
				shop.item[nextSlot].shopCustomPrice = 2500;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.TissueSample);
				shop.item[nextSlot].shopCustomPrice = 10000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.Vertebrae);
				shop.item[nextSlot].shopCustomPrice = 10000;
				}
				if (NPC.downedQueenBee)
				{
				shop.item[nextSlot].SetDefaults (ItemID.BeeWax);
				shop.item[nextSlot].shopCustomPrice = 20000;
				nextSlot++;
				}
				if (NPC.downedBoss3)
				{
				shop.item[nextSlot].SetDefaults (ItemID.Bone);
				shop.item[nextSlot].shopCustomPrice = 20000;
				nextSlot++;
				}
				if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
					{
					if (CalamityModDownedHiveMind || CalamityModDownedPerforators)
					{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("TrueShadowScale"));
					shop.item[nextSlot].shopCustomPrice = 100000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("BloodSample"));
					shop.item[nextSlot].shopCustomPrice = 100000;
					nextSlot++;
					}
					if (CalamityModDownedSlimeGod)
					{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("EbonianGel"));
					shop.item[nextSlot].shopCustomPrice = 100000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("PurifiedGel"));
					shop.item[nextSlot].shopCustomPrice = 200000;
					nextSlot++;
					}
				}
				if (NPC.downedMechBossAny)
				{
				shop.item[nextSlot].SetDefaults (ItemID.SoulofLight);
				shop.item[nextSlot].shopCustomPrice = 30000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.SoulofNight);
				shop.item[nextSlot].shopCustomPrice = 30000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("DivineLava"));
				shop.item[nextSlot].shopCustomPrice = 20000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("CursedIce"));
				shop.item[nextSlot].shopCustomPrice = 20000;
				nextSlot++;
				}
				if (NPC.downedMechBoss3)
				{
				shop.item[nextSlot].SetDefaults (ItemID.SoulofFright);
				shop.item[nextSlot].shopCustomPrice = 50000;
				nextSlot++;
				}
				if (NPC.downedMechBoss1)
				{
				shop.item[nextSlot].SetDefaults (ItemID.SoulofMight);
				shop.item[nextSlot].shopCustomPrice = 50000;
				nextSlot++;
				}
				if (NPC.downedMechBoss2)
				{
				shop.item[nextSlot].SetDefaults (ItemID.SoulofSight);
				shop.item[nextSlot].shopCustomPrice = 50000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.BlackLens);
				shop.item[nextSlot].shopCustomPrice = 500000;
				nextSlot++;
					if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
					{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("BlightedLens"));
					shop.item[nextSlot].shopCustomPrice = 330000;
					nextSlot++; 
					}
				}
				if (NPC.downedMechBoss1 && NPC.downedMechBoss3 && NPC.downedMechBoss3)
				{
				shop.item[nextSlot].SetDefaults (ItemID.HallowedBar);
				shop.item[nextSlot].shopCustomPrice = 20000;
				nextSlot++;
				}
				if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
				{
					if (CalamityModDownedCalamitas)
					{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("UnholyCore"));
					shop.item[nextSlot].shopCustomPrice = 150000;
					nextSlot++;
					}
					if (NPC.downedPlantBoss)
					{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("EssenceofEleum"));
					shop.item[nextSlot].shopCustomPrice = 50000;
					nextSlot++; 
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("EssenceofCinder"));
					shop.item[nextSlot].shopCustomPrice = 50000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("EssenceofChaos"));
					shop.item[nextSlot].shopCustomPrice = 50000;
					nextSlot++; 
					}
					if (CalamityModDownedAstrum)
					{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("AstralJelly"));
					shop.item[nextSlot].shopCustomPrice = 150000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("Stardust"));
					shop.item[nextSlot].shopCustomPrice = 100000;
					nextSlot++;
					}
				}
				if (NPC.downedGolemBoss)
				{
				shop.item[nextSlot].SetDefaults (ItemID.BeetleHusk);
				shop.item[nextSlot].shopCustomPrice = 10000;
				nextSlot++;
					if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("LivingShard"));
						shop.item[nextSlot].shopCustomPrice = 30000;
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("Tenebris"));
						shop.item[nextSlot].shopCustomPrice = 50000;
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("Lumenite"));
						shop.item[nextSlot].shopCustomPrice = 50000;
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("DepthCells"));
						shop.item[nextSlot].shopCustomPrice = 100000;
						nextSlot++;
					}
				}
				if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
				{
					if (NPC.downedMoonlord)
					{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("BarofLife"));
					shop.item[nextSlot].shopCustomPrice = 2000000;
					nextSlot++;
					}
				}
				if (NPC.downedMoonlord && OA)
				{
				shop.item[nextSlot].SetDefaults (ItemID.FragmentSolar);
				shop.item[nextSlot].shopCustomPrice = 250000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.FragmentNebula);
				shop.item[nextSlot].shopCustomPrice = 250000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.FragmentVortex);
				shop.item[nextSlot].shopCustomPrice = 250000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.FragmentStardust);
				shop.item[nextSlot].shopCustomPrice = 250000;
				nextSlot++;
				}
				if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
				{
					if (CalamityModDownedProvidence)
					{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("UnholyEssence"));
					shop.item[nextSlot].shopCustomPrice = 500000;
					nextSlot++;
					}
					if (CalamityModDownedPolter)
					{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("Phantoplasm"));
					shop.item[nextSlot].shopCustomPrice = 1000000;
					nextSlot++;
					}
					if (CalamityModDownedBirb)
					{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("NightmareFuel"));
					shop.item[nextSlot].shopCustomPrice = 5000000;
					nextSlot++;				
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("EndothermicEnergy"));
					shop.item[nextSlot].shopCustomPrice = 5000000;
					nextSlot++;
					}
				}
			}
			if (Shop2)
			{
			if (NPC.downedBoss3)
				{
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("TheBeak"));
				shop.item[nextSlot].shopCustomPrice = 200000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("LaetitiaRibbon"));
				shop.item[nextSlot].shopCustomPrice = 100000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("LaetitiaCoat"));
				shop.item[nextSlot].shopCustomPrice = 200000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("LaetitiaLeggings"));
				shop.item[nextSlot].shopCustomPrice = 150000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("Laetitia"));
				shop.item[nextSlot].shopCustomPrice = 350000;
				nextSlot++;
				}
			if (NPC.downedMechBossAny)
				{
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("FuneralofDeadButterflies"));
				shop.item[nextSlot].shopCustomPrice = 500000;
				nextSlot++;
				}
			if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
					{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("LaetitiaGift"));
					shop.item[nextSlot].shopCustomPrice = 300000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("ReverberationHead"));
					shop.item[nextSlot].shopCustomPrice = 250000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("ReverberationBody"));
					shop.item[nextSlot].shopCustomPrice = 350000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("ReverberationLegs"));
					shop.item[nextSlot].shopCustomPrice = 300000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("Reverberation"));
					shop.item[nextSlot].shopCustomPrice = 500000;
					nextSlot++;
					}
			if (NPC.downedPlantBoss)
				{
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("BigBirdLamp"));
				shop.item[nextSlot].shopCustomPrice = 750000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("GrinderMK4"));
				shop.item[nextSlot].shopCustomPrice = 750000;
				nextSlot++;
				}
			if (NPC.downedGolemBoss)
				{
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("Spore"));
				shop.item[nextSlot].shopCustomPrice = 1000000;
				nextSlot++;
				}
			}
			if (Shop3)
			{
				if (!NPC.downedBoss3)
				{
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("InformatingNote"));
				nextSlot++;
				}
				if (Config.CoinsDrop && ModLoader.GetMod("AlchemistNPCContentDisabler") == null)
				{
					if (NPC.downedBoss3 && Main.expertMode)
					{
					shop.item[nextSlot].SetDefaults (ItemID.KingSlimeBossBag);
					shop.item[nextSlot].shopCustomPrice = new int?(5);
					shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.EyeOfCthulhuBossBag);
					shop.item[nextSlot].shopCustomPrice = new int?(10);
					shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.EaterOfWorldsBossBag);
					shop.item[nextSlot].shopCustomPrice = new int?(15);
					shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.BrainOfCthulhuBossBag);
					shop.item[nextSlot].shopCustomPrice = new int?(15);
					shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.QueenBeeBossBag);
					shop.item[nextSlot].shopCustomPrice = new int?(20);
					shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.SkeletronBossBag);
					shop.item[nextSlot].shopCustomPrice = new int?(30);
					shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
					nextSlot++;
					}
					if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
						{
							if (DD2Event.DownedInvasionT1)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("DarkMageBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(30);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
								nextSlot++;
							}
						}
					if (Main.hardMode && Main.expertMode)
					{
					shop.item[nextSlot].SetDefaults (ItemID.WallOfFleshBossBag);
					shop.item[nextSlot].shopCustomPrice = new int?(10);
					shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier2ID;
					nextSlot++;
					}
					if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3 && Main.expertMode)
					{
					shop.item[nextSlot].SetDefaults (ItemID.DestroyerBossBag);
					shop.item[nextSlot].shopCustomPrice = new int?(10);
					shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier3ID;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.TwinsBossBag);
					shop.item[nextSlot].shopCustomPrice = new int?(10);
					shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier3ID;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.SkeletronPrimeBossBag);
					shop.item[nextSlot].shopCustomPrice = new int?(15);
					shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier3ID;
					nextSlot++;
					}
					if (NPC.downedPlantBoss && Main.expertMode)
					{
					shop.item[nextSlot].SetDefaults (ItemID.PlanteraBossBag);
					shop.item[nextSlot].shopCustomPrice = new int?(30);
					shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier3ID;
					nextSlot++;
					}
					if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
						{
							if (DD2Event.DownedInvasionT2)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("OgreBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(10);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier3ID;
								nextSlot++;
							}
						}
					if (NPC.downedAncientCultist && Main.expertMode)
					{
					shop.item[nextSlot].SetDefaults (ItemID.GolemBossBag);
					shop.item[nextSlot].shopCustomPrice = new int?(5);
					shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier4ID;
					nextSlot++;
					}
					if (DD2Event.DownedInvasionT3)
					{
					shop.item[nextSlot].SetDefaults (ItemID.BossBagBetsy);
					shop.item[nextSlot].shopCustomPrice = new int?(10);
					shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier4ID;
					nextSlot++;
					}
					if (NPC.downedAncientCultist && Main.expertMode)
					{
					shop.item[nextSlot].SetDefaults (ItemID.FishronBossBag);
					shop.item[nextSlot].shopCustomPrice = new int?(10);
					shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier4ID;
					nextSlot++;
					}
					if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
						{
							if(CalamityModDownedGuardian)
							{
							shop.item[nextSlot].SetDefaults (ItemID.MoonLordBossBag);
							shop.item[nextSlot].shopCustomPrice = new int?(30);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier4ID;
							nextSlot++;
						}
					}
				}
				if (!Config.CoinsDrop || ModLoader.GetMod("AlchemistNPCContentDisabler") != null)
				{
					if (NPC.downedBoss3 && Main.expertMode)
					{
					shop.item[nextSlot].SetDefaults (ItemID.KingSlimeBossBag);
					shop.item[nextSlot].shopCustomPrice = 250000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.EyeOfCthulhuBossBag);
					shop.item[nextSlot].shopCustomPrice = 500000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.EaterOfWorldsBossBag);
					shop.item[nextSlot].shopCustomPrice = 750000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.BrainOfCthulhuBossBag);
					shop.item[nextSlot].shopCustomPrice = 750000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.QueenBeeBossBag);
					shop.item[nextSlot].shopCustomPrice = 1000000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.SkeletronBossBag);
					shop.item[nextSlot].shopCustomPrice = 1500000;
					nextSlot++;
					}
					if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
						{
							if (DD2Event.DownedInvasionT1)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("DarkMageBag"));
								shop.item[nextSlot].shopCustomPrice = 2000000;
								nextSlot++;
							}
						}
					if (Main.hardMode && Main.expertMode)
					{
					shop.item[nextSlot].SetDefaults (ItemID.WallOfFleshBossBag);
					shop.item[nextSlot].shopCustomPrice = 2000000;
					nextSlot++;
					}
					if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3 && Main.expertMode)
					{
					shop.item[nextSlot].SetDefaults (ItemID.DestroyerBossBag);
					shop.item[nextSlot].shopCustomPrice = 2000000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.TwinsBossBag);
					shop.item[nextSlot].shopCustomPrice = 2000000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.SkeletronPrimeBossBag);
					shop.item[nextSlot].shopCustomPrice = 2000000;
					nextSlot++;
					}
					if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
						{
							if (DD2Event.DownedInvasionT2)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("OgreBag"));
								shop.item[nextSlot].shopCustomPrice = 3000000;
								nextSlot++;
							}
						}
					if (NPC.downedPlantBoss && Main.expertMode)
					{
					shop.item[nextSlot].SetDefaults (ItemID.PlanteraBossBag);
					shop.item[nextSlot].shopCustomPrice = 3000000;
					nextSlot++;
					}
					if (NPC.downedAncientCultist && Main.expertMode)
					{
					shop.item[nextSlot].SetDefaults (ItemID.GolemBossBag);
					shop.item[nextSlot].shopCustomPrice = 3000000;
					nextSlot++;
					}
					if (DD2Event.DownedInvasionT3)
					{
					shop.item[nextSlot].SetDefaults (ItemID.BossBagBetsy);
					shop.item[nextSlot].shopCustomPrice = 4000000;
					nextSlot++;
					}
					if (NPC.downedAncientCultist && Main.expertMode)
					{
					shop.item[nextSlot].SetDefaults (ItemID.FishronBossBag);
					shop.item[nextSlot].shopCustomPrice = 5000000;
					nextSlot++;
					}
					if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
						{
							if(CalamityModDownedGuardian)
							{
							shop.item[nextSlot].SetDefaults (ItemID.MoonLordBossBag);
							shop.item[nextSlot].shopCustomPrice = 6000000;
							nextSlot++;
						}
					}
				}
			}
			if (Shop4)
			{
				if (!NPC.downedBoss3)
				{
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("InformatingNote"));
				nextSlot++;
				}
				if (Config.CoinsDrop && ModLoader.GetMod("AlchemistNPCContentDisabler") == null)
				{
					if (NPC.downedBoss3 && Main.expertMode)
					{
						if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
						{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("DesertScourgeBag"));
						shop.item[nextSlot].shopCustomPrice = new int?(5);
						shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("CrabulonBag"));
						shop.item[nextSlot].shopCustomPrice = new int?(10);
						shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("HiveMindBag"));
						shop.item[nextSlot].shopCustomPrice = new int?(15);
						shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("PerforatorBag"));
						shop.item[nextSlot].shopCustomPrice = new int?(15);
						shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
						nextSlot++;
						}
					}
					if (Main.hardMode && Main.expertMode)
					{
						if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
						{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("SlimeGodBag"));
						shop.item[nextSlot].shopCustomPrice = new int?(5);
						shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier2ID;
						nextSlot++;
						}
					}
					if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
						{
							if (NPC.downedMechBoss1)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("CryogenBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(15);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier2ID;
								nextSlot++;
							}
							if (NPC.downedMechBoss3)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("BrimstoneWaifuBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(5);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier3ID;
								nextSlot++;
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("AquaticScourgeBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(5);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier3ID;
								nextSlot++;
							}
						}
					if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
					{
						if (NPC.downedPlantBoss)
						{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("CalamitasBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(25);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier3ID;
							nextSlot++;
						}
						if (CalamityModDownedLeviathan)
						{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("LeviathanBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(30);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier3ID;
							nextSlot++;
						}
						if (CalamityModDownedAstrageldon)
						{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("AstrageldonBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(20);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier3ID;
							nextSlot++;
						}
						if (CalamityModDownedAstrum)
						{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("AstrumDeusBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(30);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier3ID;
							nextSlot++;
						}
						if (CalamityModDownedPlaguebringer)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("PlaguebringerGoliathBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(15);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier4ID;
							nextSlot++; 
							}
						if (CalamityModDownedRavager)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("RavagerBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(15);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier4ID;
							nextSlot++; 
							}
					}
					if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
						{
							if (CalamityModDownedProvidence)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("ProvidenceBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(25);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier5ID;
								nextSlot++;
							}
							if(CalamityModDownedPolter)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("PolterghastBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(5);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier6ID;
								nextSlot++;
							}
							if (CalamityModDownedDOG && CalamityModDownedBirb)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("DevourerofGodsBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(10);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier6ID;
								nextSlot++;
							}
							if (CalamityModDownedYharon)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("BumblebirbBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(15);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier6ID;
								nextSlot++;
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("YharonBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(20);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier6ID;
								nextSlot++;
							}
						}
					if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
						{
							if (NPC.downedBoss3)	
							{
								if (ThoriumModDownedGTBird)
								{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("ThunderBirdBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(5);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
								nextSlot++;
								}
								if (ThoriumModDownedQueenJelly)
								{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("JellyFishBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(15);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
								nextSlot++;
								}
								if (ThoriumModDownedViscount)
								{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("CountBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(20);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
								nextSlot++;
								}
								if (ThoriumModDownedStorm)
								{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("GraniteBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(30);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
								nextSlot++;
								}
								if (ThoriumModDownedChampion)
								{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("HeroBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(30);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
								nextSlot++;
								}
								if (ThoriumModDownedStarScout)
								{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("ScouterBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(40);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
								nextSlot++;
								}
								if (Main.hardMode)	
								{
									if (ThoriumModDownedBoreanStrider)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("BoreanBag"));
									shop.item[nextSlot].shopCustomPrice = new int?(5);
									shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier2ID;
									nextSlot++;
									}
									if (ThoriumModDownedFallenBeholder)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("BeholderBag"));
									shop.item[nextSlot].shopCustomPrice = new int?(10);
									shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier2ID;
									nextSlot++;
									}
									if (ThoriumModDownedLich)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("LichBag"));
									shop.item[nextSlot].shopCustomPrice = new int?(10);
									shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier3ID;
									nextSlot++;
									}
									if (ThoriumModDownedAbyssion)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("AbyssionBag"));
									shop.item[nextSlot].shopCustomPrice = new int?(10);
									shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier4ID;
									nextSlot++;
									}
								}
								if (NPC.downedMoonlord)	
								{
									if (ThoriumModDownedRagnarok)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("RagBag"));
									shop.item[nextSlot].shopCustomPrice = new int?(50);
									shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier4ID;
									nextSlot++;
									}
								}
							}
						}
						if (ModLoader.GetLoadedMods().Contains("SacredTools"))
						{
							if (NPC.downedBoss3)	
							{
								if (SacredToolsDownedPumpkin)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SacredTools").ItemType("PumpkinBag"));
									shop.item[nextSlot].shopCustomPrice = new int?(10);
									shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
									nextSlot++;
									}
								if (SacredToolsDownedHarpyPreHM)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SacredTools").ItemType("HarpyBag"));
									shop.item[nextSlot].shopCustomPrice = new int?(15);
									shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
									nextSlot++;
									}
								if (SacredToolsDownedHarpyHM)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SacredTools").ItemType("HarpyBag2"));
									shop.item[nextSlot].shopCustomPrice = new int?(10);
									shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier3ID;
									nextSlot++;
									}
								if (SacredToolsDownedAbbadon)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SacredTools").ItemType("OblivionBag"));
									shop.item[nextSlot].shopCustomPrice = new int?(10);
									shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier4ID;
									nextSlot++;
									}
								if (SacredToolsDownedAraghur)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SacredTools").ItemType("SerpentBag"));
									shop.item[nextSlot].shopCustomPrice = new int?(15);
									shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier4ID;
									nextSlot++;
									}
								if (SacredToolsDownedLunarians)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SacredTools").ItemType("LunarBag"));
									shop.item[nextSlot].shopCustomPrice = new int?(5);
									shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier5ID;
									nextSlot++;
									}
								if (SacredToolsDownedChallenger)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SacredTools").ItemType("ChallengerBag"));
									shop.item[nextSlot].shopCustomPrice = new int?(10);
									shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier5ID;
									nextSlot++;
									}
							}
						}
				}
				if (!Config.CoinsDrop ||  ModLoader.GetMod("AlchemistNPCContentDisabler") != null)
				{
					if (NPC.downedBoss3 && Main.expertMode)
					{
						if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
						{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("DesertScourgeBag"));
						shop.item[nextSlot].shopCustomPrice = 350000;
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("CrabulonBag"));
						shop.item[nextSlot].shopCustomPrice = 650000;
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("HiveMindBag"));
						shop.item[nextSlot].shopCustomPrice = 1000000;
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("PerforatorBag"));
						shop.item[nextSlot].shopCustomPrice = 1000000;
						nextSlot++;
						}
					}
					if (Main.hardMode && Main.expertMode)
					{
						if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
						{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("SlimeGodBag"));
						shop.item[nextSlot].shopCustomPrice = 1750000;
						nextSlot++;
						}
					}
					if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
						{
							if (NPC.downedMechBoss1)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("CryogenBag"));
								shop.item[nextSlot].shopCustomPrice = 2000000;
								nextSlot++;
							}
							if (NPC.downedMechBoss3)
							{
								if (!CalamityModDownedProvidence)
								{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("BrimstoneWaifuBag"));
									shop.item[nextSlot].shopCustomPrice = 2000000;
									nextSlot++;
								}
								if (CalamityModDownedProvidence)
								{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("BrimstoneWaifuBag"));
								shop.item[nextSlot].shopCustomPrice = 20000000;
								nextSlot++;
								}
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("AquaticScourgeBag"));
								shop.item[nextSlot].shopCustomPrice = 2000000;
								nextSlot++;
							}
						}
					if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
					{
						if (NPC.downedPlantBoss)
						{
							if (!CalamityModDownedProvidence)
								{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("CalamitasBag"));
							shop.item[nextSlot].shopCustomPrice = 3000000;
							nextSlot++;
								}
							if (CalamityModDownedProvidence)
								{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("CalamitasBag"));
							shop.item[nextSlot].shopCustomPrice = 30000000;
							nextSlot++;
								}
						}
						if (CalamityModDownedLeviathan)
						{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("LeviathanBag"));
							shop.item[nextSlot].shopCustomPrice = 3500000;
							nextSlot++;
						}
						if (!CalamityModDownedProvidence && CalamityModDownedAstrageldon)
						{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("AstrageldonBag"));
							shop.item[nextSlot].shopCustomPrice = 4000000;
							nextSlot++;
						}
						if (CalamityModDownedProvidence && CalamityModDownedAstrageldon)
						{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("AstrageldonBag"));
							shop.item[nextSlot].shopCustomPrice = 15000000;
							nextSlot++;
						}
						if (CalamityModDownedAstrum)
						{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("AstrumDeusBag"));
							shop.item[nextSlot].shopCustomPrice = 3500000;
							nextSlot++;
						}
						if (CalamityModDownedPlaguebringer)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("PlaguebringerGoliathBag"));
							shop.item[nextSlot].shopCustomPrice = 4000000;
							nextSlot++; 
							}
						if (CalamityModDownedRavager)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("RavagerBag"));
							shop.item[nextSlot].shopCustomPrice = 4000000;
							nextSlot++; 
							}
					}
					if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
					{
						if (CalamityModDownedProvidence)
						{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("ProvidenceBag"));
							shop.item[nextSlot].shopCustomPrice = 150000000;
							nextSlot++;
						}
						if (CalamityModDownedPolter)
						{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("PolterghastBag"));
							shop.item[nextSlot].shopCustomPrice = 150000000;
							nextSlot++;
						}
						if (CalamityModDownedDOG && CalamityModDownedBirb)
						{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("DevourerofGodsBag"));
							shop.item[nextSlot].shopCustomPrice = 300000000;
							nextSlot++;
						}
						if (CalamityModDownedYharon)
						{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("BumblebirbBag"));
							shop.item[nextSlot].shopCustomPrice = 200000000;
							nextSlot++;
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("YharonBag"));
							shop.item[nextSlot].shopCustomPrice = 500000000;
							nextSlot++;
						}
					}
					if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
						{
							if (NPC.downedBoss3)	
							{
								if (ThoriumModDownedGTBird)
								{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("ThunderBirdBag"));
								shop.item[nextSlot].shopCustomPrice = 500000;
								nextSlot++;
								}
								if (ThoriumModDownedQueenJelly)
								{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("JellyFishBag"));
								shop.item[nextSlot].shopCustomPrice = 750000;
								nextSlot++;
								}
								if (ThoriumModDownedViscount)
								{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("CountBag"));
								shop.item[nextSlot].shopCustomPrice = 850000;
								nextSlot++;
								}
								if (ThoriumModDownedStorm)
								{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("GraniteBag"));
								shop.item[nextSlot].shopCustomPrice = 1000000;
								nextSlot++;
								}
								if (ThoriumModDownedChampion)
								{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("HeroBag"));
								shop.item[nextSlot].shopCustomPrice = 1000000;
								nextSlot++;
								}
								if (ThoriumModDownedStarScout)
								{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("ScouterBag"));
								shop.item[nextSlot].shopCustomPrice = 1250000;
								nextSlot++;
								}
								if (Main.hardMode)	
								{
									if (ThoriumModDownedBoreanStrider)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("BoreanBag"));
									shop.item[nextSlot].shopCustomPrice = 1500000;
									nextSlot++;
									}
									if (ThoriumModDownedFallenBeholder)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("BeholderBag"));
									shop.item[nextSlot].shopCustomPrice = 2000000;
									nextSlot++;
									}
									if (ThoriumModDownedLich)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("LichBag"));
									shop.item[nextSlot].shopCustomPrice = 3000000;
									nextSlot++;
									}
									if (ThoriumModDownedAbyssion)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("AbyssionBag"));
									shop.item[nextSlot].shopCustomPrice = 5000000;
									nextSlot++;
									}
								}
								if (NPC.downedMoonlord)	
								{
									if (ThoriumModDownedRagnarok)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("RagBag"));
									shop.item[nextSlot].shopCustomPrice = 25000000;
									nextSlot++;
									}
								}
							}
						}
					if (ModLoader.GetLoadedMods().Contains("SacredTools"))
						{
							if (NPC.downedBoss3)	
							{
								if (SacredToolsDownedPumpkin)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SacredTools").ItemType("PumpkinBag"));
									shop.item[nextSlot].shopCustomPrice = 500000;
									nextSlot++;
									}
								if (SacredToolsDownedHarpyPreHM)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SacredTools").ItemType("HarpyBag"));
									shop.item[nextSlot].shopCustomPrice = 1000000;
									nextSlot++;
									}
								if (SacredToolsDownedHarpyHM)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SacredTools").ItemType("HarpyBag2"));
									shop.item[nextSlot].shopCustomPrice = 2000000;
									nextSlot++;
									}
								if (SacredToolsDownedAbbadon)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SacredTools").ItemType("OblivionBag"));
									shop.item[nextSlot].shopCustomPrice = 5000000;
									nextSlot++;
									}
								if (SacredToolsDownedAraghur)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SacredTools").ItemType("SerpentBag"));
									shop.item[nextSlot].shopCustomPrice = 7500000;
									nextSlot++;
									}
								if (SacredToolsDownedLunarians)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SacredTools").ItemType("LunarBag"));
									shop.item[nextSlot].shopCustomPrice = 10000000;
									nextSlot++;
									}
								if (SacredToolsDownedChallenger)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SacredTools").ItemType("ChallengerBag"));
									shop.item[nextSlot].shopCustomPrice = 15000000;
									nextSlot++;
									}
							}
						}
				}
			}
			if (Shop5)
			{
				if (!NPC.downedBoss3)
				{
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("InformatingNote"));
				nextSlot++;
				}
				if (Config.CoinsDrop && ModLoader.GetMod("AlchemistNPCContentDisabler") == null)
				{
					if (NPC.downedBoss3 && Main.expertMode)
					{
						if (ModLoader.GetLoadedMods().Contains("SpiritMod"))
						{
							if (SpiritModDownedScarabeus)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SpiritMod").ItemType("BagOScarabs"));
							shop.item[nextSlot].shopCustomPrice = new int?(5);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
							nextSlot++;
							}
							if (SpiritModDownedBane)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SpiritMod").ItemType("ReachBossBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(15);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
							nextSlot++;
							}
							if (SpiritModDownedFlier)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SpiritMod").ItemType("FlyerBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(20);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
							nextSlot++;
							}
							if (SpiritModDownedStarplateRaider)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SpiritMod").ItemType("SteamRaiderBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(5);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier2ID;
							nextSlot++;
							}
							if (SpiritModDownedInfernon)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SpiritMod").ItemType("InfernonBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(10);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier2ID;
							nextSlot++;
							}
							if (SpiritModDownedDusking)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SpiritMod").ItemType("DuskingBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(10);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier3ID;
							nextSlot++;
							}
							if (SpiritModDownedEtherialUmbra)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SpiritMod").ItemType("SpiritCoreBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(10);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier3ID;
							nextSlot++;
							}
							if (SpiritModDownedIlluminantMaster)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SpiritMod").ItemType("IlluminantBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(20);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier3ID;
							nextSlot++;
							}
							if (SpiritModDownedAtlas)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SpiritMod").ItemType("AtlasBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(10);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier4ID;
							nextSlot++;
							}
							if (SpiritModDownedOverseer)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SpiritMod").ItemType("OverseerBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(30);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier4ID;
							nextSlot++;
							}
						}
						if (ModLoader.GetLoadedMods().Contains("Laugicality"))
						{
							if (EnigmaDownedSharkron)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Laugicality").ItemType("DuneSharkronTreasureBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(5);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
							nextSlot++;
							}
							if (EnigmaDownedHypothema)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Laugicality").ItemType("HypothemaTreasureBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(15);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
							nextSlot++;
							}
							if (EnigmaDownedRagnar)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Laugicality").ItemType("RagnarTreasureBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(20);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
							nextSlot++;
							}
							if (EnigmaDownedAnDio)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Laugicality").ItemType("AnDioTreasureBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(10);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier2ID;
							nextSlot++;
							}
							if (EnigmaDownedAnnihilator)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Laugicality").ItemType("AnnihilatorTreasureBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(15);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier3ID;
							nextSlot++;
							}
							if (EnigmaDownedSlybertron)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Laugicality").ItemType("SlybertronTreasureBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(15);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier3ID;
							nextSlot++;
							}
							if (EnigmaDownedSteamTrain)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Laugicality").ItemType("SteamTrainTreasureBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(15);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier3ID;
							nextSlot++;
							}
						}
					}
				}
				if (!Config.CoinsDrop ||  ModLoader.GetMod("AlchemistNPCContentDisabler") != null)
				{
					if (NPC.downedBoss3 && Main.expertMode)
					{
						if (ModLoader.GetLoadedMods().Contains("SpiritMod"))
						{
							if (SpiritModDownedScarabeus)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SpiritMod").ItemType("BagOScarabs"));
							shop.item[nextSlot].shopCustomPrice = 300000;
							nextSlot++;
							}
							if (SpiritModDownedBane)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SpiritMod").ItemType("ReachBossBag"));
							shop.item[nextSlot].shopCustomPrice = 500000;
							nextSlot++;
							}
							if (SpiritModDownedFlier)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SpiritMod").ItemType("FlyerBag"));
							shop.item[nextSlot].shopCustomPrice = 750000;
							nextSlot++;
							}
							if (SpiritModDownedStarplateRaider)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SpiritMod").ItemType("SteamRaiderBag"));
							shop.item[nextSlot].shopCustomPrice = 1000000;
							nextSlot++;
							}
							if (SpiritModDownedInfernon)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SpiritMod").ItemType("InfernonBag"));
							shop.item[nextSlot].shopCustomPrice = 2000000;
							nextSlot++;
							}
							if (SpiritModDownedDusking)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SpiritMod").ItemType("DuskingBag"));
							shop.item[nextSlot].shopCustomPrice = 2500000;
							nextSlot++;
							}
							if (SpiritModDownedEtherialUmbra)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SpiritMod").ItemType("SpiritCoreBag"));
							shop.item[nextSlot].shopCustomPrice = 2500000;
							nextSlot++;
							}
							if (SpiritModDownedIlluminantMaster)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SpiritMod").ItemType("IlluminantBag"));
							shop.item[nextSlot].shopCustomPrice = 3000000;
							nextSlot++;
							}
							if (SpiritModDownedAtlas)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SpiritMod").ItemType("AtlasBag"));
							shop.item[nextSlot].shopCustomPrice = 4000000;
							nextSlot++;
							}
							if (SpiritModDownedOverseer)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SpiritMod").ItemType("OverseerBag"));
							shop.item[nextSlot].shopCustomPrice = 8000000;
							nextSlot++;
							}
						}
						if (ModLoader.GetLoadedMods().Contains("Laugicality"))
						{
							if (EnigmaDownedSharkron)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Laugicality").ItemType("DuneSharkronTreasureBag"));
							shop.item[nextSlot].shopCustomPrice = 300000;
							nextSlot++;
							}
							if (EnigmaDownedHypothema)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Laugicality").ItemType("HypothemaTreasureBag"));
							shop.item[nextSlot].shopCustomPrice = 500000;
							nextSlot++;
							}
							if (EnigmaDownedRagnar)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Laugicality").ItemType("RagnarTreasureBag"));
							shop.item[nextSlot].shopCustomPrice = 750000;
							nextSlot++;
							}
							if (EnigmaDownedAnDio)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Laugicality").ItemType("AnDioTreasureBag"));
							shop.item[nextSlot].shopCustomPrice = 1000000;
							nextSlot++;
							}
							if (EnigmaDownedAnnihilator)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Laugicality").ItemType("AnnihilatorTreasureBag"));
							shop.item[nextSlot].shopCustomPrice = 2000000;
							nextSlot++;
							}
							if (EnigmaDownedSlybertron)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Laugicality").ItemType("SlybertronTreasureBag"));
							shop.item[nextSlot].shopCustomPrice = 2000000;
							nextSlot++;
							}
							if (EnigmaDownedSteamTrain)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Laugicality").ItemType("SteamTrainTreasureBag"));
							shop.item[nextSlot].shopCustomPrice = 2000000;
							nextSlot++;
							}
						}
					}
				}
			}
		}
	}
}