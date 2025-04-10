public class LocationHandler
{
    private List<Location> Locations = new List<Location>();
    private CharacterHandler CharacterHandler;

    public LocationHandler(CharacterHandler characterHandler)
    {
        CharacterHandler = characterHandler;
        SetupLocations();
    }

    public void SetupLocations()
    {
        Location boatDock = new Location();
        Locations.Add(boatDock);
        Location village = new Location();
        Locations.Add(village);
        Location church = new Location();
        Locations.Add(church);
        Location pub = new Location();
        Locations.Add(pub);
        Location manorHouse = new Location();
        Locations.Add(manorHouse);

        village.Initialize(
            "Village",
            @"You are in a small village on the island of Slitøya. The village is quaint and charming, with wooden houses and cobblestone streets. Altough it's the middle of the day, no one is around
            In the distance you see a path leading to an old manor house. The wind faintly carries the sound of laughter from the local pub. As you walk through the village, you are startled by the
            sudden sound of bells from the local church. The sound echoes through the village, and you can see a few villagers walking towards the church.",
            @"You see a few leaves blowing in the wind. A dog runs past you, barking happily. A small wooden sign points to the pub and the manor house. The village is quiet, with no one around.",
            @"
            ======================================================================================================================================================
            ======================================================================================================================================================
            ======================================================================================================================================================
            ======================================================================================================================================================
            ======================================================================================================================================================
            ======================================================================================================================================================
            ======================================================================================================================================================
            ====================================@@@@@@@@==========================================================================================================
            ==================================@@========@@========================================================================================================
            ================================@@============@@======================================================================================================
            ==============================%@*==============@@=====================================================================================================
            =============================@@==================@+===================================================================================================
            ===========================@@=====================@@==================================================================================================
            ==========================@@=======================@@=================================================================================================
            ========================@@==========@================@#@@@@@=============================================@@@@@@=======================================
            ======================@@=============@@===============@@====@@========================================@@=======@@@====================================
            ===================+@@================%@====@==========@@=====@@====================================@@===========*@@==================================
            =================@@@===================+@====@@=========+@=====@@=================================@@===============@@=================================
            ===============@@+======================@@====@@==========@*====+@==============================*@===================@@===============================
            =============@@==========================@@=====@@=========@@=====@============================@@======================@@=============================
            ====@@@@@@@@@=============================%@======@@========+======@*========================%@==========================@@@@@@@@@*===================
            =============@@@@@==========================@@======@+==============@@============@@@==@@@==@@======#@=====*@======================@@=================
            ===================@@@@=======================@======@@==============@@=========@@========@@=======@@========@=======================@@@==============
            =======================@@@============================#@==============@@======@@========@@========@@==========@@========================@@============
            ==========================@@@===========================@===============@@=@@*=========@+========@@=============@*=====@+=================@@==========
            =============================@@==========================@===============*@#========*@+=================================@@==================@@@=======
            ===============================@@==========================================@@+====@@======================================@@===================*@+====
            =================================@@+=========================================@@=============================================@@========================
            ===================================+@@========================@================@@%==========================================================*@@@@@====
            =========*@@@=========================@@@====================@@@==================@@=================================================@@@@@============
            ==============@@@========================#@@@=================@=====================@@#========================================*@@@+==================
            =================@@===========================@@@@===========*@========================@@@=================================+@@@=======================
            ===================@@=============================@@@%=======@@@==========================@@@===========================@@@===========================
            =====================@@@@=============================@@@====@=@=============================@@@====================@@@===============================
            ==========================@%=============================@@=@%=@+================================@@@+=========@@@@@====================#@@@===========
            =====================================@======================@===@====================================@@@@@@@%=====================@@@@================
            =====================================@=====================@@===@@@@@===============================+@@@==================#@@@@@@=====================
            =====================================@====================@@@@@@@@#===%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@==================================================
            =====================================@=====================@==@==@===========@@@@=============*@@=====================================================
            =============================@@@@@@@@@@@===================@==@==@===============#@@==========#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@=====
            =========@@@@@@@@@#========@@=======@%==@@@@@@@@@@@@@======@==@==@@@@@@@@@@@@@@@@@@@@=================================================================
            ===================@@@===*@=======@@=====*@======+@=======#@=====@====================================================================================
            =========================@@@@@@@@@@=======@*====@@=======@@=======@@====================@@@@@@@@@@=========@@@%%%#%%%@@@@@@@@@@@======================
            ==========================@==@===@@===@@==@#===@@@@@@@@@@===========@=================================================================================
            ==========================@==@===@@===@@==@%===@@======*@====@@@====@======================================+++*##*+++=================================
            =========@@@@@@@#=@@@@@@*+=+*%@@@@@@@=@@==@@===@@=@@=@=*@====@@@====@=================================================================================
            ==================@@@@*================+@@@@@@@@@=@@=@=*@====@@@====@=================================================================================
            =======================*@@%====================@@======+@====@@@===+@=============@===================================================================
            ===========================@@@==============@@@@@@%#**##*======+#@@@@@@@=========*@=======================@@@=====================@@==================
            ==============================#@@@=======================================@@@@====@@=====================@@===@=====================#@=================
            =======================================@@@===================================#@@@@@====================@@=====@@=====================@@===============
            =======================================@=@=================================*@@==========+@===========@@====@===*@=====================@@==============
            =============================@@@@@@@@@@@@@@@@@@@@@@=========@@@@@=========@@==@@==========@========+@@====#@=====@@=====================@@============
            =========+=================@@%@+===================@@=============#@@====@+====@@==========@@======@@=====*@======#@@@@@@@@@@@@@@@@@@@@@@@@===========
            =============@@@@=========@@===@@===================@@=================%@=======@@==========@@@@@==@@==============@====================@=============
            ========================@@======@@====================@@===============@====@@===#@@@@@@@@@@@@@==%@@@==============@====================@+============
            =======================@@=========@@===================@@==============@====@@===#@=========+@=====@@===@@@@@@*====@===@@=======@==@@===@*============
            =====================@@============@@====================@@============@+========*@==@===@@=%@=====@@===@@@@@@+====@===*@=======@==@@===@=============
            ====================@@@===@@==@@=====@@@@@@@@@@@@@@@@@@@@@@@===========@*========@@==@===@@=%@=====@@===@@@@@@+====@====================@@=====*@=====
            =====================@@===@@==@@=====@===================@+============@+========@@=========@@*@@@@@@@@@@@@@@@@#===@===========*****====@=============
            =====================@@===@@==@@=====@===@@@@======@=@===@+======@@@@@@*====+@@@@@@@@=====@@@=====================@@@@@@@@===============@@@@@========
            =====================@@=============+@===@@@@======@=@===@+===%#======================@@@*============================================================
            =====================@@=============+@===================@+========================@@@================================================================
            =====================@@====@@@@@=====@===================@+====================@@@@====================@@@@@@@@@======================================
            =====================@@====@@@@@=====@===@@@@======@@@===@+==========@@@@@@@=======================@@@================================================
            =======@@@@@@@@@@@@@#@@====@@@@@=====@===@@@@======@@@===@+====================================%@@====================================================
            =====================@@====@@@@@=====@===@@@@======@@@===@+================================@@@============================@@@@========@@@@============
            ====================+@@#+==@@@@@====+@===================@@@@@@@+==============@@@@@@=================================#@@@============================
            ==============@@*===========+@@@@@@##@===================@+======*@@@%=================@@@@@===================@@@@@@=================================
            =====================================@@@@@@@@@@@@@@%%%%#%*%@@@========%@@*===================@@@======================================================
            ==========================================%@@@============================@@@@==================@@@@==================================================
            ==============================================+@@@============================*@@@@=================#@@@#=============================================
            ============================@@@@@==================@@@==============================+@@@==================@@@@@=======================================
            ===================================@@@@================@@@@+====================================================@@@@==================================
            =======================================+@@===================*@@====================================================+@================================
            ======================================================================================================================================================
            ======================================================================================================================================================
            ======================================================================================================================================================
            ======================================================================================================================================================
            ======================================================================================================================================================
            ======================================================================================================================================================
            ======================================================================================================================================================
            ",
            new List<Item>(),
            new List<Character>(),
            new List<Location>()
            {
                boatDock,
                church,
                pub,
                manorHouse,
            }
        );
        boatDock.Initialize(
            "Boat Dock",
            @"After a long and hardy journey on the rough waters that seperate Rygland from Slitøya, you finally arrive at the boat dock. The sun is shining and the air is fresh. 
            You can see a small village in the distance. The air is filled with a scent of salt and the sound of seagulls. You hear laughter from the local pub, and the smell of 
            fresh fish from the market nearby. A local fisherman is unloading his catch nearby.",
            @"At the boat dock, you can see a small boat tied to the dock. The boat is old and weathered, but it looks seaworthy. There are some crates on the dock, and a few fishermen are
            unloading their catch. A newspaper is lying on the ground.",
            @"
            ======================================================================================================================================================
            ======================================================================================================================================================
            =====================================================@#===============================================================================================
            =====================================================@@===============================================================================================
            =====================================================@@===============================================================================================
            =====================================================@%===============================================================================================
            =====================================================@@===============================================================================================
            =====================================================%@+==============================================================================================
            =====================================================%#===============================================================================================
            =====================================================@@===============================================================================================
            ====================================================@@@@==============================================================================================
            ===================================================@=@@===============================================================================================
            ==================================================@==@@=@===================@@***#%@@====================@============================================
            =================================================@===@@==@==================@@@@@@@@@====================@============================================
            ================================================@====@@=====================@@@@@@@@@====================@============================================
            ===============================================@=====@@===@=================@@@@@@@@@====================@============================================
            ==============================================@======@@====@================@=======@====================@============================================
            =============================================@=======@#=====#===============@=======@====================@============================================
            ============================================@========@#===========@=========@=======@====================@============================================
            ===========================================@=========@%======@====@=========@=======@====================@============================================
            ==========================================%==========@#=======@===@=========@=======@====================@============================================
            =========================================+==========@@@@@@*+========*#@@@@@@@=======@====================@============================================
            =======================================+=========@@==#@@@@@@@@@@@@@@@@@@@@*==@@@@===@====================@============================================
            ======================================#============@@===@==@@@@@==@@@@==@@==@@@@@===@====================@@===========================================
            =====================================@==============@=@=@@=@@@@@++@@@@==@@@=@@======@====================@=%==========================================
            ====================================@===============@=@=@@=@@@@@+=@@@@==@@@=@@======@====================@=#==========================================
            ===================================@================@======@@@@@==@@@@==@@@=@@@@@@@@@====================@==@=========================================
            ===============================@==@=================@=======================@@======@#@@@@@@@@@%=========@===@========================================
            ===============================@=@==========*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@==@#======@@@@@@@@@@@@@@@@@@@==@===@========================================
            ===============================@@==========@=================================@@@@@==@=====@@=====@=======@##@@@@@@@@#=================================
            ==============================%@%%+========@======%%@@@@@@@@@@@@@@@%*================@@@@@@@@+===@=======@==%==@==@==@#===============================
            =========================#@@===@=====+@@@@@@@==========****+===++++=====+@@@@@@@@*========@@====#@@@@@@@@@==*%+@@=@==@@===============================
            =======================@@======@==============+@@@@@==@@@@@@@@@@@@@@@@===============@@@@@@@@@===@=======@==@==@@@@@@@@@==============================
            =======================@=======@======================*@@@@@@@@@@@@@@======@@@==@@@==*+=========*@@@@@@@@@@%@=+@@=@#=@%===============================
            =======================@=======@=============@@+==============@@@@@@@======@@@==@@@==@@@=@@@@=%@@===================#@@@==============================
            =======================@@@@@@==@==*@@@@@@@===========@@==========@=========@@@==@@@==@@@=@@@@=@@@#=@@@=@@=@@#@@==@@@@==@==============================
            ========================@======@=============*@@@@@+===============@@===========@@@==@@@=#@@@=@@@+=@@@=@@+@@@=@==@@=@==@==============================
            ========================@@=====@======================#@@@@@+========@@@@=====================%@@==@@%=@@=@@+@@+=@@=@*=@==============================
            =========================@*====@================================%@@@@@@====#@@@@@@@@#=========#@@======================@==============================
            ==========================@====@===========================================+%@@@@@@@@@#===+#@@@@@@@@@@@@@%%#%#%@@@@@@@@@@@============================
            ==========================@====@=============================================================+@@@@@@@*%%@%@####%@@@@@@@@@@============================
            ===========================@===@=======================================@@============================@@@=================@============================
            ===========================@===@===================================================@====@@=====@@====@@@================*@==@*#@=====@@=@=============
            ===========================#@==@=====================================================================@@@================@===@==@======@=@=============
            ============================@==@@@@@@@@@@+===========================================================@@@==========*@@@@@====@==@======@=@=============
            ============================@@=@@@@@@@@@@@@@@@@@@@@@@@@@@%=========================================@@@@@@@@@@@@@@@@@@@@@@@@@@==@@@@@@@@=@@@@@@@@======
            =======+##%@@@@@@@@@@%++*%@@%@=@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@=@@=====================@==@======================
            =============================@*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@=@@@@@@@@@@@@@@@@@@@@@@@@==@@@@@@@@@@@@@@@@@======
            ==============================@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@=@@@@@@%@@@====@@@======@==@=====+@@@=============
            ==============================@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%+=======@=@@@====@@@====@@@======@==@======@@@=============
            ===============================@@@@@@@@%++++===========================================*===========@=@@@====@@@====@@@======@==@======@@@=============
            ==================================================+@@@@@@@@@@@@@@@@@@%#================================%====@@@=============@@@@======================
            ======================================================================================================================================================
            ===============================@@@@@@@@@@*======================@@@@@@%======================================+++++*%*+================================
            ======================================================================================================================================================
            ======================================================================================================================================================
            ===============================@@@@@@@@@@+============================================================================================================
            ======================================================================================================================================================
            ======================================================================================================================================================
            ",
            new List<Item>()
            {
                new Item("Fishing Rod", "You pick up the fishing rod and see a name inscribed on the handle. It belongs to someone else and you leave it be.", false),
                new Item("Crate", "You inpsect the wooden crates. They are used for storing fish.", false),
                new Item("Boat", "An old boat, but it looks seaworthy.", false),
                new Item("Newspaper", "A local newspaper.", true)
            },
            new List<Character>()
            {
                CharacterHandler.GetCharacter("Fisherman"),
            },
            new List<Location>()
            {
                village
            }
        );
        Locations.Add(boatDock);
    }

    public Location GetLocation(string name)
    {
        var location = Locations.FirstOrDefault(l => l.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (location == null)
        {
            throw new InvalidOperationException($"Location with name '{name}' not found.");
        }
        return location;
    }
}